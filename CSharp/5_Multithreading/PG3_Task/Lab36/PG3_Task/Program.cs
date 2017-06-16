using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3_Task
{
    /*
    * 1. try..catch
    * 실무에서는 try.. catch 를 필요하지 않은 곳에 습관적으로 써서는 안됩니다. 이유는 exception을 eat 하면 제품 출시후 버그를 잡기가 힘들어 지기 때문입니다.
    * 만약 Excel 프로그램에 항상 Exception을 무시(eat)한다면, 어떤 에러 상황을 그대 묻는다는 뜻인데, 이는 Data Inconsistency 와 같은 문제까지 초래할 수 있습니다.
    * 따라서, try.. catch는 예상 가능한 범위내의 exception을 Workaround 로 처리할 수 있을때, Exception을 잡아 처리해줌으로써 Applicaiton의 Reliability 를 높일 수 있습니다.
    * 예를 들어, 파일이 현재 In use이면, 이 Exception을 잡아 10초마다 3번 retry 해본다는 등등 또는 DB에 에러를 로깅하기 위해 Unhandled Exception을 잡아 처리해줄 수는 있습니다.
    * 2. Closure
    * for 루프내 delegate에서 이렇게 i 를 사용하면 Closure 가 됩니다. Closure 아티클을 읽어보세요. http://www.csharpstudy.com/DevNote/Article/26
    * 이렇게 i 를 표시하면, 1 ~ 10 이 아닌 임의의 i 값에 해당하는 하나의 파일만 생성될 수 있습니다. 따라서, Task.Factory.StartNew((p) => {... }, i) 와 같이 i를 전달해야 합니다. (i 를 변수 p 에 받으므로 fileName + p 사용)
    * 3. Task.Wait() 
    * genTasks[i].Wait(); 이렇게 task.Wait() 을 쓰면 for 루프에서 하나의 쓰레드를 시작한 후에 그 쓰레드를 기다린 후 다시 다음 쓰레드를 시작합니다. 동시에 10개를 실행하는 것이 아닙니다. 루프 밖에서 Task.WaitAll()을 사용하십시오.
    */
    class Program
    {
        private const int TASK_SIZE = 10;
        private const int NUM_SIZE = 1000;

        static void Main(string[] args)
        {
            string fileName = "random.";
            string folderName = AppDomain.CurrentDomain.BaseDirectory + "RandomFile";

            // Generate tasks
            Task[] genTasks = new Task[TASK_SIZE];

            // folder check
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            for (int i = 0; i < genTasks.Length; i++)
            {
                Random rand = new Random();

                genTasks[i] = Task.Factory.StartNew((p) =>
                {
                    //file write
                    using (StreamWriter file =
                        new StreamWriter(Path.Combine(folderName, fileName + p + ".txt"), true))
                    {
                        for (int j = 0; j < NUM_SIZE; j++)
                        {
                            file.WriteLine(rand.Next() % NUM_SIZE);
                        }
                    }
                }, i);
            }
            Task.WaitAll(genTasks);

            //Get max tasks
            Task<int>[] maxTasks = new Task<int>[TASK_SIZE];

            for (int i = 0; i < maxTasks.Length; i++)
            {
                maxTasks[i] = Task.Factory.StartNew<int>((p) =>
                {
                    int maxNum = 0;

                    using (StreamReader sr = new StreamReader(Path.Combine(folderName, fileName + p + ".txt")))
                    {
                        while (!sr.EndOfStream)
                        {
                            int num = Convert.ToInt32(sr.ReadLine());

                            if (maxNum < num)
                            {
                                maxNum = num;
                            }
                        }
                    }
                    return maxNum;
                }, i);
            }

            // Return maxNum from each task
            foreach (Task<int> tsk in maxTasks)
            {
                Console.WriteLine(tsk.Result);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PG4_Mutex
{
    /* Review
     * 1.Unmaged Resource
     * -.NET에서 Unmanaged Resource 는 명시적으로 Dispose( 혹은 Close) 해 줘야 합니다. .NET 객체는 Unmanaged Resource 에 대한 
     * Wrapper 이기 때문에 .NET 객체가 소멸된다고 해도 Unmanaged Resource는 계속 존재하게 됩니다.
     * 2.Handle
     * -프로세스 Handle은 private handle로서 시스템 전체의 Unique value가 아닙니다. 대신 시스템내 유일한 Process ID 를 사용하면 됩니다.
     * 3.Iteration Statements
     * -사용시 break문 고려해서 구성하기.
     * 4.MainWindowHandle
     * -MainWindowHandle은 Top-level "메인 윈도우"에 대한 핸들이고, Handle 은 프로세스 자체에 대한 핸들입니다. 
     * 하나의 프로세는 여러개의 윈도우를 가질 수 있습니다.
     * 5.Allication.Exit() vs this.Close()
     * -Application.Exit()는 모든 쓰레드에 message pump 를 중지할 것을 명령하여 프로그램을 중단하는 것이고, 
     * this.Close()는 현재 Form 만 close 하는 것입니다. 만약 현재 폼이 메인 폼이면 물론 프로그램이 중단하겠죠. 
     * 여기서는 폼이 메인폼이므로 둘이 실제 동일한 효과를 내겠지만, 둘은 종료 메카니즘의 차이가 있습니다. 
     * Form Close 쪽이 종료 전 좀 더 많은 체크를 합니다. entryMutex와는 특별한 관계는 없습니다.
     * 이 Form은 메인 폼입니다. 메인폼이 종료되면 이어 프로세스가 종료됩니다. 프로세스가 종료되면, 모든 리소스가 Release 됩니다. 
     * 따라서, 이 ~frmEntry() 코드는 불필요한 코드입니다.
     */
    public partial class frmEntry : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int flags);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const string GUID = "60C3D9CA-5957-41B2-9B6D-419DC9BE77DF";
        private Mutex entryMutex;

        public frmEntry()
        {
            InitializeComponent();
        }

        private void frmEntry_Load(object sender, EventArgs e)
        {
            if (!IsAlreadyRunning())
            {
                Launch();
            }
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsAlreadyRunning()
        {
            bool initiallyOwned = true; // same as initializing with WaitOne()
            string mutexName = GUID;
            bool createdNew;
            this.entryMutex = new Mutex(initiallyOwned, mutexName, out createdNew);

            try
            {
                if (!createdNew)
                {
                    const int SW_SHOWNORMAL = 1;
                    string currentProcessName = Process.GetCurrentProcess().ProcessName;
                    IntPtr hWnd = IntPtr.Zero;

                    foreach (Process targetProcess in Process.GetProcessesByName(currentProcessName))
                    {
                        if (targetProcess.Id != Process.GetCurrentProcess().Id)
                        {
                            hWnd = targetProcess.MainWindowHandle;
                            break;
                        }
                    }
                    this.Close();
                    ShowWindow(hWnd, SW_SHOWNORMAL); // Activates and displays a window.
                    SetForegroundWindow(hWnd); // Brings the thread that created the specified window into the foreground and activates the window.                    

                    return true;
                }
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        private void Launch()
        {
            this.Text = "Running";
        }
    }
}

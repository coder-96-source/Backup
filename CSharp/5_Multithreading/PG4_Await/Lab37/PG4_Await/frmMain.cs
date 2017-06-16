using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLibrary;

namespace PG4_Await
{
    /* Thread, Await 구성은 프로그램 어디에서나 이루어 질 수 있다.
     * await task 구문에서 그 이후 작업을 보류해두고 메서드를 리턴한다. 따라서, 한 메서드에
     * 여러개의 await을 구성시, 첫 번째 await에서 작업이 완료될 때까지 메서드를 return한다.
     */
    public partial class frmMain : Form
    {
        private DataManager dataManager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.dataManager = new DataManager();
            ThreadRun();
        }

        private void ThreadRun()
        {
            UpdateOrderList();
            UpdateOrderTotalCost();
            UpdateOrderTotalQuantity();
        }

        private async void UpdateOrderList()
        {
            // Thread Run 4.5sec
            Task<List<Order>> taskOrderList = Task.Factory.StartNew(() => this.dataManager.GetLast5Orders());
            await taskOrderList;

            // UI Update
            this.dgvRecentOrderList.DataSource = taskOrderList.Result;
        }
        private async void UpdateOrderTotalCost()
        {
            // Thread Run 1.5sec
            Task<decimal> taskTotalCost = Task.Factory.StartNew(() => this.dataManager.GetOrderTotal());
            await taskTotalCost;

            //UI Update
            this.txtOrderTotalCost.Text = taskTotalCost.Result.ToString();
        }
        private async void UpdateOrderTotalQuantity()
        {
            // Thread Run 1.0sec
            Task<decimal> taskTotalQuantity = Task.Factory.StartNew(() => this.dataManager.GetOrderBookCount());
            await taskTotalQuantity;

            //UI Update
            this.txtOrderTotalQuantity.Text = taskTotalQuantity.Result.ToString();
        }
    }
}

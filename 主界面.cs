using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class 主界面 : Form
    {
        public 主界面()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Query frm3 = new Query();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            BuildArchive bda = new BuildArchive();
            bda.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            登录 sign_In = new 登录();
            sign_In.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            患者编辑 updateArchive = new 患者编辑();
            updateArchive.Show();
        }
    }
}

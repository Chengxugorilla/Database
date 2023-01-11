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
    public partial class 患者编辑 : Form
    {
        public 患者编辑()
        {
            InitializeComponent();
        }

        private void UpdateArchive_Load(object sender, EventArgs e)
        {

        }

        private void LoadForm(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new 档案目录());
        }

        private void MainPanel_Paint(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new 病史());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new 就诊记录());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadForm(new 谈方案());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm(new 一期());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(new 二期());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm(new 取模());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadForm(new 戴牙());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadForm(new 软硬组织库());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadForm(new 数字化());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadForm(new 特殊患者());
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            主界面 main = new 主界面();
            main.Show();
        }
    }
}

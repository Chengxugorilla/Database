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
    public partial class BuildArchive : Form
    {
        public BuildArchive()
        {
            InitializeComponent();
        }

        private void BuildArchive_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            主界面 main = new 主界面();
            main.Show();
        }
    }
}

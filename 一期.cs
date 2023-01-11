using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Test
{
    public partial class 一期 : Form
    {
        public 一期()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void 一期_Load(object sender, EventArgs e)
        {
            BindData2Dgv(dataGridView1);
        }

        private void BindData2Dgv(DataGridView dgv)
        {
            String sqlText = "SELECT  [患者代码-姓名视图].姓名, [牙位-患者表].种植牙位, 一期信息.手术方式, 一期信息.骨质类型, 一期信息.牙龈厚度, 一期信息.种植体型号, 一期信息.种植体直径, 一期信息.种植体长度, 一期信息.植入扭矩, 一期信息.愈合方式, 一期信息.覆盖螺丝尺寸, 一期信息.愈合基台型号, 一期信息.是否植骨, 一期信息.植骨量, 一期信息.植骨品牌, 一期信息.是否使用屏障膜, 一期信息.屏障膜长度, 一期信息.屏障膜宽度, 一期信息.屏障膜品牌, 一期信息.手术备注 FROM      [患者代码-姓名视图] INNER JOIN [牙位-患者表] ON [患者代码-姓名视图].患者代码 = [牙位-患者表].患者代码 INNER JOIN 一期信息 ON [牙位-患者表].牙位ID = 一期信息.牙位ID";
            System.Data.DataTable dt = null;

            OleDbConnection conn = new OleDbConnection(DBInfo.ConnectString);//创建一个新的连接
            OleDbCommand cmd = new OleDbCommand();//OleDbCommand表示要对数据源执行的sql语句或存储过程；初始化此实例
            try
            {
                conn.Open();//打开连接
                cmd.Connection = conn;
                cmd.CommandText = sqlText;   //连接到数据库并执行SQL语言

                DataSet ds = new DataSet(); //new一个数据集实例
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);//OleDbDataAdapter 充当 DataSet 和数据源之间的桥梁，用于检索和保存数据
                adapter.Fill(ds);//使用 Fill 将数据从数据源加载到 DataSet 中
                //Fill()方法有一个重载版本，就是Fill(DataSet ds,Tables tablesName),可见，它需要两个参数，第一个参数是DataSet对象，不可省略.
                //第二参数是“表名”对象（这个表名是自己给命名的），如果省略的话，电脑默认把这个表从零“0”开始储存，
                //即有了ds.Tables[0]，当然这个对象可以替换成在使用Fill（）方法时命名的表名。
                //例如：用Fill()填充DataSet对象写作：Fill(ds,"MyNewTable"),
                //这样就看出 MyNewTable其实是自己随便取的名字,再读取的时候当然就得用：
                //ds.Tables["MyNewTable"].
                if (ds != null && ds.Tables.Count > 0)
                    dt = ds.Tables[0];

                dgv.DataSource = dt;  //传递数据到界面上的DataGridView控件
            }
            catch (Exception e)
            {
                throw new ApplicationException("获取DataSet查询异常：" + e.Message + "(" + sqlText + ")");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

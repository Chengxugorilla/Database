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
    public partial class 软硬组织库 : Form
    {
        public 软硬组织库()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 软硬组织库_Load(object sender, EventArgs e)
        {
            BindData2Dgv(dataGridView1);
        }

        private void BindData2Dgv(DataGridView dgv)
        {
            String sqlText = "SELECT  [患者代码-姓名视图].姓名, [牙位-患者表].种植牙位, 软硬组织库.口腔模型位置, 软硬组织库.模型备注,软硬组织库.是否仓扫, 软硬组织库.仓扫备注, 软硬组织库.是否拍CT, 软硬组织库.CT备注,软硬组织库.是否拟合, 软硬组织库.拟合备注, 软硬组织库.牙长轴角度, 软硬组织库.骨长轴角度,软硬组织库.[交角（牙长轴-骨长轴）], 软硬组织库.牙槽嵴顶宽度, 软硬组织库.CEJ宽度,软硬组织库.[CEJ-牙槽嵴], 软硬组织库.[CEJ下2-BL], 软硬组织库.[CEJ下2-B], 软硬组织库.[CEJ下2-L],软硬组织库.[CEJ下2-牙根], 软硬组织库.[CEJ下4-BL], 软硬组织库.[CEJ下4-B], 软硬组织库.[CEJ下4-L],软硬组织库.[CEJ下4-牙根], 软硬组织库.[CEJ-6-BL], 软硬组织库.[CEJ下6-B], 软硬组织库.[CEJ下6-L],软硬组织库.[CEJ下6-牙根], 软硬组织库.[根尖-唇腭侧], 软硬组织库.[根尖-唇侧],软硬组织库.[根尖-腭侧（M-N）], 软硬组织库.[根尖冠向2mm-唇腭侧], 软硬组织库.[根尖冠向2mm-唇侧],软硬组织库.[根尖冠向2mm-腭侧], 软硬组织库.[根尖冠向2mm-牙根], 软硬组织库.[根尖冠向4mm-唇腭侧],软硬组织库.[根尖冠向4mm-唇侧], 软硬组织库.[根尖冠向4mm-腭侧], 软硬组织库.[根尖冠向4mm-牙根],软硬组织库.[骨嵴-基骨], 软硬组织库.[骨尖-基骨], 软硬组织库.[牙长轴牙槽嵴-基骨],软硬组织库.[牙长轴根尖-基骨], 软硬组织库.根尖2mm宽度, 软硬组织库.牙长轴根尖2mmB,软硬组织库.牙长轴根尖2mmP, 软硬组织库.UndercutH, 软硬组织库.UndercutD, 软硬组织库.[S-CEJ+1],软硬组织库.[S-CEJ], 软硬组织库.[S-CEJ1], 软硬组织库.[S-CEJ2], 软硬组织库.[S-CEJ4],软硬组织库.[S-CEJ6], 软硬组织库.[S-Crest], 软硬组织库.[Crest-Margin] FROM [患者代码-姓名视图] INNER JOIN [牙位-患者表] ON [患者代码-姓名视图].患者代码 = [牙位-患者表].患者代码 INNER JOIN 软硬组织库 ON [牙位-患者表].牙位ID = 软硬组织库.牙位ID";
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

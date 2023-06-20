using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manageApp
{
    public partial class Form3 : Form
    {
        string sid;
        public Form3()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public Form3(string sid)
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            this.sid = sid;
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            toolStripStatusLabel1.Text = "欢迎学号为" + sid + "的同学登录选课系统";
            timer1.Start();
            show_Table();
        }

        private void show_Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from tb_course";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["teacher"].ToString();
                d = dr["credit"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void 课程选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int cout = dataGridView1.SelectedRows.Count;
            //MessageBox.Show($"{cout}");
            string cid = dataGridView1.SelectedCells[0].Value.ToString();// 获取选中的课程号
            string sql1 = "select * from tb_student_course where sid = '" + sid + "'and cid = '" + cid + "' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql1);
            if (!dr.Read())
            {
                string sql = "Insert into tb_student_course Values('" + sid + "','" + cid + "')";
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 form31 = new Form31(sid);
            form31.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 form32 = new Form32(sid);
            form32.Show();
        }
    }
}

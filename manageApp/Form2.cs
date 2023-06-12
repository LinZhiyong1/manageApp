using System;
using System.Windows.Forms;
using System.Data;

namespace manageApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            show_Table();
        }

        /// <summary>
        /// 展示数据
        /// </summary>
        private void show_Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from tb_student";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["class"].ToString();
                d = dr["birthday"].ToString();
                e = dr["address"].ToString();
                string[] str = { a, b, c, d, e };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 form21 = new Form21();
            form21.ShowDialog();// 弹出对话框
            show_Table();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
            Form21 form21 = new Form21(str);
            form21.ShowDialog();
            show_Table();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if ("OK".Equals(result.ToString()))
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from tb_student where id='" + id + "' and name= '" + name + "'";
                MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Excute(sql);
                show_Table();
            }
            else
            {
                return;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            show_Table();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

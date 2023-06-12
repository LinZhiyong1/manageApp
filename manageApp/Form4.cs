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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            show_Table();
        }
        private void show_Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from tb_teacher";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["password"].ToString();
                d = dr["title"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 form41 = new Form41();
            form41.ShowDialog();// 弹出对话框
            show_Table();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString() };
            Form41 form41 = new Form41(str);
            form41.ShowDialog();
            show_Table();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if ("ok".Equals(result.ToString()))
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

        private void 添加课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

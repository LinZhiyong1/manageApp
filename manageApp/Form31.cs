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
    public partial class Form31 : Form
    {
        string sid;
        public Form31()
        {
            InitializeComponent();
        }

        public Form31(string sid)
        {
            InitializeComponent();
            this.sid = sid;
            show_Table();
        }

        private void show_Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from tb_student_course where sid = '"+sid+"' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string cid = dr["cid"].ToString();
                string sql2 = "select * from tb_course where id = '" + cid + "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["id"].ToString();
                b = dr2["name"].ToString();
                c = dr2["teacher"].ToString();
                d = dr2["credit"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();
        }

        private void 取消选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("没有选课信息");
                return;
            }
            DialogResult result = MessageBox.Show("确定要删除该吗？", "提示", MessageBoxButtons.OKCancel);
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "delete from tb_student_course where sid ='" + sid + "' and cid = '" + id + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            show_Table();
        }
    }
}

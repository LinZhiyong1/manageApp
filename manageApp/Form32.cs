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
    public partial class Form32 : Form
    {
        string sid;
        public Form32(string sid)
        {
            InitializeComponent();
            this.sid = sid;
        }



        private void Form32_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select * from tb_student where id = '" + sid + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            if (dr.Read())
            {
                string password = dr["password"].ToString();
                if (password.Equals(textBox1.Text))
                {
                    if (textBox2.Text.Equals(textBox3.Text))
                    {
                        string name = dr["name"].ToString();
                        string newPassword = textBox3.Text;
                        string sql1 = "Update tb_student set password = '" + newPassword + "' where id = '" + sid + "'and name = '" + name + "' ";
                        int i = dao.Excute(sql1);
                        if (i > 0)
                        {
                            MessageBox.Show("修改成功");
                        }
                    }
                    else
                    {
                        MessageBox.Show("两次输入的密码不一致，请重新输入");
                        textBox2.Text = null;
                        textBox3.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
            }
            else
            {
                MessageBox.Show("用户不存在！");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
            }
        }
    }
}

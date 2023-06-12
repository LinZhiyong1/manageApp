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
    public partial class Form21 : Form
    {
        string[] str = new string[5];
        public Form21()
        {
            InitializeComponent();
            button2.Hide();
        }

        public Form21(string[] a)
        {
            InitializeComponent();
            button1.Hide();
            button3.Hide();
            for(int i = 0; i < 5; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into tb_student values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + 123456 + "')";
                MessageBox.Show(sql);
                Dao dao = new Dao();
                int result = dao.Excute(sql);
                if(result > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("修改后有空值，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TextBox[] textBoxes = new TextBox[5] { textBox1, textBox2, textBox3, textBox4, textBox5 };
                string[] arr = { "id", "name", "class", "birthday", "address" };
                int j = 0;
                for(int i = 0;i < 5; i++)
                {
                    if (textBoxes[i].Text != str[i])
                    {
                        string sql = "update tb_student set " + arr[i] + " = '" + textBoxes[i].Text + "' where id = '" + str[0] + "' and name = '" + str[1] + "' ";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        j++;
                        str[i] = textBoxes[i].Text;
                    }
                }
                if (j > 0)
                {
                    MessageBox.Show($"修改成功，影响行数为{j}行");
                }
            }
        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }
    }
}

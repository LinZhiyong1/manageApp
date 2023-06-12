using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace manageApp
{
    public partial class Form41 : Form
    {
        string[] str = new string[5];
        public Form41()
        {
            InitializeComponent();
            button3.Hide();
        }

        public Form41(string[] a)
        {
            InitializeComponent();
            button1.Hide();
            button2.Hide();
            for (int i = 0; i < 4; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
        }

        private void Form41_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into tb_teacher values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                MessageBox.Show(sql);
                Dao dao = new Dao();
                int result = dao.Excute(sql);
                if (result > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("修改后有空值，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TextBox[] textBoxes = new TextBox[4] { textBox1, textBox2, textBox3, textBox4 };
                string[] arr = { "id", "name", "password", "title" };
                for (int i = 0; i < 4; i++)
                {
                    if (textBoxes[i].Text != str[i])
                    {
                        string sql = "update tb_teacher set " + arr[i] + " = '" + textBoxes[i].Text + "' where id = '" + str[0] + "' and name = '" + str[1] + "' ";
                        MessageBox.Show(sql);
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[i] = textBoxes[i].Text;
                    }
                }
            }
        }
    }
}

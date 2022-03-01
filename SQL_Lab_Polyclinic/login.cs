using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Lab_Polyclinic
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            using(SqlConnection con=new SqlConnection(Properties.Resources.ConnectionString)) {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select *from users where [username]=@usernam and [password]=@passwor";
                cmd.Parameters.AddWithValue("@usernam", username);
                cmd.Parameters.AddWithValue("@passwor", password);
                bool login = false;
                int role = 0;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    login = true;
                    role = reader.GetInt32(3);
                }
                if (login)
                {
                    var f = new Form1() { Role = role };
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильно введен логин или пароль");
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}

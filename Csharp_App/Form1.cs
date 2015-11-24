using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Csharp_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            password_txt.PasswordChar = '*';
            password_txt.MaxLength = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
                MySqlConnection myConn = new MySqlConnection(myConnection);
            
                MySqlCommand SelectCommand = new MySqlCommand("SELECT * from mydatabase.users where user_name='" + this.username_txt.Text + "'and password='" + this.password_txt.Text + "' ;", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                //MessageBox.Show("Connection is done!");
                
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    progressBar1.Visible = true;
                    this.loadtimer.Start();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate usernamer and password..Login denied");
                }
                else
                    MessageBox.Show("Usernamer and password is not correct!");
                    myConn.Close();                   
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadtimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(progressBar1.Value)+10;
            percent_lbl.Text = progressBar1.Value.ToString() + " %";

            if (Convert.ToInt32(progressBar1.Value) > 90)
            {
                loadtimer.Stop();

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogexit = MessageBox.Show("Are you sure that you want to exit by app?",
                "Exit", MessageBoxButtons.YesNo);
            if (dialogexit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}

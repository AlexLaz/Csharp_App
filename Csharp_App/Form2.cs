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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FillCombo();
            FillList();
            FillTable();
            timer1.Start();
        }

        string Sex;

        public void ClearTexts()
        {
            id_txt.Text = "";
            name_txt.Text = "";
            surname_txt.Text = "";
            age_txt.Text = "";

            if (radioButton1.Checked)
            {
                radioButton1.Checked = false;
            }

            if (radioButton2.Checked)
            {
                radioButton2.Checked = false;
            }

        } 

        void FillList()
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = " select * from mydatabase.users  ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("fname");
                    listBox1.Items.Add(sName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void FillCombo()
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = " select * from mydatabase.users  ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();
           
                while (myReader.Read())
                {
                    string sName = myReader.GetString("fname");
                    comboBox1.Items.Add(sName);
            
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = "insert into mydatabase.users(id,fname,lname,age,sex,marketDate) values('" + this.id_txt.Text + "', '" + this.name_txt.Text + "', '" + this.surname_txt.Text + "','" + this.age_txt.Text + "', '" + Sex + "', '" + this.dateTimePicker1.Text + "');";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();
                MessageBox.Show("Saved");
                while(myReader.Read()){

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);              
            }
            FillTable();

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = "update mydatabase.users set id='" + this.id_txt.Text + "',fname='" + this.name_txt.Text + "',lname='" + this.surname_txt.Text + "',age='" + this.age_txt.Text + "',sex = '" + Sex + "',marketDate = '" + this.dateTimePicker1.Text + "' where id='" + this.id_txt.Text + "'  ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();
                MessageBox.Show("Updated");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = "delete from mydatabase.users where id='" + this.id_txt.Text + "' ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearTexts();
        }


        private void Addstring_btn_Click(object sender, EventArgs e)
        {
            string namestorage = name_txt.Text;
            comboBox1.Items.Add(namestorage);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = " select * from mydatabase.users where fname = '" + comboBox1.Text + "'  ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();

                while (myReader.Read())
                {
                    string sId = myReader.GetInt32("id").ToString();
                    string sName = myReader.GetString("fname");
                    string sSurname = myReader.GetString("lname");
                    string sAge = myReader.GetInt32("age").ToString();
                    id_txt.Text = sId;
                    name_txt.Text = sName;
                    surname_txt.Text = sSurname;
                    age_txt.Text = sAge;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = " select * from mydatabase.users where fname = '" + listBox1.Text + "'  ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();

                while (myReader.Read())
                {
                    string sId = myReader.GetInt32("id").ToString();
                    string sName = myReader.GetString("fname");
                    string sSurname = myReader.GetString("lname");
                    string sAge = myReader.GetInt32("age").ToString();
                    id_txt.Text = sId;
                    name_txt.Text = sName;
                    surname_txt.Text = sSurname;
                    age_txt.Text = sAge;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void FillTable()
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id as 'Customer ID',fname as 'First Name',lname as 'Last Name',age as 'Age',sex as 'Sex', marketDate as 'Market Date' from mydatabase.users  ;", conDatabase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTable_btn_Click(object sender, EventArgs e)
        {
            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id as 'Customer ID',fname as 'First Name',lname as 'Last Name',age as 'Age',sex as 'Sex', marketDate as 'Market Date' from mydatabase.users  ;", conDatabase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadChart_btn_Click(object sender, EventArgs e)
        {
            /*this.chart1.Series["Age"].Points.AddXY("Dimitris", 33);
            this.chart1.Series["Age"].Points.AddXY("Alex", 35);
            this.chart1.Series["Age"].Points.AddXY("Antonis", 22);
            this.chart1.Series["Age"].Points.AddXY("Marios", 39);*/

            string constring = "server=127.0.0.1;database=mydatabase;Uid=root;pwd=";
            string Query = " select * from mydatabase.users ;";
            MySqlConnection conData = new MySqlConnection(constring);
            MySqlCommand cmdData = new MySqlCommand(Query, conData);
            MySqlDataReader myReader;

            try
            {
                conData.Open();
                myReader = cmdData.ExecuteReader();

                while (myReader.Read())
                {
                    this.chart1.Series["Age"].Points.AddXY(myReader.GetString("fname"), myReader.GetInt32("age"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.time_lbl.Text = datetime.ToString();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            id_txt.Text = row.Cells["Customer ID"].Value.ToString();
            name_txt.Text = row.Cells["First Name"].Value.ToString();
            surname_txt.Text = row.Cells["Last Name"].Value.ToString();
            age_txt.Text = row.Cells["Age"].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Sex = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Sex = "Female";
        }

    }
}

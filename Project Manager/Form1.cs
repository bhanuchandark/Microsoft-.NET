using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Customer> customers = new List<Customer>();
        private void OnFileOpen(object sender, EventArgs e)
        {
            //Deserialization
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                FileStream fs = new FileStream(fileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                customers = bf.Deserialize(fs) as List<Customer>;
                fs.Close();
                this.dataGridView1.DataSource = customers.ToList();
            }
        }

        private void OnFileSave(object sender, EventArgs e)
        {

            ////Serialization
            //SaveFileDialog dlg = new SaveFileDialog();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = dlg.FileName;
            //    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            //    BinaryFormatter bf = new BinaryFormatter();
            //    fs.Close();
                
            //}

        }

        private void OnCustomerRegister(object sender, EventArgs e)
        {
            string firstName = this.txtFirstName.Text;
            string lastName = this.txtLastName.Text;
            string contactNumber = this.txtContactNumber.Text;
            DateTime birthDate = this.dtpBirthDate.Value;

            Customer cst = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                ContactNumber = contactNumber,
                BirthDate = birthDate
            };
            this.customers.Add(cst);
            this.dataGridView1.DataSource = customers.ToList();
        }

        private void OnEditRefersh(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = customers;
        }

        private void OnSaveAsFile(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, customers);
                fs.Close();

            }
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

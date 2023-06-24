using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Note
{
    public partial class Form1 : Form
    {
        List<contact> contacts = new List<contact>()
        {
            new contact ()
            {
                id = 1,
                FirstName = "Amir",
                LastName = "Ghasemian",
                PhoneNumber = "09302278598",
            }
        };
        bool edditing = false;
        int id = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = contacts.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edditing)
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
                {
                    MessageBox.Show(" فرمت نادرست است لطفا همه فیلد ها را پر کنید ");
                    return;
                }
                int newid;
                try
                {
                    newid = contacts.OrderByDescending(a => a.id).FirstOrDefault().id;
                }
                catch (Exception)
                {
                    newid = 0;
                }
                contact contact = new contact()
                {
                    id = newid + 1,
                    FirstName = textBox1.Text,
                    LastName = textBox2.Text,
                    PhoneNumber = textBox3.Text,
                };
                contacts.Add(contact);
                dataGridView1.DataSource = contacts.ToList();
            }
            else if (edditing)
            {
                var qcontacs = contacts.Where(a => a.id == id).FirstOrDefault();
                qcontacs.FirstName = textBox1.Text;
                qcontacs.LastName = textBox2.Text;
                qcontacs.PhoneNumber = textBox3.Text;
            }
            ClearDatas();
            dataGridView1.DataSource = contacts.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            var qcontacs = contacts.Where(a=> a.id == id).FirstOrDefault();
            if(qcontacs != null)
            {
                textBox1.Text = qcontacs.FirstName;
                textBox2.Text = qcontacs.LastName;
                textBox3.Text = qcontacs.PhoneNumber;
                edditing = true;
            }
        }
        private void ClearDatas ()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            var qcontacs = contacts.Where(a => a.id == id).FirstOrDefault();
            if (qcontacs != null)
            {
                contacts.Remove(qcontacs);
            }
            dataGridView1.DataSource = contacts.ToList();
        }
    }
}

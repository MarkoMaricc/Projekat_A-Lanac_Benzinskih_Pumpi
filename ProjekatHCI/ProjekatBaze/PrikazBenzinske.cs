using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatBaze
{
    public partial class PrikazBenzinske : Form
    {
        DodajBenzinske azg;
        public PrikazBenzinske()
        {
            InitializeComponent();
            azg=new DodajBenzinske(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {

            ObradaBenzinske.DisplayAndSearch("SELECT id,Adresa,Grad,Drzava,Telefon,email,BrojParkingMjesta,Naziv FROM `benzinska_pumpa`.`benzinske_stanice`",dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.Adresa = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Grad = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.Drzava = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                azg.Telefon = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                azg.email = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                azg.BrojParkingMjesta = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                azg.Naziv = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to clear the pump?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaBenzinske.obrisiBenzinske(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {
                    if (MessageBox.Show("Da li zaista želite da obrišete pumpu?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaBenzinske.obrisiBenzinske(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            azg.ocisti();
            azg.DodavanjeInfo();
            azg.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ObradaBenzinske.DisplayAndSearch("SELECT id,Adresa,Grad,Drzava,Telefon,email,BrojParkingMjesta,Naziv FROM `benzinska_pumpa`.`benzinske_stanice`WHERE Naziv LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }
    }
}

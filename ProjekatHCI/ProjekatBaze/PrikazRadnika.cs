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
    public partial class PrikazRadnika : Form
    {
        DodajRadnika azg;
        public PrikazRadnika()
        {
            InitializeComponent();
            azg = new DodajRadnika(this);
        }

        public void Display()
        {
            
           ObradaRadnika.DisplayAndSearch("SELECT benzinska_pumpa.radnik.id,JMBG,Prezime,Ime,Uloga,Plata,PutniTroskovi,BrojLicneKarte,DatumRodjenja,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv" +
               " FROM `benzinska_pumpa`.`radnik` join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice", dataGridView1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            azg.ocisti();
            azg.DodavanjeInfo();
            azg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.jmbg = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Prezime = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.Ime = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                azg.Uloga = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                azg.Plata = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                azg.PutniTroskovi = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                azg.BrojLicneKarte = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                azg.DatumRodjenja = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                azg.idStanice = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to delete the worker?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaRadnika.obrisiRadnika(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {

                    if (MessageBox.Show("Da li zaista želite da obrišete radnika?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaRadnika.obrisiRadnika(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ObradaRadnika.DisplayAndSearch("SELECT benzinska_pumpa.radnik.id,JMBG,Prezime,Ime,Uloga,Plata,PutniTroskovi,BrojLicneKarte,DatumRodjenja,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv" +
             " FROM `benzinska_pumpa`.`radnik` join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice WHERE Prezime LIKE '%" + textBox1.Text + "%'", dataGridView1);

        }
    }
}

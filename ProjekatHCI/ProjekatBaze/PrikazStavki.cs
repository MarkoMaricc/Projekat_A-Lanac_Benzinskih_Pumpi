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
    public partial class PrikazStavki : Form
    {

        DodajStavku azg;
      
        public string idRacuna;
        public PrikazStavki(bool tekst,string id)
        {
            InitializeComponent();
           azg = new DodajStavku(this);

        }

        public void Display()
        {
            
            ObradaRacuna.DisplayAndSearch("SELECT id,Kolicina,Cena,idRacuna,PROIZVOD_Vrsta FROM `benzinska_pumpa`.`stavka`", dataGridView2);
            }

        private void PrikazStavki_Load(object sender, EventArgs e)
        {

        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.id = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.Kolicina = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Cena = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.idRacuna = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
               azg.Proizvod_vrsta= dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to delete the item?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaStavki.obrisiStavku(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {

                    if (MessageBox.Show("Da li zaista želite da obrišete stavku?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaStavki.obrisiStavku(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            azg.ocisti();
            azg.DodavanjeInfo();
            azg.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ObradaRacuna.DisplayAndSearch("SELECT id,Kolicina,Cena,idRacuna,PROIZVOD_Vrsta FROM `benzinska_pumpa`.`stavka` WHERE PROIZVOD_Vrsta LIKE '%" + textBox1.Text + "%'", dataGridView2);

        }
    }
}

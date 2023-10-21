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
    public partial class PrikazKase : Form
    {
        DodajKasu azg;
        public PrikazKase()
        {
            InitializeComponent();
            azg = new DodajKasu(this);
        }


        public void Display()
        {
            ObradaKase.DisplayAndSearch("SELECT benzinska_pumpa.kasa.id,NacinPlacanja,Vrsta,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv FROM `benzinska_pumpa`.`kasa` " +
                "join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            azg.ocisti();
            azg.DodavanjeInfo();
            azg.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.NacinPlacanja = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Vrsta = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.idStanice = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
               

                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {

                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to clear the checkout?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaKase.obrisiKasu(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {

                    if (MessageBox.Show("Da li zaista želite da obrišete kasu?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaKase.obrisiKasu(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ObradaKase.DisplayAndSearch("SELECT benzinska_pumpa.kasa.id,NacinPlacanja,Vrsta,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv FROM `benzinska_pumpa`.`kasa` " +
               "join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice WHERE `benzinska_pumpa`.`benzinske_stanice`.Naziv LIKE '%" + textBox1.Text + "%'", dataGridView1);

        }
    }
}

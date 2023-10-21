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
    public partial class PrikazR : Form
    {
        DodajRacun azg;
        public PrikazR()
        {
            InitializeComponent();
            azg = new DodajRacun(this);

        }

        public void Display()
        {
            ObradaRacuna.DisplayAndSearch("SELECT benzinska_pumpa.racun.id,Datum,Cena,idKase,`benzinska_pumpa`.`kasa`.Vrsta" +
              " FROM `benzinska_pumpa`.`racun` join `benzinska_pumpa`.`kasa` on `benzinska_pumpa`.`kasa`.id=idKase", dataGridView);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PrikazStavki pr = new PrikazStavki(false,"");
            pr.ShowDialog();
           
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.Datum = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Cena = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.idKase= dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
              
               
                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to delete account?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaRacuna.obrisiRacun(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {



                    if (MessageBox.Show("Da li zaista želite da obrišete racun?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaRacuna.obrisiRacun(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
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
            ObradaRacuna.DisplayAndSearch("SELECT benzinska_pumpa.racun.id,Datum,Cena,idKase,`benzinska_pumpa`.`kasa`.Vrsta" +
             " FROM `benzinska_pumpa`.`racun` join `benzinska_pumpa`.`kasa` on `benzinska_pumpa`.`kasa`.id=idKase WHERE Vrsta LIKE '%" + textBox1.Text + "%'", dataGridView);

        }
    }
}

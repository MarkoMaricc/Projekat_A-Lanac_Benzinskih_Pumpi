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
    public partial class PrikazP : Form
    {

        DodajProizvod azg;
        public PrikazP()
        {
            InitializeComponent();
            azg = new DodajProizvod(this);
        }


        public void Display()
        {
            ObradaProizvoda.DisplayAndSearch("SELECT benzinska_pumpa.proizvod.Vrsta,Cena,idSkladista,`benzinska_pumpa`.`skladiste`.Status FROM `benzinska_pumpa`.`proizvod` " +
                "join `benzinska_pumpa`.`skladiste` on id=idSkladista", dataGridView1);
        }

        private void PrikazP_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                azg.ocisti();
                azg.Vrsta = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.Cena = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.idSkladista = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
               

                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to delete the product?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaProizvoda.obrisiProizvod(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {

                    if (MessageBox.Show("Da li zaista želite da obrišete proizvod?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaProizvoda.obrisiProizvod(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

            ObradaProizvoda.DisplayAndSearch("SELECT benzinska_pumpa.proizvod.Vrsta,Cena,idSkladista,`benzinska_pumpa`.`skladiste`.Status FROM `benzinska_pumpa`.`proizvod` " +
                "join `benzinska_pumpa`.`skladiste` on id=idSkladista WHERE benzinska_pumpa.proizvod.Vrsta LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }
    }
}

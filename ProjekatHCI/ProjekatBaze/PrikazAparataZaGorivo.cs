using MySqlX.XDevAPI.Relational;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatBaze
{
    public partial class PrikazAparataZaGorivo : Form
    {
        DodajAparatZaGorivo azg;
        public PrikazAparataZaGorivo()
        {
            InitializeComponent();
            azg=new DodajAparatZaGorivo(this);
        }


        public void Display()
        {
            ObradaAparataZaGorivo.DisplayAndSearch("SELECT benzinska_pumpa.aparat_za_gorivo.id,Vrsta,Materijal,Proizvodjac,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv FROM `benzinska_pumpa`.`aparat_za_gorivo` " +
                "join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
               
                azg.ocisti();
                azg.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                azg.Vrsta = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                azg.Materijal = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                azg.Proizvodjac = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                azg.idStanice = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                azg.IzmjenaInfo();
                azg.ShowDialog();
                return;


            }


            if (e.ColumnIndex == 1)
            {
                var currCulture = Thread.CurrentThread.CurrentCulture;

                if (currCulture.Name == "en")
                {
                    if (MessageBox.Show("Are you sure you want to wipe the fuel dispenser?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaAparataZaGorivo.obrisiAparat(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
                else
                {
                    if (MessageBox.Show("Da li zaista želite da obrišete aparat za gorivo?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ObradaAparataZaGorivo.obrisiAparat(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Display();
                    }
                    return;
                }
            }
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            azg.ocisti();
            azg.DodavanjeInfo();
            azg.ShowDialog();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ObradaAparataZaGorivo.DisplayAndSearch("SELECT benzinska_pumpa.aparat_za_gorivo.id,Vrsta,Materijal,Proizvodjac,idStanice,`benzinska_pumpa`.`benzinske_stanice`.Naziv FROM `benzinska_pumpa`.`aparat_za_gorivo` " +
               "join `benzinska_pumpa`.`benzinske_stanice` on `benzinska_pumpa`.`benzinske_stanice`.id=idStanice WHERE `benzinska_pumpa`.`benzinske_stanice`.Naziv LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }
    }
}

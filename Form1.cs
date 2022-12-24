using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelLogic.LogicPersonalList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelLogic.LogicPersonalList();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            PersonelEntity personel = new PersonelEntity();
            personel.PersonelAd = txtAd.Text;
            personel.PersonelSoyad = txtSoyad.Text;
            personel.PersonelSehir = txtSehir.Text;
            personel.PersonelMaas = short.Parse(txtMaas.Text);
            personel.PersonelDurum = bool.Parse(txtDurum.Text);
            personel.PersonelMeslek = txtMeslek.Text;
            PersonelLogic.LogicPersonelEkle(personel);
            Listele();
            Temizle();
        }

        void Listele()
        {
            dataGridView1.DataSource = PersonelLogic.LogicPersonalList();
        }

        void Temizle()
        {
            txtMaas.Clear();
            txtSehir.Clear();
            txtDurum.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtMeslek.Clear();
            txtId.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            PersonelLogic.LogicPersonelSil(id);
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            PersonelEntity personel = new PersonelEntity();
            personel.PersonelId = int.Parse(txtId.Text);
            personel.PersonelAd = txtAd.Text;
            personel.PersonelSoyad = txtSoyad.Text;
            personel.PersonelSehir = txtSehir.Text;
            personel.PersonelMaas = short.Parse(txtMaas.Text);
            personel.PersonelDurum = bool.Parse(txtDurum.Text);
            personel.PersonelMeslek = txtMeslek.Text;
            PersonelLogic.LogicPersonelGuncelle(personel);
            Listele();
            Temizle();
        }
    }
}

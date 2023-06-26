using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IsTakip.Entity;

namespace IsTakip.Formlar
{
    public partial class FrmYeniGorev : Form
    {
        public FrmYeniGorev()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler tblGorevler = new TblGorevler();
            tblGorevler.Tarih = DateTime.Parse(txtTarih.Text);
            tblGorevler.Aciklama = txtAciklama.Text;
            tblGorevler.GorevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            tblGorevler.GorevVeren = 1;
            tblGorevler.Durum = true;

            db.TblGorevler.Add(tblGorevler);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni görev kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmYeniGorev_Load(object sender, EventArgs e)
        {
            var GorevAlan = (from x in db.TblPersoneller
                             select new
                             {
                                 x.ID,
                                 AdSoyad = x.name +" " + x.surname
                             }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DataSource = GorevAlan;

            txtGorevVeren.Text = "5";

        }


    }
}

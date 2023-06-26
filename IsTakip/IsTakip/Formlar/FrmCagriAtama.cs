using DevExpress.XtraEditors;
using IsTakip.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsTakip.Formlar
{
    public partial class FrmCagriAtama : Form
    {
        public int Id;
        public FrmCagriAtama()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void FrmCagriAtama_Load(object sender, EventArgs e)
        {
            var GorevAlan = (from x in db.TblPersoneller
                             select new
                             {
                                 x.ID,
                                 AdSoyad = x.name + " " + x.surname
                             }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DataSource = GorevAlan;

            txtCagriID.Text = Id.ToString();
            txtCagriID.Enabled = false;
            var gelenVeri = db.TblCagrilar.Find(Id);
            txtAciklama.Text = gelenVeri.Aciklama;
            txtTarih.Text = gelenVeri.Tarih.ToString();
            TxtKonu.Text = gelenVeri.Konu.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            var gelenVeri = db.TblCagrilar.Find(Id);
            gelenVeri.Konu = TxtKonu.Text;
            gelenVeri.Aciklama = txtAciklama.Text;
            gelenVeri.Tarih = DateTime.Parse(txtTarih.Text);
            gelenVeri.CagriPersonel =int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Çağrı personele atandı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

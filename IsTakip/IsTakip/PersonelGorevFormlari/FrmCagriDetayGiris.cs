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

namespace IsTakip.PersonelGorevFormlari
{
    public partial class FrmCagriDetayGiris : Form
    {
        public int Id;
        public FrmCagriDetayGiris()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void FrmCagriDetayGiris_Load(object sender, EventArgs e)
        {
            string tarih, saat;
            txtCagriID.Enabled = false;
            txtCagriID.Text = Id.ToString();
            tarih = DateTime.Now.ToShortDateString();
            saat = DateTime.Now.ToShortTimeString();
            TxtSaat.Text = saat;
            txtTarih.Text = tarih;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblCagriDetay t = new TblCagriDetay();
            t.Cagri = int.Parse(txtCagriID.Text);
            t.Saat = TxtSaat.Text;
            t.Tarih = DateTime.Parse(txtTarih.Text);
            t.Aciklama = txtAciklama.Text;
            db.TblCagriDetay.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Çağrı detayı sisteme başarılı bir şekilde kaydedildi!","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}

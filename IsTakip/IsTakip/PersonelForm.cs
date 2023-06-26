using IsTakip.Formlar;
using IsTakip.PersonelGorevFormlari;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsTakip
{
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }
        public string Mail;
        PersonelGorevFormlari.FrmPersonelAktifGorevler frmPersonelAktifGorevler;
        private void btnAktifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmPersonelAktifGorevler == null || frmPersonelAktifGorevler.IsDisposed)
            {
                frmPersonelAktifGorevler = new PersonelGorevFormlari.FrmPersonelAktifGorevler();
                //frmPersonelAktifGorevler.MdiParent = this;
                frmPersonelAktifGorevler.mail2 = Mail.ToString();
                frmPersonelAktifGorevler.Show();
            }
        }
        PersonelGorevFormlari.FrmPersonelPasifGorevler psfGorev;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (psfGorev == null || psfGorev.IsDisposed)
            {
                psfGorev = new PersonelGorevFormlari.FrmPersonelPasifGorevler();
                //psfGorev.MdiParent = this;
                psfGorev.Show();
            }
        }
        PersonelGorevFormlari.FrmCagriListesi CagriListesi;

        private void btnCagriList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(CagriListesi == null || CagriListesi.IsDisposed)
            {
                CagriListesi = new FrmCagriListesi();
                CagriListesi.mail2 = Mail.ToString();
                //CagriListesi.MdiParent = this;
                CagriListesi.Show();
            }
        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            //this.Text = Mail.ToString();
            this.Text = "Personel Paneli";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login.FrmLogin login = new Login.FrmLogin();
            login.Show();
            this.Hide(); 
        }
    }
}

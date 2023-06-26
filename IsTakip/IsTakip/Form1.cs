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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmDepartmanlar frmDepartmanlar;
        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmDepartmanlar == null || frmDepartmanlar.IsDisposed)
            {
                frmDepartmanlar = new Formlar.FrmDepartmanlar();
                frmDepartmanlar.MdiParent = this;
                frmDepartmanlar.Show();
            }
        }

        Formlar.FrmPersoneller frmPersoneller;
        private void btnPersonelList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmPersoneller == null || frmPersoneller.IsDisposed)
            {
                frmPersoneller = new Formlar.FrmPersoneller();
                frmPersoneller.MdiParent = this;
                frmPersoneller.Show();
            }
        }

        Formlar.FrmPersonelIstatistik frmPersonelIstatistik;
        private void btnPersonelIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmPersonelIstatistik == null || frmPersonelIstatistik.IsDisposed)
            {
                frmPersonelIstatistik = new Formlar.FrmPersonelIstatistik();
                frmPersonelIstatistik.MdiParent = this;
                frmPersonelIstatistik.Show();
            }
        }

        Formlar.FrmGorevListesi frmGorevListesi;
        private void btnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmGorevListesi == null || frmGorevListesi.IsDisposed)
            {
                frmGorevListesi = new Formlar.FrmGorevListesi();
                frmGorevListesi.MdiParent = this;
                frmGorevListesi.Show();
            }
        }

        Formlar.FrmYeniGorev frmYeniGorev;
        private void btnYeniGorev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmYeniGorev == null || frmYeniGorev.IsDisposed)
            {
                frmYeniGorev = new Formlar.FrmYeniGorev();
                frmYeniGorev.Show();
            }

        }

        Formlar.FrmGorevDetay frmGorevDetay;
        private void BtnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmGorevDetay == null || frmGorevDetay.IsDisposed)
            {
                frmGorevDetay = new Formlar.FrmGorevDetay();
                frmGorevDetay.Show();
            }

        }

        Formlar.FrmAnasayfa frmAnasayfa;
        private void BtnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAnasayfa == null || frmAnasayfa.IsDisposed)
            {
                frmAnasayfa = new Formlar.FrmAnasayfa();
                frmAnasayfa.MdiParent = this;
                frmAnasayfa.Show();
            }
            
        }
        Formlar.FrmAktifCagrilar frmAktifCagrilar;
        private void btnAktifCafrilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAktifCagrilar == null || frmAktifCagrilar.IsDisposed)
            {
                frmAktifCagrilar = new Formlar.FrmAktifCagrilar();
                frmAktifCagrilar.MdiParent = this;
                frmAktifCagrilar.Show();
            }
        }

        Formlar.FrmPasifCagrilar FrmPasifCagrilar;
        private void btnPasifCagrilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmPasifCagrilar == null || FrmPasifCagrilar.IsDisposed)
            {
                FrmPasifCagrilar = new Formlar.FrmPasifCagrilar();
                FrmPasifCagrilar.MdiParent = this;
                FrmPasifCagrilar.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login.FrmLogin login = new Login.FrmLogin();
            login.Show();
            this.Hide();
        }
    }
}

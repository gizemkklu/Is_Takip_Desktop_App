using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using IsTakip.Entity;

namespace IsTakip.Formlar
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            //Devam eden görevler
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                         AdSoyad =  x.TblPersoneller.name + " "+ x.TblPersoneller.surname,
                                         x.Aciklama,
                                         x.Durum
                                       }).Where(y => y.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            //Bugün Yapılan görevler
            var bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            gridControl3.DataSource = (from x in db.TblGorevDetay
                                       select new
                                       {
                                           x.Tarih,
                                           x.Aciklama,
                                           gorev = x.TblGorevler.Aciklama
                                       }).Where(y => y.Tarih == bugun).ToList();

            //Çağrı Aktif Listesi
            gridControl2.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.TblFirmalar.name,
                                           x.Konu,
                                           x.Tarih,                                           
                                           x.Durum,
                                       }).Where(y => y.Durum == true).ToList();
            gridView2.Columns["Durum"].Visible =false;


            //Fihrist
            gridControl4.DataSource = (from x in db.TblFirmalar
                                       select new
                                       {
                                           x.name,
                                           x.number,
                                           x.Mail,
                                       }).ToList();

            // Çağrı Grafiği
            int aktif_cagrilar = db.TblCagrilar.Where(x => x.Durum == true).Count();
            int pasif_cagrilar = db.TblCagrilar.Where(x => x.Durum == false).Count();

            chartControl1.Series["Series 1"].Points.AddPoint("Aktif Çağrılar", aktif_cagrilar);
            chartControl1.Series["Series 1"].Points.AddPoint("Pasif Çağrılar", pasif_cagrilar);
        }


    }
}

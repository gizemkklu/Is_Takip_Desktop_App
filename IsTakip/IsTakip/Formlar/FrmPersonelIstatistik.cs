using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraLayout.Filtering.Templates;
using IsTakip.Entity;

namespace IsTakip.Formlar
{
    public partial class FrmPersonelIstatistik : Form
    {
        public FrmPersonelIstatistik()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void FrmPersonelIstatistik_Load(object sender, EventArgs e)
        {
            lblToplamPersonel.Text = db.TblPersoneller.Count().ToString();
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            lblFirmalar.Text = db.TblFirmalar.Count().ToString();
            lblAktifIs.Text = db.TblGorevler.Where(x=>x.Durum== true).Count().ToString();
            lblPasifIs.Text = db.TblGorevler.Where(x=>x.Durum== false).Count().ToString();
            lblSonGorev.Text = db.TblGorevler.OrderByDescending(x=>x.ID).Select(x => x.Aciklama).FirstOrDefault();
            lblFirmalar.Text = db.TblFirmalar.Count().ToString();
            LblSehirler.Text = db.TblFirmalar.Select(x=>x.province).Distinct().Count().ToString();
            lblSektor.Text = db.TblFirmalar.Select(x=>x.Sector).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;
            lblBugunkuGorev.Text = db.TblGorevler.Count(x=>x.Tarih == bugun).ToString();
            var sonGorevId = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
            LblSonGorevTarihi.Text = db.TblGorevDetay.Where(y=>y.Gorev == sonGorevId).Select(x => x.Tarih).FirstOrDefault().ToString();
            var userid = db.TblGorevler.GroupBy(x=>x.GorevVeren).OrderByDescending(y=>y.Count()).Select(m=>m.Key).FirstOrDefault();
            lblAyinPersoneli.Text = db.TblPersoneller.Where(x => x.ID == userid).Select(x => x.name +" " + x.surname).FirstOrDefault();
            var departmanId = db.TblPersoneller.Where(x => x.ID == userid).Select(x => x.Departman).FirstOrDefault();
            LblAyinDepartmani.Text = db.TblDepartmanlar.Where(x => x.ID == departmanId).Select(x => x.Name).FirstOrDefault();

        }
    }
}

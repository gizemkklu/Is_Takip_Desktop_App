using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts.Native;
using IsTakip.Entity;


namespace IsTakip.Formlar
{
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        void Listele()
        {
            gridControl1.DataSource = (from x in db.TblGorevler 
                            select new
                            {
                                x.Aciklama
                            }).ToList();
        }

        void Chart()
        {
            lblPasifGorev.Text = db.TblGorevler.Where(x => x.Durum == false).Count().ToString();
            lblAktifGorev.Text = db.TblGorevler.Where(x => x.Durum == true).Count().ToString();
            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler",int.Parse(lblAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", int.Parse(lblPasifGorev.Text));

        }
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            Listele();
            Chart();

            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
        }


    }
}

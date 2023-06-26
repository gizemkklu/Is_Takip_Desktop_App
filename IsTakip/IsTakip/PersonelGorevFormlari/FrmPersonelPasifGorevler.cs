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
    public partial class FrmPersonelPasifGorevler : Form
    {
        public FrmPersonelPasifGorevler()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        public string mail2;

        private void FrmPersonelPasifGorevler_Load(object sender, EventArgs e)
        {
            var personelID = db.TblPersoneller.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();
            var deger = (from x in db.TblGorevler
                         select new
                         {
                             x.ID,
                             x.Aciklama,
                             x.Tarih,
                             x.GorevAlan,
                             x.Durum
                         }).Where(x => x.GorevAlan == personelID && x.Durum == false).ToList();
            gridControl1.DataSource = deger;

            gridView1.Columns["GorevAlan"].Visible = false;
            gridView1.Columns["Durum"].Visible = false;
        }
    }
}

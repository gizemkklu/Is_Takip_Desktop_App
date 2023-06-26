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
    public partial class FrmPasifCagrilar : Form
    {
        public FrmPasifCagrilar()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void FrmPasifCagrilar_Load(object sender, EventArgs e)
        {
            var deger = (from x in db.TblCagrilar
                         select new
                         {
                             x.ID,
                             x.TblFirmalar.name,
                             x.TblFirmalar.number,
                             x.Konu,
                             x.Aciklama,
                             x.Durum

                         }).Where(y=>y.Durum == false).ToList();
            gridControl1.DataSource = deger;
        }
    }
}

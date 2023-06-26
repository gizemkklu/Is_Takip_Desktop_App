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
    public partial class FrmCagriListesi : Form
    {
        public FrmCagriListesi()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        public string mail2;
        private void FrmCagriListesi_Load(object sender, EventArgs e)
        {
            var personelID = db.TblPersoneller.Where(x => x.Mail == mail2).Select(y => y.ID).FirstOrDefault();
            gridControl1.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.ID,
                                           x.TblFirmalar.name,
                                           x.TblFirmalar.number,
                                           x.TblFirmalar.Mail,
                                           x.Aciklama,
                                           x.CagriPersonel,
                                           x.Durum
                                       }).Where(x=>x.Durum == true && x.CagriPersonel == personelID).ToList();
            gridView1.Columns["Durum"].Visible = false;
            gridView1.Columns["CagriPersonel"].Visible = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriDetayGiris frmCagriDetayGiris = new FrmCagriDetayGiris();
            frmCagriDetayGiris.Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            frmCagriDetayGiris.Show();
        }
    }
}

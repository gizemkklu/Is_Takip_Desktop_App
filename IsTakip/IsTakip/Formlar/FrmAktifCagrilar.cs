﻿using IsTakip.Entity;
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
    public partial class FrmAktifCagrilar : Form
    {
        public FrmAktifCagrilar()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void FrmAktifCagrilar_Load(object sender, EventArgs e)
        {
            var deger = (from x in db.TblCagrilar
                         select new
                         {
                             x.ID,
                             x.TblFirmalar.name,
                             x.TblFirmalar.number,
                             Personel = x.TblPersoneller.name,
                             x.Konu,
                             x.Aciklama,
                             x.Durum

                         }).Where(y => y.Durum == true).ToList();
            gridControl1.DataSource = deger;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriAtama frmCagriAtama = new FrmCagriAtama();
            frmCagriAtama.Id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            frmCagriAtama.Show();
        }
    }
}

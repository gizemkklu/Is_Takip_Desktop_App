using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsTakip.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IsTakip.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        void Listele()
        {
       
            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Name
                            }
                            ).ToList();
            gridControl1.DataSource = degerler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Name = txtAD.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman kaydedildi !", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblDepartmanlar.Find(id);
            db.TblDepartmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Departman Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblDepartmanlar.Find(id);
            deger.Name = txtAD.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();

        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}

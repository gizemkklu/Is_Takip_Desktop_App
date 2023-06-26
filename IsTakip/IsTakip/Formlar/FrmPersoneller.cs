using DevExpress.XtraEditors;
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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        IsTakipDbEntities1 db = new IsTakipDbEntities1();

        void Listele()
        {
            var degerler = from x in db.TblPersoneller
                           select new
                           {
                               x.ID,
                               x.name,
                               x.surname,
                               x.Mail,
                               Departman = x.TblDepartmanlar.Name,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x=>x.Durum == true).ToList();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Listele();
            var departmanlar = (from x in db.TblDepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Name
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblPersoneller tblPersoneller = new TblPersoneller();
            tblPersoneller.name = txtAD.Text;
            tblPersoneller.surname = txtSoyad.Text;
            tblPersoneller.Mail = txtMail.Text;
            tblPersoneller.Image = txtGorsel.Text;
            tblPersoneller.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.TblPersoneller.Add(tblPersoneller);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni personel başarıyla eklendi!","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblPersoneller.Find(id);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            Listele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblPersoneller.Find(id);
            deger.name = txtAD.Text;
            deger.surname = txtSoyad.Text;
            deger.Mail = txtMail.Text;
            deger.Image = txtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();  
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("name").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("surname").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            // txtGorsel.Text = gridView1.GetFocusedRowCellValue("Image").ToString() ;
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }
    }
}

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

namespace IsTakip.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        IsTakipDbEntities1 db = new IsTakipDbEntities1();
        private void btnYoneticiGiris_Click(object sender, EventArgs e)
        {

            var admin = db.TblAdmin.Where(x => x.Kullanici == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if(admin != null)
            {
               Form1 form1 = new Form1();
               form1.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPersonelGiris_Click(object sender, EventArgs e)
        {
            var personel = db.TblPersoneller.Where(x=>x.Mail == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
           if(personel != null)
            {
                PersonelForm prslForm = new PersonelForm();
                prslForm.Mail = personel.Mail;
                prslForm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com");
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void WebLinki_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:7229/Login/Index");
        }

        private void appClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void help_Click(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start("");
        }
    }
}

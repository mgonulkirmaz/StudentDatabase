using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITYLAYER;
using FACADELAYER;
using BUSINESSLOGICLAYER;

namespace OgrenciSistemi
{
    public partial class Form1 : Form
    {
        bool state = true;

        public Form1()
        {
            InitializeComponent();
        }

        void OgrenciListesi()
        {
            List<ENTITYOGRENCI> OgrList = BLLOGRENCI.LISTELE();
            dataGridView1.Update();
            dataGridView1.DataSource = OgrList;
            this.Text = "Öğrenci Listesi";
        }

        void KulupListesi()
        {
            List<ENTITYOGRENCIKULUP> KlpList = BLLKULUP.LISTELE();
            cmbKULUP.DisplayMember = "KULUPAD";
            cmbKULUP.ValueMember = "KULUPID";
            cmbKULUP.DataSource = KlpList;
            dataGridView1.DataSource = KlpList;
            this.Text = "Kulüp Listesi";
        }

        void NotListesi()
        {
            state = false;
            List<ENTITYNOT> entNot = BLLNOTLAR.LISTELE();
            dataGridView1.DataSource = entNot;
            this.Text = "Not Listesi";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KulupListesi();
            OgrenciListesi();          
        }

        private void btnKAYDET_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCI ogr = new ENTITYOGRENCI();
            ogr.AD = txtOGRAD.Text;
            ogr.SOYAD = txtOGRSOYAD.Text;
            ogr.FOTOGRAF = txtOGRFOTO.Text;
            ogr.KULUPID = Convert.ToInt16(cmbKULUP.SelectedValue);

            int kaydet = BLLOGRENCI.EKLE(ogr);

            if (kaydet > -1)
                MessageBox.Show(ogr.AD + " " + ogr.SOYAD + " isimli öğrenci eklendi");
            else
                MessageBox.Show("Hatalı veya eksik giriş sebebiyle öğrenci eklenemedi");
            OgrenciListesi();
        }

        private void btnSIL_Click(object sender, EventArgs e)
        {
            int deger = Convert.ToInt16(txtOGRID.Text);
        }

        private void btnLISTELE_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
        }

        private void btnGUNCELLE_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCI ogr = new ENTITYOGRENCI();
            ogr.ID = Convert.ToInt16(txtOGRID.Text);
            ogr.AD = txtOGRAD.Text;
            ogr.SOYAD = txtOGRSOYAD.Text;
            ogr.FOTOGRAF = txtOGRFOTO.Text;
            ogr.KULUPID = Convert.ToInt16(cmbKULUP.SelectedValue);

            bool kaydet = BLLOGRENCI.GUNCELLE(ogr);

            if (kaydet)
                MessageBox.Show(ogr.AD + " " + ogr.SOYAD + " isimli öğrencinin bilgileri güncellendi");
            else
                MessageBox.Show("Hatalı veya eksik giriş sebebiyle öğrencinin bilgileri güncellenemedi");

            OgrenciListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.Text == "Öğrenci Listesi")
            {
                dataGridView1.Update();
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtOGRID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOGRAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtOGRSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtOGRFOTO.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                cmbKULUP.SelectedIndex = Convert.ToInt16(dataGridView1.Rows[secilen].Cells[4].Value);
            }

            if (this.Text == "Not Listesi")
            {
                state = false;
                dataGridView1.Update();
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtIDNOT.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOGRID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOGRAD.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                txtOGRSOYAD.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
                txtSINAV1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtSINAV2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtSINAV3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtPROJE.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                txtORT.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                txtDURUM.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            }

            if (this.Text == "Kulüp Listesi")
            {
                dataGridView1.Update();
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtKULUPID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtKULUPAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            }
            state = true;
        }

        private void btnNOTLISTELE_Click(object sender, EventArgs e)
        {
            NotListesi();
        }

        private void btnNOTGUNCELLE_Click(object sender, EventArgs e)
        {
            ENTITYNOT not = new ENTITYNOT();
            not.AD = txtOGRAD.Text;
            not.SOYAD = txtOGRSOYAD.Text;
            not.OGRENCIID = Convert.ToInt16(txtIDNOT.Text);
            not.SINAV1 = Convert.ToInt16(txtSINAV1.Text);
            not.SINAV2 = Convert.ToInt16(txtSINAV2.Text);
            not.SINAV3 = Convert.ToInt16(txtSINAV3.Text);
            not.PROJE = Convert.ToInt16(txtPROJE.Text);
            not.ORTALAMA = ((not.SINAV1 + not.SINAV2 + not.SINAV3) / 3) * 0.6 + not.PROJE * 0.4;

            if (not.ORTALAMA >= 50)
                not.DURUM = "True";
            else
                not.DURUM = "False";

            bool guncelle = BLLNOTLAR.GUNCELLE(not);
            if (guncelle)
                MessageBox.Show(not.AD + " " + not.SOYAD + " isimli öğrencinin notları güncellendi");
            else
                MessageBox.Show("Eksik veya hatalı giriş yapıldı");
            NotListesi();
        }

        private void txtSINAV1_TextChanged(object sender, EventArgs e)
        {
            if (state)
            {
                int s1, s2, s3, p1;
                double ort;
                s1 = Convert.ToInt16(txtSINAV1.Text);
                s2 = Convert.ToInt16(txtSINAV2.Text);
                s3 = Convert.ToInt16(txtSINAV3.Text);
                p1 = Convert.ToInt16(txtPROJE.Text);
                ort = ((s1 + s2 + s3) / 3) * 0.6 + p1 * 0.4;
                txtORT.Text = ort.ToString("F");

                if (ort >= 50)
                    txtDURUM.Text = "True";
                else
                    txtDURUM.Text = "False";
            }
        }

        private void txtSINAV2_TextChanged(object sender, EventArgs e)
        {
            if (state)
            {
                int s1, s2, s3, p1;
                double ort;
                s1 = Convert.ToInt16(txtSINAV1.Text);
                s2 = Convert.ToInt16(txtSINAV2.Text);
                s3 = Convert.ToInt16(txtSINAV3.Text);
                p1 = Convert.ToInt16(txtPROJE.Text);
                ort = ((s1 + s2 + s3) / 3) * 0.6 + p1 * 0.4;
                txtORT.Text = ort.ToString("F");

                if (ort >= 50)
                    txtDURUM.Text = "True";
                else
                    txtDURUM.Text = "False";
            }
        }

        private void txtSINAV3_TextChanged(object sender, EventArgs e)
        {
            if (state)
            {
                int s1, s2, s3, p1;
                double ort;
                s1 = Convert.ToInt16(txtSINAV1.Text);
                s2 = Convert.ToInt16(txtSINAV2.Text);
                s3 = Convert.ToInt16(txtSINAV3.Text);
                p1 = Convert.ToInt16(txtPROJE.Text);
                ort = ((s1 + s2 + s3) / 3) * 0.6 + p1 * 0.4;
                txtORT.Text = ort.ToString("F");

                if (ort >= 50)
                    txtDURUM.Text = "True";
                else
                    txtDURUM.Text = "False";
            }
        }

        private void txtPROJE_TextChanged(object sender, EventArgs e)
        {
            if (state)
            {
                int s1, s2, s3, p1;
                double ort;
                s1 = Convert.ToInt16(txtSINAV1.Text);
                s2 = Convert.ToInt16(txtSINAV2.Text);
                s3 = Convert.ToInt16(txtSINAV3.Text);
                p1 = Convert.ToInt16(txtPROJE.Text);
                ort = ((s1 + s2 + s3) / 3) * 0.6 + p1 * 0.4;
                txtORT.Text = ort.ToString("F");

                if (ort >= 50)
                    txtDURUM.Text = "True";
                else
                    txtDURUM.Text = "False";
            }
        }

        private void btnKULUPKAYDET_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCIKULUP klp = new ENTITYOGRENCIKULUP();
            klp.KULUPAD = txtKULUPAD.Text;
            int kaydet = BLLKULUP.EKLE(klp);

            if (kaydet > 0)
                MessageBox.Show(klp.KULUPAD + " başarıyla eklendi");
            else
                MessageBox.Show("Eksik veya hatalı giriş yapıldı");
            KulupListesi();
        }

        private void btnKULUPSIL_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCIKULUP ent = new ENTITYOGRENCIKULUP();
            ent.KULUPID = Convert.ToInt16(txtKULUPID.Text);
            bool sil = BLLKULUP.SIL(ent.KULUPID);

            if (sil)
                MessageBox.Show("Başarıyla silindi");
            else
                MessageBox.Show("Eksik veya hatalı giriş yapıldı");
            KulupListesi();
        }

        private void btnKULUPGUNCELLE_Click(object sender, EventArgs e)
        {
            ENTITYOGRENCIKULUP ent = new ENTITYOGRENCIKULUP();
            ent.KULUPAD = txtKULUPAD.Text;
            ent.KULUPID = Convert.ToInt16(txtKULUPID.Text);
            bool guncelle = BLLKULUP.GUNCELLE(ent);

            if (guncelle)
                MessageBox.Show("Başarıyla güncellendi");
            else
                MessageBox.Show("Eksik veya hatalı giriş yapıldı");
            KulupListesi();
        }

        private void btnKULUPLISTELE_Click(object sender, EventArgs e)
        {
            KulupListesi();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MetroSet_UI.Forms;
using System.IO;
using Tulpep.NotificationWindow;
using LiveCharts.Wpf;
using LiveCharts;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroSetForm
    {
        public static string veritabaniyolu = "Data source=Database/veritabani.db";
        public static SQLiteConnection baglanti = new SQLiteConnection(veritabaniyolu);
        public Form1()
        {
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(3000);
            InitializeComponent();
            //t.Abort();
            string dosya_yolu = "metin.txt";
            StreamReader sr = new StreamReader(dosya_yolu);                                   //Bu kod bloğu anasayfadaki notlar kısmını metin belgesinden okuyarak yazıları yerleştirir.                      
            not_text.Text = sr.ReadToEnd();
            sr.Close();

        }
        public void Uyari(string mesaj, string mesaj2 = "")
        {
            msgbox msg = new msgbox();
            msg.hatauyarisi(mesaj, mesaj2);
        }
        private void Form1_Load(object sender, EventArgs e)                     //uygulama acılırken calısan kod blogu.
        {

            baglanti.Open();
            satilacak_urunler.AllowUserToAddRows = false;
            string sql_urun_bilgi_getir = "SELECT * FROM Urunler";                          //Bu kod bloğu Ürünler tablosuna verileri veritabanından çekerek yerleştirir. 
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql_urun_bilgi_getir, baglanti);
            DataTable dturunler = new DataTable();
            da.Fill(dturunler);
            tablo_urunler.DataSource = dturunler;
            DatadridviewSetting(tablo_urunler);
            DatadridviewSetting(satilacak_urunler);
            //satilacak_urunler.Rows[0].Selected = true;
            satilacak_urunler.AllowUserToAddRows = false;


            string sql_urun_bilgi_getir2 = "SELECT * FROM Urunler";                             //Bu kod bloğu Ürünler tablosuna verileri veritabanından çekerek yerleştirir. 
            SQLiteDataAdapter da2 = new SQLiteDataAdapter(sql_urun_bilgi_getir2, baglanti);
            DataTable dturunler2 = new DataTable();
            da2.Fill(dturunler2);
            tbl2_urunler.DataSource = dturunler2;
            DatadridviewSetting(tbl2_urunler);

            string sql_urun3_bilgi_getir2 = "SELECT * FROM Urunler";                            //Bu kod bloğu Ürünler tablosuna verileri veritabanından çekerek yerleştirir. 
            SQLiteDataAdapter da9 = new SQLiteDataAdapter(sql_urun3_bilgi_getir2, baglanti);
            DataTable dturunler5 = new DataTable();
            da9.Fill(dturunler5);
            table_urunler_3.DataSource = dturunler5;
            DatadridviewSetting(table_urunler_3);

            string sql_ted_bilgi_getir = "SELECT * FROM Tedarikciler";                         //Bu kod bloğu Tedarikçiler tablosuna verileri veritabanından çekerek yerleştirir. 
            SQLiteDataAdapter da_t = new SQLiteDataAdapter(sql_ted_bilgi_getir, baglanti);
            DataTable dt_ted = new DataTable();
            da_t.Fill(dt_ted);
            tablo_tedarikciler.DataSource = dt_ted;
            DatadridviewSetting(tablo_tedarikciler);

            string sql_tedler_bilgi_getir = "SELECT TedID,TedarikciIsmi,SorumluKisi FROM Tedarikciler";   //Bu kod bloğu Tedarikçiler tablosuna verileri veritabanından çekerek yerleştirir. 
            SQLiteDataAdapter da_ted = new SQLiteDataAdapter(sql_tedler_bilgi_getir, baglanti);
            DataTable dt_tedler = new DataTable();
            da_ted.Fill(dt_tedler);
            table_tedler_2.DataSource = dt_tedler;
            DatadridviewSetting(table_tedler_2);

            string sql_must_bilgi_getir = "SELECT * FROM Musteriler";                         //Bu kod bloğu Müşteriler tablosuna verileri veritabanından çekerek yerleştirir.  
            SQLiteDataAdapter da_m = new SQLiteDataAdapter(sql_must_bilgi_getir, baglanti);
            DataTable dt_must = new DataTable();
            da_m.Fill(dt_must);
            tablo_musteriler.DataSource = dt_must;
            DatadridviewSetting(tablo_musteriler);

            string sql_must_bilgi_getir2 = "SELECT * FROM Musteriler";                         //Bu kod bloğu Müşteriler2 tablosuna verileri veritabanından çekerek yerleştirir.  
            SQLiteDataAdapter da_m2 = new SQLiteDataAdapter(sql_must_bilgi_getir2, baglanti);
            DataTable dt_must2 = new DataTable();
            da_m2.Fill(dt_must2);
            tbl2_musteriler.DataSource = dt_must2;
            DatadridviewSetting(tbl2_musteriler);

            string sql_alis_bilgi_getir = "SELECT * FROM Alislar";                         //Bu kod bloğu Alışlar tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da_a = new SQLiteDataAdapter(sql_alis_bilgi_getir, baglanti);
            DataTable dt_alis = new DataTable();
            da_a.Fill(dt_alis);
            table_alislar.DataSource = dt_alis;
            DatadridviewSetting(table_alislar);

            string sql_satis_bilgi_getir = "SELECT * FROM Satislar";                         //Bu kod bloğu Satışlar tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da_s = new SQLiteDataAdapter(sql_satis_bilgi_getir, baglanti);
            DataTable dt_satis = new DataTable();
            da_s.Fill(dt_satis);
            table_satislar.DataSource = dt_satis;
            DatadridviewSetting(table_satislar);

            string sql_azalan_bilgi_getir = "SELECT * FROM Urunler where ToplamUrunAdedi<=10";       //Bu kod bloğu Ürünler tablosunda adedi 10dan az olan ürünleri tabloya getirir.
            SQLiteDataAdapter da_azalan = new SQLiteDataAdapter(sql_azalan_bilgi_getir, baglanti);
            DataTable dt_azalan = new DataTable();
            da_azalan.Fill(dt_azalan);
            tbl_azalan_stok.DataSource = dt_azalan;
            DatadridviewSetting(tbl_azalan_stok);

            DatadridviewSetting(table_ciro_satislar);
            DatadridviewSetting(table_ciro_alislar);

            if (tbl_azalan_stok.RowCount > 1)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.warning__1_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);                                  //10dan az ürün varsa program acılırken sag altta kırmızı uyarı şekilde bir uyarı verir.
                popup.BodyColor = System.Drawing.Color.FromArgb(255, 48, 48);
                popup.TitleText = "Önemli Uyarı!";
                popup.ContentText = "\n Bazı ürünlerinizin stoğu azalmaktadır.Lütfen ana sayfadan kontrol ediniz.";
                popup.Popup();

            }
            try
            {
                DateTime bugun = DateTime.Today;
                string ay = bugun.ToString("MM");
                string yil = bugun.ToString("yyyy");
                string sql_tarih_sorgula = $"SELECT UrunAdi,SUM(UrunAdedi)as UrunAdedi,UrunSatisFiyati FROM Satislar INNER JOIN Urunler on Satislar.UrunID = Urunler.UrunID where SatisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31' GROUP BY UrunAdi";

                SQLiteDataAdapter dagraf = new SQLiteDataAdapter(sql_tarih_sorgula, baglanti);
                DataTable dtgraf = new DataTable();
                dagraf.Fill(dtgraf);
                dataGridView1.DataSource = dtgraf;
                dataGridView1.AllowUserToAddRows = false;
                if (dataGridView1.RowCount > 0)
                {
                    button4.Visible = false;
                }
                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                SeriesCollection piechartData = new SeriesCollection();
                var collection = dataGridView1.Rows.Cast<DataGridViewRow>().GroupBy(x => x.Cells[1].Value).Where(g => g.Count() > 0).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    piechartData.Add(new PieSeries { Title = Convert.ToString(item.Cells["UrunAdi"].Value), Values = new ChartValues<double> { Convert.ToDouble(item.Cells["UrunAdedi"].Value) }, DataLabels = true, LabelPoint = labelPoint });
                }



                pieChart1.Series = piechartData;
                pieChart1.LegendLocation = LegendLocation.Right;

            }
            catch
            {
                button4.Visible = true;
            }

            baglanti.Close();
            metroSetTabControl1.SelectedIndex = 0;
        }

        private void DatadridviewSetting(DataGridView datagridview)                           //Bu fonksiyon Ürünler tablosunu kişiselleştirmeye renklerini vs ayarlamaya yarar
        {
            datagridview.RowHeadersVisible = false;
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50,50,50); //50
            datagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65,65,65); //65
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            datagridview.EnableHeadersVisualStyles = false;
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40,40,40);  //40
            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void a_btn_temizle_Click(object sender, EventArgs e)            //Bu kısımda textboxların içlerini boşalttık.
        {
            txt_2_u_alis_f.Text = String.Empty;
            txt_2_t_ad.Text = String.Empty;
            a_urun_id.Text = String.Empty;
            txt_2_u_adet.Text = String.Empty;
            txt_2_u_alis_f.Text = String.Empty;


        }

        private void StartForm()                                    //form acılırken splashscreen calısıyor
        {
            Application.Run(new splashscreen());

        }

        private void notu_kaydet_Click(object sender, EventArgs e)                  //burada anasayfadaki not kısmına yazılan bilgiler metin.txt dosyasına aktarılıyor.
        {
            string dosya_yolu = "metin.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(not_text.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.checked__2_;
            popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);              //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
            popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);
            popup.TitleText = "İşlem Başarılı";
            popup.ContentText = "\n Notunuz başarıyla kaydedilmiştir.";
            popup.Popup();


        }

        private void notu_temizle_Click(object sender, EventArgs e)             //bu kısımda anasayfadaki not kısmında temizleme işlemleri metin.txt dosyasında yapılıyor.
        {
            DialogResult dialogResult = MessageBox.Show("Notunuzu temizlemek istediğinizden emin misiniz? Temizlerseniz yazdıklarınıza erişemeyeceksiniz", "Emin Misiniz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string dosya_yolu = "metin.txt";
                TextWriter tw = new StreamWriter(dosya_yolu);
                tw.Write("");
                tw.Close();
                not_text.Text = String.Empty;


            }
        }

        private void txt_box_mst_ara_TextChanged(object sender, EventArgs e)        //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık
        {
            if (mst_tc_radio.Checked == true)
            {
                (tablo_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusteriTc LIKE '{0}%'", txt_box_mst_ara.Text);
            }
            else if (mst_ad_radio.Checked == true)
            {
                (tablo_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Isim LIKE '{0}%'", txt_box_mst_ara.Text);
            }
            else {
                mst_tc_radio.Checked=true;
                (tablo_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusteriTc LIKE '{0}%'", txt_box_mst_ara.Text);

            }
        }

        private void txt_box_urun_ara_TextChanged(object sender, EventArgs e)     //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık
        {

           
            if (radio_urun_ad.Checked == true)
            {
                (tablo_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", txt_box_urun_ara.Text);
            }
            else if (radio_urun_id.Checked == true)
            {
                (tablo_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(UrunID, System.String) LIKE '{0}%'", txt_box_urun_ara.Text);
            }
            else
            {
                radio_urun_ad.Checked = true;
                (tablo_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", txt_box_urun_ara.Text);

            }
        }

        private void btn_urun_gnclle_Click(object sender, EventArgs e)              //tablodan seçili olan ürünün bilgileri textboxlara doluyor.
        {
            if (tablo_urunler.SelectedRows.Count > 0)
            {
                string urunId = tablo_urunler.SelectedRows[0].Cells[0].Value + string.Empty;
                string veritabaniyolu2 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);
                btn_urun_sil.Visible = true;
                baglanti2.Open();
                string sql_m_sorgula = $"SELECT * FROM Urunler WHERE UrunID='{urunId}'";                                //gerekli sql kodları veritabanında calıstırılıyor.
                SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti2);
                cmd_m_sorgula.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                da.Fill(dt);
                SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                if (dr.Read())
                {
                    urun_adi_gnclle.Text = dr["UrunAdi"].ToString();
                    urun_adedi_gnclle.Text = dr["ToplamUrunAdedi"].ToString();
                    urun_id__.Text = dr["UrunID"].ToString();                                       //bilgiler textboxlara getiriliyor.
                    urun_fiyati_gnclle.Text = dr["SatisFiyati"].ToString();
                    urun_adedi_gnclle.ReadOnly = false;
                    urun_adi_gnclle.ReadOnly = false;
                    urun_fiyati_gnclle.ReadOnly = false;
                }
                dr.Close();
                baglanti2.Close();



            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void tablolariGuncelle()             //Bu fonksiyon herhangi veritabanı ile ilgili bir işlem yapıldıgında programdaki tüm datagridview'leri güncelleyen bir fonksiyondur.
        {
            string veritabaniyolu2 = "Data source=Database/veritabani.db";                  //burada veritabanına baglanıyoruz
            SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);
            baglanti2.Open();

            string sql_urun_bilgi_getir = "SELECT * FROM Urunler";                              //Bu kod bloğu Urunler tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql_urun_bilgi_getir, baglanti);
            DataTable dturunler = new DataTable();
            da.Fill(dturunler);
            tablo_urunler.DataSource = dturunler;
                                                                                                //Bu kod bloğu Urunler tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da2 = new SQLiteDataAdapter(sql_urun_bilgi_getir, baglanti);
            DataTable dturunler2 = new DataTable();
            da2.Fill(dturunler2);
            tbl2_urunler.DataSource = dturunler2;
                                                                                                 //Bu kod bloğu Urunler tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da9 = new SQLiteDataAdapter(sql_urun_bilgi_getir, baglanti);
            DataTable dturunler5 = new DataTable();
            da9.Fill(dturunler5);
            table_urunler_3.DataSource = dturunler5;

            string sql_ted_bilgi_getir = "SELECT * FROM Tedarikciler";                               //Bu kod bloğu Tedarikciler tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da_t = new SQLiteDataAdapter(sql_ted_bilgi_getir, baglanti);
            DataTable dt_ted = new DataTable();
            da_t.Fill(dt_ted);
            tablo_tedarikciler.DataSource = dt_ted;

            string sql_tedler_bilgi_getir = "SELECT TedID,TedarikciIsmi,SorumluKisi FROM Tedarikciler";        //Bu kod bloğu Tedarikciler tablosuna verileri veritabanından çekerek yerleştirir.    
            SQLiteDataAdapter da_ted = new SQLiteDataAdapter(sql_tedler_bilgi_getir, baglanti);
            DataTable dt_tedler = new DataTable();
            da_ted.Fill(dt_tedler);
            table_tedler_2.DataSource = dt_tedler;

            string sql_must_bilgi_getir = "SELECT * FROM Musteriler";                         //Bu kod bloğu Müşteriler tablosuna verileri veritabanından çekerek yerleştirir.  
            SQLiteDataAdapter da_m = new SQLiteDataAdapter(sql_must_bilgi_getir, baglanti);
            DataTable dt_must = new DataTable();
            da_m.Fill(dt_must);
            tablo_musteriler.DataSource = dt_must;
                                                                                               //Bu kod bloğu Müşteriler tablosuna verileri veritabanından çekerek yerleştirir.  
            SQLiteDataAdapter da_m2 = new SQLiteDataAdapter(sql_must_bilgi_getir, baglanti);
            DataTable dt_must2 = new DataTable();
            da_m2.Fill(dt_must2);
            tbl2_musteriler.DataSource = dt_must2;

            string sql_alis_bilgi_getir = "SELECT * FROM Alislar";                         //Bu kod bloğu Alışlar tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da_a = new SQLiteDataAdapter(sql_alis_bilgi_getir, baglanti);
            DataTable dt_alis = new DataTable();
            da_a.Fill(dt_alis);
            table_alislar.DataSource = dt_alis;

            string sql_satis_bilgi_getir = "SELECT * FROM Satislar";                         //Bu kod bloğu Satışlar tablosuna verileri veritabanından çekerek yerleştirir.
            SQLiteDataAdapter da_s = new SQLiteDataAdapter(sql_satis_bilgi_getir, baglanti);
            DataTable dt_satis = new DataTable();
            da_s.Fill(dt_satis);
            table_satislar.DataSource = dt_satis;

            string sql_azalan_bilgi_getir = "SELECT * FROM Urunler where ToplamUrunAdedi<=10";       //Bu kod bloğu Ürünler tablosunda adedi 10dan az olan ürünleri tabloya getirir.
            SQLiteDataAdapter da_azalan = new SQLiteDataAdapter(sql_azalan_bilgi_getir, baglanti);
            DataTable dt_azalan = new DataTable();
            da_azalan.Fill(dt_azalan);
            tbl_azalan_stok.DataSource = dt_azalan;

            try
            {
                DateTime bugun = DateTime.Today;
                string ay = bugun.ToString("MM");
                string yil = bugun.ToString("yyyy");
                string sql_tarih_sorgula = $"SELECT UrunAdi,SUM(UrunAdedi)as UrunAdedi,UrunSatisFiyati FROM Satislar INNER JOIN Urunler on Satislar.UrunID = Urunler.UrunID where SatisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31' GROUP BY UrunAdi";

                SQLiteDataAdapter dagraf = new SQLiteDataAdapter(sql_tarih_sorgula, baglanti);
                DataTable dtgraf = new DataTable();
                dagraf.Fill(dtgraf);
                dataGridView1.DataSource = dtgraf;
                dataGridView1.AllowUserToAddRows = false;
                if (dataGridView1.RowCount > 0)
                {
                    button4.Visible = false;
                }
                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                SeriesCollection piechartData = new SeriesCollection();
                var collection = dataGridView1.Rows.Cast<DataGridViewRow>().GroupBy(x => x.Cells[1].Value).Where(g => g.Count() > 0).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    piechartData.Add(new PieSeries { Title = Convert.ToString(item.Cells["UrunAdi"].Value), Values = new ChartValues<double> { Convert.ToDouble(item.Cells["UrunAdedi"].Value) }, DataLabels = true, LabelPoint = labelPoint });
                }
                


                pieChart1.Series = piechartData;
                pieChart1.LegendLocation = LegendLocation.Right;

            }
            catch
            {
                button4.Visible = true;
            }




            baglanti2.Close();
        }
        
        private void btn_u_gnclle_Click(object sender, EventArgs e)         //bilgileri getirilmiş ürünün güncelleme işlemleri yapılıyor bu kısımda.
        {
            if (urun_adi_gnclle.Text == "" || urun_adedi_gnclle.Text == "")
            {

                MessageBox.Show("Lütfen bir ürün seçip bilgilerini getirdikten sonra güncelleme işlemi yapınız", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string veritabaniyolu2 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);
                string sql_m_sorgula = $"UPDATE  Urunler set UrunAdi='{urun_adi_gnclle.Text}',ToplamUrunAdedi='{urun_adedi_gnclle.Text}',SatisFiyati='{urun_fiyati_gnclle.Text}' WHERE UrunID='{urun_id__.Text}'";
                SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti2);
                baglanti2.Open();
                cmd_m_sorgula.ExecuteNonQuery();

                urun_adi_gnclle.Text = String.Empty;
                urun_adedi_gnclle.Text = String.Empty;
                urun_id__.Text = String.Empty;  
                urun_fiyati_gnclle.Text = String.Empty;                             //Bu kısımda textboxların içlerini boşalttık.
                urun_adi_gnclle.ReadOnly = true;    
                urun_adedi_gnclle.ReadOnly = true;
                urun_fiyati_gnclle.ReadOnly = true;
                btn_urun_sil.Visible = false;

                baglanti2.Close();
                tablolariGuncelle();

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);          //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Ürün başarıyla güncellenmiştir.";
                popup.Popup();

            }
        }

        private void btn_must_gnclle_Click(object sender, EventArgs e)          //müşteri bilgileri textboxlara getiriliyor bu kısımda.
        {
            

            if (tablo_musteriler.SelectedRows.Count > 0)
            {
                string mtcara = tablo_musteriler.SelectedRows[0].Cells[0].Value + string.Empty;
                if (mtcara == "")
                {
                    MessageBox.Show("Lütfen bir müşteri seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btn_must_sil.Visible = true;
                    m_tc.ReadOnly = true;
                    m_bilgi_guncelle.Visible = true;

                    baglanti.Open();
                    string sql_m_sorgula = $"SELECT * FROM Musteriler WHERE MusteriTC='{mtcara}'";
                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);               //veritabanından bilgiler sorgulanıp getiriliyor.
                    cmd_m_sorgula.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);
                    SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                    if (dr.Read())
                    {
                        m_tc.Text = dr["MusteriTC"].ToString();
                        m_ad.Text = dr["Isim"].ToString();
                        m_soyad.Text = dr["SoyIsim"].ToString();            //veriler textboxlara geliyor
                        m_tel.Text = dr["Telefon"].ToString();
                        m_mail.Text = dr["Eposta"].ToString();
                        m_adres.Text = dr["Adres"].ToString();

                    }
                    da.Dispose();
                    dt.Dispose();
                    dr.Close();

                    baglanti.Close();
                }



            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void m_btn_ekle_Click_1(object sender, EventArgs e)                 //bu kısımda müşteri ekledğimiz fonksiyon calısıyor
        {
            if (m_tc.Text == "" || m_ad.Text == "" || m_soyad.Text == "" || m_tel.Text == "" || m_mail.Text == "" || m_adres.Text == "") // kullanıcı boş textbox bırakırsa program uyarı veriyor
            {
                MessageBox.Show("Lütfen Gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (m_tc.Text.Length < 11)                             //TC textbox'ına 11den az hane girerse uyarı veriyor program
            {   
                MessageBox.Show("TC kimlik numarası 11 haneden küçük olamaz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                    
                    string veritabaniyolu2 = "Data source=Database/veritabani.db";
                    SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);                 //veritabanına baglanıyoruz bu kısımda
                    baglanti2.Open();

                    string sql_m_sorgula = $"SELECT * FROM Musteriler WHERE MusteriTC='{m_tc.Text}'";
                    string sql_m_ekle = $"INSERT INTO Musteriler (MusteriTC,Isim,SoyIsim,Telefon,Eposta,Adres) VALUES ('{m_tc.Text}','{m_ad.Text}','{m_soyad.Text}','{m_tel.Text}','{m_mail.Text}','{m_adres.Text}')";

                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti2);
                    cmd_m_sorgula.ExecuteNonQuery();                        //veritabanı ile ilgili aynı tcye sahip bir müşterinin olup olmadıgı sorgusu calısıyor

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)                                          //eğer aynı TC numarasına sahip bir müşteri varsa bu uyarıyı veriyor
                    {   
                        MessageBox.Show("Kaydetmeye çalıştığınız TC numarasına ait bir müşteri veritabanında zaten bulunmaktadır.");
                    }
                    else
                    {
                        SQLiteCommand cmd_m_ekle = new SQLiteCommand(sql_m_ekle, baglanti2);
                        cmd_m_ekle.ExecuteNonQuery();

                        m_tc.Text = String.Empty;
                        m_ad.Text = String.Empty;
                        m_soyad.Text = String.Empty;
                        m_tel.Text = String.Empty;                                      //Bu kısımda textboxların içlerini boşalttık.
                        m_mail.Text = String.Empty;
                        m_adres.Text = String.Empty;

                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.checked__2_;
                        popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);              //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                        popup.TitleText = "İşlem Başarılı";
                        popup.ContentText = "\n Müşteri başarıyla eklenmiştir";
                        popup.Popup();
                        baglanti2.Close();
                        cmd_m_ekle.Dispose();
                        tablolariGuncelle();
                    }
               
            }
        }

        private void m_btn_temizle_Click(object sender, EventArgs e)                //Bu kısımda textboxların içlerini boşalttık.
        {
            m_tc.Text = String.Empty;
            m_ad.Text = String.Empty;
            m_soyad.Text = String.Empty;
            m_tel.Text = String.Empty;
            m_mail.Text = String.Empty;
            btn_must_sil.Visible = false;
            m_adres.Text = String.Empty;
            m_bilgi_guncelle.Visible = false;
            m_tc.ReadOnly = false;
            m_btn_ekle.Visible = true;
            btn_must_sil.Visible = false;
        }

        private void m_bilgi_guncelle_Click_1(object sender, EventArgs e)           //burada müşteri bilgileri güncelle butonunun calıstırdıgı fonksiyon bulunuyor.
        {
            //MÜŞTERİ BİLGİLERİ GÜNCELLEME
            if (m_tc.Text == "" || m_ad.Text == "" || m_soyad.Text == "" || m_tel.Text == "" || m_mail.Text == "" || m_adres.Text == "")
            {
                MessageBox.Show("Güncelleme işlemi için lütfen gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                //MÜŞTERİ BİLGİLERİNİ GÜNCELLEME
                string sql_m_guncelle = $"UPDATE Musteriler SET Isim='{m_ad.Text}', SoyIsim='{m_soyad.Text}', Telefon='{m_tel.Text}', Eposta='{m_mail.Text}', Adres='{m_adres.Text}' WHERE MusteriTC='{m_tc.Text}'";
                baglanti.Open();
                SQLiteCommand cmd_m_guncelle = new SQLiteCommand(sql_m_guncelle, baglanti);
                cmd_m_guncelle.ExecuteNonQuery();

                baglanti.Close();
                tablolariGuncelle();
                
                m_btn_ekle.Visible = true;
                m_bilgi_guncelle.Visible = false;
                m_tc.Text = String.Empty;
                m_ad.Text = String.Empty;
                m_soyad.Text = String.Empty;                                        //Bu kısımda textboxların içlerini boşalttık.
                m_tel.Text = String.Empty;
                m_mail.Text = String.Empty;
                m_adres.Text = String.Empty;
                m_tc.ReadOnly = false;
                btn_must_sil.Visible = false;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);          //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Müşteri başarıyla güncellenmiştir";
                popup.Popup();

            }
        }

        private void btn_must_sil_Click_1(object sender, EventArgs e)               //burada müşteri silme fonksiyonumuz calısıyor
        {
            baglanti.Open();
            string sql_m_sorgula = $"SELECT * FROM Satislar WHERE MusteriTC='{m_tc.Text}'";
            SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);
            cmd_m_sorgula.ExecuteNonQuery();

            DataTable dt3 = new DataTable();
            SQLiteDataAdapter da5 = new SQLiteDataAdapter(cmd_m_sorgula);
            da5.Fill(dt3);
            DialogResult soru2 = new DialogResult();
            if (dt3.Rows.Count > 0)
            {
                soru2 = MessageBox.Show("Bu müşterinin kayıtlı siparişi olduğu için silme işlemi veri kaybına yol açacaktır.Silmek istediğinize emin misiniz? (Silmeniz ÖNERİLMEZ)", "Müşteri Sil", MessageBoxButtons.YesNo);
                if (soru2 == DialogResult.Yes)
                {
                    string sql_m_sil = $"DELETE FROM Musteriler where MusteriTC='{m_tc.Text}'";
                    string sql_satis_sil = $"DELETE FROM Satislar where MusteriTC='{m_tc.Text}'";
                    SQLiteCommand cmd_m_sil = new SQLiteCommand(sql_m_sil, baglanti);                   //müşterinin satıslar ve müşteri tablosundaki bilgiler sorgulanıp kullanıcı onaylarsa siliniyor.
                    SQLiteCommand cmd_s_sil = new SQLiteCommand(sql_satis_sil, baglanti);
                    cmd_m_sil.ExecuteNonQuery();
                    cmd_s_sil.ExecuteNonQuery();

                    m_tc.Text = String.Empty;
                    m_ad.Text = String.Empty;
                    m_soyad.Text = String.Empty;
                    m_tel.Text = String.Empty;                              //Bu kısımda textboxların içlerini boşalttık.
                    m_mail.Text = String.Empty;
                    m_adres.Text = String.Empty;
                    btn_must_sil.Visible = false;
                    m_bilgi_guncelle.Visible = false;
                    m_tc.ReadOnly = false;

                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.checked__2_;
                    popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                  //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                    popup.TitleText = "İşlem Başarılı";
                    popup.ContentText = "\n Müşteri başarıyla silinmiştir";
                    popup.Popup();


                    string sql_must_bilgi_getir = "SELECT * FROM Musteriler";                         //Bu kod bloğu Müşteriler tablosuna verileri veritabanından çekerek yerleştirir.
                    SQLiteDataAdapter da_m = new SQLiteDataAdapter(sql_must_bilgi_getir, baglanti);
                    DataTable dt_must = new DataTable();
                    da_m.Fill(dt_must);
                    tablo_musteriler.DataSource = dt_must;
                    DatadridviewSetting(tablo_musteriler);
                    string sql_satis_bilgi_getir = "SELECT * FROM Satislar";                         //Bu kod bloğu Satışlar tablosuna verileri veritabanından çekerek yerleştirir.
                    SQLiteDataAdapter da_s3 = new SQLiteDataAdapter(sql_satis_bilgi_getir, baglanti);
                    DataTable dt_satis2 = new DataTable();
                    da_s3.Fill(dt_satis2);
                    table_satislar.DataSource = dt_satis2;
                    DatadridviewSetting(table_satislar);
                }
            }
            else {
                DialogResult soru3 = new DialogResult();
                soru3 = MessageBox.Show("Müşteriyi silmek istediğinizden emin misiniz", "Müşteri Sil", MessageBoxButtons.YesNo);
                if (soru3 == DialogResult.Yes) { 
                    string sql_m2_sil = $"DELETE FROM Musteriler where MusteriTC='{m_tc.Text}'";
                    SQLiteCommand cmd_m2_sil = new SQLiteCommand(sql_m2_sil, baglanti);
                    cmd_m2_sil.ExecuteNonQuery();

                    m_tc.Text = String.Empty;
                    m_ad.Text = String.Empty;
                    m_soyad.Text = String.Empty;
                    m_tel.Text = String.Empty;                                                  //Bu kısımda textboxların içlerini boşalttık.
                    m_mail.Text = String.Empty;
                    m_adres.Text = String.Empty;
                    btn_must_sil.Visible = false;
                    m_bilgi_guncelle.Visible = false;
                    m_tc.ReadOnly = false;


                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.checked__2_;
                    popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                      //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                    popup.TitleText = "İşlem Başarılı";
                    popup.ContentText = "\n Müşteri başarıyla silinmiştir";
                    popup.Popup();
                    string sql_must_bilgi_getir = "SELECT * FROM Musteriler";                         //Bu kod bloğu Müşteriler tablosuna verileri veritabanından çekerek yerleştirir.
                    SQLiteDataAdapter da_m = new SQLiteDataAdapter(sql_must_bilgi_getir, baglanti);
                    DataTable dt_must = new DataTable();
                    da_m.Fill(dt_must);
                    tablo_musteriler.DataSource = dt_must;
                    DatadridviewSetting(tablo_musteriler);
                }
            }

            baglanti.Close();
            tablolariGuncelle();
        }

        private void t_btn_temizle_Click_1(object sender, EventArgs e)          //Bu kısımda textboxların içlerini boşalttık.
        {
            t_isim.Text = String.Empty;
            t_id.Text = String.Empty;
            t_mail.Text = String.Empty;
            t_tel.Text = String.Empty;
            t_srml_kisi.Text = String.Empty;
            t_adres.Text = String.Empty;
            t_sil_bttn.Visible = false;
            bttn_t_gnclle.Visible = false;
        }

        private void txtbox_t_ara_TextChanged(object sender, EventArgs e)          //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık
        {
       
            if (radio_btn_td_ad.Checked == true)
            {
                (tablo_tedarikciler.DataSource as DataTable).DefaultView.RowFilter = string.Format("TedarikciIsmi LIKE '{0}%'", txtbox_t_ara.Text);
            }
            else if (radio_btn_tel.Checked == true)
            {
                (tablo_tedarikciler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(Telefon, System.String) LIKE '{0}%'", txtbox_t_ara.Text);
            }
            else
            {
                radio_btn_td_ad.Checked = true;
                (tablo_tedarikciler.DataSource as DataTable).DefaultView.RowFilter = string.Format("TedarikciIsmi LIKE '{0}%'", txtbox_t_ara.Text);
            }

        }   

        private void btn_tdrk_blg_Getir_Click(object sender, EventArgs e)         //Bu kısımda tabloda seçili olan tedarikçi bilgilerini textboxlara getirdik
        {
            if (tablo_tedarikciler.SelectedRows.Count > 0)
            {
                string mtara = tablo_tedarikciler.SelectedRows[0].Cells[0].Value + string.Empty;
                if (mtara == "")
                {
                    MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    t_sil_bttn.Visible = true;
                    bttn_t_gnclle.Visible = true;
                    baglanti.Open();
                    string sql_m_sorgula = $"SELECT * FROM Tedarikciler WHERE TedID='{mtara}'";
                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);                       //bu kısımda veritabanınba baglanılıp gerekli sorgular çalıstırılıyor.
                    cmd_m_sorgula.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);
                    SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                    if (dr.Read())
                    {
                        t_id.Text = dr["TedID"].ToString();
                        t_isim.Text = dr["TedarikciIsmi"].ToString();
                        t_tel.Text = dr["Telefon"].ToString();              //bilgiler textboxlara getiriliyor
                        t_mail.Text = dr["Mail"].ToString();
                        t_adres.Text = dr["Adres"].ToString();
                        t_srml_kisi.Text = dr["SorumluKisi"].ToString();


                    }
                    da.Dispose();
                    dt.Dispose();
                    dr.Close();

                    baglanti.Close();
                }



            }
            else
            {
                MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bttn_t_gnclle_Click(object sender, EventArgs e)             //bu kısımda tedarikçi güncellediğimiz bölüm calısıyor.
        {
            if (t_isim.Text == "" || t_tel.Text == "" || t_mail.Text == "" || t_adres.Text == "" || t_srml_kisi.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string veritabaniyolu2 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);                     //Bu kısımda veritabanına bağlandık
                baglanti2.Open();

                
                string sql_m_guncelle = $"UPDATE Tedarikciler SET TedarikciIsmi='{t_isim.Text}', Telefon='{t_tel.Text}', Mail='{t_mail.Text}', Adres='{t_adres.Text}',SorumluKisi='{t_srml_kisi.Text}' WHERE TedID='{t_id.Text}'";
                SQLiteCommand cmd_m_guncelle = new SQLiteCommand(sql_m_guncelle, baglanti2);
                cmd_m_guncelle.ExecuteNonQuery();

                baglanti2.Close();
                tablolariGuncelle();

                bttn_t_gnclle.Visible = false;
                t_sil_bttn.Visible = false;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                      //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Tedarikçi başarıyla güncellenmiştir.";
                popup.Popup();

                t_tel.Text = String.Empty;
                t_isim.Text = String.Empty;
                t_mail.Text = String.Empty;                                                         //Bu kısımda textboxların içlerini boşalttık.
                t_srml_kisi.Text = String.Empty;
                t_adres.Text = String.Empty;
                t_id.Text = String.Empty;
                
            }
        }

        private void t_sil_bttn_Click(object sender, EventArgs e)        //tedarikçi sildiğimiz kısım çalışıyor.
        {
            baglanti.Open();
            DialogResult soru = new DialogResult();
            soru = MessageBox.Show("Tedarikçi veritabanından silinirse VERİ KAYBINA YOL AÇACAKTIR.Tedarikçiyi silmek istediğinize emin misiniz? (SİLMENİZ ÖNERİLMEZ)", "Tedarikçi Sil", MessageBoxButtons.YesNo);
            if (soru == DialogResult.Yes)
            {
                string sql_m_sil = $"DELETE FROM Tedarikciler where TedID='{t_id.Text}'";
                string sql_t_sil = $"DELETE FROM Alislar where TedarikciIsmi='{t_isim.Text}'";          //tedarikçinin baglantısı olan alış işlemleri siliniyor.
                SQLiteCommand cmd_m_sil = new SQLiteCommand(sql_m_sil, baglanti);   
                SQLiteCommand cmd_t_sil = new SQLiteCommand(sql_t_sil, baglanti);
                cmd_m_sil.ExecuteNonQuery();
                cmd_t_sil.ExecuteNonQuery();

                t_isim.Text = String.Empty;
                t_id.Text = String.Empty;
                t_mail.Text = String.Empty;
                t_tel.Text = String.Empty;
                t_srml_kisi.Text = String.Empty;                                                        //Bu kısımda textboxların içlerini boşalttık.
                t_adres.Text = String.Empty;
                bttn_t_gnclle.Visible = false;
                t_sil_bttn.Visible = false;


                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);                            //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Tedarikçi başarıyla silinmiştir.";
                popup.Popup();
            }
           
            baglanti.Close();
            tablolariGuncelle();

        }

        private void button1_Click(object sender, EventArgs e)              //burada tedarikçi eklediğimiz fonksiyon çalısıyor.
        {
            if (t_isim.Text == "" || t_mail.Text == "" || t_tel.Text == "" || t_adres.Text == "" || t_srml_kisi.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string veritabaniyolu2 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);         //veritabanına bağlanıyoruz
                baglanti2.Open();

                string sql_ted_sorgula = $"SELECT * FROM Tedarikciler WHERE TedarikciIsmi='{t_isim.Text}'";
                SQLiteCommand cmd_ted_sorgula = new SQLiteCommand(sql_ted_sorgula, baglanti2);
                cmd_ted_sorgula.ExecuteNonQuery();                                                      //veritabanı ile ilgili işlemler yapılıyor.Eğer aynı tedarikçi isminde biri varsa program uyarı veriyor.
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_ted_sorgula);
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Kaydetmeye çalıştığınız tedarikçi isminde bir başka tedarikçi zaten veritabanında kayıtlıdır.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

                else { 
                string sql_m_ekle = $"INSERT INTO Tedarikciler (TedarikciIsmi,Mail,Telefon,Adres,SorumluKisi) VALUES ('{t_isim.Text}','{t_mail.Text}','{t_tel.Text}','{t_adres.Text}','{t_srml_kisi.Text}')";
                SQLiteCommand cmd_m_ekle = new SQLiteCommand(sql_m_ekle, baglanti2);
                cmd_m_ekle.ExecuteNonQuery();

                
                t_isim.Text = String.Empty;
                t_id.Text = String.Empty;
                t_mail.Text = String.Empty;                                                     //Bu kısımda textboxların içlerini boşalttık.
                t_srml_kisi.Text = String.Empty;
                t_tel.Text = String.Empty;
                t_adres.Text = String.Empty;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);                          //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Tedarikçi başarıyla eklenmiştir.";
                popup.Popup();
                
                
                baglanti2.Close();
                cmd_m_ekle.Dispose();
                tablolariGuncelle();

                }

            }
        }

        private void txt_urun_ara2_TextChanged(object sender, EventArgs e)          //Bu kısımda textboxa girilen harfe göre tablodan filtreleme işlemi yapılıyor
        {
            if (radio_btn_urun_isim.Checked == true)
            {
                (tbl2_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", txt_urun_ara2.Text);
            }
            else if (radio_btn_id.Checked == true)
            {
                (tbl2_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(UrunID, System.String) LIKE '{0}%'", txt_urun_ara2.Text);
            }
            else
            {
                radio_btn_urun_isim.Checked = true;
                (tbl2_urunler.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", txt_urun_ara2.Text);
            }
        }

        private void txt_must_ara2_TextChanged(object sender, EventArgs e)          //Bu kısımda textboxa girilen harfe göre tablodan filtreleme işlemi yapılıyor
        {
            
            if (radio_tc_satis.Checked == true)
            {
                (tbl2_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusteriTC LIKE '{0}%'", txt_must_ara2.Text);
            }
            else if (radio_isim_satis.Checked == true)
            {
                (tbl2_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Isim LIKE '{0}%'", txt_must_ara2.Text);
            }
            else
            {
                radio_isim_satis.Checked = true;
                (tbl2_musteriler.DataSource as DataTable).DefaultView.RowFilter = string.Format("Isim LIKE '{0}%'", txt_must_ara2.Text);
            }
        }

        private void btn_change_tab_Click(object sender, EventArgs e)           //bu kısımda müşteri işlemleri sekmesi acılıyor.
        {
            metroSetTabControl1.SelectedIndex = 4;
        }

        private void satis_urun_bilgi_getir_Click(object sender, EventArgs e)       //Bu kısımda tabloda seçili olan ürün bilgilerini textboxlara getirdik
        {
            if (tbl2_urunler.SelectedRows.Count > 0)
            {
                string urunId = tbl2_urunler.SelectedRows[0].Cells[0].Value + string.Empty;
                if (urunId == "")
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToInt32(tbl2_urunler.SelectedRows[0].Cells[2].Value) == 0) 
                {
                    Uyari("Seçtiğiniz ürünün stoğu kalmamıştır");
                }
                else
                {
                    string id = tbl2_urunler.SelectedRows[0].Cells[0].Value + string.Empty;
                    string ad = tbl2_urunler.SelectedRows[0].Cells[1].Value + string.Empty;
                    string fiyat = tbl2_urunler.SelectedRows[0].Cells[3].Value + string.Empty;



                    int numRows = satilacak_urunler.Rows.Count;



                    if (numRows == 0)
                    {
                        satilacak_urunler.Rows.Add(id, ad, 1, fiyat);
                    }
                    else
                    {
                        bool check = true;
                        string[] liste = new string[numRows];
                        for (int i = 0; i < numRows; ++i)
                        {
                            liste[i] = satilacak_urunler.Rows[i].Cells[0].Value.ToString();
                        }

                        foreach (string a in liste)
                        {
                            if (a == id)
                            {
                                MessageBox.Show("Eklemeye çalıştığınız ürün zaten siparişlerde bulunmaktadır.Adeti arttırmak istiyorsanız lütfen Arttır butonuna basınız", "Hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                check = false;
                                break;
                            }
                        }
                        if (check == true)
                        {
                            satilacak_urunler.Rows.Add(id, ad, 1, fiyat);
                        }

                    }



                }

                        
                
                    
            }
        }
            
        

        private void m_bilgi_getir3_Click(object sender, EventArgs e)           //Bu kısımda tabloda seçili olan müşteri bilgilerini textboxlara getirdik
        {
            if (tbl2_musteriler.SelectedRows.Count > 0)
            {
                string mtcara = tbl2_musteriler.SelectedRows[0].Cells[0].Value + string.Empty;
                if (mtcara == "")
                {
                    MessageBox.Show("Lütfen bir müşteri seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    satis_m_tc.Text = tbl2_musteriler.CurrentRow.Cells[0].Value.ToString();
                   
                    satis_m_adres.Text = tbl2_musteriler.CurrentRow.Cells[5].Value.ToString();

                }

            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void satis_siparis_adedi_TextChanged(object sender, EventArgs e)  //Bu kısımda textboxların içlerine sadece rakamsal ifade girmesini ve iki textboxın verilerine göre satış fiyatı label'ını ayarladık.
        {
            /*if (System.Text.RegularExpressions.Regex.IsMatch(satis_siparis_adedi.Text, "[^0-9]"))
            {
                satis_siparis_adedi.Text = satis_siparis_adedi.Text.Remove(satis_siparis_adedi.Text.Length - 1);
            }
            else
            {
                try
                {
                    if (satis_siparis_adedi.Text == "")
                    {
                        metroSetLabel39.Text = "";
                    }
                    else
                    {
                        //int adet = Convert.ToInt32(satis_siparis_adedi.Text);
                        //int fiyat = Convert.ToInt32(satis_urun_fiyat.Text);
                        int sonuc = adet * fiyat;
                        metroSetLabel39.Text = Convert.ToString(sonuc) + " ₺";
                    }
                }
                catch
                {
                }

            }*/
        }

        private void satis_urun_fiyat_TextChanged(object sender, EventArgs e)   //Bu kısımda textboxların içlerine sadece rakamsal ifade girmesini ve iki textboxın verilerine göre satış fiyatı label'ını ayarladık.
        {
            /*if (System.Text.RegularExpressions.Regex.IsMatch(satis_urun_fiyat.Text, "[^0-9]"))
            {
                satis_urun_fiyat.Text = satis_urun_fiyat.Text.Remove(satis_urun_fiyat.Text.Length - 1);
            }
            else
            {
                try
                {
                    if (satis_urun_fiyat.Text == "")
                    {
                        metroSetLabel39.Text = "";
                    }
                    else
                    {
                        int adet = Convert.ToInt32(satis_siparis_adedi.Text);
                        int fiyat = Convert.ToInt32(satis_urun_fiyat.Text);
                        int sonuc = adet * fiyat;
                        metroSetLabel39.Text = Convert.ToString(sonuc) + " ₺";
                    }
                }
                catch
                {
                }

            }*/
        }

        private void urunislemleri_tmzle_Click(object sender, EventArgs e)                  //Bu kısımda textboxların içlerini boşalttık.
        {
            urun_adi_gnclle.Text = String.Empty;
            urun_adedi_gnclle.Text = String.Empty;
            urun_id__.Text = String.Empty;
            urun_fiyati_gnclle.Text = String.Empty;
            urun_adedi_gnclle.ReadOnly = true;
            urun_adi_gnclle.ReadOnly = true;
            urun_fiyati_gnclle.ReadOnly = true;
            btn_urun_sil.Visible = false;
        }

        private void satis_temizle_Click(object sender, EventArgs e)                    //Bu kısımda textboxların içlerini boşalttık.
        {
            satis_m_tc.Text = String.Empty;
            satis_fatura_no.Text = String.Empty;
            satis_m_adres.Text = String.Empty;
            satilacak_urunler.Rows.Clear();
        }

        private void txtbox_azalan_urun_ara_TextChanged(object sender, EventArgs e)             //Bu kısımda textboxa girilen harfe göre filtreleme işlemi yaptık
        {
            (tbl_azalan_stok.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", txtbox_azalan_urun_ara.Text);
        }

        private void satis_bilgi_Getir_Click(object sender, EventArgs e)                    //Bu kısımda tablodan seçili olan satırın bilgilerini getirdiğimiz fonksiyon calıstı
        {
            if (table_satislar.SelectedRows.Count > 0)
            {
                string skodu = table_satislar.SelectedRows[0].Cells[0].Value + string.Empty;
                if (skodu == "")
                {
                    MessageBox.Show("Lütfen bir satış seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txt_teslimat_adres.ReadOnly = false;
                    txt_box_satis_fiyat.ReadOnly = false;
                    string veritabaniyolu3 = "Data source=Database/veritabani.db";          
                    SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);                 //Bu kısımda veritabanına bağlandık
                    baglanti2.Open();
                   
                    string sql_m9_sorgula = $"SELECT SatisKodu,Isim,SoyIsim,UrunAdi,TeslimatAdresi,UrunAdedi,UrunSatisFiyati,SatisTarihi FROM Satislar INNER JOIN Urunler ON Satislar.UrunID=Urunler.UrunID INNER JOIN Musteriler ON Satislar.MusteriTC=Musteriler.MusteriTC WHERE SatisKodu='{skodu}'";

                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m9_sorgula, baglanti2);
                    cmd_m_sorgula.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);
                    SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                    
                    if (dr.Read())
                    {
                        satis_kodu.Text = dr["SatisKodu"].ToString();
                        txt_box_satis_fiyat.Text = dr["UrunSatisFiyati"].ToString();                        //Bu kısımda tablodan gelen bilgileri textboxlara yerleştirdik.
                        txt_teslimat_adres.Text = dr["TeslimatAdresi"].ToString();
                        txt_satis_tarihi.Text= dr["SatisTarihi"].ToString();
                        urun_adet_satislar.Text = dr["UrunAdedi"].ToString();
                        m_adi_satislar.Text = dr["Isim"].ToString() + " " + dr["SoyIsim"].ToString();
                        urun_adi_satislar.Text = dr["UrunAdi"].ToString();                                 //Bu kısımda tablodan gelen bilgileri textboxlara yerleştirdik.


                    }
                    dr.Close();
                   

                    baglanti2.Close();
                }

            }
            else
            {
                MessageBox.Show("Lütfen bir satış seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }           

        private void satislar_temizle_btn_Click(object sender, EventArgs e)         //Bu kısımda textboxların içlerini boşalttık.
        {
            txt_teslimat_adres.ReadOnly = true;
            txt_box_satis_fiyat.ReadOnly = true;
            txt_satis_tarihi.Text = String.Empty;
            txt_teslimat_adres.Text = String.Empty;
            txt_box_satis_fiyat.Text = String.Empty;
            satis_kodu.Text = String.Empty;
            m_adi_satislar.Text = String.Empty;
            urun_adi_satislar.Text = String.Empty;
            urun_adet_satislar.Text = String.Empty;

        }

        private void btn_Satis_Yap_Click(object sender, EventArgs e)                //bu kısımda satış yaptıgımız blok calısıyor.
        {
            if (satis_m_tc.Text == "" || satis_m_adres.Text == "" || satis_fatura_no.Text == ""||satilacak_urunler.Rows.Count==0)
            {
                Uyari("Satış işlemi için lütfen Gerekli alanları doldurunuz.");
            }
            else
            {
                string veritabaniyolu3 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);
                baglanti2.Open();

                DateTime bugun = DateTime.Today;
                string gun = bugun.ToString("dd");
                string ay = bugun.ToString("MM");
                string yil = bugun.ToString("yyyy");
                string tarihler = $"{yil}-{ay}-{gun}";

                for (int i = 0; i < satilacak_urunler.Rows.Count; i++) 
                {
                    string sql = $"INSERT INTO Satislar ('UrunID','UrunAdedi','UrunSatisFiyati','FaturaNo') VALUES ('{satilacak_urunler.Rows[i].Cells[0].Value}','{satilacak_urunler.Rows[i].Cells[2].Value}','{satilacak_urunler.Rows[i].Cells[3].Value}','{satis_fatura_no.Text}') "; 
                    SQLiteCommand cmd_sql = new SQLiteCommand(sql, baglanti2);
                    cmd_sql.ExecuteNonQuery();
                }
                int toplamfiyat = 0;
                for (int i = 0; i < satilacak_urunler.Rows.Count; ++i)
                {
                    int ID = Convert.ToInt32(satilacak_urunler.Rows[i].Cells[0].Value);              
                    int adet = Convert.ToInt32(satilacak_urunler.Rows[i].Cells[2].Value);              
                    int fiyat = Convert.ToInt32(satilacak_urunler.Rows[i].Cells[3].Value);              
                    toplamfiyat += adet * fiyat;
                    string stokdurumu = $"SELECT ToplamUrunAdedi FROM Urunler where UrunID='{ID}'";
                    SQLiteCommand cmd_stok = new SQLiteCommand(stokdurumu, baglanti2);
                    int stok = Convert.ToInt32(cmd_stok.ExecuteScalar());
                    int sonuc = stok - adet;
                    string sql_gnclle = $"UPDATE Urunler set ToplamUrunAdedi='{sonuc}' where UrunID='{ID}'";
                    SQLiteCommand cmd_gnclle = new SQLiteCommand(sql_gnclle, baglanti2);
                    cmd_gnclle.ExecuteNonQuery();

                }
                string sql_fatura = $"INSERT INTO Faturalar ('FaturaNo','MusteriTC','Tarih','ToplamFiyat','TeslimatAdresi') VALUES ('{satis_fatura_no.Text}','{satis_m_tc.Text}','{tarihler}','{toplamfiyat}','{satis_m_adres.Text}')";
                SQLiteCommand cmd_fatura = new SQLiteCommand(sql_fatura, baglanti2);
                cmd_fatura.ExecuteNonQuery();

                for (int i = 0; i < satilacak_urunler.Rows.Count; ++i)
                {
                    int satilacak_adet = Convert.ToInt32(satilacak_urunler.Rows[i].Cells[2].Value);            
                    int fiyat = Convert.ToInt32(satilacak_urunler.Rows[i].Cells[3].Value);             
                }






                baglanti.Close();
                satis_m_tc.Text = String.Empty;
                satis_fatura_no.Text = String.Empty;
                satis_m_adres.Text = String.Empty;
                satilacak_urunler.Rows.Clear();

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                          //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Satış başarıyla oluşturulmuştur.";
                popup.Popup();

                tablolariGuncelle();
                /*
                string veritabaniyolu3 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);                                             //Bu kısımda veritabanına bağlandık
                baglanti2.Open();
                string stok_varmi = $"SELECT ToplamUrunAdedi FROM Urunler where UrunID='{satis_urun_id.Text}'";

                SQLiteCommand cmd_stok_varmi = new SQLiteCommand(stok_varmi, baglanti2);
               
                int toplamAdet = Convert.ToInt32(cmd_stok_varmi.ExecuteScalar());

                int satilanadet= Convert.ToInt32(satis_siparis_adedi.Text);
                int sonuc=toplamAdet - satilanadet;                                         //Bu kısımda stoktan fazla ürün satılmaya calısıyorsa bu blok calısıyor.
                if (satilanadet > toplamAdet)
                {
                    MessageBox.Show("Yeterli stok olmadığından dolayı satış işleminız GERÇEKLEŞMEMİŞTİR.", "İŞLEM BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (satis_siparis_adedi.Text == "0") { 
                    MessageBox.Show("Sıfır 0 ürün satışı yapmanız imkansızdır.", "İŞLEM BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    DateTime bugun = DateTime.Today;
                    string gun = bugun.ToString("dd");
                    string ay = bugun.ToString("MM");
                    string yil = bugun.ToString("yyyy");
                    string tarihler = $"{yil}-{ay}-{gun}";
                    string fiyat = metroSetLabel39.Text;
                    fiyat = fiyat.Substring(0, fiyat.Length - 2);
                    int gnclefiyat = Convert.ToInt32(fiyat);
                    string sql_satis_ekle = $"INSERT INTO Satislar ('MusteriTC','UrunID','TeslimatAdresi','UrunAdedi','UrunSatisFiyati','SatisTarihi') VALUES ('{satis_m_tc.Text}','{satis_urun_id.Text}','{satis_m_adres.Text}','{satis_siparis_adedi.Text}','{gnclefiyat}','{tarihler}')";
                    SQLiteCommand cmd_satis_ekle = new SQLiteCommand(sql_satis_ekle, baglanti2);

                    string stokguncelle = $"UPDATE Urunler set ToplamUrunAdedi='{sonuc}' where UrunID='{satis_urun_id.Text}'";
                    SQLiteCommand cmd_stok_gncl = new SQLiteCommand(stokguncelle, baglanti2);                   //Bu kısımda veritabanı ile ilgili işlemler yapılıyor
                    cmd_stok_gncl.ExecuteNonQuery();    
                    cmd_satis_ekle.ExecuteNonQuery();

                    satis_m_tc.Text = String.Empty;
                    satis_fatura_no.Text = String.Empty;
                    metroSetTextBox4.Text = String.Empty;
                    satis_urun_id.Text = String.Empty;
                    satis_urun_ad.Text = String.Empty;                                                      //Bu kısımda textboxların içlerini boşalttık.
                    satis_siparis_adedi.Text = String.Empty;
                    satis_urun_fiyat.Text = String.Empty;
                    satis_m_adres.Text = String.Empty;

                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.checked__2_;
                    popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                          //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                    popup.TitleText = "İşlem Başarılı";
                    popup.ContentText = "\n Satış başarıyla oluşturulmuştur.";
                    popup.Popup();
                    baglanti2.Close();

                    tablolariGuncelle();

                }*/
            }
        }

        private void btn_satislari_gnclle_Click(object sender, EventArgs e)             //Bu blokta satısları güncellediğimiz metod calısıyor.
        {
            if (satis_kodu.Text == "")
            {
                MessageBox.Show("Güncelleme işlemi için lütfen bir satış seçip bilgileri getir butonuna basınız", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_teslimat_adres.Text == "" || txt_box_satis_fiyat.Text == "")
            {
                MessageBox.Show("Güncelleme işlemi için lütfen gerekli bilgileri giriniz.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else { 
            baglanti.Open();
            string sql_m_sorgula = $"UPDATE Satislar set UrunSatisFiyati='{txt_box_satis_fiyat.Text}', TeslimatAdresi='{txt_teslimat_adres.Text}' WHERE SatisKodu='{satis_kodu.Text}'";
            SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);

            cmd_m_sorgula.ExecuteNonQuery();

            baglanti.Close();
            tablolariGuncelle();


            txt_teslimat_adres.ReadOnly = true;
            txt_box_satis_fiyat.ReadOnly = true;

            txt_teslimat_adres.Text = String.Empty;
            txt_box_satis_fiyat.Text = String.Empty;
            satis_kodu.Text = String.Empty;                                                             //Bu kısımda textboxların içlerini boşalttık.
            m_adi_satislar.Text = String.Empty;
            txt_satis_tarihi.Text = String.Empty;
            urun_adi_satislar.Text = String.Empty;
            urun_adet_satislar.Text = String.Empty;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.checked__2_;
            popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                                 //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.                 
            popup.TitleText = "İşlem Başarılı";                         
            popup.ContentText = "\n Satış güncelleme işlemi başarıyla tamamlanmıştır.";
            popup.Popup();
            }
        }

        private void txtbox_satislar_ara_TextChanged(object sender, EventArgs e)          //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık.
        {
            if (sts_tc_radio.Checked == true)
            {
                (table_satislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusteriTC LIKE '{0}%'", txtbox_satislar_ara.Text);
            }
            else if (sts_id_radio.Checked == true)
            {
                (table_satislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(UrunID, System.String) LIKE '{0}%'", txtbox_satislar_ara.Text); 
            }
            else {
                sts_tc_radio.Checked = true;
                (table_satislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("MusteriTC LIKE '{0}%'", txtbox_satislar_ara.Text);
            }
        }

        private void switch_tus_SwitchedChanged(object sender)                          //Bu kısımda alış işlemlerinde yeni ürün mü yoksa kayıtlı ürün için mi alış yapacak kullanıcı onun görünürlük ayarı yapıldı
        {
            if (panel_var_olan_urun.Visible == true)
            {
                panel_var_olan_urun.Visible = false;
                panel_yeni_urun.Visible = true;
                txt_1_t_id.Text = String.Empty;
                txt_1_t_ad.Text = String.Empty;
                txt_1_u_adi.Text = String.Empty;
                txt_1_u_alis_f.Text = String.Empty;
                txt_1_u_satis_f.Text = String.Empty;
                txt_1_u_adet.Text = String.Empty;                                   //Bu kısımda tuş açılıp kapanırken textboxların içlerini boşalttık.
                txt_2_t_id.Text = String.Empty;
                txt_2_t_ad.Text = String.Empty;
                a_urun_id.Text = String.Empty;
                txt_2_urun_ad.Text = String.Empty;
                txt_2_u_alis_f.Text = String.Empty;
                txt_2_u_adet.Text = String.Empty;
            }
            else {
                panel_var_olan_urun.Visible = true;
                panel_yeni_urun.Visible = false;
                txt_1_t_id.Text = String.Empty;
                txt_1_t_ad.Text = String.Empty;
                txt_1_u_adi.Text = String.Empty;
                txt_1_u_alis_f.Text = String.Empty;
                txt_1_u_satis_f.Text = String.Empty;                                //Bu kısımda tuş açılıp kapanırken textboxların içlerini boşalttık.
                txt_1_u_adet.Text = String.Empty;
                txt_2_t_id.Text = String.Empty;
                txt_2_t_ad.Text = String.Empty;
                a_urun_id.Text = String.Empty;
                txt_2_urun_ad.Text = String.Empty;
                txt_2_u_alis_f.Text = String.Empty;
                txt_2_u_adet.Text = String.Empty;
            }
        }

        private void btn_urun_sil_Click(object sender, EventArgs e)                         //Bu kısımda ürün sildiğimiz fonksiyon calısıyor
        {
            baglanti.Open();

            DialogResult soru2 = new DialogResult();
            soru2 = MessageBox.Show("Bu ürünün kayıtlı olduğu Alış ve Satış işlemleri olduğu için silme işlemi veri kaybına yol açacaktır.Silmek istediğinize emin misiniz? (Silmeniz KESİNLİKLE ÖNERİLMEZ)", "Ürün Sil", MessageBoxButtons.YesNo);
            if (soru2 == DialogResult.Yes)
            {
                string sql_m_sil = $"DELETE FROM Urunler where UrunID='{urun_id__.Text}'";
                string sql_satis_sil = $"DELETE FROM Alislar where UrunID='{urun_id__.Text}'";          
                string sql_alis_sil = $"DELETE FROM Satislar where UrunID='{urun_id__.Text}'";                  //ürüne bağlı olan alış ve satış işlemleri siliniyor
                SQLiteCommand cmd_m_sil = new SQLiteCommand(sql_m_sil, baglanti);
                SQLiteCommand cmd_s_sil = new SQLiteCommand(sql_satis_sil, baglanti);
                SQLiteCommand cmd_alis_sil = new SQLiteCommand(sql_alis_sil, baglanti);
                cmd_m_sil.ExecuteNonQuery();
                cmd_s_sil.ExecuteNonQuery();
                cmd_alis_sil.ExecuteNonQuery();

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                                  //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.            
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Ürün başarıyla silinmiştir.";
                popup.Popup();

                urun_adi_gnclle.Text = String.Empty;
                urun_adedi_gnclle.Text = String.Empty;
                urun_id__.Text = String.Empty;
                urun_fiyati_gnclle.Text = String.Empty;                                                             //Bu kısımda textboxların içlerini boşalttık.
                urun_adedi_gnclle.ReadOnly = true;
                urun_adi_gnclle.ReadOnly = true;
                urun_fiyati_gnclle.ReadOnly = true;
                btn_urun_sil.Visible = false;

            }
            baglanti.Close();
            tablolariGuncelle();
        }

        private void ted_ekle_btn_Click(object sender, EventArgs e)                 //Bu kısımda butona basıldıgında tedarikçi eklediğimiz sekme açılıyor.
        {
            metroSetTabControl1.SelectedIndex = 3;
        }

        private void btn_1_temizle_Click(object sender, EventArgs e)                //Bu kısımda textboxların içlerini boşalttık.
        {
            txt_1_t_id.Text = String.Empty;
            txt_1_t_ad.Text = String.Empty;
            txt_1_u_adi.Text = String.Empty;
            txt_1_u_alis_f.Text = String.Empty;                                             
            txt_1_u_satis_f.Text = String.Empty;
            txt_1_u_adet.Text = String.Empty;
        }

        private void a_btn_temizle_Click_1(object sender, EventArgs e)                  //Bu kısımda textboxların içlerini boşalttık.  
        {
            txt_2_t_id.Text = String.Empty;
            txt_2_t_ad.Text = String.Empty;
            a_urun_id.Text = String.Empty;                                          
            txt_2_urun_ad.Text = String.Empty;
            txt_2_u_alis_f.Text = String.Empty;
            txt_2_u_adet.Text = String.Empty;

        }           

        private void search_ted_txt_TextChanged(object sender, EventArgs e)           //Bu kısımda textboxa girilen harfe göre tablodan filtreleme işlemi yapılıyor.
        {
            (table_tedler_2.DataSource as DataTable).DefaultView.RowFilter = string.Format("TedarikciIsmi LIKE '{0}%'", search_ted_txt.Text);
        }

        private void alis_ted_bilgi_getir_Click(object sender, EventArgs e)         //Bu kısımda butona basıldıgında tedarikçi tablosundan bilgiler textboxlara getiriliyor.
        {
            if (panel_yeni_urun.Visible == true)
            {
                if (table_tedler_2.SelectedRows.Count > 0)
                {
                    string mtara = table_tedler_2.SelectedRows[0].Cells[0].Value + string.Empty;
                    if (mtara == "")
                    {
                        MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        baglanti.Open();
                        string sql_m_sorgula = $"SELECT TedID,TedarikciIsmi FROM Tedarikciler WHERE TedID='{mtara}'";
                        SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);
                        cmd_m_sorgula.ExecuteNonQuery();                                                                //Bu kısımda veritabanı ile ilgili işlemler yapılıyor
                        DataTable dt = new DataTable();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                        da.Fill(dt);
                        SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                        if (dr.Read())
                        {
                            txt_1_t_id.Text = dr["TedID"].ToString();
                            txt_1_t_ad.Text = dr["TedarikciIsmi"].ToString();                                       //Bu kısımda veriler textboxlara getiriliyor
                        }
                        da.Dispose();
                        dt.Dispose();
                        dr.Close();
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else {
                if (table_tedler_2.SelectedRows.Count > 0)
                {
                    string mtara = table_tedler_2.SelectedRows[0].Cells[0].Value + string.Empty;
                    if (mtara == "")
                    {
                        MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        baglanti.Open();
                        string sql_m_sorgula = $"SELECT TedID,TedarikciIsmi FROM Tedarikciler WHERE TedID='{mtara}'";
                        SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti);
                        cmd_m_sorgula.ExecuteNonQuery();
                        DataTable dt = new DataTable();                                                             //Bu kısımda veritabanı ile ilgili işlemler yapılıyor
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                        da.Fill(dt);
                        SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                        if (dr.Read())
                        {
                            txt_2_t_id.Text = dr["TedID"].ToString();
                            txt_2_t_ad.Text = dr["TedarikciIsmi"].ToString();                                           //Bu kısımda veriler textboxlara getiriliyor
                        }
                        da.Dispose();
                        dt.Dispose();
                        dr.Close();
                        baglanti.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen bir tedarikçi seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void alis_urun_bilgi_getir_Click(object sender, EventArgs e)            //Bu kısımda butona basıldıgında ürün tablosundaki bilgiler textboxlara getiriliyor.
        {
            if (panel_yeni_urun.Visible == false)
            {
                if (table_urunler_3.SelectedRows.Count > 0)
                {
                    string urunId = table_urunler_3.SelectedRows[0].Cells[0].Value + string.Empty;
                    string veritabaniyolu2 = "Data source=Database/veritabani.db";
                    SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu2);
                    baglanti2.Open();
                    string sql_m_sorgula = $"SELECT * FROM Urunler WHERE UrunID='{urunId}'";
                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti2);
                    cmd_m_sorgula.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);
                    SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_2_urun_ad.Text = dr["UrunAdi"].ToString();
                        a_urun_id.Text = dr["UrunID"].ToString();
                    }
                    dr.Close();
                    baglanti2.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("Yeni ürün eklerken,kayıtlı ürün bilgilerinizden bilgi getiremezsiniz.Yeni ürün eklemek için yeni bilgiler girmelisiniz.","Hata Uyarısı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            
            }
        }

        private void ted_ekle_btn_2_Click(object sender, EventArgs e)           //Bu kısımda butona basıldıgında tedarikçi sekmesi açılıyor.
        {
           metroSetTabControl1.SelectedIndex = 3;
        }

        private void search_urun_txt_TextChanged(object sender, EventArgs e)        //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık.
        {
            if (search_radio_isim.Checked == true)
            {
                (table_urunler_3.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", search_urun_txt.Text);
            }
            else if (search_radio_id.Checked == true)
            {
                (table_urunler_3.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(UrunID, System.String) LIKE '{0}%'", search_urun_txt.Text);
            }
            else
            {
                search_radio_isim.Checked = true;
                (table_urunler_3.DataSource as DataTable).DefaultView.RowFilter = string.Format("UrunAdi LIKE '{0}%'", search_urun_txt.Text);
            }
        }

        private void btn_alis_yap_Click(object sender, EventArgs e)                 //Bu kısımda yeni ürün alış yaptığımız fonksiyon çalışıyor
        {
            if (txt_1_t_id.Text == "" || txt_1_t_ad.Text == "" || txt_1_u_adi.Text == "" || txt_1_u_alis_f.Text == "" || txt_1_u_satis_f.Text == "" || txt_1_u_adet.Text == "")
            {
                MessageBox.Show("Alış işlemi için lütfen Gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string veritabaniyolu3 = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);             //Bu kısımda veritabanına bağlandık.
                baglanti2.Open();

                string sql_urunid_sorgula = $"SELECT * FROM Urunler WHERE UrunAdi='{txt_1_u_adi.Text}'";
                SQLiteCommand cmd_urunid_sorgula = new SQLiteCommand(sql_urunid_sorgula, baglanti2);
                cmd_urunid_sorgula.ExecuteNonQuery();                                                               //Bu kısımda veritabanı ile ilgili işlemler yaptık.Aynı ürün adında bir başka ürün var mı kontrol ettik
                DataTable dt33 = new DataTable();
                SQLiteDataAdapter da22 = new SQLiteDataAdapter(cmd_urunid_sorgula);
                da22.Fill(dt33);

                if (dt33.Rows.Count > 0)            //eğer aynı ürün adında bir ürün varsa veritabanında bu bloğa girip kullanıcıya uyarı mesajı verdik.
                {
                    MessageBox.Show("Kaydetmeye çalıştığınız ürünün isminde bir başka ürün zaten veritabanında kayıtlıdır.Lütfen farklı bir ürün isminde kayıt işlemi yapınız.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                else {                              //eğer aynı ürün adında bir ürün yoksa veritabanında bu bloğa giriyor.

                string sql_urun_ekle = $"INSERT INTO Urunler ('UrunAdi','ToplamUrunAdedi','SatisFiyati') VALUES ('{txt_1_u_adi.Text}','{txt_1_u_adet.Text}','{txt_1_u_satis_f.Text}')";
                SQLiteCommand cmd_urun_ekle = new SQLiteCommand(sql_urun_ekle, baglanti2);
                cmd_urun_ekle.ExecuteNonQuery();

                    
                string id_sorgula = $"SELECT MAX(UrunID) FROM Urunler";
                SQLiteCommand cmd_id_sorgu = new SQLiteCommand(id_sorgula, baglanti2);
                int ID = Convert.ToInt32(cmd_id_sorgu.ExecuteScalar());
                      
              
                SQLiteDataReader dr6;
                dr6 = cmd_id_sorgu.ExecuteReader();
                while (dr6.Read()) {
                                                                              //Bu kısımda veritabanı ile ilgili işlemler yaptık
                    DateTime bugun = DateTime.Today;
                    string gun = bugun.ToString("dd");
                    string ay = bugun.ToString("MM");
                    string yil = bugun.ToString("yyyy");
                    string tarih = $"{yil}-{ay}-{gun}";
                    string fiyat = lbl_alis_fiyati.Text;
                    fiyat = fiyat.Substring(0, fiyat.Length - 2);
                    int gnclefiyat = Convert.ToInt32(fiyat);
                    string alis_ekle = $"INSERT INTO Alislar ('TedarikciIsmi','UrunID','AlinanUrunAdedi','UrununAlisFiyati','AlisTarihi') VALUES ('{txt_1_t_ad.Text}','{ID}','{txt_1_u_adet.Text}','{fiyat}','{tarih}')";
                    SQLiteCommand cmd_alis_ekle = new SQLiteCommand(alis_ekle, baglanti2);
                    cmd_alis_ekle.ExecuteNonQuery();
                }
                
                txt_1_t_id.Text = String.Empty;
                txt_1_t_ad.Text = String.Empty;
                txt_1_u_adi.Text = String.Empty;
                txt_1_u_alis_f.Text = String.Empty;                                                             //Bu kısımda textboxların içlerini boşalttık.
                txt_1_u_satis_f.Text = String.Empty;
                txt_1_u_adet.Text = String.Empty;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                                  //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                    popup.TitleText = "İşlem Başarılı";     
                popup.ContentText = "\n Alış işlemi başarıyla oluşturulmuştur.";
                popup.Popup();
                baglanti2.Close();

                tablolariGuncelle();

                }
            }
        }               

        private void a_btn_alisyap_Click(object sender, EventArgs e)                //Bu kısımda kayıtlı ürüne alış yaptığımız fonksiyon çalışıyor.
        {
            if (txt_2_t_id.Text == "" || txt_2_t_ad.Text == "" || a_urun_id.Text == "" || txt_2_urun_ad.Text == "" || txt_2_u_alis_f.Text == "" || txt_2_u_adet.Text == "")
            {
                MessageBox.Show("Alış işlemi için lütfen Gerekli alanları doldurunuz.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string veritabaniyolu3 = "Data source=Database/veritabani.db";              //Bu kısımda veritabanına bağlanıyoruz
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);
                baglanti2.Open();

                string sql_adet_Sorgu = $"SELECT ToplamUrunAdedi FROM Urunler where UrunID='{a_urun_id.Text}'";
                SQLiteCommand cmd_urun_adet_sorgula = new SQLiteCommand(sql_adet_Sorgu, baglanti2);
                cmd_urun_adet_sorgula.ExecuteNonQuery();

                string str_e_adet = txt_2_u_adet.Text;
                int e_adet = Convert.ToInt32(str_e_adet);

                SQLiteDataReader dr6;
                dr6 = cmd_urun_adet_sorgula.ExecuteReader();
                while (dr6.Read())
                {
                    string b = dr6.GetValue(0).ToString();
                    int adet = Convert.ToInt32(b);
                    int toplam=e_adet + adet;

                    string sql_stokgnclle = $"UPDATE Urunler SET ToplamUrunAdedi='{toplam}' where UrunID='{a_urun_id.Text}'";
                    SQLiteCommand cmd_stok_gnclle = new SQLiteCommand(sql_stokgnclle, baglanti2);
                    cmd_stok_gnclle.ExecuteNonQuery();
                }
                DateTime bugun = DateTime.Today;
                string gun = bugun.ToString("dd");
                string ay = bugun.ToString("MM");
                string yil = bugun.ToString("yyyy");
                string tarih = $"{yil}-{ay}-{gun}";
                string fiyat = lbl_2_alislar_fiyat.Text;
                fiyat = fiyat.Substring(0, fiyat.Length - 2);
                int gnclefiyat = Convert.ToInt32(fiyat);
                string sql_alis_ekle = $"INSERT INTO Alislar ('TedarikciIsmi','UrunID','AlinanUrunAdedi','UrununAlisFiyati','AlisTarihi') VALUES ('{txt_2_t_ad.Text}','{a_urun_id.Text}','{txt_2_u_adet.Text}','{fiyat}','{tarih}')";
                SQLiteCommand CMD_alis_ekle = new SQLiteCommand(sql_alis_ekle, baglanti2);
                CMD_alis_ekle.ExecuteNonQuery();

                txt_2_t_id.Text = String.Empty;
                txt_2_t_ad.Text = String.Empty;
                a_urun_id.Text = String.Empty;                                                                  //Bu kısımda textboxların içlerini boşalttık.
                txt_2_urun_ad.Text = String.Empty;
                txt_2_u_alis_f.Text = String.Empty;
                txt_2_u_adet.Text = String.Empty;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);                                  //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Alış işlemi başarıyla oluşturulmuştur.";
                popup.Popup();
                baglanti2.Close();

                tablolariGuncelle();

            }
        }

        private void btn_alis_bilgi_getir_Click(object sender, EventArgs e)             //Bu kısımda tablodan seçili olan satırın bilgilerini getirdiğimiz fonksiyon calıstı.
        {
            if (table_alislar.SelectedRows.Count > 0)
            {
                string akodu = table_alislar.SelectedRows[0].Cells[0].Value + string.Empty;
                if (akodu == "")
                {
                    MessageBox.Show("Lütfen bir alış seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    alis_fiyati_alislar.ReadOnly = false;
                    string veritabaniyolu3 = "Data source=Database/veritabani.db";          //Bu kısımda veritabanına bağlanıldı.
                    SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu3);
                    baglanti2.Open();
                    string sql_m_sorgula = $"SELECT AlisKodu,TedarikciIsmi,UrunAdi,AlinanUrunAdedi,UrununAlisFiyati FROM Alislar INNER JOIN Urunler ON Alislar.UrunID=Urunler.UrunID WHERE AlisKodu='{akodu}'";

                    SQLiteCommand cmd_m_sorgula = new SQLiteCommand(sql_m_sorgula, baglanti2);
                    cmd_m_sorgula.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd_m_sorgula);
                    da.Fill(dt);
                    SQLiteDataReader dr = cmd_m_sorgula.ExecuteReader();

                    if (dr.Read())
                    {
                        alis_kodu.Text = dr["AlisKodu"].ToString();
                        text_ted_adi.Text = dr["TedarikciIsmi"].ToString();                     //Bu kısımda tablodaki verileri ilgili textboxların içlerine yerleştirmiş olduk.
                                                                                                
                        alis_u_id.Text = table_alislar.CurrentRow.Cells[2].Value.ToString();
                        txt_toplam_urun_Adet.Text = dr["AlinanUrunAdedi"].ToString();
                        alis_fiyati_alislar.Text = dr["UrununAlisFiyati"].ToString();
                        urun_adi.Text = dr["UrunAdi"].ToString();                              //Bu kısımda tablodaki verileri ilgili textboxların içlerine yerleştirmiş olduk.


                    }
                    dr.Close();

                    
                    baglanti2.Close();
                }

            }
            else
            {
                MessageBox.Show("Lütfen bir alış seçiniz", "Hata Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_temizle_alislar_Click(object sender, EventArgs e)              //Bu kısımda textboxların içlerini boşalttıp bazı textboxların readonly özelliğini true yaptık.
        {
            alis_kodu.Text = String.Empty;
            text_ted_adi.Text = String.Empty;
            alis_u_id.Text = String.Empty;
            urun_adi.Text = String.Empty;                                               //Bu kısımda textboxların içlerini boşalttık.
            txt_toplam_urun_Adet.Text = String.Empty;
            alis_fiyati_alislar.Text = String.Empty;
            alis_fiyati_alislar.ReadOnly = true;
        }

        private void btn_gnclle_alis_Click(object sender, EventArgs e)                  //Bu blokta alış tablosundaki verileri güncelleme işlemlerini yaptık.
        {
            if (alis_u_id.Text == "" || alis_fiyati_alislar.Text=="")
            {
                MessageBox.Show("Alış bilgisini tablodan getirmeden güncelleme işlemi yapamazsınız.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();

                string sql_m_guncelle = $"UPDATE Alislar SET UrununAlisFiyati='{alis_fiyati_alislar.Text}' WHERE AlisKodu='{alis_kodu.Text}'";
                SQLiteCommand cmd_m_guncelle = new SQLiteCommand(sql_m_guncelle, baglanti);
                cmd_m_guncelle.ExecuteNonQuery();

                baglanti.Close();
                tablolariGuncelle();    

                bttn_t_gnclle.Visible = false;
                t_sil_bttn.Visible = false;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked__2_;
                popup.TitleColor = System.Drawing.Color.FromArgb(0, 0, 0);                  //Bu kısımda kullanıcıya sağ altta bilgi mesajı verdik.
                popup.BodyColor = System.Drawing.Color.FromArgb(69, 139, 116);
                popup.TitleText = "İşlem Başarılı";
                popup.ContentText = "\n Alış işlemi başarıyla güncellenmiştir.";
                popup.Popup();

                alis_kodu.Text = String.Empty;
                text_ted_adi.Text = String.Empty;
                alis_u_id.Text = String.Empty;                                              //Bu kısımda textboxların içlerini boşalttık.
                urun_adi.Text = String.Empty;
                txt_toplam_urun_Adet.Text = String.Empty;
                alis_fiyati_alislar.Text = String.Empty;
                alis_fiyati_alislar.ReadOnly = true;
            }




        }

        private void search_txt_alis_ara_TextChanged(object sender, EventArgs e)        //Bu blokta kullanıcı tabloda veri ararken radiobutonların aktif olma durumuna göre arama yapmasını sağladık.
        {
            if (radio_ted_isim.Checked == true)
            {
                (table_alislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("TedarikciIsmi LIKE '{0}%'", search_txt_alis_ara.Text);
            }
            else if (radio_alis_urun_id.Checked == true)
            {
                (table_alislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(UrunID, System.String) LIKE '{0}%'", search_txt_alis_ara.Text);
            }
            else
            {
                radio_ted_isim.Checked = true;
                (table_alislar.DataSource as DataTable).DefaultView.RowFilter = string.Format("TedarikciIsmi LIKE '{0}%'", search_txt_alis_ara.Text);
            }
        }

        private void m_tc_TextChanged(object sender, EventArgs e)                       //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(m_tc.Text, "[^0-9]"))
            {
                m_tc.Text = m_tc.Text.Remove(m_tc.Text.Length - 1);
            }
        }

        private void m_tel_TextChanged(object sender, EventArgs e)                      //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(m_tel.Text, "[^0-9]"))
            {
                m_tel.Text = m_tel.Text.Remove(m_tel.Text.Length - 1);
            }
        }

        private void t_tel_TextChanged(object sender, EventArgs e)                      //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(t_tel.Text, "[^0-9]"))
            {
                t_tel.Text = t_tel.Text.Remove(t_tel.Text.Length - 1);
            }
        }

        private void txt_box_satis_fiyat_TextChanged(object sender, EventArgs e)        //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_box_satis_fiyat.Text, "[^0-9]"))
            {
                txt_box_satis_fiyat.Text = txt_box_satis_fiyat.Text.Remove(txt_box_satis_fiyat.Text.Length - 1);
            }
        }

        private void txt_1_u_alis_f_TextChanged(object sender, EventArgs e)             //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_1_u_alis_f.Text, "[^0-9]"))
            {
                txt_1_u_alis_f.Text = txt_1_u_alis_f.Text.Remove(txt_1_u_alis_f.Text.Length - 1);
            }
            else
            {

                try
                {
                    if (txt_1_u_alis_f.Text == "")
                    {
                        lbl_alis_fiyati.Text = "";
                    }
                    else
                    {
                        int adet = Convert.ToInt32(txt_1_u_adet.Text);
                        int fiyat = Convert.ToInt32(txt_1_u_alis_f.Text);
                        int sonuc = adet * fiyat;
                        lbl_alis_fiyati.Text = Convert.ToString(sonuc) + " ₺";
                    }
                }
                catch
                {
                }
            }
                
        }

        private void txt_1_u_satis_f_TextChanged(object sender, EventArgs e)            //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_1_u_satis_f.Text, "[^0-9]"))
            {
                txt_1_u_satis_f.Text = txt_1_u_satis_f.Text.Remove(txt_1_u_satis_f.Text.Length - 1);
            }
        }

        private void txt_1_u_adet_TextChanged(object sender, EventArgs e)              //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_1_u_adet.Text, "[^0-9]"))
            {
                txt_1_u_adet.Text = txt_1_u_adet.Text.Remove(txt_1_u_adet.Text.Length - 1);
            }
            else {
                    try
                    {
                        if (txt_1_u_adet.Text == "")
                        {
                        lbl_alis_fiyati.Text = "";
                        }
                        else
                        {
                            int adet = Convert.ToInt32(txt_1_u_adet.Text);
                            int fiyat = Convert.ToInt32(txt_1_u_alis_f.Text);
                            int sonuc = adet * fiyat;
                        lbl_alis_fiyati.Text = Convert.ToString(sonuc) + " ₺";
                        }
                    }
                    catch
                    {
                    }
                
            }
        }

        private void txt_2_u_alis_f_TextChanged(object sender, EventArgs e)             //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_2_u_alis_f.Text, "[^0-9]"))
            {
                txt_2_u_alis_f.Text = txt_2_u_alis_f.Text.Remove(txt_2_u_alis_f.Text.Length - 1);
            }
            else
            {
                try
                {
                    if (txt_2_u_alis_f.Text == "")
                    {
                        lbl_2_alislar_fiyat.Text = "";
                    }
                    else
                    {
                        int adet = Convert.ToInt32(txt_2_u_alis_f.Text);
                        int fiyat = Convert.ToInt32(txt_2_u_adet.Text);
                        int sonuc = adet * fiyat;
                        lbl_2_alislar_fiyat.Text = Convert.ToString(sonuc) + " ₺";
                    }
                }
                catch
                {
                }
            }
        }

        private void txt_2_u_adet_TextChanged(object sender, EventArgs e)               //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_2_u_adet.Text, "[^0-9]"))
            {
                txt_2_u_adet.Text = txt_2_u_adet.Text.Remove(txt_2_u_adet.Text.Length - 1);
            }
            else
            {

                try
                {
                    if (txt_2_u_adet.Text == "")
                    {
                        lbl_2_alislar_fiyat.Text = "";
                    }
                    else
                    {
                        int adet = Convert.ToInt32(txt_2_u_alis_f.Text);
                        int fiyat = Convert.ToInt32(txt_2_u_adet.Text);
                        int sonuc = adet * fiyat;
                        lbl_2_alislar_fiyat.Text = Convert.ToString(sonuc) + " ₺";
                    }
                }
                catch
                {
                }

            }
        }

        private void alis_fiyati_alislar_TextChanged(object sender, EventArgs e)         //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(alis_fiyati_alislar.Text, "[^0-9]"))
            {
                alis_fiyati_alislar.Text = alis_fiyati_alislar.Text.Remove(alis_fiyati_alislar.Text.Length - 1);
            }
        }

        private void urun_adedi_gnclle_TextChanged(object sender, EventArgs e)          //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(urun_adedi_gnclle.Text, "[^0-9]"))
            {
                urun_adedi_gnclle.Text = urun_adedi_gnclle.Text.Remove(urun_adedi_gnclle.Text.Length - 1);
            }
        }

        private void urun_fiyati_gnclle_TextChanged(object sender, EventArgs e)         //Bu blokta kullanıcının textboxa sadece rakamsal ifade girilmesini sağladık.
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(urun_fiyati_gnclle.Text, "[^0-9]"))
            {
                urun_fiyati_gnclle.Text = urun_fiyati_gnclle.Text.Remove(urun_fiyati_gnclle.Text.Length - 1);
            }
        }

        private void satislar_switch_btn_SwitchedChanged(object sender)             //Satışlar sayfasındaki Bu ay/Tüm zamanların switch nesnesi değişirken çalışan blok 
        {
            string veritabaniyolu = "Data source=Database/veritabani.db";
            SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu);
            DateTime bugun = DateTime.Today;
            string ay = bugun.ToString("MM");
            string yil = bugun.ToString("yyyy");
            baglanti2.Open();
            if (satislar_switch_btn.Switched==true)                                                               
            {
                string sql_Gelir_Tablosu = $"SELECT * FROM Satislar";
                SQLiteDataAdapter da_gelir_tablosu = new SQLiteDataAdapter(sql_Gelir_Tablosu, baglanti);
                DataTable dt_gelir_tablosu = new DataTable();
                da_gelir_tablosu.Fill(dt_gelir_tablosu);
                table_satislar.DataSource = dt_gelir_tablosu;
            }
            else                                                                                              
            {
                string sql_Gelir_Tablosu = $"SELECT * FROM Satislar WHERE SatisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31'";
                SQLiteDataAdapter da_gelir_tablosu = new SQLiteDataAdapter(sql_Gelir_Tablosu, baglanti);
                DataTable dt_gelir_tablosu = new DataTable();
                da_gelir_tablosu.Fill(dt_gelir_tablosu);
                table_satislar.DataSource = dt_gelir_tablosu;
            }
            baglanti2.Close();
        }


        private void switch_grafik_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e) //Ciro sayfasında tablo/pasta grafiği değiştirilmesini sağlayan blok
        {
            if (switch_grafik.Checked == true)
            {
                panel_pasta1.Visible = true;
                panel_pasta2.Visible = true;
                table_ciro_satislar.Visible = false;
                table_ciro_alislar.Visible = false;
            }
            else
            {
                panel_pasta1.Visible = false;
                panel_pasta2.Visible = false;
                table_ciro_satislar.Visible = true;
                table_ciro_alislar.Visible = true;

            }
        }

        private void btn_aylik_ciro_Click(object sender, EventArgs e) //Tarihe göre pasta ve tablolara aylık ciro bilgilerini getiren method 
        {
            string veritabaniyolu = "Data source=Database/veritabani.db";
            SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu);
            baglanti2.Open();
            string ay = cbox_ay.Text;
            string yil = cbox_yil.Text;

            
            string sql_satis_sorgula = $"SELECT Isim,SoyIsim,UrunAdi,UrunAdedi,UrunSatisFiyati,SatisTarihi from satislar INNER JOIN Urunler ON Satislar.UrunID=Urunler.UrunID INNER JOIN Musteriler ON Satislar.MusteriTC=Musteriler.MusteriTC where SatisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31'";
            string sql_alis_sorgula = $"SELECT TedarikciIsmi,UrunAdi,AlinanUrunAdedi,UrununAlisFiyati,AlisTarihi FROM Alislar INNER JOIN Urunler on Alislar.UrunID=Urunler.UrunID where AlisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31' ORDER BY AlisTarihi";
            string sql_chart_satis = $"SELECT TedarikciIsmi,UrunAdi, SUM(AlinanUrunAdedi)AS AlinanUrunAdedi, AlisTarihi,SUM(UrununAlisFiyati) as UrununAlisFiyati FROM Alislar INNER JOIN Urunler on Alislar.UrunID = Urunler.UrunID WHERE AlisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31' GROUP BY UrunAdi";
            string sql_chart_alis = $"SELECT UrunAdi,SUM(UrunAdedi)as UrunAdedi,UrunSatisFiyati FROM Satislar INNER JOIN Urunler on Satislar.UrunID = Urunler.UrunID where SatisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31' GROUP BY UrunAdi";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql_alis_sorgula, baglanti2);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SQLiteDataAdapter da2 = new SQLiteDataAdapter(sql_satis_sorgula, baglanti2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            SQLiteDataAdapter da3 = new SQLiteDataAdapter(sql_chart_satis, baglanti2);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            SQLiteDataAdapter da4 = new SQLiteDataAdapter(sql_chart_alis, baglanti2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            table_ciro_alislar.DataSource = dt;
            table_ciro_alislar.AllowUserToAddRows = false;

            table_ciro_satislar.DataSource = dt2;
            table_ciro_satislar.AllowUserToAddRows = false;

            table_chart_alislar.DataSource = dt3;
            table_chart_alislar.AllowUserToAddRows = false;

            table_chart_satislar.DataSource = dt4;
            table_chart_satislar.AllowUserToAddRows = false;

            int toplam_alis = 0;
            for (int i = 0; i < table_ciro_alislar.Rows.Count; ++i)
            {
                toplam_alis += Convert.ToInt32(table_ciro_alislar.Rows[i].Cells[3].Value);              //Toplam alışları tablo üzerinde for döngüsü ile gezinerek topluyoruz ve label'a aktarıyoruz
            }
            lbl_aylik_gider.Text = Convert.ToString(toplam_alis);
            int toplam_satis = 0;

            for (int i = 0; i < table_ciro_satislar.Rows.Count; ++i)
            {
                toplam_satis += Convert.ToInt32(table_ciro_satislar.Rows[i].Cells[4].Value);            //Toplam satışları tablo üzerinde for döngüsü ile gezinerek topluyoruz ve label'a aktarıyoruz
            }
            lbl_aylik_gelir.Text = Convert.ToString(toplam_satis);

            int toplam_ciro=toplam_satis - toplam_alis;
            lbl_aylik_ciro.Text = Convert.ToString(toplam_ciro);

            
            
            baglanti2.Close();
                                                                                                    //Alışların pasta grafiğini doldurma işlemleri
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection piechartData = new SeriesCollection();
            var collection = table_chart_alislar.Rows.Cast<DataGridViewRow>().GroupBy(x => x.Cells[1].Value).Where(g => g.Count() > 0).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
            foreach (DataGridViewRow item in table_chart_alislar.Rows)
            {
                piechartData.Add(new PieSeries { Title = Convert.ToString(item.Cells["UrunAdi"].Value), Values = new ChartValues<double> { Convert.ToDouble(item.Cells["AlinanUrunAdedi"].Value) }, DataLabels = true, LabelPoint = labelPoint });
            }
            chart_alislar.Series = piechartData;
            chart_alislar.LegendLocation = LegendLocation.Right;
                                                                                                      //Satışların pasta grafiğini doldurma işlemleri
            Func<ChartPoint, string> labelPoint2 = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection piechartData2 = new SeriesCollection();
            var collection2 = table_chart_satislar.Rows.Cast<DataGridViewRow>().GroupBy(x => x.Cells[1].Value).Where(g => g.Count() > 0).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
            foreach (DataGridViewRow item in table_chart_satislar.Rows)
            {
                piechartData2.Add(new PieSeries { Title = Convert.ToString(item.Cells["UrunAdi"].Value), Values = new ChartValues<double> { Convert.ToDouble(item.Cells["UrunAdedi"].Value) }, DataLabels = true, LabelPoint = labelPoint });
            }
            chart_satislar.Series = piechartData2;
            chart_satislar.LegendLocation = LegendLocation.Right;

        }

        private void switch_alislar_SwitchedChanged(object sender)  //Alıslar sayfasındaki Bu ay/Tüm zamanların switch nesnesi değişirken çalışan blok
        {
            string veritabaniyolu = "Data source=Database/veritabani.db";
            SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu);
            DateTime bugun = DateTime.Today;
            string ay = bugun.ToString("MM");
            string yil = bugun.ToString("yyyy");
            baglanti2.Open();
            if (switch_alislar.Switched == true)
            {
                string sql_Gelir_Tablosu = $"SELECT * FROM Alislar";
                SQLiteDataAdapter da_gelir_tablosu = new SQLiteDataAdapter(sql_Gelir_Tablosu, baglanti);
                DataTable dt_gelir_tablosu = new DataTable();
                da_gelir_tablosu.Fill(dt_gelir_tablosu);
                table_alislar.DataSource = dt_gelir_tablosu;
            }
            else
            {
                string sql_Gelir_Tablosu = $"SELECT * FROM Alislar WHERE AlisTarihi BETWEEN '{yil}-{ay}-01' AND '{yil}-{ay}-31'";
                SQLiteDataAdapter da_gelir_tablosu = new SQLiteDataAdapter(sql_Gelir_Tablosu, baglanti);
                DataTable dt_gelir_tablosu = new DataTable();
                da_gelir_tablosu.Fill(dt_gelir_tablosu);
                table_alislar.DataSource = dt_gelir_tablosu;
            }
            baglanti2.Close();
        }

        private void btn_arttir_Click(object sender, EventArgs e)
        {
            if (satilacak_urunler.SelectedRows.Count == 0)
            {
                Uyari("Lütfen önce ürün ekleyiniz.");
            }
            else
            {
                string id = satilacak_urunler.SelectedRows[0].Cells[0].Value + string.Empty;
                int adet = Convert.ToInt32(satilacak_urunler.SelectedRows[0].Cells[2].Value);

                string veritabaniyolu = "Data source=Database/veritabani.db";
                SQLiteConnection baglanti2 = new SQLiteConnection(veritabaniyolu);
                baglanti2.Open();
                string sqlsorgu = $"SELECT ToplamUrunAdedi FROM Urunler where UrunID='{id}'";
                SQLiteCommand cmd = new SQLiteCommand(sqlsorgu, baglanti2);
                int toplamadet = Convert.ToInt32(cmd.ExecuteScalar());
                baglanti2.Close();
                if (adet == toplamadet) 
                {
                    Uyari("Yetersiz stoktan dolayı ekleme yapamazsınız.");
                }
                else 
                { 
                adet += 1;
                satilacak_urunler.SelectedRows[0].Cells[2].Value = adet;
                }
            }

        }

        private void btn_azalt_Click(object sender, EventArgs e)
        {
            if (satilacak_urunler.SelectedRows.Count == 0)
            {
                Uyari("Lütfen önce ürün ekleyiniz.");
            }
            else
            {
                int adet = Convert.ToInt32(satilacak_urunler.SelectedRows[0].Cells[2].Value);
                if (adet == 1)
                {
                    foreach (DataGridViewRow row in satilacak_urunler.SelectedRows)
                    {
                        satilacak_urunler.Rows.RemoveAt(row.Index);
                    }
                }
                else { 
                adet -= 1;
                satilacak_urunler.SelectedRows[0].Cells[2].Value = adet;
                }
            }
        }
    }
    
}


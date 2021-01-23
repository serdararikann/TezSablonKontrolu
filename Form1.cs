using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using System.Text.RegularExpressions;

namespace Tez_Sablon_Kontrolu
{
    public partial class TezSablon : Form
    {
        public TezSablon()
        {
            InitializeComponent();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ac_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Metin Dosyaları(*.docx)|*.docx|Tüm Dosyalar|*.*";
            openFileDialog1.Title = "Dosya Seç";
            DialogResult buton = openFileDialog1.ShowDialog();

            if (buton == DialogResult.OK)
            {
                FileInfo dosya = new FileInfo(openFileDialog1.FileName.ToString());
                dosyaAdi = openFileDialog1.FileName.ToString();
                string sonDeger = dosyaAdi.Split('\\').Last();
                dosya_label.Text = sonDeger;
                kontrol.Enabled = true;
            }
        }

        static string dosyaAdi;
        static string totaltext;
        static byte kaynakSayisi;

        private void kontrol_Click(object sender, EventArgs e)
        {
            oku();
            kaynakSay(totaltext);
            atifKontrol(totaltext);
            paragrafKontrol(totaltext);
            kelimeSay(totaltext);
            onsozKontrol(totaltext);
            kapsamKontrol(totaltext);
            denklemKontrol(totaltext);
        }

        private void TezSablon_Load(object sender, EventArgs e)
        {
            kontrol.Enabled = false;
        }

        public void oku()
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = dosyaAdi;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                totaltext += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
            }
            docs.Close();
            word.Quit();
        }
        public void kaynakSay(string metin)
        {
            byte sayi1 = 1, sayi2 = 2;
            string s1 = "", s2 = "";
            while (true)
            {
                s1 = "[" + sayi1.ToString() + "]";
                s2 = "[" + sayi2.ToString() + "]";
                sayi1 = sayi2;

                if (metin.Contains(s1))
                {
                    sayi1++;

                }
                if (metin.Contains(s2))
                {
                    sayi2++;
                }
                else
                {
                    break;
                }
            }

            richTextBox1.Text = (--sayi1).ToString() + " adet kaynak bulunmaktadır.\n";
            kaynakSayisi = sayi1;
        }

        public void atifKontrol(string metin)
        {
            byte sayi = 1;
            string s1 = "";

            while (sayi < kaynakSayisi)
            {
                s1 = "[" + sayi.ToString() + "]";
                int textUzunluk = metin.Length;
                int yeniTextUzunluk = metin.Replace(s1, null).Length;
                int kacDefa = (textUzunluk - yeniTextUzunluk) / s1.Length;
                if (kacDefa < 2)
                {
                    richTextBox1.Text += "\n" + (s1 + ". kaynağa atıf yapılmamıştır.");
                }
                sayi++;
            }
        }

        public void paragrafKontrol(string metin)
        {
            int paraCount = metin.Split('\n').Length;
            string[] dizi = new string[paraCount];
            dizi = metin.Split('\n');
            for (int i = 0; i < paraCount; i++)
            {
                char k = char.Parse(dizi[i].Substring(1, 1));
                bool a = !Char.IsNumber(k);
                if (dizi[i].Length < 180 && i != 0 && a == true && dizi[i].Length > 1 && k == '\r')
                {
                    richTextBox1.Text += "\n" + i + ". paragrafta cümle sayısı ikiden azdır.";
                }
            }
        }
        public void kelimeSay(string metin)
        {
            string s1 = "“";
            string s2 = "”";
            int sayac = 0;
            bool kontrol = false;

            int paraCount = metin.Split('\n').Length;
            string[] dizi = new string[paraCount];
            dizi = metin.Split('\n');
            for (int i = 0; i < paraCount; i++)
            {
                if (dizi[i].Contains(s1))
                {
                    sayac = dizi[i].Split(' ').Length;
                    string[] dizi1 = new string[sayac];
                    dizi1 = dizi[i].Split(' ');
                    for (int j = 0; j < sayac; j++)
                    {
                        if (dizi1[j].Contains(s2))
                        {
                            if (j > 50)
                            {
                                richTextBox1.Text += "\n\n50 kelimeden fazla alıntı yapılmıştır.";
                                kontrol = true;
                                break;
                            }
                        }
                        if (kontrol == true)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void onsozKontrol(string metin)
        {
            int paraCount = metin.Split('\n').Length;
            string[] dizi = new string[paraCount];
            dizi = metin.Split('\n');
            for (int i = 0; i < paraCount; i++)
            {
                if (dizi[i].Contains("ÖNSÖZ") || dizi[i].Contains("Önsöz"))
                {
                    if (dizi[i + 1].Contains("teşekkür") || dizi[i + 1].Contains("Teşekkür"))
                    {
                        richTextBox1.Text += "\n\nÖnsöz bölümünün ilk paragrafında teşekkür ifadesi vardır.";
                        break;
                    }
                }
            }
        }

        public void kapsamKontrol(string metin)
        {
            byte kontrol = 0;
            int j = 0;
            int paraCount = metin.Split('\n').Length;
            string[] dizi = new string[paraCount];
            dizi = metin.Split('\n');
            for (int i = 0; i < paraCount; i++)
            {
                if (dizi[i].Contains("GİRİŞ") || dizi[i].Contains("Giriş"))
                {
                    for (; ; )
                    {
                        if (j >= paraCount || dizi[j].Contains("2."))
                        {
                            break;
                        }
                        else if (dizi[j].Contains("kapsam") || dizi[j].Contains("Kapsam") || dizi[j].Contains("Bu tez çalışmasında") || dizi[j].Contains("Bu tez çalışması") || dizi[j].Contains("Bu tezde") || dizi[j].Contains("Bu çalışmada"))
                        {
                            kontrol = 1;
                            break;
                        }
                        else
                        {
                            kontrol = 2;
                        }
                        j++;
                    }
                    break;
                }
                if (kontrol == 2)
                {
                    break;
                }
            }
            if (kontrol == 2)
            {
                richTextBox1.Text += "\n\nGiriş kısmında Kapsam ve Organizasyona yer verilmemiştir.";
            }
        }

        public void denklemKontrol(string metin)
        {
            int sayi = 2;
            int j = 0;

            bool kontrol = true;
            int paraCount = metin.Split('\n').Length;
            string[] dizi = new string[paraCount];
            dizi = metin.Split('\n');
            for (int i = 0; i < paraCount; i++)
            {
                string denklem = sayi.ToString() + ". ";
                string denklem2 = (sayi + 1).ToString() + ". ";
                if (dizi[i].Contains(denklem))
                {
                    j = i;
                    while (true)
                    {
                        if (j >= paraCount)
                        {
                            break;
                        }
                        if (dizi[j].Contains("Denklem " + (sayi + 1).ToString()) || dizi[j].Contains("Denklem " + (sayi + 2).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi + 3).ToString()) || dizi[j].Contains("Denklem " + (sayi + 4).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi + 5).ToString()) || dizi[j].Contains("Denklem " + (sayi + 6).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi + 7).ToString()) || dizi[j].Contains("Denklem " + (sayi + 8).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi + 9).ToString()) || dizi[j].Contains("Denklem " + (sayi + 10).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi - 1).ToString()) || dizi[j].Contains("Denklem " + (sayi - 2).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi - 5).ToString()) || dizi[j].Contains("Denklem " + (sayi - 6).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi - 7).ToString()) || dizi[j].Contains("Denklem " + (sayi - 8).ToString()) ||
                            dizi[j].Contains("Denklem " + (sayi - 9).ToString()) || dizi[j].Contains("Denklem " + (sayi - 10).ToString()))
                        {
                            kontrol = false;
                            break;
                        }
                        if (dizi[j].Contains(denklem2))
                        {
                            sayi++;
                            break;
                        }
                        j++;
                    }
                }
                if (kontrol == false)
                {
                    break;
                }
            }

            if (kontrol == false)
            {
                richTextBox1.Text += "\n\nDenklem numarası ve bölüm başlığı arasında uyuşmazlık vardır.";
            }
        }

        public void tabloKontrol(string metin)
        {

        }
    }    
}

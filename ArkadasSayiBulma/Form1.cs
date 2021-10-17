using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkadasSayiBulma
{
    public partial class Form1 : Form
    {
        /* Global olarak tanımladığımız değişkenler aşağıdadır. Arkadaş mı butonuna tıkladıktan sonra dinamik olarak eklenmesi için
           ve verileri bu eventlere yazdırmakta kullanacağımız yapıdır.
        */
        // dinamik olarak ekleyeceğimiz textbox değişkeni. Girilen sayının çarpanlarının toplamını gösterecektir.
        public TextBox textbox;
        // dinamik olarak ekleyeceğimiz listbox değişkeni. Girilen sayının çarplanlarını tek tek burada gösterilecektir.
        public ListBox listbox;
        // dinamik olarak ekleyeceğimiz label değişkeni. X,Y ve TOPLAMLAR olarak Text özelliğinden yararlanacağımız label.
        public Label label;
        // XsayisiCarpanToplam değişkenine girilen X sayısının çarpanlarının toplamı atanacaktır.
        int XsayisiCarpanToplam = 0;
        // YsayisiCarpanToplam değişkenine girilen Y sayısının çarpanlarının toplamı atanacaktır.
        int YsayisiCarpanToplam = 0;
        // Sayıların arkadaş mı olup olmadıklarını yazdıracağımız string bir mesaj;
        string mesaj;
        // Arkadaş mı butonuna bir kere basmamızı sağlar böylelikle eventler ve olaylar tekrarlanmaz.
        int sayac = 0;
        // textbox1de ki girilecek olan sayıya atanan değer ( X sayısı )
        int GirilenXSayisi;
        // textbox2de ki girilecek olan sayıya atanan değer ( Y sayısı )
        int GirilenYSayisi;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ARKADAŞ MI BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            // sayac 0 iken buton bir kere çalışacak
            if(sayac == 0)
            {
                // herhangi bir karakter girilmez ise veya 0 girilirse boş karakter girilmez mesajı gösterecektir ve tekrar dönecektir.
                if ((textBox1.Text == "" || textBox2.Text == "") || (textBox1.Text == "0" || textBox2.Text == "0"))
                {
                    
                    MessageBox.Show("BOŞ KARAKTER GİRİLEMEZ! veya  0 KARAKTERİ KULLANILAMAZ!");
                    return;
                }
                // girilen X sayısını int tipine dönüştürüyoruz
                GirilenXSayisi = Convert.ToInt32(textBox1.Text);
                // girilen Y sayısını int tipine dönüştürüyoruz
                GirilenYSayisi = Convert.ToInt32(textBox2.Text);
               

                #region Dinamik Events
                // butona tıklandıktan sonra formun boyutunu tekrar belirliyoruz.
                Size = new Size(750, 420);


                // burada for 2 kere dönüldü çünkü label 3 textbox 2  listbox 2 kere oluşturulacağından, textbox'un eksik kalanını aşağıda belirledik böylelikle daha kolay oldu
            for (int i = 0; i < 2; i++)
            {
                    // her döngüde tekrar newleyerek yeni bir textbox oluşturuyor.
                textbox = new TextBox();
                    // her döngüde tekrar newleyerek yeni bir listbox oluşturuyor.
                    listbox = new ListBox();
                    // her döngüde tekrar newleyerek yeni bir label oluşturuyor.
                    label = new Label();
                    // label 2 TOPLAMLAR texti için kullanılacaktır.
                    label2 = new Label();

                    // birinci döngüdeki olayları yakalamak için böyle bir if yapısı oluşturulmak zorunda kalındı.
                    // genelde 2 adet dinamik event oluşturulacağı için birinci döngüde ve (else) 2. döngüde yapılacaklar belirlendi.
                if (i == 0)
                {
                    //label text özelliğine X atandı
                    label.Text = "X";
                    //label ın pozisyonu set edildi
                    label.Location = new Point(400, 20);
                    //listbox ın boyutları set edildi
                    listbox.Size = new Size(125, 250);
                    //listbox ın pozisyonu set edildi
                    listbox.Location = new Point(350, 60);
                    //textbox ın boyutları set edildi
                    textbox.Size = new Size(125, 50);
                    //textbox ın pozisyonu set edildi
                    textbox.Location = new Point(350, 320);
                    // label2 nin boyutu set edildi
                    label2.Size = new Size(100, 100);
                    // label2 nin texti set edildi
                    label2.Text = "TOPLAMLAR ";
                    // label2 nin pozisyonu set edildi
                    label2.Location = new Point(275, 323);

                        
                        //Burada girilen X sayısının çarpanlarını ayırma işlemini yapıyoruz.
                        //j yi 1 den başlatmak şartıyla girilen sayıdan küçük oluncaya kadar..
                        for (int j = 1; j < GirilenXSayisi; j++)
                    {
                            //ve eğer X sayısı 1 den başlayıp X sayısına kadar olan sayıların ( teker teker )
                            if (GirilenXSayisi % j == 0)
                        {

                           
                                // modu yani 0 a kalansız bölünüyorsa ( çarpanlarıdır bunlar ) bu sayıları listboxa ekle.
                                listbox.Items.Add(j);
                                //Her çarpanı XsayisiCarpanToplam a toplayarak set et.
                               XsayisiCarpanToplam += j;
                                // ve son olarak textbox değerine XsayisiCarpanToplam değerini set et.
                                textbox.Text = XsayisiCarpanToplam.ToString();
                        }
                    }
                }

                else
                {
                    // label2 ye Y set edildi.
                    label.Text = "Y";
                    //label ın pozisyonu set edildi
                    label.Location = new Point(600, 20);
                    //listbox ın boyutu set edildi
                    listbox.Size = new Size(125, 250);
                    //listbox ın pozisyonu set edildi
                    listbox.Location = new Point(550, 60);
                    //textbox ın boyutları set edildi.
                    textbox.Size = new Size(125, 50);
                    //textbox ın pozisyonu set edildi.
                    textbox.Location = new Point(550, 320);


                        //Girilen Y sayısının çarpanlarını ayırma işlemini yapıyoruz.
                        //j yi 1 den başlatmak şartıyla girilen sayıdan küçük oluncaya kadar..
                        for (int j = 1; j < GirilenYSayisi; j++)
                    {
                            //ve eğer X sayısı 1 den başlayıp Y sayısına kadar olan sayıların ( teker teker )
                            if (GirilenYSayisi % j == 0)
                        {
                          
                            // modu yani 0 a kalansız bölünüyorsa ( çarpanlarıdır bunlar ) bu sayıları 2.listboxa ekle.
                            listbox.Items.Add(j);
                            //Her çarpanı YsayisiCarpanToplam a toplayarak set et.
                            YsayisiCarpanToplam += j;
                            // ve son olarak textbox değerine YsayisiCarpanToplam değerini set et.
                            textbox.Text = YsayisiCarpanToplam.ToString();
                        }

                    }

                }
                // girilen X ve Y ortak oldukları için (boyutları) sorgu dışında set ediyoruz.
                label.Size = new Size(35, 35);

                // formumuza dinamik olarak label' i ekliyoruz.   
                Controls.Add(label);
                // formumuza dinamik olarak listbox' ı ekliyoruz.
                Controls.Add(listbox);
                // formumuza dinamik olarak textbox' ı ekliyoruz.
                Controls.Add(textbox);
                // formumuza dinamik olarak label2' yi ekliyoruz.
                Controls.Add(label2);
            }
            
            #endregion
            // girilen x sayısı ile Girilen Y sayısının çarplanları toplamı eşit ise ve girilen y sayısı ile Girilen X sayısının çarpanları toplamı eşit ise
            if (GirilenXSayisi == YsayisiCarpanToplam && GirilenYSayisi == XsayisiCarpanToplam)
            {
                    // mesaja bu 2 sayı arkadaştır ı set ediyoruz
                mesaj = "Bu 2 Sayı ARKADAŞ !";
            }
            // değilse
            else
                    // bu 2 sayı arkadaş değişdiri set ediyoruz ve..
                mesaj = "Bu 2 Sayı ARKADAŞ DEĞİL !";
            // kullanıcıya burada mesajı gösteriyoruz.
            MessageBox.Show(mesaj);
            }
            // sayacı bir kere attırarak butona bir daha basma iznini ortadan kaldırıyoruz.
            sayac++;
        }



        // BOŞ.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        // textbox1 e sadece rakam girilmesine izin verildi
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // textbox2 ye sadece rakam girilmesine izin verildi.
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // Son butonu ile uygulamadan çıkılıyor.
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

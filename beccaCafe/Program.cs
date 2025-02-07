using System.Xml.Serialization;
using System.Threading;
using System.Drawing;
using System.ComponentModel.Design;

int[] HesapMasa = { 0, 0, 0, 0, 0 };
int masanumarasi=-1;
// İşlem menusu dizisi
string[] islemler = { "Masa Aç[1]", "Masa İşlem[2]", "Masa Hesap[3]", "Çıkış [0]" };
//toplamda 5 masa vardır. 1 ve 3. masalar doludur. 
string[] masalar = { "MASA[1]___[BOŞ]", "MASA[2]___[BOŞ]", "MASA[3]___[DOLU]", "MASA[4]___[BOŞ]", "MASA[5]___[DOLU]" };

while (true)
{
    Console.WriteLine("                 ANA MENU                     ");

    
    for (int i = 0; i < islemler.Length; i++) { Console.WriteLine("\t" + islemler[i]); }

    Console.Write(" İşlem numarasını girin: ");
    string islem = Console.ReadLine();
    Console.WriteLine("\n \n -----------------------------------------\n \n");

    if (islem == "1")
    {

        for (int i = 0; i < masalar.Length; i++) { Console.WriteLine("\t" + masalar[i]); }
        //Console.Write("Hangi masayı açıyorsunuz:  ");

        while (true)  // BURADA masalar dizisindeki elemanların içinde DOLU harfleri varsa masa dolu uyarısını vereceğiz.
        {
            Console.WriteLine("Önceki menüye dönmek için ESC tuşuna basın.. yoksa Enter tuşuna basın. . .");

            // Tuşları hemen oku
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape) // ESC tuşuna basıldı mı?
            {
                Console.WriteLine("ESC tuşuna basıldı, Ana menüye dönülüyor...");
                break;
            }
           
            Console.Write("Hangi masayı açıyorsunuz:  ");
            //ConsoleKeyInfo key = Console.ReadKey(true); // Tuşu oku ama ekrana yazma

            string input = Console.ReadLine();
            if (!int.TryParse(input, out masanumarasi))
            {
                Console.WriteLine("Geçersiz giriş, lütfen bir masa numarası giriniz.");
                continue;
            }

            if (masanumarasi < 1 || masanumarasi > 5)
            {
              
                Console.WriteLine("Yanlış masa seçimi tekrar masa numarasını giriniz: ");
                continue;
            }
            if (masalar[masanumarasi - 1].Contains("DOLU"))
            {
            Console.WriteLine("Bu masa Doludur, farklı bir masa seçiniz...");

                continue;
            }

           
            else
            {
                break;
            }
        }
        if (masanumarasi > 0)
        {
            masalar[masanumarasi - 1] = "MASA" + (masanumarasi) + "___[DOLU]";
            Console.Write("------------" + masanumarasi + ". Masa Açılmıştır."); Thread.Sleep(1000); Console.Write("Menüye dönülüyor."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(600); Console.WriteLine("."); Thread.Sleep(500);
            foreach (string m in masalar) { Console.WriteLine(m); }
        }

    }


    int hesapToplam = 0;
    String[] hesapMenu = new String[10];
   
    Console.ForegroundColor = ConsoleColor.Green;

    //MENULERIN GÖSTERİMİ 
    if (islem =="2")
    {
        Console.Write("Hangi masanın işlemi yapılacak: ");
        masanumarasi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("                           ------------------------------MENULER------------------------------ ");
        string[] Menu_icecek = { "Kola-- 40 TL", "Ayran-- 30 TL", "Su-- 10 TL" };
        string[] Menu_Kebap = { "Adana Kebap-- 200 TL", "Tavuk Şiş-- 170 TL", "Ciğer Kebabı-- 220 TL" };
        string[] Menu_Pizza = { "Karışık Pizza -- 160 TL", "Vegan Pizza-- 150 TL", "Mozeralla Pizza-- 160 TL" };
        string[] Menu_Tatli = { "Künefe-- 120 TL", "Baklava-- 140 TL", "Sütlaç-- 65 TL" };

        //Tüm menülerdeki harf sayısı en uzun menünün uzunluğunu aldık
        int enbuyuk = 0, uzunluk1 = 0, uzunluk2 = 0;
        for (int i = 0; i < 3; i++)
        {
            uzunluk1 = Math.Max(Menu_icecek[i].Length, Menu_Kebap[i].Length);
            uzunluk2 = Math.Max(Menu_Pizza[i].Length, Menu_Tatli[i].Length);
            // Console.WriteLine("uzunluk1" + uzunluk1 + "   UZUNLUK2" + uzunluk2);
            if (uzunluk1 > enbuyuk) { enbuyuk = uzunluk1; }
            if (uzunluk2 > enbuyuk) { enbuyuk = uzunluk2; }
            // Console.WriteLine("en uzun kısım : " + enbuyuk); 

        }
        Console.WriteLine("\t   KEBAPLAR[K]" + new string(' ', enbuyuk) + " PİZZALAR[P]" + new string(' ', enbuyuk) + "İÇECEKLER[İ]" + new string(' ', enbuyuk - 8) + "TATLILAR[T]");
        for (int i = 0; i < 3; i++)
        {
            int boslukkebap = enbuyuk + 7 - Menu_Kebap[i].Length;
            int boslukicecek = enbuyuk + 7 - Menu_icecek[i].Length;
            int boslukpizza = enbuyuk + 7 - Menu_Pizza[i].Length;
            int bosluktatli = enbuyuk + 7 - Menu_Tatli[i].Length;
            Console.WriteLine("\t" + Menu_Kebap[i] + new string(' ', boslukkebap) + Menu_Pizza[i] + new string(' ', boslukpizza) + Menu_icecek[i] + new string(' ', boslukicecek) + Menu_Tatli[i]);


        }
        //MENU SECİM EKRANI 
        string secimtus = " ";
        while (secimtus != "b")
        {

            Console.Write("  MENU SEÇİNİNİZ:[K,P,T,İ] ");
            string secilenmenu = Console.ReadLine();


            //kebap SEÇMEK İÇİN k VEYA K tuşlarına basılır 
            if (secilenmenu == "k" || secilenmenu == "K")
            {

                for (int i = 0; i < Menu_Kebap.Length; i++)
                {
                    Console.WriteLine("\t " + (i + 1) + ". " + Menu_Kebap[i]);
                }
                Console.WriteLine("Hangi Kebap siparişi alındı ?[1,2,3]: ");

                string kebapsecimi = Console.ReadLine();
                if (kebapsecimi == "1")
                {
                    hesapToplam = hesapToplam + 200;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Kebap[0]; break; } i++; }
                }
                if (kebapsecimi == "2")
                {
                    hesapToplam = hesapToplam + 170;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Kebap[1]; break; } i++; }
                }

                if (kebapsecimi == "3")
                {
                    hesapToplam = hesapToplam + 220;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Kebap[2]; break; } i++; }
                }
                Console.Write("(Devam etmek için herhagi bir tuşa basın)  Menuyu bitirmek için b ye basın: ");
                secimtus = Console.ReadLine();

            }


            //pizza SEÇMEK İÇİN P VEYA p tuşlarına basılır 
            if (secilenmenu == "P" || secilenmenu == "p")
            {
                for (int i = 0; i < Menu_Pizza.Length; i++)
                {
                    Console.WriteLine("\t " + (i + 1) + ". " + Menu_Pizza[i]);
                }
                Console.WriteLine("Hangi Pizza siparişi alındı ?[1,2,3]: ");

                string pizzaSecimi = Console.ReadLine();
                if (pizzaSecimi == "1")
                {
                    hesapToplam = hesapToplam + 160;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Pizza[0]; break; } i++; }
                }
                if (pizzaSecimi == "2")
                {
                    hesapToplam = hesapToplam + 150;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Pizza[1]; break; } i++; }
                }

                if (pizzaSecimi == "3")
                {
                    hesapToplam = hesapToplam + 160;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Pizza[2]; break; } i++; }
                }
                Console.Write("(Devam etmek için herhagi bir tuşa basın) Menuyu bitirmek için b ye basın: ");
                secimtus = Console.ReadLine();
            }


            //İÇECEK SEÇMEK İÇİN İ VEYA i tuşlarına basılır 
            if (secilenmenu == "i" || secilenmenu == "İ")
            {
                for (int i = 0; i < Menu_icecek.Length; i++)
                {
                    Console.WriteLine("\t " + (i + 1) + ". " + Menu_icecek[i]);
                }
                Console.WriteLine("Hangi İçecek siparişi alındı ?[1,2,3]: ");

                string icecekSecimi = Console.ReadLine();
                if (icecekSecimi == "1")
                {
                    hesapToplam = hesapToplam + 40;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_icecek[0]; break; } i++; }
                }
                if (icecekSecimi == "2")
                {
                    hesapToplam = hesapToplam + 30;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_icecek[1]; break; } i++; }
                }

                if (icecekSecimi == "3")
                {
                    hesapToplam = hesapToplam + 10;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_icecek[2]; break; } i++; }
                }
                Console.Write("(Devam etmek için herhagi bir tuşa basın) Menuyu bitirmek için b ye basın: ");
                secimtus = Console.ReadLine();
            }

            //Tatlı seçmek için "t" veya "T" tuşlarına basılır
            if (secilenmenu == "t" || secilenmenu == "T")
            {
                for (int i = 0; i < Menu_Tatli.Length; i++)
                {
                    Console.WriteLine("\t " + (i + 1) + ". " + Menu_Tatli[i]);
                }
                Console.WriteLine("Hangi İçecek siparişi alındı ?[1,2,3]: ");

                string tatliSecimi = Console.ReadLine();
                if (tatliSecimi == "1")
                {
                    hesapToplam = hesapToplam + 120;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Tatli[0]; break; } i++; }
                }
                if (tatliSecimi == "2")
                {
                    hesapToplam = hesapToplam + 140;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Tatli[1]; break; } i++; }
                }

                if (tatliSecimi == "3")
                {
                    hesapToplam = hesapToplam + 65;
                    int i = 0;
                    while (i < hesapMenu.Length) { if (hesapMenu[i] == null) { hesapMenu[i] = Menu_Tatli[2]; break; } i++; }
                }
                Console.Write("(Devam etmek için herhagi bir tuşa basın) Menuyu bitirmek için b ye basın: ");
                secimtus = Console.ReadLine();


            }

            HesapMasa[masanumarasi - 1] = hesapToplam;
        }
        if (secimtus == "b")
        {
            Console.Clear();
            Console.WriteLine("\tTOPLAM HESAP : " + HesapMasa[masanumarasi - 1]);
            for (int i = 0; i < hesapMenu.Length; i++)
            {
                Console.WriteLine("\t" + hesapMenu[i]);
            }
            HesapMasa[masanumarasi - 1] = hesapToplam;
            Thread.Sleep(500);Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(800); Console.Write("."); Thread.Sleep(1000);
        }
    }

    Console.Clear();

    if (islem == "3")
    {
        Console.Write("Hangi masanın hesabı isteniyor?: ");
        masanumarasi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\tTOPLAM HESAP : " + HesapMasa[masanumarasi-1]);

        Thread.Sleep(2000);

    }
    if (islem == "0") { Console.Clear(); Console.WriteLine("İŞLEMLER BİTİRİLMİŞTİR.."); Thread.Sleep(1000); Console.Write("Çıkış sağlanıyor."); Thread.Sleep(700); Console.Write( " ."); Thread.Sleep(700); Console.Write(" ."); return; }
    
    Console.Clear();
}
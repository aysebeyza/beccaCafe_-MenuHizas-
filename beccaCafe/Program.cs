
/*
string[] masalar = { "MASA[1]-- BOŞ", "MASA[2]-- BOŞ", "MASA[3]-- DOLU", "MASA[4] -- BOŞ", "MASA[4]-- BOŞ" };
for (int i = 0; i < masalar.Length; i++)
{
    Console.WriteLine(masalar[i]);
}
Console.Write("MASA SEÇİNİZ(1,2,3,4): ");
int secilennumara=Convert.ToInt16(Console.ReadLine());
/*if(secilennumara!=1 || secilennumara!=2 || secilennumara!=3 || secilennumara!=4)
{
    Console.WriteLine("yanlış giriş yaptınız lütfen masa numarasını giriniz(1,2,3,4): ");
    
/
if (masalar[secilennumara-1].Contains("DOLU"))
{
    Console.WriteLine("Seçtiğiniz masa dolu lütfen boş masa seçiniz!!!");
}
else
{
    masalar[secilennumara-1]= masalar[secilennumara - 1].Replace("BOŞ", "DOLU");
}

for(int i = 0; i < masalar.Length; i++)
{
    Console.WriteLine(masalar[i]);
}

*/
Console.WriteLine("MENULER");
string [] Menu_icecek = {" Kola-- 40 TL"," Ayran-- 30 TL", " Su-- 10 TL"};
string[] Menu_Kebap = { "Adana Kebap-- 200 TL", "Tavuk Şiş-- 170 TL", "Ciğer Kebabı-- 220 TL" };
string[] Menu_Pizza = { "Karışık Pizza -- 160 TL", "Vegan Pizza-- 150 TL", "Mozeralla Pizza-- 160 TL" };
string[] Menu_Tatli = { "Künefe-- 120 TL", " Baklava-- 140 TL", "Sütlaç-- 65 TL" };

//Tüm menülerdeki harf sayısı en uzun menünün uzunluğunu aldık
int enbuyuk = 0, uzunluk1 = 0, uzunluk2 = 0;
for (int i = 0; i< 3; i++)
{
    uzunluk1 = Math.Max(Menu_icecek[i].Length, Menu_Kebap[i].Length);
    uzunluk2 = Math.Max(Menu_Pizza[i].Length, Menu_Tatli[i].Length);
   Console.WriteLine("uzunluk1" + uzunluk1 + "   UZUNLUK2" + uzunluk2);
    if (uzunluk1 > enbuyuk) { enbuyuk = uzunluk1; }
    if (uzunluk2 > enbuyuk) { enbuyuk = uzunluk2; }
  // Console.WriteLine("en uzun kısım : " + enbuyuk); 
  
}
Console.WriteLine("\t KEBAPLAR" + new string(' ', enbuyuk) + " PİZZALAR" + new string(' ', enbuyuk) + "   İÇECEKLER" + new string(' ', enbuyuk) + "    TATLILAR ");
for (int i =0; i<3; i++)
{
    int boslukkebap = enbuyuk + 10 - Menu_Kebap[i].Length;
    int boslukicecek = enbuyuk + 10 - Menu_icecek[i].Length;
    int boslukpizza = enbuyuk + 10 - Menu_Pizza[i].Length;
    int bosluktatli = enbuyuk + 10 - Menu_Tatli[i].Length;
    Console.WriteLine("\t" + Menu_Kebap[i] + new string(' ', boslukkebap) + Menu_Pizza[i] + new string(' ', boslukpizza) + Menu_icecek[i] + new string(' ', boslukicecek) + Menu_Tatli[i]);


}
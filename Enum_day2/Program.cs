using System;
using System.Security.Cryptography.X509Certificates;

[Flags] // Flags attribute kullanımı
enum DosyaIzinleri
{
    Yok = 0,
    Okuma = 1,
    Yazma = 2,
    Calistirma = 4,
    Test = Yok | Okuma | Yazma | Calistirma
}

class Program
{
    static void Main1()
    {
        // Dosya izinlerini ayarlama
        DosyaIzinleri izinler = DosyaIzinleri.Test;

        // Dosya izinlerini kontrol etme
        if (izinler.HasFlag(DosyaIzinleri.Okuma))
        {
            Console.WriteLine("Okuma izni var.");
        }

        // Dosya izinlerini güncelleme
        izinler |= DosyaIzinleri.Calistirma;

        // Güncellenmiş izinleri yazdırma
        Console.WriteLine(izinler);  // Okuma, Yazma, Calistirma
    }
    static void Main(string[] args)
    {
        paral
    }
}
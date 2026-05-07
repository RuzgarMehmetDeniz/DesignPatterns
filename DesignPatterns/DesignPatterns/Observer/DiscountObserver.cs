using DesignPatterns.Entites;
using System;
namespace DesignPatterns.DesignPatterns.Observer
{
    public class DiscountObserver : IObserver
    {
        public void CreateObserver(CustomerProcess process)
{
    decimal eskiFiyat = process.Product.Price;  
    decimal yeniFiyat = eskiFiyat / 2;
    string mesaj = $"📢 MÜJDE: Sayın {process.CustomerName}, beklediğiniz fırsat geldi!\n" +
                   $"🥒 {process.Product.Name} ürününde %50 dev indirim başladı!\n" +
                   $"❌ Eski Fiyat: {eskiFiyat:C2}\n" +
                   $"✅ İndirimli Fiyat: {yeniFiyat:C2}\n" +
                   $"Kaçırmamak için hemen organikmarket.com üzerinden sipariş verin! 🌿";
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine($"[BİLDİRİM GÖNDERİLDİ] -> {process.CustomerName}");
    Console.WriteLine("MESAJ İÇERİĞİ:");
    Console.WriteLine(mesaj);
    Console.WriteLine("-----------------------------------------------");
}
    }
}

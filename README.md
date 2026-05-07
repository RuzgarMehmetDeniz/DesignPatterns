
# 🌿 Meyve & Sebze Satış Platformu — Design Patterns Uygulaması

Günlük hayatımızın vazgeçilmezi olan taze meyve ve sebzelerin online ortamda satışını yönetmek için geliştirilmiş bu platform, aynı zamanda modern yazılım mimarisinin nasıl kurulması gerektiğini gösteren teknik bir çalışmadır. Kullanıcı sipariş verdiği andan ödemeyi tamamladığı ana kadar geçen her adım, birbirinden bağımsız ve tek sorumluluğu olan yazılım bileşenleri tarafından yönetilir. Sistemin tüm verileri Microsoft SQL Server üzerinde tutulmakta, .NET 8 ile geliştirilen backend katmanı aracılığıyla dinamik olarak işlenerek kullanıcıya sunulmaktadır.

---

## 🏗️ Kullanılan Tasarım Kalıpları

**🔔 Observer Pattern —** Sistemdeki bir veri değiştiğinde, o veriye bağlı tüm bileşenler otomatik olarak haberdar edilir. Fiyat güncellemesi yapıldığında bunu manuel kontrol etmek yerine sistem kendisi ilgili yerlere bildirir.

**⛓️ Chain of Responsibility —** Bir işlemin tamamlanması için geçmesi gereken adımlar zincir halinde sıralanır. Her halka yalnızca kendi kontrolünü yapar. Stok yok mu, zincir orada kırılır. Her şey yolundaysa bir sonraki adıma geçilir.

**♟️ Strategy Pattern —** Aynı işlemi farklı yollarla yapabilmek için kullanılır. Örneğin indirim hesaplama; toplu alım mı, mevsimsel mi yoksa standart mı olacak kararı çalışma zamanında verilir, mevcut kod bozulmaz.

**🎨 Decorator Pattern —** Bir nesneye temel yapısını değiştirmeden yeni özellikler ekler. Ürün fiyatına KDV, organik etiketi veya kampanya fiyatı katman katman giydirilir, her katman birbirinden habersiz çalışır.

**🗄️ Repository & Unit of Work —** Veritabanı işlemleri iş mantığından ayrılır ve standart bir yapıya kavuşturulur. Birden fazla işlem tek transaction altında çalışır, hata olursa hepsi geri alınır, yarım kayıt oluşmaz.

---

## 📸 Ekran Görüntüleri

### 🌐 Ana Sayfa
> Veritabanından gelen ürünler, kategoriler ve kampanyalar dinamik olarak ana sayfaya yansır. Admin panelindeki her değişiklik sayfayı yenilemeden anında görünür.

<img width="1350" alt="Default1" src="https://github.com/user-attachments/assets/90b6eec4-7afa-49c7-9188-e81b185172c1" />

---

### 📦 Ürün Listeleme ve Kategori Sayfası
> Meyve, sebze ve diğer ürün grupları kategorilere ayrılmış şekilde listelenir. Filtreleme ve sıralama işlemleri Repository katmanı üzerinden SQL'e iletilir.

<img width="1350" alt="Default2" src="https://github.com/user-attachments/assets/d67818de-57d6-42e0-b1df-9dc85f9ad597" />

---

<img width="1341" alt="Default3" src="https://github.com/user-attachments/assets/dd34e020-b7e5-4611-bcd4-66415c15cc83" />

---

### 💠 Ürün Detay Sayfası
> Ürün fiyatı KDV ve kampanya hesabıyla birlikte gösterilir. Hangi indirim algoritmasının çalışacağına bu sayfada karar verilir.

<img width="1350" alt="Prodcut1" src="https://github.com/user-attachments/assets/d97e0dee-623d-4a65-ac11-64019746ca65" />

---

### 🛒 Ürün Kartları ve Kullanıcı Arayüzü
> SQL'den gelen ürün görseli, fiyat ve stok bilgisi her kart için ayrı ayrı çekilir. Sepete ekleme işlemleri tutarlı ve hatasız çalışır.

<img width="1351" alt="Basket1" src="https://github.com/user-attachments/assets/cd9b0544-d18d-47fc-817a-05d907469b0f" />

---

### ⛓️ Sepet ve Ödeme Süreci
> Kullanıcı ödemeye geçtiğinde stok kontrolü, adres doğrulama ve ödeme onayı sırasıyla işlenir. Herhangi bir adımda sorun çıkarsa süreç orada durur.
<img width="1351" alt="Card1" src="https://github.com/user-attachments/assets/4b2b325e-9f2f-413d-a47e-7943bbb3ce0c" />

---
### ⚡ Admin — Ürün Yönetimi
> Ürün fiyatı, görseli veya stok durumu buradan güncellenir. Yapılan değişiklik kullanıcı arayüzüne anında yansır.

<img width="1344" alt="AdminProduct" src="https://github.com/user-attachments/assets/eb1dccf8-6dbe-4a3c-91d9-a507d3ecca93" />

---

### 📋 Admin — Sipariş Takibi
> Gelen siparişlerin hangi aşamada olduğu burada izlenir. Siparişin durumu merkezi olarak görüntülenir ve yönetilir.

<img width="1363" alt="AdminOrder" src="https://github.com/user-attachments/assets/80856533-1d65-489e-b227-3314c536aadc" />

---

### 🗂️ Admin — Kategori Yönetimi
> Ürün kategorileri buradan eklenir ve düzenlenir. Kategori verileri standart bir yapıda veritabanına yazılır ve okunur.

<img width="1153" alt="AdminCategory" src="https://github.com/user-attachments/assets/17fdad97-9738-458c-ae58-bbc53a9573af" />

---

### 📝 Admin — Blog Yönetimi
> Platform üzerinden yayınlanan içerikler buradan yönetilir. Eklenen her içerik veritabanına kaydedilerek arayüze dinamik olarak yansır.

<img width="1351" alt="AdminBlog" src="https://github.com/user-attachments/assets/493230fb-6bd2-4299-8ca7-de281fbd1cea" />

---

### 🖼️ Admin — Banner Yönetimi
> Ana sayfadaki görsel kampanyalar ve duyurular buradan güncellenir. Yapılan değişiklik anında kullanıcıya yansır.

<img width="1365" alt="AdminBanner" src="https://github.com/user-attachments/assets/40cb4db7-2bc8-4172-939f-cad29fbfa98d" />

---
### ✅ Sipariş Onay Sayfası
> Ödeme süreci tamamlandığında kullanıcıya sipariş onay ekranı gösterilir. Mutfağa iletilen sipariş hazırlanmaya başlar.

<img width="542" alt="OrderOkey" src="https://github.com/user-attachments/assets/155d2998-40a7-4c90-86c7-ba6a2559a375" />
---


### 🏢 Admin — Kurumsal Sayfa Yönetimi (About)
> Hakkımızda ve kurumsal bilgi alanları sabit HTML yerine veritabanından gelir. Yönetici panelinden yapılan düzenleme sayfaya anında yansır.

<img width="1361" alt="Adminabout" src="https://github.com/user-attachments/assets/29345c1f-1024-43b1-af8b-6d3c5e17c1f7" />

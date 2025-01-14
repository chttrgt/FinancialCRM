# Finansal CRM Uygulaması

Bu proje, C# ve Entity Framework kullanarak "Database First" yaklaşımı ile geliştirilmiş bir Finansal CRM uygulamasıdır. Uygulama, müşterilerin finansal bilgilerini yönetmek, işlem geçmişlerini takip etmek ve analizler sağlamak için tasarlanmıştır.

**Not: Bu proje, eğitim amaçlı geliştirilmiştir ve üretim ortamında kullanılmak üzere optimize edilmemiştir.**
### Eğitmen: Murat Yücedağ

---

## 🚀 Başlarken

Bu rehber, projenin çalıştırılmasını ve geliştirilmesini kolaylaştırmak için adım adım talimatlar sunar.

### Gereksinimler

- .NET 6 veya üzeri
- Microsoft SQL Server
- Visual Studio 2022 veya üzeri

---

## 📂 Proje Yapısı

```
📦 FinancialCRM
├── 📁 Models             # Entity Framework modelleri
├── 📁 Data               # Veritabanı bağlantı ve bağlam dosyaları
├── 📁 Controllers        # İş mantığı ve API uç noktaları
├── 📁 Views              # Kullanıcı arayüzü (MVC kullanıyorsanız)
├── 📁 Services           # İş hizmetleri katmanı
├── 📄 Program.cs         # Ana giriş noktası
├── 📄 README.md          # Proje açıklama dosyası
```

---

## 🔧 Kurulum ve Çalıştırma

### 1. Veritabanını Hazırlayın
1. Microsoft SQL Server'ı başlatın.
2. Proje için kullanılacak bir veritabanı oluşturun. Örneğin:
   ```sql
   CREATE DATABASE FinancialCRM;
   ```
3. Veritabanınızı tablolarla doldurmak için gerekli SQL scriptlerini çalıştırın (örnek scriptler `scripts/` klasöründe bulunabilir).

### 2. Projeyi Çalıştırın

#### A. Entity Framework Database First Ayarları
1. Entity Framework Core Tools yükleyin:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
2. Veritabanı modellerini oluşturmak için aşağıdaki komutu çalıştırın:
   ```bash
   dotnet ef dbcontext scaffold "Server=YOUR_SERVER;Database=FinancialCRM;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
   ```
   
#### B. Projeyi Başlatın
1. Projeyi Visual Studio ile açın.
2. `appsettings.json` dosyasındaki veritabanı bağlantı dizgisini yapılandırın.
3. Çözümü derleyip çalıştırın.

---

## 🌟 Özellikler

- **Müşteri Yönetimi:** Müşteri bilgilerini ekleyin, düzenleyin ve görüntüleyin.
- **Finansal İşlemler:** Gelir ve gider işlemlerini yönetin.
- **Analiz ve Raporlama:** Müşteri bazlı finansal raporlar oluşturun.
- **Güvenlik:** Kullanıcı doğrulama ve yetkilendirme.

---

## 📸 Ekran Görüntüleri

### DashBoard
![Proje Görseli](FinancialCRM/Images/dashboard.png)

### Banks Form
![Proje Görseli](FinancialCRM/Images/banks.png)

### Bills Form
![Proje Görseli](FinancialCRM/Images/bills.png)
---

## 🛠 Kullanılan Teknolojiler

- **Backend:** ASP.NET Core, Entity Framework Core
- **Frontend:** Razor Pages veya MVC (isteğe bağlı Angular/React)
- **Veritabanı:** Microsoft SQL Server

---

## 📌 Katkıda Bulunma

1. Projeyi forklayın.
2. Yeni bir dal oluşturun: `git checkout -b yeni-ozellik`
3. Değişikliklerinizi ekleyin ve commit yapın: `git commit -am 'Yeni özellik ekleme'`
4. Dalınıza push yapın: `git push origin yeni-ozellik`
5. Bir Pull Request oluşturun.

---

## 📞 İletişim

Herhangi bir sorunuz varsa, [e-posta adresi](mailto:ornek@ornek.com) üzerinden bizimle iletişime geçebilirsiniz.

---

**Not:** Projeyi ilk kez kuruyorsanız, karşılaşabileceğiniz yaygın hatalar ve çözümleri için `TROUBLESHOOTING.md` dosyasına göz atın.

# musteri-otomasyon
C# dilinde geliştirilmiş, WinForms ve ADO.NET teknolojilerini kullanan bir müşteri yönetim otomasyonu. Uygulama, müşteri kaydı ekleme, silme, güncelleme ve farklı kriterlere göre arama yapma gibi temel CRUD işlemlerini güvenli bir şekilde gerçekleştirir.
Özellikler
Veri Yönetimi: Müşteri verilerini veritabanına ekleme, silme, güncelleme ve görüntüleme.
Akıllı Veri Girişi: Aylık geliri 10.000 TL ve üzeri olan müşterilerin krediye uygun olup olmadığı bilgisinin otomatik olarak belirlenmesi.
Gelişmiş Arama: Ad, soyad, şehir ve aylık gelire göre müşteri kaydı arama.
Güvenlik: SQL Injection saldırılarına karşı parametreli sorgu kullanımı.
Kullanıcı Dostu Arayüz: Sade ve anlaşılır Windows Forms arayüzü.

Teknolojiler
Programlama Dili: C#
UI Framework: Windows Forms (WinForms)
Veritabanı: Microsoft SQL Server
Veritabanı Erişimi: ADO.NET

Kurulum
Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edin:
Projeyi Klonlayın:
Bash
git clone https://github.com/Eelllif/musteri-otomasyon.git
Veritabanını Kurun:
SQL Server'da ProjelerVT adında yeni bir veritabanı oluşturun.
Oluşturduğunuz veritabanında, aşağıdaki sütunlara sahip Müsteri adında bir tablo oluşturun:
MusteriId (int, IDENTITY, Primary Key)
Ad (nvarchar)
Soyad (nvarchar)
AylikGelir (int)
KrediyeUygunMu (bit)
Sehir (nvarchar)
Bağlantı Dizesini Güncelleyin:
Visual Studio'da projeyi açın ve Form1.cs dosyasını bulun.
SqlConnection baglanti = new SqlConnection(...) satırındaki bağlantı dizesini kendi yerel SQL Server ayarlarınıza uygun şekilde güncelleyin.
Projeyi Çalıştırın:
Projeyi derlemek ve çalıştırmak için Visual Studio'da F5 tuşuna basın.

Lisans
Bu proje, MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için lütfen LISANS dosyasına bakın.

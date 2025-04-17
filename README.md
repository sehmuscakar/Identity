Identity Project
Bu proje, bir ASP.NET Core uygulaması üzerinde kullanıcı kimlik doğrulama ve yönetim sistemi için temel işlevleri içeren bir uygulamadır. Uygulama, kullanıcıların kaydolmasını, oturum açmasını ve rollerle birlikte yönetilmesini sağlar.

İçerik
1. Identity
IdentityContext.cs: Kullanıcı kimlik doğrulama ve kullanıcı yönetimi ile ilgili veritabanı bağlamı (context) sınıfıdır. Bu sınıf, veritabanı ile kullanıcı bilgilerini ilişkilendiren temel yapıdır.

2. Controllers
HomeController.cs: Ana sayfa ve kullanıcı yönlendirmeleri ile ilgili işlevleri kontrol eden sınıftır. Kullanıcılara sayfa yönlendirmelerini ve içeriklerini sağlar.

3. Entities
AppRole.cs: Uygulamadaki kullanıcı rolleriyle ilgili sınıf. Kullanıcıların sahip olduğu rollerin bilgilerini tutar.

AppUser.cs: Kullanıcı bilgileri için sınıf. Kullanıcıların sisteme kaydederken tutulan temel bilgileri içerir.

4. Migrations
Bu klasör, Entity Framework Core üzerinden veritabanı şeması değişikliklerini izler. Migration dosyaları, veritabanı yapılandırmalarının nasıl değiştiğini ve veritabanı ile uygulama arasındaki uyumu sağlar.

5. Models
UserCreateModel.cs: Yeni bir kullanıcı oluşturmak için gerekli olan model.

UserSignInModel.cs: Kullanıcının sisteme giriş yapabilmesi için gerekli olan model.

6. Properties
Uygulamanın genel özellikleri ve yapılandırmalarını içeren dosyalar.

7. Views
Home: Ana sayfaya ait Razor View dosyaları.

Shared: Paylaşılan view bileşenlerini içeren klasör. _Layout.cshtml, sayfa şablonlarını ve ortak bileşenleri içerir. _ViewImports.cshtml, view'lar arasındaki ortak namespace'leri ve servisleri içerir.

8. bin/Debug/net6.0 ve obj
Projenin derleme çıktılarının bulunduğu klasörler. Genellikle, derleme işlemi sonrasında oluşan dosyaları içerir.

9. wwwroot
bootstrap: Bootstrap CSS ve JS dosyalarını içeren dizin. Uygulamanın görünümü için gerekli stil ve tasarım kaynaklarını barındırır.

10. Proje Dosyaları
Identity.csproj: Proje yapılandırma dosyası. Uygulamanın bağımlılıklarını ve yapılandırmalarını içerir.

Identity.csproj.user: Kullanıcıya özel proje yapılandırma dosyası.

Program.cs: Uygulamanın giriş noktası ve yapılandırma dosyası. Uygulamanın başlatılmasını sağlayan ana sınıf.

appsettings.Development.json ve appsettings.json: Uygulamanın farklı ortamlar için yapılandırma dosyaları. Örneğin, veritabanı bağlantıları ve diğer ayarlar burada tutulur.

libman.json: Frontend kütüphanelerinin (örneğin, Bootstrap gibi) yönetimi için kullanılan dosya.

11. Diğer Dosyalar
.gitattributes: Git'e özgü dosya ayarlarını ve özelliklerini içerir.

Identity.sln: Visual Studio çözüm dosyası. Projenin tamamını ve çözüm içindeki tüm projeleri yönetir.

Kurulum
Projenin yerel ortamda çalışması için şu adımları takip edebilirsiniz:

Projeyi indirin veya klonlayın.

Visual Studio veya başka bir IDE ile projeyi açın.

Gerekli NuGet paketlerini yüklemek için dotnet restore komutunu çalıştırın.

Veritabanı migrasyonlarını uygulamak için dotnet ef database update komutunu çalıştırın.

Uygulamayı çalıştırarak yerel sunucuda test edin.

Kullanıcı Rolleri
Uygulama, kullanıcıların belirli rollere atanmasını sağlar. Roller aşağıdaki gibi olabilir:

Admin: Yönetici haklarına sahip kullanıcı.

User: Normal kullanıcı.

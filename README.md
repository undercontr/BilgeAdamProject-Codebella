# BilgeAdam Bitirme Projesi // *Codebella.io*
Proje multi-layered architecture mimarisinde yazılmıştır. Klasik bir blog sitesidir. Site içerisinde mümkün olduğunca internal link mevcuttur. Bir article'a bir kaç yolla ulaşmak mümkündür. İster tagler aracığı ile ister kategori isterseniz de yazar aracılığı ile ulaşabilirsiniz.

**Dependency Injection** IServiceCollection interface aracılığı ile sağlandı (yani ek paket kullanmadım sadece .NET varsayılan paketleri ile devam ettim). Bunu sağlamak için ek bir **Infrastructure** adında bir servis oluşturdum ve tüm projelerde gerekebilecek IoC container bilgilerimi bu serviste IServiceCollection interfaceine bir extension olarak **AddCodebellaInfrastructure** methodu yazdım. Yalnızca blog uygulaması ile ilgili gerekli dependency leri containera kaydetmek için kullanılıyor.

Örnek : 

    services.AddCodebellaInfraStructure(builder.Configuration.GetConnectionString("DefaultConnection"));

Şeklinde kullanılıyor. Kod içeriği Infrastructure servisinde ServiceExtension.cs dosyası içerisinde tanımlıdır.

Veritabanı olarak Microsoft SQL Server ve ORM olarak Entity Framework kullanıldı. Code-First yaklaşımı ile veritabanı yazıldı. One-to-many ve many-to-many hatta one-to-one şeklinde tüm ilişiki çeşitleri ile modeller oluşturuldu. Unique indexler kullanıldı.

Model konfigurasyonları ayı bir serviste **Mapping** servisinde yazıldı ve **DataAccess** adını verdiğim serviste kayıt edildi.

SEO uyumlu olması açısından URL routing'de **Id** yerine **Slug** sistemi kullanıldı. Yani anlamlı bir URL yaratmayı hedefledim. Örnek vermek gerekirse bir article'ın başlığını ve unique IDsini kullanarak bir url oluşturdum.

Kategori yolu ile örnek: `http://codebella.io/category/csharp/what-is-boxing-and-unboxing-12`\
Tag yolu ile örnek: `http://codebella.io/tag/entity`\
Yazar yolu ile örnek: `http://codebella.io/author/@onderalkan`

**Data transferring objects** için **AutoMapper** paketi kullanıldı. Ve entityler genelinde yaygın olarak kullanıldı.

Anlaşılabilir kod okunabilmesi için extension methodlar kullanıldı. Extension methodlar hem Razor classları hemde diğer C# classları için yazıldı.

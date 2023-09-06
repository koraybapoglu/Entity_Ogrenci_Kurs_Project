# Ogrenci_Kurs Projesi

Bu proje, Entity Framework Core ve Code First tekniği kullanılarak geliştirilmiş bir Console uygulamasını içermektedir. MSSQL veritabanı ile entegre edilmiş ve temel CRUD işlemleri ile birlikte farklı LINQ sorgularını içermektedir. Proje, öğrenciler, öğretmenler, dersler, kurslar ve Ogrenci_Kurs gibi temel entity'leri içerir.

## Gereksinimler

Bu projenin çalıştırılabilmesi için aşağıdaki gereksinimlere ihtiyaç vardır:

- [ASP.NET Core 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MSSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Proje Yapısı

Proje, aşağıdaki temel bileşenleri içerir:

- **DataServices:** Veritabanı işlemlerinin gerçekleştirildiği bu bölümde, Entity Framework Core ve LINQ sorguları kullanılarak veri erişimi sağlanır.

- **MenuServices:** Menü işlemlerinin yapıldığı bu bölüm, kullanıcı arayüzü ile etkileşimi yönetir ve veritabanı işlemlerini çağırır.

- **Interfaces:** Proje içinde kullanılan arayüzleri içerir. `IAdminService`, `ICRUDService` ve `IOgrenci_Kurs` interfaceleri projenin yapısını sağlamlaştırır.

## Veritabanı

Projede, MSSQL veritabanı kullanılmıştır. Migration kullanarak veritabanında yapılan değişiklikler kayıt altına alınmıştır.

## Temel Fonksiyonlar

Proje, aşağıdaki temel işlevleri içerir:

- **CRUD İşlemleri:** Öğrenciler, öğretmenler, dersler, kurslar ve Ogrenci_Kurs gibi temel entity'ler için CRUD (Create, Read, Update, Delete) işlemleri gerçekleştirilebilir.

- **Count:** LINQ kullanarak veritabanındaki kayıt sayısını hesaplar.

- **Max:** LINQ kullanarak belirli bir özellik (örneğin, KursID) için maksimum değeri bulur.

- **Min:** LINQ kullanarak belirli bir özellik (örneğin, KursID) için minimum değeri bulur.

- **Distinct:** LINQ kullanarak veritabanındaki benzersiz değerleri alır.

- **GroupBy:** LINQ kullanarak veritabanındaki verileri belirli bir özellik (örneğin, KursAdi) üzerinde gruplar.

- **Any:** LINQ kullanarak belirli bir şartı sağlayan kayıt var mı yok mu kontrol eder.

- **Find:** Belirli bir öğrenci, öğretmen veya diğer entity'leri belirli bir şarta göre bulur.

- **Except:** İki koleksiyon arasındaki farkı bulmak için LINQ operatörünü kullanır.

## Kullanım

Proje, Entity Framework Core ve Code First tekniğini kullanarak oluşturulduğu için, veritabanı modelini ve bağlantısını projenize uygun şekilde yapılandırabilirsiniz. Ayrıca, DataServices ve MenuServices içindeki işlemleri projenizin ihtiyaçlarına göre özelleştirebilirsiniz.

## Lisans

Bu proje ücretsiz kullanıma sunulmuştur.

## Not

Bu proje ASP.NET Core 7.0 ve Entity Framework Core kullanılarak geliştirilmiştir.

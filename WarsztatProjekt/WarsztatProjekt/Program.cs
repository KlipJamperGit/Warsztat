
using System.Text.Json;
namespace WarsztatProjekt;

class Program
{
    static void Main(string[] args)
    {
        //start
        //var samochód = new List<Samochód>
        //{
        //   new Samochód(1, "Mazda", "MX5", "1289087", 1200, 2.0, 150000, StatusZlecenia.Nowe, 500),
        //   new Samochód(2, "Ford", "Mustang", "M2313r", 1300, 2.2, 140000, StatusZlecenia.WTrakcie, 700),
        //   new Samochód(3, "Honda", "NSX", "s12swwe2", 1100, 1.6, 100000, StatusZlecenia.Zakonczone, 300),
        //};
        //var motocykl = new List<Motocykl>
        //{
        //    new Motocykl(1, "Yamaha", "R1M", "23ewa23", 200, 0.3, 50000, StatusZlecenia.GotoweDoOdbioru, 1500)
        //};
        //var mechanik = new List<Mechanik>
        //{
        //    new Mechanik(1, "cania", "haslo123", 50, 5),
        //};
        //var stazysta = new List<Stażysta>
        //{
        //    new Stażysta(1, "cania-1", "haslo123", 20, 1)
        //};
        //var klient = new List<Klient>
        //{
        //    new Klient(1, "cania0", "haslo789", 1000)
        //};
        //var admin = new List<Admin>
        //{
        //   new Admin(1, "admin", "admin123", 100, 40)
        //};


        // Перевірка наявності файлу
        string filePath = "data.json";

        if (!File.Exists(filePath))
        {
            var initialData = new WarsztatData();
            string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, initialJson);
        }
        // Читання даних з файлу
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };
        var warsztatData = JsonSerializer.Deserialize<WarsztatData>(json,options);

        //start

        //warsztatData.AddKlient(klient[0]);
        //warsztatData.AddPracownik(mechanik[0]);
        //warsztatData.AddPracownik(stazysta[0]);
        //warsztatData.AddTransport(samochód[0]);
        //warsztatData.AddTransport(samochód[1]);
        //warsztatData.AddTransport(samochód[2]);
        //warsztatData.AddTransport(motocykl[0]);
        //warsztatData.AddPracownik(admin[0]);

        //// Збереження оновлених даних у файл
        //string updatedJson = JsonSerializer.Serialize(warsztatData, new JsonSerializerOptions { WriteIndented = true });
        //File.WriteAllText(filePath, updatedJson);

        var allTransports = new List<Transport>();
        if (warsztatData.Samochód != null)
        {
            allTransports.AddRange(warsztatData.Samochód);
        }
        if (warsztatData.Motocykl != null)
        {
            allTransports.AddRange(warsztatData.Motocykl);
        }

        var allPracowniks = new List<Pracownik>();
        if (warsztatData.Mechanik != null)
        {
            allPracowniks.AddRange(warsztatData.Mechanik);
        }
        if (warsztatData.Stażysta != null)
        {
            allPracowniks.AddRange(warsztatData.Stażysta);
        }
        if (warsztatData.Admin != null)
        {
            allPracowniks.AddRange(warsztatData.Admin);
        }

        Console02.ConsoleZobacz(allTransports, allPracowniks, warsztatData.Klient);
        string updatedJson = JsonSerializer.Serialize(warsztatData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, updatedJson);

    }

}

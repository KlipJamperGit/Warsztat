using System.Text.Json;
using System.Text.Json.Serialization;

namespace WarsztatProjekt
{
    public class WarsztatData
    {
        [JsonPropertyName("klients")]
        public List<Klient> Klient { get; set; }

        [JsonPropertyName("mechanik")]
        public List<Mechanik> Mechanik { get; set; }

        [JsonPropertyName("stażysta")]
        public List<Stażysta> Stażysta { get; set; }
        [JsonPropertyName("admin")]
        public List<Admin> Admin { get; set; }

        [JsonPropertyName("samochód")]
        public List<Samochód> Samochód { get; set; }
        [JsonPropertyName("motocykl")]
        public List<Motocykl> Motocykl { get; set; }

        public WarsztatData()
        {
            Klient = new List<Klient>();
            Mechanik = new List<Mechanik>();
            Stażysta = new List<Stażysta>();
            Admin = new List<Admin>();
            Samochód = new List<Samochód>();
            Motocykl = new List<Motocykl>();
        }
        public void AddKlient(Klient klient)
        {
            string filePath = "data.json";

            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);

            }
            Klient.Add(klient);
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
        public void AddPracownik(Admin admin)
        {
            string filePath = "data.json";
            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);

            }
            Admin.Add(admin); 
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
        public void AddPracownik(Mechanik pracownik)
        {
            string filePath = "data.json";

            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);

            }
            Mechanik.Add(pracownik);
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
        public void AddPracownik(Stażysta pracownik)
        {
            string filePath = "data.json";

            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);
                
            }
            Stażysta.Add(pracownik);
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
        public void AddTransport(Motocykl transport)
        {
            string filePath = "data.json";

            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);

            }
            Motocykl.Add(transport);
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
        public void AddTransport(Samochód transport)
        {
            string filePath = "data.json";

            if (!File.Exists(filePath))
            {
                var initialData = new WarsztatData();
                string initialJson = JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, initialJson);

            }
            Samochód.Add(transport);
            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
        }
    }
}

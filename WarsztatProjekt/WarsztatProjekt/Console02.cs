using System;
using System.Text.Json;
namespace WarsztatProjekt;
public static class Console02
{
    public static void ConsoleZobacz(List<Transport> transport, List<Pracownik> pracowniks, List<Klient> klients)
    {
        string filePath = "data.json";
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };
        var warsztatData = JsonSerializer.Deserialize<WarsztatData>(json, options);
        while (true)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            Console.WriteLine("\n---  Główne Menu ---");
            Console.WriteLine("\nLista pracowników:");
            foreach (var osoba in pracowniks)
            {
                osoba.WyswietlDane();
            }
            Console.WriteLine("\nLista klientów:");
            foreach (var osoba in klients)
            {
                osoba.WyswietlDane();
            }
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. utwórz klienta");
            Console.WriteLine("2. utwórz administratora");
            Console.WriteLine("3. utwórz mechanika");
            Console.WriteLine("4. utwórz Stażystu");
            Console.WriteLine("5. Interakcja z pojazdami");
            Console.WriteLine("6. Interakcja admina");
            Console.WriteLine("7. Dodaj samochód");
            Console.WriteLine("8. Dodaj motocykl");
            Console.WriteLine("9. Wyjść");
            Console.Write("wybierz opcje: ");
            string choice = Console.ReadLine();
            try
            {


                switch (choice)
                {
                    case "1":
                        int klientId = IdGenerator.GenerateId();
                        Console.Write("wprowadż imie klienta: ");
                        string klientImie = Console.ReadLine();
                        Console.Write("Password: ");
                        string klientPassword = Console.ReadLine();
                        Console.Write("Balans: ");
                        double klientBalance = double.Parse(Console.ReadLine());
                        Klient newKlient = new Klient(klientId, klientImie, klientPassword, klientBalance);
                        foreach (var k in klients)
                        {
                            if(!k.Equals(newKlient) && k.GetHashCode() != newKlient.GetHashCode())
                            {
                                klients.Add(newKlient);
                                warsztatData.AddKlient(newKlient);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Klient {newKlient.Imie} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Klient {newKlient.Imie} nie został dodany.");
                                break;
                            }
                        }
                        break;

                    case "2":
                        int adminId = IdGenerator.GenerateId();
                        Console.Write("wprowadż imie administratora: ");
                        string adminImie = Console.ReadLine();
                        Console.Write("Password: ");
                        string adminPassword = Console.ReadLine();
                        Console.Write("Wprowadź stawkę godzinową: ");
                        double adminStawkaGodzinowa = double.Parse(Console.ReadLine());
                        Console.Write("Wprowadź czas pracy w godzinach: ");
                        int adminCzasPracy = int.Parse(Console.ReadLine());
                        Admin admin = new Admin(adminId, adminImie, adminPassword, adminStawkaGodzinowa, adminCzasPracy);
                        foreach (var k in pracowniks)
                        {
                            if (!k.Equals(admin) && k.GetHashCode() != admin.GetHashCode())
                            {
                                pracowniks.Add(admin);
                                warsztatData.AddPracownik(admin);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Admin {admin.Imie} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Admin {admin.Imie} nie został dodany.");
                                break;
                            }
                        }
                        break;

                    case "3":
                        int mechanikId = IdGenerator.GenerateId();
                        Console.Write("wprowadż imie mechanika: ");
                        string mechanikImie = Console.ReadLine();
                        Console.Write("Password: ");
                        string mechanikPassword = Console.ReadLine();
                        Console.Write("Wprowadź stawkę godzinową: ");
                        double mechanikStawka = double.Parse(Console.ReadLine());
                        Console.Write("umiejętność wpisz jako godziny dodatkowe: ");
                        int mechanikAddCzas = int.Parse(Console.ReadLine());
                        Mechanik mechanik = new Mechanik(mechanikId, mechanikImie, mechanikPassword, mechanikStawka, mechanikAddCzas);
                        foreach (var k in pracowniks)
                        {
                            if (!k.Equals(mechanik) && k.GetHashCode() != mechanik.GetHashCode())
                            {
                                pracowniks.Add(mechanik);
                                warsztatData.AddPracownik(mechanik);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Mechanik {mechanik.Imie} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Mechanik {mechanik.Imie} nie został dodany.");
                                break;
                            }
                        }
                        break;

                    case "4":
                        int stazystaId = IdGenerator.GenerateId();
                        Console.Write("wprowadż imie stazysty: ");
                        string stazystaImie = Console.ReadLine();
                        Console.Write("Password: ");
                        string stazystaPassword = Console.ReadLine();
                        Console.Write("Wprowadź stawkę godzinową: ");
                        double stazystaStawka = double.Parse(Console.ReadLine());
                        Console.Write("umiejętność wpisz jako godziny dodatkowe: ");
                        int stazystaAddCzas = int.Parse(Console.ReadLine());
                        Stażysta stażysta = new Stażysta(stazystaId, stazystaImie, stazystaPassword, stazystaStawka, stazystaAddCzas);
                        foreach (var k in pracowniks)
                        {
                            if (!k.Equals(stażysta) && k.GetHashCode() != stażysta.GetHashCode())
                            {
                                pracowniks.Add(stażysta);
                                warsztatData.AddPracownik(stażysta);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Stażysta {stażysta.Imie} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Stażysta {stażysta.Imie} nie został dodany.");
                                break;
                            }
                        }
                        break;

                    case "5":
                        InterakcjaPojazduł(transport, pracowniks, klients);
                        break;
                    case "6":
                        InterakcjaAdmina(transport, pracowniks, klients);
                        break;
                    case "7": 
                        int sId = IdGenerator.GenerateId();
                        Console.Write("Marka: ");
                        string sMarka = Console.ReadLine();
                        Console.Write("Model: ");
                        string sModel = Console.ReadLine();
                        Console.Write("Rejestracja: ");
                        string sRejestracja = Console.ReadLine();
                        Console.Write("Waga: ");
                        double sWaga = double.Parse(Console.ReadLine());
                        Console.Write("Pojemność silnika: ");
                        double sPojemnoscSilnika = double.Parse(Console.ReadLine());
                        Console.Write("Przebieg: ");
                        double sPrzebieg = double.Parse(Console.ReadLine());
                        Console.Write("Koszt naprawy: ");
                        double sKosztNaprawy = double.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz status naprawy: 1 - Nowe, 2 - W Trakcie, 3 - Zakończone");
                        Console.Write("Wybierz status: ");
                        string switchStatus = Console.ReadLine();
                        StatusZlecenia statusZlecenia;
                        switch (switchStatus)
                        {
                            case "1":
                                statusZlecenia = StatusZlecenia.Nowe;
                                break;
                            case "2":
                                statusZlecenia = StatusZlecenia.WTrakcie;
                                break;
                            case "3":
                                statusZlecenia = StatusZlecenia.Zakonczone;
                                break;
                            default:
                                statusZlecenia = StatusZlecenia.Nowe;
                                break;
                        }
                        var newSamochód = new Samochód
                        {
                            Id = sId,
                            Marka = sMarka,
                            Model = sModel,
                            Rejestracja = sRejestracja,
                            Waga = sWaga,
                            PojemnoscSilnika = sPojemnoscSilnika,
                            Przebieg = sPrzebieg,
                            status = statusZlecenia,
                            KosztNaprawu = sKosztNaprawy
                        };
                        foreach (var t in transport)
                        {
                            if (!t.Equals(newSamochód) && t.GetHashCode() != newSamochód.GetHashCode())
                            {
                                transport.Add(newSamochód);
                                warsztatData.AddTransport(newSamochód);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Samochód {newSamochód.Marka} {sModel} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Samochód {newSamochód.Marka} {sModel} nie został dodany.");
                                break;
                            }
                        }
                        break;

                    case "8": 
                        int mId = IdGenerator.GenerateId();
                        Console.Write("Marka: ");
                        string mMarka = Console.ReadLine();
                        Console.Write("Model: ");
                        string mModel = Console.ReadLine();
                        Console.Write("Rejestracja: ");
                        string mRejestracja = Console.ReadLine();
                        Console.Write("Waga: ");
                        double mWaga = double.Parse(Console.ReadLine());
                        Console.Write("Pojemność silnika: ");
                        double mPojemnoscSilnika = double.Parse(Console.ReadLine());
                        Console.Write("Przebieg: ");
                        double mPrzebieg = double.Parse(Console.ReadLine());
                        Console.Write("Koszt naprawy: ");
                        double mKosztNaprawy = double.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz status naprawy: 1 - Nowe, 2 - W Trakcie, 3 - Zakończone");
                        Console.Write("Wybierz status: ");
                        string mswitchStatus = Console.ReadLine();
                        StatusZlecenia mstatusZlecenia;
                        switch (mswitchStatus)
                        {
                            case "1":
                                mstatusZlecenia = StatusZlecenia.Nowe;
                                break;
                            case "2":
                                mstatusZlecenia = StatusZlecenia.WTrakcie;
                                break;
                            case "3":
                                mstatusZlecenia = StatusZlecenia.Zakonczone;
                                break;
                            default:
                                mstatusZlecenia = StatusZlecenia.Nowe;
                                break;
                        }
                        var newMotocykl = new Motocykl
                        {
                            Id = mId,
                            Marka = mMarka,
                            Model = mModel,
                            Rejestracja = mRejestracja,
                            Waga = mWaga,
                            PojemnoscSilnika = mPojemnoscSilnika,
                            Przebieg = mPrzebieg,
                            status = mstatusZlecenia,
                            KosztNaprawu = mKosztNaprawy
                        };
                        foreach (var t in transport)
                        {
                            if (!t.Equals(newMotocykl) && t.GetHashCode() != newMotocykl.GetHashCode())
                            {
                                transport.Add(newMotocykl);
                                warsztatData.AddTransport(newMotocykl);
                                Console.WriteLine("Gotowo!");
                                Console.WriteLine($"Samochód {newMotocykl.Marka} {mModel} został dodany.");
                            }
                            else
                            {
                                Console.WriteLine($"Samochód {newMotocykl.Marka} {mModel} nie został dodany.");
                                break;
                            }
                        }
                        break;
                    case "9":
                        Console.WriteLine("Wyjść...");
                        return;

                    default:
                        Console.WriteLine("Error spróbuj zachować poprawne dane.");
                        break;
                }
            }
            catch (MyCustomException ex)
            {
                ex.GetFullError();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Błąd formatu danych. Proszę spróbować ponownie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
    private static void InterakcjaAdmina(List<Transport> transport, List<Pracownik> pracowniks, List<Klient> klients)
    {
        while (true)
        {
            Console.WriteLine("\nLista adminów:");
            foreach (var admin in pracowniks.OfType<Admin>())
            {
                admin.WyswietlDane();
            }
            Console.WriteLine("\n--- Interakcja Adminów ---");
            Console.WriteLine("1. Zmensz konto klienta");
            Console.WriteLine("2. Wypłać wynagrodzenie pracownikowi");
            Console.WriteLine("3. Doładuj koszt");
            Console.WriteLine("4. Powrót do głównego menu");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            try
            {

                switch (choice)
                {

                    case "1":
                        Console.Write("Podaj ID klienta: ");
                        int klientId = int.Parse(Console.ReadLine());
                        var klient = Sortuwanie.FindElement(klients, s => s.GetId() == klientId);
                        Console.Write("Podaj ID admina: ");
                        int adminId = int.Parse(Console.ReadLine());
                        var admin = Sortuwanie.FindElement(pracowniks, s => s.GetId() == adminId);
                        if (klient != null)
                        {
                            Console.Write("Podaj sume: ");
                            double kwota = double.Parse(Console.ReadLine());
                            klient.Pay(admin, kwota);
                            Console.WriteLine(admin.GetBalance());
                            Console.WriteLine($"Konto klienta {klient.Imie} zostało - {kwota}.");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono klienta o podanym ID.");
                        }
                        break;

                    case "2":
                        Console.Write("Podaj ID pracownika: ");
                        int pracownikId = int.Parse(Console.ReadLine());
                        var pracownik = Sortuwanie.FindElement(pracowniks, p => p.GetId() == pracownikId);
                        Console.Write("Podaj ID admina: ");
                        adminId = int.Parse(Console.ReadLine());
                        admin = Sortuwanie.FindElement(pracowniks, s => s.GetId() == adminId);
                        if (pracownik != null)
                        {
                            Console.Write("Podaj sume: ");
                            double kwota = double.Parse(Console.ReadLine());
                            IPay pay1 = (IPay)admin;
                            pay1.DoładowanieBalance(kwota);
                            Console.WriteLine($"Pracownik {pracownik.Imie} otrzymał {kwota}.");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono pracownika o podanym ID.");
                        }
                        break;

                    case "3":
                        Console.Write("Podaj sume: ");
                        double adminKwota = double.Parse(Console.ReadLine());
                        Console.Write("Podaj ID admina: ");
                        adminId = int.Parse(Console.ReadLine());
                        admin = Sortuwanie.FindElement(pracowniks, s => s.GetId() == adminId);
                        IPay pay = (IPay)admin;
                        pay.DoładowanieBalance(adminKwota);
                        Console.WriteLine($"Konto administratora {admin.Imie} zostało + {adminKwota}.");
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Spróbuj ponownie.");
                        break;
                }
            }
            catch (MyCustomException ex)
            {
                ex.GetFullError();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Błąd formatu danych. Proszę spróbować ponownie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
    private static void InterakcjaPojazduł(List<Transport> transport, List<Pracownik> pracowniks, List<Klient> klients)
    {
        while (true)
        {
            Console.WriteLine("\nLista pojazdów:");
            foreach (var pojazd in transport)
            {
                pojazd.GetOpisTransportu();
            }
            Console.WriteLine("\n---  Interakcja Pojazduł ---");
            Console.WriteLine("1. Zamów naprawę pojazdu");
            Console.WriteLine("2. Opłać zamówienie");
            Console.WriteLine("3. Info");
            Console.WriteLine("4. Powrót do głównego menu");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Wprowadź ID pojazdu do naprawy: ");
                        int idNaprawa = Convert.ToInt32(Console.ReadLine());
                        Transport pojazdDoNaprawy = Sortuwanie.FindElement(transport, s => s.Id == idNaprawa);
                        if (pojazdDoNaprawy != null)
                        {
                            pojazdDoNaprawy.status = StatusZlecenia.WTrakcie;
                            Console.WriteLine($"Naprawa pojazdu {pojazdDoNaprawy.Marka} {pojazdDoNaprawy.Model} została zamówiona.");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono pojazdu o podanym ID.");
                        }
                        break;

                    case "2":
                        Console.Write("Wprowadź ID pojazdu do opłacenia: ");
                        int idOplata = Convert.ToInt32(Console.ReadLine());
                        Transport pojazdDoOplaty = Sortuwanie.FindElement(transport, s => s.Id == idOplata);
                        if (pojazdDoOplaty != null)
                        {
                            Console.Write("Wprowadź ID klienta: ");
                            int klientId = Convert.ToInt32(Console.ReadLine());
                            Klient klient = Sortuwanie.FindElement(klients, s => s.GetId() == klientId);
                            if (klient != null)
                            {
                                Console.Write("Wprowadź ID pracownik: ");
                                int pracownikID = Convert.ToInt32(Console.ReadLine());
                                Pracownik pracownik = Sortuwanie.FindElement(pracowniks, s => s.GetId() == pracownikID);
                                if (pracownik != null)
                                {
                                    
                                    var balanse = klient.GetBalance();
                                    var kosztNaprawy = pojazdDoOplaty.KosztNaprawu + (pracownik.StawkaGodzinowa * pracownik.CzasPracy(pracownik.AddCzas).Hour);
                                    Console.WriteLine($"Koszt naprawy: {kosztNaprawy}");
                                    if (balanse >= kosztNaprawy)
                                    {
                                        IPay pay = (IPay)klient;
                                        pay.Pay(klient, kosztNaprawy);
                                        pojazdDoOplaty.status = StatusZlecenia.Zakonczone;
                                        Console.WriteLine($"Pojazd {pojazdDoOplaty.Marka} {pojazdDoOplaty.Model} został opłacony.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Klient nie ma wystarczających środków.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nie znaleziono pracownika ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono klienta ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono pojazdu ID.");
                        }
                        break;


                    case "3":
                        var sorted = new List<Transport>(transport);
                        sorted.Sort((a, b) => a.PojemnoscSilnika.CompareTo(b.PojemnoscSilnika));
                        Console.WriteLine("\nsortowanie po PojemnoscSilnika :");
                        foreach (var samochód in sorted)
                        {
                            samochód.GetOpisTransportu();
                        }

                        Console.WriteLine("\nWpisz ID samohoda żeby powiedzieć więcej:");
                        int id = int.Parse(Console.ReadLine());
                        Transport selectedCar = Sortuwanie.FindElement(transport, t => t.Id == id);
                        if (selectedCar != null)
                        {
                            Console.WriteLine("Gotowe:");
                            selectedCar.GetOpisTransportu();
                        }
                        else
                        {
                            Console.WriteLine("Nie ma takiego Transportu.");
                        }

                        Console.WriteLine("\nLista Statusu:");
                        foreach (var status in Enum.GetValues(typeof(StatusZlecenia)))
                        {
                            Console.WriteLine($"- {status}");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
            catch (MyCustomException ex)
            {
                ex.GetFullError();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Błąd formatu danych. Proszę spróbować ponownie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }

        }
    }
}

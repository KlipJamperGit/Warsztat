using System.Text.Json.Serialization;
namespace WarsztatProjekt;

public class Admin : Pracownik
{
    int AddCzas { get; set; }
    [JsonConstructor]
    public Admin(int Id, string Imie, string Password, double StawkaGodzinowa, int AddCzas)
        : base(Id, Imie, Password, StawkaGodzinowa, Stanowisko: typeof(Admin), AddCzas)
    {
        this.AddCzas = AddCzas;
    }

    public override void WyswietlDane()
    {
        Console.WriteLine($"ID: {Id}, Imię: {Imie}, Stanowisko: Admin");
    }

    public override int GetId()
    {
        return Id;
    }

    public override bool Pay(IPay pay, double KosztNaprawy)
    {
        try
        {
            pay.Pay(this, KosztNaprawy);
            pay.DoładowanieBalance(KosztNaprawy);
            Console.WriteLine("Oplata gotowa");
            return true;
        }
        catch (MyCustomException ex)
        {
            ex.PaymentError();
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public override double GetBalance()
    {
        return IPay.Balance;
    }

    public override string GetOpisStanowiska()
    {
        return $"Admin ";
    }

    public override DateTime CzasPracyPracownica(int czasPracy)
    {
        return base.CzasPracy(AddCzas + czasPracy);
    }
}

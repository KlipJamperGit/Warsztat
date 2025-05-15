
using System.Text.Json.Serialization;

namespace WarsztatProjekt;

public class Stażysta : Pracownik
{
    int AddCzas { get; set; }
    [JsonConstructor]
    public Stażysta(int Id, string Imie, string Password, double StawkaGodzinowa, int AddCzas)
        : base(Id, Imie, Password, StawkaGodzinowa, Stanowisko: typeof(Stażysta), AddCzas)
    {
    }

    public override string GetOpisStanowiska()
    {
        return $"Stażysta ";
    }

    public override DateTime CzasPracyPracownica(int czasPracy)
    {
        return base.CzasPracy(AddCzas + czasPracy);

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
            IPay.Balance += KosztNaprawy;
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


}

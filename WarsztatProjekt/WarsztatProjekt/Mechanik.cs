using System;
using System.Text.Json.Serialization;


namespace WarsztatProjekt;

public class Mechanik : Pracownik
{
    int AddCzas { get; set; }
    [JsonConstructor]
    public Mechanik(int Id, string Imie, string Password, double StawkaGodzinowa, int AddCzas)
        : base(Id, Imie, Password, StawkaGodzinowa, Stanowisko: typeof(Mechanik), AddCzas)
    {
        this.AddCzas = AddCzas;
    }
    public override DateTime CzasPracyPracownica(int czasPracy)
    {
        return base.CzasPracy(AddCzas + czasPracy);
    }


    public override string GetOpisStanowiska()
    {
        return $"Mechanik ";
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

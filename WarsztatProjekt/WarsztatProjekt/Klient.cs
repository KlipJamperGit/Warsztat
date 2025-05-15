using System;
using System.Text.Json.Serialization;
namespace WarsztatProjekt;

public class Klient : Osoba, IPay
{
    public double Balance { get; private set; }
    public List<Transport> Transports { get; private set; }
    [JsonConstructor]
    public Klient(int Id, string Imie, string Password, double Balance)
        : base(Id, Imie, Password, Balance)
    {
        this.Balance = Balance;

    }
    public override void WyswietlDane()
    {
        Console.WriteLine($"ID: {Id}, Imię: {Imie}, Stanowisko: Klient, Balance {Balance}");
    }




    public override double GetBalance()
    {
        return this.Balance;
    }

    public override bool Pay(IPay pay, double KosztNaprawy)
    {
        try
        {
            this.Balance -= KosztNaprawy;
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

    public override int GetId()
    {
        return Id;
    }
}

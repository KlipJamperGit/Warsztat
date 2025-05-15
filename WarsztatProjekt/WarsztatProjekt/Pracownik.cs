using System;
using System.Text.Json.Serialization;

namespace WarsztatProjekt;

public abstract class Pracownik : Osoba
{
    public double StawkaGodzinowa { get; set; }
    [JsonIgnore]
    public Type Stanowisko { get; set; }
    public int AddCzas { get; set; }
    protected Pracownik(int Id, string Imie, string Password, double StawkaGodzinowa, Type Stanowisko, int AddCzas)
        : base(Id, Imie, Password)
    {
        this.StawkaGodzinowa = StawkaGodzinowa;
        this.Stanowisko = Stanowisko;
        this.AddCzas = AddCzas;
    }


    public abstract string GetOpisStanowiska();
    public abstract DateTime CzasPracyPracownica(int czasPracy);

    public DateTime CzasPracy(int czasPracy)
    {
        DateTime czas = DateTime.Now;

        while (czasPracy > 0)
        {
            int time = czas.Hour;

            if (time >= 20 || time < 8 || IsWeekend(czas))
            {
                czas = czas.AddDays(1);
                czas = new DateTime(czas.Year, czas.Month, czas.Day, 8, 0, 0);
            }
            else 
            {
                czasPracy -= 1;
                czas = czas.AddHours(1);
            }
        }

        return czas;
    }
    private bool IsWeekend(DateTime time)
    {
        return time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday;
    }
    public override int GetId()
    {
        return Id;
    }
    public override double GetBalance()
    {
        return IPay.Balance;
    }

    public override string ToString()
    {
        return $"{base.ToString()},Id {Id} Stanowisko: {Stanowisko.Name}, Stawka godzinowa: {StawkaGodzinowa}"; 
    }
    public override void WyswietlDane()
    {
        Console.WriteLine($"Id {Id}, Imię: {Imie}, Stanowisko: {Stanowisko.Name}, Stawka godzinowa: {StawkaGodzinowa}");
    }
}
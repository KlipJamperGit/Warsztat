using System;
using System.Text.Json.Serialization;

namespace WarsztatProjekt;

 
public class Samochód : Transport
{
    public Samochód() : base() { }
    public Samochód(int id, string marka, string model, string rejestracja, double waga, double pojemnoscSilnika, double przebieg, StatusZlecenia status, double kosztNaprawy) : base(id, marka, model, rejestracja, waga, pojemnoscSilnika, przebieg, status, kosztNaprawy)
    {
    }
    public double GetKosztNaprawy()
    {
        return KosztNaprawu;
    }

    public override void GetOpisTransportu()
    {
        Console.WriteLine($"ID: {Id}, Marka: {Marka}, Model: {Model}, Rejestracja: {Rejestracja}, Waga: {Waga}, PojemnoscSilnika: {PojemnoscSilnika}, Przebieg: {Przebieg}, Status: {status}");
    }

}

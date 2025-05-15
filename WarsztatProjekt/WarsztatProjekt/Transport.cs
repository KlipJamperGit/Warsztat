using System.Text.Json.Serialization;

namespace WarsztatProjekt;

public abstract class Transport 
{
    public int Id { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Rejestracja { get; set; }
    public double Waga { get; set; }
    public double PojemnoscSilnika { get; set; }
    public double Przebieg { get; set; }
    public StatusZlecenia status { get; set; }
    public double KosztNaprawu { get; set; }
    protected Transport() { }
    protected Transport(int id, string marka, string model, string rejestracja, double waga, double pojemnoscSilnika, double przebieg, StatusZlecenia status, double kosztNaprawy)
    {
        Id = id;
        Marka = marka;
        Model = model;
        Rejestracja = rejestracja;
        Waga = waga;
        PojemnoscSilnika = pojemnoscSilnika;
        Przebieg = przebieg;
        this.status = status;
        KosztNaprawu = kosztNaprawy;
    }


    public abstract void GetOpisTransportu();


    public void ToString()
    {
        Console.WriteLine($"ID: {Id}, Marka: {Marka}, Model: {Model}, Rejestracja: {Rejestracja}, Waga: {Waga}, PojemnoscSilnika: {PojemnoscSilnika}, Przebieg: {Przebieg}, Status: {status}");
    }

    public bool Equals(Osoba other)
    {
        return this.Id == other.Id;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}

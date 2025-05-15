
namespace WarsztatProjekt;
public abstract class Osoba : IEquatable<Osoba>, IPay
{
    public int Id { get; private set; }
    public string Imie { get; set; }
    public string Password { get; private set; } 

    protected Osoba(int Id, string Imie, string Password, double Balance = 0)
    {
        this.Id = Id;
        this.Imie = Imie;
        this.Password = Password;
    }

    public abstract void WyswietlDane();
    public abstract int GetId();

    public virtual bool CheckPassword(string password)
    {
        return Password == password;
    }
    public override string ToString()
    {
        return $"ID: {Id}, Imię: {this.Imie}";
    }

    public bool Equals(Osoba other)
    {
        return this.Id == other.Id && this.Imie == other.Imie;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public abstract bool Pay(IPay pay, double KosztNaprawy);
    public abstract double GetBalance();
}

using System;
using WarsztatProjekt;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IPay
{
    protected static double Balance;
    bool Pay(IPay Balance, double KosztNaprawy);
    public void DoładowanieBalance(double sum)
    {
        IPay.Balance += sum;
    }
    public double GetBalance()
    {
        return IPay.Balance;
    }
}

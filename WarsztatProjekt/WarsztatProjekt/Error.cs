using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MyCustomException : Exception
{
    private int ErrorCode;

    public MyCustomException(string message, int errorCode)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    public string GetFullError()
    {
        return $" Error [{ErrorCode}]: {Message}";
    }
    public string PaymentError()
    {
        return $" Error \"Nie masz wystarczających środków na koncie.\" [{ErrorCode}]: {Message}";
    }
}


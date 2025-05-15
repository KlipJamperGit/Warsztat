using System;

namespace WarsztatProjekt;

public static class IdGenerator
{
    public static int GenerateId()
    {
        return Guid.NewGuid().GetHashCode();
    }
}

using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object obj)
    {
        if(obj is FacialFeatures other)
            return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
        return false;
        
    }
    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object obj)
    {
        if(obj is Identity other)
            return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
        return false;
    }
    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures.GetHashCode());
}

public class Authenticator
{
    private static readonly string adminEmail = "admin@exerc.ism";
    private static readonly FacialFeatures adminFace = new("green",0.9m);
    private readonly Identity adminIdentity = new Identity(adminEmail, adminFace);
    private readonly HashSet<Identity> identities = [];
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(adminIdentity);

    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;

   
}

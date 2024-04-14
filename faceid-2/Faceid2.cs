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

    public override bool Equals(object obj) => ReferenceEquals(this,obj) || Equals(obj as  FacialFeatures);
    private bool Equals(FacialFeatures other) => other is not null && EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
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
    public override bool Equals(object obj) => ReferenceEquals(this,obj) || Equals(obj as Identity);
    private bool Equals(Identity other) => other is not null && Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures.GetHashCode());
}

public class Authenticator
{
    
    private readonly HashSet<Identity> identities = [];
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(adminIdentity);

    public bool Register(Identity identity) => !IsRegistered(identity) && identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;

    #region Fixed values
    private static readonly Identity adminIdentity = new("admin@exerc.ism", new("green", 0.9m));
    #endregion

}

namespace ASE_Test.Models;

public class Locatie : IComparable<Locatie>
{
    public string Straat { get; set; }
    public int Postcode { get; set; }
    public string Stad { get; set; }

    public override string ToString()
    {
        return $"{Straat}, {Postcode} {Stad}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Locatie locatie)
        {
            return Straat == locatie.Straat && Stad == locatie.Stad;
        }
        return false;
    }

    public int CompareTo(Locatie other)
    {
        if (other == null)
            return 1;

        int straatComparison = Straat.CompareTo(other.Straat);
        if (straatComparison == 0)
            return Stad.CompareTo(other.Stad);

        return straatComparison;
    }
    
}
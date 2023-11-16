using System.Runtime.InteropServices;

namespace ASE_Test.Models;

public abstract class Controle : IComparable<Controle>
{
    public int Jaar { get; set; }
    public int Maand { get; set; }
    public Locatie Locatie { get; set; }
    public abstract string Details { get; }

    public override string ToString()
    {
        string maandText = Maand switch
        {
            1 => "Januari",
            2 => "Februari",
            3 => "Maart",
            4 => "April",
            5 => "Mei",
            6 => "Juni",
            7 => "Juli",
            8 => "Augustus",
            9 => "September",
            10 => "Oktober",
            11 => "November",
            12 => "December",
            _ => "Onbekende maand"
        };

        return $"\nControle:\n{maandText} {Jaar}\n{Locatie}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Controle controle)
            return Locatie.Equals(controle.Locatie);
        return false;
    }

    public int CompareTo(Controle other)
    {
        if (other == null)
            return 1;

        int stadComparison = Locatie.Stad.CompareTo(other.Locatie.Stad);
        if (stadComparison == 0)
            return Locatie.Straat.CompareTo(other.Locatie.Straat);

        return stadComparison;
    }
}

public class Snelheidscontrole : Controle
{
    public int AantalControles { get; set; }
    public int AantalVoertuigen { get; set; }
    public int AantalOvertredingen { get; set; }
    public float OvertredingsGraad
    {
        get { return (float)AantalOvertredingen / AantalVoertuigen; }
    }

    public override string Details
    {
        get { return $"Details:\nAantal controles: {AantalControles}\nAantal voertuigen: {AantalVoertuigen}\nAantal overtredingen: {AantalOvertredingen}\nOvertredingsgraad: {OvertredingsGraad:F2}%"; }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\n{Details}";
    }
}

public class SnelheidscontroleExceptie : Exception
{
    public string WrongFieldName { get; }
    public object WrongValue { get; }
    public object WrongLine { get; }

    public SnelheidscontroleExceptie(string fieldName, object value, string line)
    {
        WrongFieldName = fieldName;
        WrongValue = value;
        WrongLine = line;

        using (StreamWriter writer = File.AppendText("errors.txt"))
        {
            writer.WriteLine($"[{DateTime.Now}] {Message}\n\t\tWrong line: [{WrongLine}]");
        }
    }

    public override string Message =>
        $"Invalid value '{WrongValue}' for field '{WrongFieldName}' in Snelheidscontrole.";
}
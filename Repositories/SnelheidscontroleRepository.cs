using System.Net;

namespace ASE_Test.Repositories;

public interface ISnelheidscontroleRepository
{
    List<Snelheidscontrole> GetSnelheidscontroles();
    IEnumerable<Snelheidscontrole> GetSnelheidscontrolesByLocatie(Locatie locatie);
    IEnumerable<Snelheidscontrole> GetSnelheidscontrolesByMaand(int maand);
}

public class SnelheidscontroleRepository : ISnelheidscontroleRepository
{
    public List<Snelheidscontrole> GetSnelheidscontroles()
    {
        List<Snelheidscontrole> snelheidscontroles = new();

        string filePath = Path.Combine(Environment.CurrentDirectory, "data", "speedcontrols.csv");
        string[] content = File.ReadAllLines(filePath);

        foreach (string line in content.Skip(1))
        {
            try
            {            
                string[] values = line.Split(',');

                Locatie locatie = new()
                {
                    Straat = values[2],
                    Postcode = int.Parse(values[3]),
                    Stad = values[4]
                };

                if (string.IsNullOrEmpty(values[0]))
                    throw new SnelheidscontroleExceptie("Jaar", values[0], line);
                if (string.IsNullOrEmpty(values[1]))
                    throw new SnelheidscontroleExceptie("Maand", values[1], line);
                if (string.IsNullOrEmpty(values[5]))
                    throw new SnelheidscontroleExceptie("Aantal controles", values[5], line);
                if (string.IsNullOrEmpty(values[6]))
                    throw new SnelheidscontroleExceptie("Aantal voertuigen", values[6], line);
                if (string.IsNullOrEmpty(values[7]))
                    throw new SnelheidscontroleExceptie("Aantal overtredingen", values[7], line);

                Snelheidscontrole snelheidscontrole = new()
                {
                    Jaar = int.Parse(values[0]),
                    Maand = int.Parse(values[1]),
                    Locatie = locatie,
                    AantalControles = int.Parse(values[5]),
                    AantalVoertuigen = int.Parse(values[6]),
                    AantalOvertredingen = int.Parse(values[7])
                };
                snelheidscontroles.Add(snelheidscontrole);
            }
            catch (SnelheidscontroleExceptie e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return snelheidscontroles;
    }

    public IEnumerable<Snelheidscontrole> GetSnelheidscontrolesByLocatie(Locatie locatie)
    {
        List<Snelheidscontrole> snelheidscontroles = GetSnelheidscontroles();
        return snelheidscontroles.Where(snelheidscontrole => snelheidscontrole.Locatie.Equals(locatie));
    }

    public IEnumerable<Snelheidscontrole> GetSnelheidscontrolesByMaand(int maand)
    {
        List<Snelheidscontrole> snelheidscontroles = GetSnelheidscontroles();
        return snelheidscontroles.Where(snelheidscontrole => snelheidscontrole.Maand == maand);
    }

    public void AddSnelheidscontrole(Snelheidscontrole snelheidscontrole)
    {
        List<Snelheidscontrole> snelheidscontroles = GetSnelheidscontroles();
        snelheidscontroles.Add(snelheidscontrole);
        SaveSnelheidscontroles(snelheidscontroles);
    }

    private void SaveSnelheidscontroles(List<Snelheidscontrole> snelheidscontroles)
    {
        string file = "jaar,maand,straat,postcode,stad,aantal controles,aantal voertuigen,aantal overtredingen\n";

        foreach (Snelheidscontrole snelheidscontrole in snelheidscontroles)
        {
            file += $"{snelheidscontrole.Jaar},{snelheidscontrole.Maand},{snelheidscontrole.Locatie.Straat},{snelheidscontrole.Locatie.Postcode},{snelheidscontrole.Locatie.Stad},{snelheidscontrole.AantalControles},{snelheidscontrole.AantalVoertuigen},{snelheidscontrole.AantalOvertredingen}\n";
        }
        File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "data", "speedcontrols.csv"), file);
    }
}
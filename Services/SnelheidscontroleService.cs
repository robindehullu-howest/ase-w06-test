namespace ASE_Test.Services;

public interface ISnelheidscontroleService
{
    List<Snelheidscontrole> GetSnelheidscontroles();
    List<Snelheidscontrole> GetSortedSnelheidscontroles();
    List<Snelheidscontrole> GetSnelheidscontrolesByLocatie(Locatie locatie);
    List<Snelheidscontrole> GetSnelheidscontrolesByMaand(int maand);
    List<string> GetDetailsOfSnelheidscontroles();
    List<string> GetDetailsOfSortedSnelheidscontroles();
    List<string> GetDetailsOfSnelheidscontrolesByLocatie(Locatie locatie);
    List<string> GetDetailsOfSnelheidscontrolesByMaand(int maand);
    void AddSnelheidscontrole(Snelheidscontrole snelheidscontrole);
}

public class SnelheidscontroleService : ISnelheidscontroleService
{
    private SnelheidscontroleRepository _snelheidscontroleRepository = new();
    public List<Snelheidscontrole> GetSnelheidscontroles() => _snelheidscontroleRepository.GetSnelheidscontroles();
    public List<Snelheidscontrole> GetSortedSnelheidscontroles()
    {
        List<Snelheidscontrole> snelheidscontroles = GetSnelheidscontroles();
        snelheidscontroles.Sort();
        return snelheidscontroles;
    }

    public List<Snelheidscontrole> GetSnelheidscontrolesByLocatie(Locatie locatie) => _snelheidscontroleRepository.GetSnelheidscontrolesByLocatie(locatie).ToList();

    public List<Snelheidscontrole> GetSnelheidscontrolesByMaand(int maand) => _snelheidscontroleRepository.GetSnelheidscontrolesByMaand(maand).ToList();

    public List<string> GetDetailsOfSnelheidscontroles() => GetSnelheidscontroles().Select(snelheidscontrole => snelheidscontrole.Details).ToList();

    public List<string> GetDetailsOfSortedSnelheidscontroles() => GetSortedSnelheidscontroles().Select(snelheidscontrole => snelheidscontrole.Details).ToList();

    public List<string> GetDetailsOfSnelheidscontrolesByLocatie(Locatie locatie) => GetSnelheidscontrolesByLocatie(locatie).Select(snelheidscontrole => snelheidscontrole.Details).ToList();

    public List<string> GetDetailsOfSnelheidscontrolesByMaand(int maand) => GetSnelheidscontrolesByMaand(maand).Select(snelheidscontrole => snelheidscontrole.Details).ToList();

    public void AddSnelheidscontrole(Snelheidscontrole snelheidscontrole) => _snelheidscontroleRepository.AddSnelheidscontrole(snelheidscontrole);
}
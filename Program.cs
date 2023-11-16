bool exitRequested = false;
SnelheidscontroleService snelheidscontroleService = new();

while (!exitRequested)
{
    Console.WriteLine("\n[Snelheidscontroles]");
    Console.WriteLine("1. Snelheidscontroles opvragen");
    Console.WriteLine("2. Snelheidscontrole per maand opvragen");
    Console.WriteLine("3. Snelheidscontrole per locatie opvragen");
    Console.WriteLine("4. Details opvragen");
    Console.WriteLine("5. Detail per maand opvragen");
    Console.WriteLine("6. Detail per locatie opvragen");
    Console.WriteLine("7. Snelheidscontrole toevoegen");
    Console.WriteLine("8. Exit");
    Console.Write("Keuze: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("\n[Snelheidscontroles]");
            foreach (Snelheidscontrole sc1 in snelheidscontroleService.GetSnelheidscontroles())
            {
                Console.WriteLine(sc1);
            }
            break;
        case "2":
            Console.WriteLine("\n[Snelheidscontrole per maand opvragen]");
            Console.Write("Maand: ");
            int maand = Console.ReadLine().ToLower() switch
            {
                "januari" => 1,
                "februari" => 2,
                "maart" => 3,
                "april" => 4,
                "mei" => 5,
                "juni" => 6,
                "juli" => 7,
                "augustus" => 8,
                "september" => 9,
                "oktober" => 10,
                "november" => 11,
                "december" => 12,
                _ => 0
            };

            foreach (Snelheidscontrole sc2 in snelheidscontroleService.GetSnelheidscontrolesByMaand(maand))
            {
                Console.WriteLine(sc2);
            }
            break;
        case "3":
            Console.WriteLine("\n[Snelheidscontrole per locatie opvragen]");
            Console.Write("Straat: ");
            string straat1 = Console.ReadLine().ToUpper();
            Console.Write("Postcode: ");
            int postcode = int.Parse(Console.ReadLine());
            Console.Write("Stad: ");
            string stad1 = Console.ReadLine().ToUpper();
            Locatie locatie = new()
            {
                Straat = straat1,
                Postcode = postcode,
                Stad = stad1
            };

            foreach (Snelheidscontrole sc3 in snelheidscontroleService.GetSnelheidscontrolesByLocatie(locatie))
            {
                Console.WriteLine(sc3);
            }
            break;
        case "4":
            Console.WriteLine("\n[Details opvragen]");
            foreach (string details in snelheidscontroleService.GetDetailsOfSnelheidscontroles())
            {
                Console.WriteLine(details);
            }
            break;
        case "5":
            Console.WriteLine("\n[Detail per maand opvragen]");
            Console.Write("Maand: ");
            maand = Console.ReadLine().ToLower() switch
            {
                "januari" => 1,
                "februari" => 2,
                "maart" => 3,
                "april" => 4,
                "mei" => 5,
                "juni" => 6,
                "juli" => 7,
                "augustus" => 8,
                "september" => 9,
                "oktober" => 10,
                "november" => 11,
                "december" => 12,
                _ => 0
            };

            foreach (string details in snelheidscontroleService.GetDetailsOfSnelheidscontrolesByMaand(maand))
            {
                Console.WriteLine(details);
            }
            break;
        case "6":
            Console.WriteLine("\n[Detail per locatie opvragen]");
            Console.Write("Straat: ");
            string straat2 = Console.ReadLine().ToUpper();
            Console.Write("Postcode: ");
            postcode = int.Parse(Console.ReadLine());
            Console.Write("Stad: ");
            string stad2 = Console.ReadLine().ToUpper();
            locatie = new()
            {
                Straat = straat2,
                Postcode = postcode,
                Stad = stad2
            };

            foreach (string details in snelheidscontroleService.GetDetailsOfSnelheidscontrolesByLocatie(locatie))
            {
                Console.WriteLine(details);
            }
            break;
        case "7":
            Console.WriteLine("\n[Snelheidscontrole toevoegen]");
            Console.Write("Jaar: ");
            int jaar = int.Parse(Console.ReadLine());
            Console.Write("Maand: ");
            maand = Console.ReadLine().ToLower() switch
            {
                "januari" => 1,
                "februari" => 2,
                "maart" => 3,
                "april" => 4,
                "mei" => 5,
                "juni" => 6,
                "juli" => 7,
                "augustus" => 8,
                "september" => 9,
                "oktober" => 10,
                "november" => 11,
                "december" => 12,
                _ => 0
            };
            Console.Write("Straat: ");
            string straat3 = Console.ReadLine().ToUpper();
            Console.Write("Postcode: ");
            postcode = int.Parse(Console.ReadLine());
            Console.Write("Stad: ");
            string stad3 = Console.ReadLine().ToUpper();
            Console.Write("Aantal controles: ");
            int aantalControles = int.Parse(Console.ReadLine());
            Console.Write("Aantal voertuigen: ");
            int aantalVoertuigen = int.Parse(Console.ReadLine());
            Console.Write("Aantal overtredingen: ");
            int aantalOvertredingen = int.Parse(Console.ReadLine());
            locatie = new()
            {
                Straat = straat3,
                Postcode = postcode,
                Stad = stad3
            };
            Snelheidscontrole sc5 = new()
            {
                Jaar = jaar,
                Maand = maand,
                Locatie = locatie,
                AantalControles = aantalControles,
                AantalVoertuigen = aantalVoertuigen,
                AantalOvertredingen = aantalOvertredingen
            };
            snelheidscontroleService.AddSnelheidscontrole(sc5);
            break;
        case "8":
            exitRequested = true;
            break;
        default:
            Console.WriteLine("Ongeldige keuze");
            break;
    }
}
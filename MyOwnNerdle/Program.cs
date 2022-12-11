// See https://aka.ms/new-console-template for more information

using MyOwnNerdle;

GeneratorRovnice generator = new GeneratorRovnice();
Rovnice rovnice = new Rovnice();
VykreslovacRovnic vykreslovac = new VykreslovacRovnic();
List<string> vykresleniRovnic = new List<string>(); // Kolekce obsahuje uživatelské vstupy
string vstup = ""; // Uživatelský vstup
char[] povoleneZnaky = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '=' }; // Povolené znaky v rovnici
bool konecHry = false; // Logická proměnná řídí hlavní cyklus
bool spravnyVstup = false; // Logická proměnná řídí cyklus pro uživatelské vstupy

int vysledek = generator.VygenerujVysledek(); // Výsledek rovnice
int prvniCislo = generator.VygenerujPrvniCislo(vysledek); // První číslo v rovnici

rovnice = generator.VygenerujRovnici(vysledek, prvniCislo); // Rovnice

string rovnicePorovnani = rovnice.ToString().Replace(" ", ""); // Rovnice pro poronání s odstraněnými mezerami

while (!konecHry) // Hlavní cyklus programu
{
    Console.Clear();
    vstup = "";    

    Console.ForegroundColor = ConsoleColor.Yellow;
    
    Console.WriteLine("---------------");

    foreach (string r in vykresleniRovnic)
    {
        string vypis = r.Replace(" ", "");
        int[] infoKVypisu = vykreslovac.PorovnejVstupSRovnici(rovnicePorovnani, vypis);

        for (int i = 0; i < vypis.Length; i++)
        {
            switch(infoKVypisu[i])
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.Write(vypis[i] + " ");
        }
        Console.WriteLine();

    }

    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("---------------");

    if (vykresleniRovnic.Count > 0 && rovnicePorovnani == vykresleniRovnic.Last())
    {
        Console.WriteLine("Uhodl jsi dnešní rovnici.");
        break;
    }

    if (vykresleniRovnic.Count < 8)
    {
        while (!spravnyVstup) // Cyklus řídí uživatelské vstupy
        {
            for (int i = 0; i < 8; i++)
            {
                char znak = Console.ReadKey().KeyChar;
                vstup += znak;

                Console.CursorLeft += 1;
            }
            Console.WriteLine();

            if (!vykreslovac.ZkontrolujVstup(vstup, povoleneZnaky))
            {
                Console.WriteLine("Neplatný znak ve vstupu.");
                vstup = "";
            }
            else
            if (!vykreslovac.ZkontrolujRovnost(vstup))
            {
                Console.WriteLine("Levá strana se nerovná pravé.");
                vstup = "";
            }
            else
                spravnyVstup = true;
        }
        
        spravnyVstup = false;

        vykresleniRovnic.Add(vstup);
    }
    else
    {
        Console.WriteLine("Dnešní rovnici si neuhodl, tak snad příště.");
        konecHry = true;
    }


}

Console.ReadKey();

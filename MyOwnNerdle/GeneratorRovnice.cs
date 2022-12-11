using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnNerdle
{
    /// <summary>
    /// Třída reprezentuje generátor rovnice
    /// </summary>
    internal class GeneratorRovnice
    {
        private Rovnice rovnice; // Rovnice
        private Random generator; // Generátor čísel
        private int vysledek; // Výsledek rovnice
        private int prvniCislo; // První číslo v rovnici
        private int druheCislo; // Druhé číslo v rovnici
        private int tretiCislo; // Třetí číslo v rovnici
        private Rovnice.Operatory prvniOperator; // První operátor v rovnici
        private Rovnice.Operatory druhyOperator; // Druhý operátor v rovnici        

        private int operace; // Určuje jakou operace provedem v rovnici
        private int prirozenaCisla = 10; // Určuje délku cyklu
        private int prirozenaCislaVetsi = 100; // Určuje délku cyklu
        private bool spravneCislo = false; // Určuje zda dané číslo zapadá do rovnice

        //private int[,] malaNasobilka = new int[9, 9]; // Pole obsahuje malou násobilku
        //private int[] prirozenaCisla = new int[10]; // Pole obsahuje přirozená čísla od 0 do 9
        //private int[] prirozenaCislaVetsi = new int[100]; // Pole obsahuje přirozená čísla od 0 do 99

        // Vytvoří instanci třídy
        public GeneratorRovnice()
        {
            rovnice = new Rovnice();
            //NaplnPole(malaNasobilka);
            //NaplnMalePole(prirozenaCisla);
            //NaplnMalePole(prirozenaCislaVetsi);
        }

        // Vygeneruje náhodné číslo
        private int Generuj(int pocatek, int konec)
        {
            generator = new Random();
            return generator.Next(pocatek, konec + 1);
        }

        /// <summary>
        /// Vygeneruje výsledek
        /// </summary>
        /// <returns></returns>
        public int VygenerujVysledek()
        {
            int mnozstviVysledku = 892;
            IEnumerable<int> vysledky = Enumerable.Range(0, mnozstviVysledku);
            generator = new Random();

            vysledek = vysledky.Skip(generator.Next(mnozstviVysledku)).First();

            return vysledek;
        }

        /// <summary>
        /// Vygeneruje první číslo, v závislosti na hodnotě výsledku
        /// </summary>
        /// <param name="vysledek">Hodnota výsledku</param>
        /// <returns></returns>
        public int VygenerujPrvniCislo(int vysledek)
        {
            int mnozstviPrvnichCisel = 892;

            if (vysledek >= 100)
                mnozstviPrvnichCisel = 100;

            IEnumerable<int> prvniCisla = Enumerable.Range(0, mnozstviPrvnichCisel);
            generator = new Random();

            prvniCislo = prvniCisla.Skip(generator.Next(mnozstviPrvnichCisel)).First();

            return prvniCislo;
        }

        // Naplní pole malou násobilkou
        //private void NaplnPole(int[,] pole)
        //{
        //    for (int j = 0; j < pole.GetLength(1); j++)
        //    {
        //        for (int i = 0; i < pole.GetLength(0); i++)
        //        {
        //            pole[i, j] = (i + 1) * (j + 1);
        //        }
        //    }
        //}

        // Naplní pole čísly
        //private void NaplnMalePole(int[] pole)
        //{
        //    for (int k = 0; k < pole.Length; k++)
        //    {
        //        pole[k] = k;
        //    }
        //}

        /// <summary>
        /// Vyhledá další čísla do rovnice
        /// </summary>
        /// <param name="operace">Metoda, která určí, zda se parametry rovnají</param>
        /// <param name="prvniCislo">První číslo v rovnici</param>
        /// <param name="vysledek">Výsledek rovnice</param>
        /// <param name="zacatekCyklu">Hodnota pro začátek vedlejšího cyklu</param>
        /// <param name="konecCyklu">Hodnota pro konec vedlejšího cyklu</param>
        /// <param name="prvniOperator">První operátor v rovnici</param>
        private void NajdiCisla(Operace operace, int prvniCislo, int vysledek, int zacatekCyklu, int konecCyklu, Rovnice.Operatory prvniOperator)
        {
            for (int i = 0; i < prirozenaCisla; i++)
            {
                for (int j = zacatekCyklu; j < konecCyklu; j++)
                {
                    if (operace(prvniCislo, i, j, vysledek, prvniOperator, Rovnice.Operatory.Krat))
                    {
                        druheCislo = i;
                        tretiCislo = j;
                        druhyOperator = Rovnice.Operatory.Krat;
                        break;
                    }
                    else
                    if (operace(prvniCislo, j, i, vysledek, prvniOperator, Rovnice.Operatory.Krat))
                    {
                        druheCislo = j;
                        tretiCislo = i;
                        druhyOperator = Rovnice.Operatory.Krat;
                        break;
                    }
                    else
                    if (operace(prvniCislo, i, j, vysledek, prvniOperator, Rovnice.Operatory.Deleno))
                    {
                        druheCislo = i;
                        tretiCislo = j;
                        druhyOperator = Rovnice.Operatory.Deleno;
                        break;
                    }
                    else
                    if (operace(prvniCislo, j, i, vysledek, prvniOperator, Rovnice.Operatory.Deleno))
                    {
                        druheCislo = j;
                        tretiCislo = i;
                        druhyOperator = Rovnice.Operatory.Deleno;
                        break;
                    }
                    else
                    if (operace(prvniCislo, i, j, vysledek, prvniOperator, Rovnice.Operatory.Plus))
                    {
                        druheCislo = i;
                        tretiCislo = j;
                        druhyOperator = Rovnice.Operatory.Plus;
                    }
                    else
                    if (operace(prvniCislo, j, i, vysledek, prvniOperator, Rovnice.Operatory.Plus))
                    {
                        druheCislo = j;
                        tretiCislo = i;
                        druhyOperator = Rovnice.Operatory.Plus;
                    }
                    else
                    if (operace(prvniCislo, i, j, vysledek, prvniOperator, Rovnice.Operatory.Minus))
                    {
                        druheCislo = i;
                        tretiCislo = j;
                        druhyOperator = Rovnice.Operatory.Minus;
                        break;
                    }
                    else
                    if (operace(prvniCislo, j, i, vysledek, prvniOperator, Rovnice.Operatory.Minus))
                    {
                        druheCislo = j;
                        tretiCislo = i;
                        druhyOperator = Rovnice.Operatory.Minus;
                        break;
                    }
                }
            }
        }

        public delegate bool Operace(int a, int b, int c, int d, Rovnice.Operatory prvniOperator, Rovnice.Operatory druhyOperator); // Delegát zastupuje metodu pro porovnání čísel v rovnici

        public delegate bool KratsiOperace(int a, int b, int c, Rovnice.Operatory prvniOperator); // Delegát zastupuje metodu pro porovnání čísel v rovnici o jednom operátoru

        /// <summary>
        /// Vyhledá další číslo do rovnice
        /// </summary>
        /// <param name="operace">Metoda pro vyhledávání</param>
        /// <param name="prvniCislo">První číslo v rovnici</param>
        /// <param name="vysledek">Výsledek</param>
        /// <param name="zacatekCyklu">Začátek vyhledávacího cyklu</param>
        /// <param name="konecCyklu">Konec vyhledávacího cyklu</param>
        /// <param name="prvniOperator">První operátor v rovnici</param>
        private void NajdiDalsiCisla(KratsiOperace operace, int prvniCislo, int vysledek, int zacatekCyklu, int konecCyklu, Rovnice.Operatory prvniOperator)
        {
            for (int i = zacatekCyklu; i < konecCyklu; i++)
            {
                if (operace(prvniCislo, i, vysledek, prvniOperator))
                {
                    druheCislo = i;
                    break;
                }
                else
                    druheCislo = 999;
            }
        }
        public Rovnice VygenerujRovnici(int vysledek, int prvniCislo)
        {
            /*vysledek = Generuj(0, 9);*/ // Výsledek může být číslo od 0 do 891 včetně            
            druhyOperator = Rovnice.Operatory.Prazdny;

            switch (vysledek)
            {
                case < 10: // Jednociferný výsledek
                    /*prvniCislo = Generuj(0, 891);*/ // První číslo může nabýt hodnoty od 0 do 891                    
                    operace = Generuj(1, 4);
                    switch (prvniCislo)
                    {
                        case < 10: // Jednociferné první číslo                            

                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání                                                                       

                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);

                                        break;
                                    case 2: // Odčítání                                    

                                        prvniOperator = Rovnice.Operatory.Minus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);

                                        break;

                                    case 3: // Násobení

                                        prvniOperator = Rovnice.Operatory.Krat;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);

                                        break;

                                    case 4: // Dělení                                  

                                        //for (int i = 0; i < prirozenaCisla; i++) // Jednociferná čísla
                                        //{
                                        //    for (int j = 10; j < prirozenaCislaVetsi; j++) // Dvouciferná čísla
                                        //    {
                                        //        if (i != 0 && ((double)prvniCislo) / i + j == vysledek)
                                        //        {
                                        //            druheCislo = i;
                                        //            tretiCislo = j;
                                        //            druhyOperator = Rovnice.Operatory.Plus;
                                        //        }
                                        //        else
                                        //        if (((double)prvniCislo) / j + i == vysledek)
                                        //        {
                                        //            druheCislo = j;
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Plus;
                                        //        }
                                        //        else
                                        //        if (i != 0 && ((double)prvniCislo) / i * j == vysledek)
                                        //        {
                                        //            druheCislo = i;
                                        //            tretiCislo = j;
                                        //            druhyOperator = Rovnice.Operatory.Krat;
                                        //            break;
                                        //        }
                                        //        else
                                        //        if (((double)prvniCislo) / j * i == vysledek)
                                        //        {
                                        //            druheCislo = j;
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Krat;
                                        //            break;
                                        //        }
                                        //        else
                                        //        if (i != 0 && ((double)prvniCislo) / i / j == vysledek)
                                        //        {
                                        //            druheCislo = i;
                                        //            tretiCislo = j;
                                        //            druhyOperator = Rovnice.Operatory.Deleno;
                                        //            break;
                                        //        }
                                        //        else
                                        //        if (i != 0 && ((double)prvniCislo) / j / i == vysledek)
                                        //        {
                                        //            druheCislo = j;
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Deleno;
                                        //            break;
                                        //        }

                                        //    }
                                        //}

                                        prvniOperator = Rovnice.Operatory.Deleno;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);
                                        break;
                                }

                                if (operace == 3 && druhyOperator == Rovnice.Operatory.Prazdny)
                                    operace = 4;
                                else
                                if (operace == 4 && druhyOperator == Rovnice.Operatory.Prazdny)
                                    operace = 3;
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;
                            break;

                        case < 100: // Dvouciferné první číslo                            
                            //if (prvniCislo > 18 && operace == 1) // Je-li první číslo větší než 18 a výsledek jednociferný, nebude sčítání fungovat, přejdeme tedy na další operaci
                            //    operace++;
                            //if (prvniCislo >= 90 && operace != 4) // Pokud je první číslo větší než 90, lze pouze vydělit
                            //    operace = 4;

                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání                                    

                                        //druheCislo = Generuj(0, 9);

                                        //if (prvniCislo + druheCislo > 18) // Pokud je součet prvního a druhého čísla větší než 18, druhé číslo se zmenší
                                        //{
                                        //    druheCislo -= prvniCislo + druheCislo - 18;
                                        //}

                                        //int rozdil = prvniCislo + druheCislo - vysledek; // Hodnota třetího čísla, v jiné proměnné kvůli kontrole hodnoty

                                        //if (rozdil > 9) // Pokud je rozdíl > 9, musí se upravit rovnice
                                        //{
                                        //    rozdil -= 9;
                                        //    int moduloRozdilu = rozdil % 2;
                                        //    int prvniPolovina = ((rozdil - moduloRozdilu) / 2) + moduloRozdilu;
                                        //    int druhaPolovina = (rozdil - moduloRozdilu) / 2;

                                        //    prvniCislo -= prvniPolovina;
                                        //    vysledek += druhaPolovina;

                                        //    if (prvniCislo < 10) // Kontrola, zda první číslo není menší než 10
                                        //    {
                                        //        int zvyseni = 10 - prvniCislo;
                                        //        prvniCislo += zvyseni;
                                        //        vysledek += zvyseni;
                                        //    }

                                        //    if (vysledek > 10) // Kontrola, zda výsledek není větší než 10
                                        //    {
                                        //        int snizeni = vysledek - 10 + 1;
                                        //        prvniCislo -= snizeni;
                                        //        vysledek -= snizeni;
                                        //    }
                                        //}

                                        //tretiCislo = prvniCislo + druheCislo - vysledek; // Dopočítané třetí číslo po kontrole všech hodnot

                                        //prvniOperator = Rovnice.Operatory.Plus;
                                        //druhyOperator = Rovnice.Operatory.Minus;

                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 2: // Odčítání

                                        ////while (!spravneCislo)
                                        ////{
                                        ////    int mezicislo = prvniCislo - vysledek;

                                        ////    foreach (int i in prirozenaCisla) // Zkontrolujeme, zda se mezičíslo dá vytvořit součtem či rozdílem
                                        ////    {
                                        ////        for (int j = 0; j < prirozenaCisla.Length; j++)
                                        ////        {
                                        ////            if (mezicislo == i + j) // Kontrola součtu
                                        ////            {
                                        ////                druheCislo = i;
                                        ////                tretiCislo = j;
                                        ////                druhyOperator = Rovnice.Operatory.Plus;
                                        ////            }
                                        ////            else
                                        ////            if (prvniCislo - i - j == vysledek) // Kontrola rozdílu
                                        ////            {
                                        ////                druheCislo = i;
                                        ////                tretiCislo = j;
                                        ////                druhyOperator = Rovnice.Operatory.Minus;
                                        ////            }
                                        ////        }

                                        ////        for (int j = 1; j < prirozenaCisla.Length; j++) // Kontrolujeme, zda mezičíslo vytvoříme podílem
                                        ////        {
                                        ////            if (mezicislo == i / j && i % j == 0)
                                        ////            {
                                        ////                druheCislo = i;
                                        ////                tretiCislo = j;
                                        ////                druhyOperator = Rovnice.Operatory.Deleno;
                                        ////            }
                                        ////        }
                                        ////    }

                                        ////    for (int j = 0; j < malaNasobilka.GetLength(1); j++) // Kontrolujeme, zda mezičíslo vytvoříme součinem
                                        ////    {
                                        ////        for (int i = 0; i < malaNasobilka.GetLength(0); i++)
                                        ////        {
                                        ////            if (malaNasobilka[i, j] == mezicislo)
                                        ////            {
                                        ////                druheCislo = i + 1;
                                        ////                tretiCislo = j + 1;
                                        ////                druhyOperator = Rovnice.Operatory.Krat;
                                        ////            }
                                        ////        }
                                        ////    }

                                        ////    if (druhyOperator == Rovnice.Operatory.Prazdny) // Pokud nenastane ani jedna podmínka, upravíme první číslo nebo výsledek
                                        ////    {
                                        ////        if (prvniCislo > 10)
                                        ////            prvniCislo -= 1;
                                        ////        else
                                        ////            if (vysledek < 9)
                                        ////        {
                                        ////            vysledek += 1;
                                        ////        }
                                        ////    }
                                        ////    else
                                        ////        spravneCislo = true;
                                        ////}

                                        ////spravneCislo = false;
                                        ////prvniOperator = Rovnice.Operatory.Minus;

                                        prvniOperator = Rovnice.Operatory.Minus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 3: // Násobení

                                        ////druheCislo = Generuj(0, 9); // Vygenerujeme druhé číslo

                                        ////while (prvniCislo * druheCislo >= 90 && druheCislo >= 0) // Snížíme druhé číslo pokud je součín větší než nebo roven 90
                                        ////{
                                        ////    druheCislo--;
                                        ////}

                                        ////while (!spravneCislo)
                                        ////{
                                        ////    for (int i = 0; i < prirozenaCisla.Length; i++)
                                        ////    {
                                        ////        if (prvniCislo * druheCislo + i == vysledek) // Kontrolujeme, zda třetí číslo můžeme přičíst
                                        ////        {
                                        ////            tretiCislo = i;
                                        ////            druhyOperator = Rovnice.Operatory.Plus;
                                        ////        }
                                        ////        else
                                        ////        if (prvniCislo * druheCislo - i == vysledek) // Kontrolujeme, zda třetí číslo můžeme odečíst 
                                        ////        {
                                        ////            tretiCislo = i;
                                        ////            druhyOperator = Rovnice.Operatory.Minus;
                                        ////        }
                                        ////        else
                                        ////        if (prvniCislo * druheCislo * i == vysledek) // Kontrolujeme, zda třetím číslem můžeme násobit
                                        ////        {
                                        ////            tretiCislo = i;
                                        ////            druhyOperator = Rovnice.Operatory.Krat;
                                        ////        }
                                        ////        else
                                        ////        if (i != 0 && prvniCislo * druheCislo / i == vysledek && prvniCislo * druheCislo % i == 0) // Kontrolujeme, zda třetím číslem můžeme dělit
                                        ////        {
                                        ////            tretiCislo = i;
                                        ////            druhyOperator = Rovnice.Operatory.Deleno;
                                        ////        }
                                        ////    }

                                        ////    if (druhyOperator == Rovnice.Operatory.Prazdny) // Pokud nenastane ani jedna podmínka, upravíme první číslo nebo výsledek
                                        ////    {
                                        ////        if (prvniCislo > 10)
                                        ////            prvniCislo -= 1;
                                        ////        else
                                        ////            if (vysledek < 9)
                                        ////        {
                                        ////            vysledek += 1;
                                        ////        }
                                        ////    }
                                        ////    else
                                        ////        spravneCislo = true;
                                        ////}

                                        ////spravneCislo = false;
                                        ////prvniOperator = Rovnice.Operatory.Krat;

                                        prvniOperator = Rovnice.Operatory.Krat;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 4: // Dělení

                                        //while (!spravneCislo)
                                        //{
                                        //    int[] modula = new int[10];
                                        //    modula[0] = 100; // Schválně dosadíme nesmyslnou hodnotu, aby nám ji dotaz nevracel jako nejmenší

                                        //    for (int i = 1; i < prirozenaCisla.Length; i++) // Zjistíme, zda jde první číslo dělit beze zbytku
                                        //    {
                                        //        modula[i] = prvniCislo % prirozenaCisla[i];
                                        //    }

                                        //    int dotaz = modula.OrderBy(m => m).Select(m => m).First(); // Vybereme nejnižší modulo
                                        //    druheCislo = prirozenaCisla[Array.LastIndexOf(modula, dotaz)]; // Jako druhé číslo nastavíme takové kterým je první číslo nejlépe dělitelné
                                        //    prvniCislo -= dotaz; // Upravíme první číslo, aby se jednalo o rovnici

                                        //    for (int i = 0; i < prirozenaCisla.Length; i++)
                                        //    {
                                        //        if (prvniCislo / druheCislo + i == vysledek) // Kontrolujeme, zda třetí číslo můžeme přičíst
                                        //        {
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Plus;
                                        //        }
                                        //        else
                                        //        if (prvniCislo / druheCislo - i == vysledek) // Kontrolujeme, zda třetí číslo můžeme odečíst 
                                        //        {
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Minus;
                                        //        }
                                        //        else
                                        //        if (prvniCislo / druheCislo * i == vysledek) // Kontrolujeme, zda třetím číslem můžeme násobit
                                        //        {
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Krat;
                                        //        }
                                        //        else
                                        //        if (i != 0 && prvniCislo / druheCislo / i == vysledek && prvniCislo / druheCislo % i == 0) // Kontrolujeme, zda třetím číslem můžeme dělit
                                        //        {
                                        //            tretiCislo = i;
                                        //            druhyOperator = Rovnice.Operatory.Deleno;
                                        //        }
                                        //    }

                                        //    if (druhyOperator == Rovnice.Operatory.Prazdny) // Pokud nenastane ani jedna podmínka, upravíme první číslo nebo výsledek
                                        //    {
                                        //        if (prvniCislo > 10)
                                        //            prvniCislo -= 1;
                                        //        else
                                        //            if (vysledek < 9)
                                        //        {
                                        //            vysledek += 1;
                                        //        }
                                        //    }
                                        //    else
                                        //        spravneCislo = true;
                                        //}

                                        //spravneCislo = false;
                                        //prvniOperator = Rovnice.Operatory.Deleno;

                                        prvniOperator = Rovnice.Operatory.Deleno;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;
                                }

                                if (druhyOperator == Rovnice.Operatory.Prazdny)
                                {
                                    if (operace == 1)
                                    {
                                        if (vysledek < 9)
                                            vysledek++;
                                        else
                                        if (prvniCislo > 10)
                                            prvniCislo--;
                                    }

                                    if (operace == 2)
                                    {
                                        if (prvniCislo > 10)
                                            prvniCislo--;
                                    }

                                    if (operace == 4)
                                    {
                                        if (prvniCislo > 10)
                                            prvniCislo--;
                                    }
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;

                        case >= 100: // Trojciferné první číslo

                            ////if (vysledek == 0) // Ošetření případu, kde by mohlo dojít k dělení nulou
                            ////    vysledek = Generuj(1, 9);
                            ////while (!spravneCislo)
                            ////{
                            ////    if (prvniCislo % vysledek != 0) // Úprava prvního čísla pro případ, že by nešlo dělit výsledkem beze zbytku
                            ////        prvniCislo -= prvniCislo % vysledek;

                            ////    druheCislo = prvniCislo / vysledek;

                            ////    if (druheCislo > 99 || prvniCislo < 100)// Ošetření případu, kde by bylo druhé číslo trojciferné, nebo první dvouciferné
                            ////    {
                            ////        prvniCislo = 120;
                            ////        int[] nahradniVysledek = { 2, 3, 4, 5, 6 }; // Pokud rovnice nevyhovuje, použíjeme alternativní výsledky 
                            ////        vysledek = nahradniVysledek.Skip(Generuj(0, nahradniVysledek.Length - 1)).First();
                            ////    }
                            ////    else
                            ////        spravneCislo = true;
                            ////}

                            ////spravneCislo = false;
                            ////prvniOperator = Rovnice.Operatory.Deleno;                            

                            while (!spravneCislo)
                            {
                                prvniOperator = Rovnice.Operatory.Deleno;
                                NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);

                                if (druheCislo == 999)
                                {
                                    if (prvniCislo > 100)
                                        prvniCislo--;
                                    else
                                        vysledek++;
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;

                    }
                    break;

                case < 100: // Dvouciferný výsledek
                    //prvniCislo = Generuj(0, 891);
                    operace = Generuj(1, 4);
                    switch (prvniCislo)
                    {
                        case < 10: // Jednociferné první číslo

                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání
                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 2: // Odčítání
                                        prvniOperator = Rovnice.Operatory.Minus;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 3: // Násobení
                                        prvniOperator = Rovnice.Operatory.Krat;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 4: // Dělení                                    
                                        prvniOperator = Rovnice.Operatory.Deleno;
                                        NajdiCisla(rovnice.ZkontrolujRovnost, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;
                                }

                                if (druhyOperator == Rovnice.Operatory.Prazdny)
                                {
                                    operace = 3;

                                    if (prvniCislo != 9)
                                        prvniCislo++;

                                    if (vysledek > 10)
                                        vysledek--;
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;
                            break;

                        case < 100: // Dvouciferné první číslo

                            if (operace == 3 || operace == 4)
                                operace = 2;
                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání
                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);
                                        break;

                                    case 2: // Odčítání
                                        prvniOperator = Rovnice.Operatory.Minus;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);
                                        break;
                                }

                                if (druheCislo == 999)
                                {
                                    if (prvniCislo > 19 && vysledek > 10)
                                        vysledek--;
                                    else
                                    if (prvniCislo < 20)
                                    {
                                        prvniCislo++;
                                    }

                                    operace = 2;
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;

                        case >= 100: // Trojciferné první číslo

                            if (operace == 1 || operace == 3)
                                operace = 2;
                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 2: // Odčítání
                                        prvniOperator = Rovnice.Operatory.Minus;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 4: // Dělení
                                        prvniOperator = Rovnice.Operatory.Deleno;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;
                                }

                                if (druheCislo == 999)
                                {
                                    if (operace == 2)
                                    {
                                        if (prvniCislo > 108)
                                            prvniCislo--;
                                        else
                                        if(vysledek < 99)
                                            vysledek++;

                                    }

                                    if (operace == 4)
                                    {
                                        if (vysledek < 99)
                                            vysledek++;
                                        else
                                        if (prvniCislo < 891)
                                            prvniCislo++;
                                    }
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;
                    }
                    break;

                case >= 100: // Trojciferný výsledek
                    //prvniCislo = Generuj(0, 99);
                    operace = Generuj(1, 4);
                    if (operace == 2 || operace == 4)
                        operace = 3;
                    switch (prvniCislo)
                    {
                        case < 10: // Jednociferné první číslo
                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání
                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);
                                        break;

                                    case 3: // Násobení
                                        prvniOperator = Rovnice.Operatory.Krat;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 10, prirozenaCislaVetsi, prvniOperator);
                                        break;
                                }

                                if (druheCislo == 999)
                                {
                                    if (operace == 1)
                                    {
                                        if (prvniCislo == 0)
                                            prvniCislo++;
                                        else
                                        if (vysledek > 100)
                                            vysledek--;
                                    }

                                    if (operace == 3)
                                    {
                                        if (prvniCislo < 9)
                                            prvniCislo++;
                                        else
                                        if (vysledek < 891)
                                            vysledek++;
                                    }
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;

                        case < 100: // Dvouciferné první číslo

                            while (!spravneCislo)
                            {
                                switch (operace)
                                {
                                    case 1: // Sčítání
                                        prvniOperator = Rovnice.Operatory.Plus;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;

                                    case 3: // Násobení
                                        prvniOperator = Rovnice.Operatory.Krat;
                                        NajdiDalsiCisla(rovnice.ZkontrolujRovnostVetsichCisel, prvniCislo, vysledek, 0, prirozenaCisla, prvniOperator);
                                        break;
                                }

                                if (druheCislo == 999)
                                {
                                    if (operace == 1)
                                    {
                                        if (prvniCislo < 91)
                                            prvniCislo++;
                                        else
                                        if (vysledek > 100)
                                            vysledek--;
                                    }

                                    if (operace == 3)
                                    {
                                        if (prvniCislo < 99)
                                            prvniCislo++;
                                        else
                                        if (vysledek < 891)
                                            vysledek++;
                                    }
                                }
                                else
                                    spravneCislo = true;
                            }
                            spravneCislo = false;

                            break;
                    }
                    break;

                default:
                    prvniCislo = 7;
                    druheCislo = 14;
                    tretiCislo = 2;
                    vysledek = 1;
                    prvniOperator = Rovnice.Operatory.Deleno;
                    druhyOperator = Rovnice.Operatory.Krat;
                    break;

            }

            if (druhyOperator == Rovnice.Operatory.Prazdny)
                return new Rovnice(vysledek, prvniCislo, druheCislo, prvniOperator);

            return new Rovnice(vysledek, prvniCislo, druheCislo, tretiCislo, prvniOperator, druhyOperator);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnNerdle
{
    /// <summary>
    /// Třída reprezentuje vykreslovač rovnic
    /// </summary>
    internal class VykreslovacRovnic
    {
        Rovnice rovnice; // Instance třídy rovnice
        
        /// <summary>
        /// Konstruktor vytvoří instanci třídy
        /// </summary>
        public VykreslovacRovnic()
        {
            rovnice= new Rovnice();
        }

        /// <summary>
        /// Metoda zkontroluje, zda vstup od uživatele neobsahuje nepovolené znaky
        /// </summary>
        /// <param name="vstup">Vstup od uživatele</param>
        /// <param name="povoleneZnaky">Povolené znaky</param>
        /// <returns></returns>
        public bool ZkontrolujVstup(string vstup, char[] povoleneZnaky)
        {
            foreach (char z in vstup)
            {
                if (!povoleneZnaky.Contains(z))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Metoda zkontoluje, zda se levá strana rovnice rovná pravé
        /// </summary>
        /// <param name="vstup">Vstup od uživatele</param>
        /// <returns></returns>
        public bool ZkontrolujRovnost(string vstup)
        {
            int prvniC = 0;
            int druheC = 0;
            int tretiC = 0;
            int vysled = 0;
            List<char> serazeneOperatory = new List<char>();
            Rovnice.Operatory prvniOperator = Rovnice.Operatory.Prazdny;
            Rovnice.Operatory druhyOperator = Rovnice.Operatory.Prazdny;
            char[] operatory = { '+', '-', '*', '/' };
            string[] rovniceKusy = vstup.Split(new char[] { '+', '-', '*', '/', '=' });
            try
            {
                foreach (char c in vstup)
                {
                    if (operatory.Contains(c))
                        serazeneOperatory.Add(c);
                }

                prvniC = int.Parse(rovniceKusy[0]);
                druheC = int.Parse(rovniceKusy[1]);

                if (rovniceKusy.Length == 4)
                    tretiC = int.Parse(rovniceKusy[2]);

                vysled = int.Parse(rovniceKusy.Last());

                if (serazeneOperatory.Count <= 2)
                {
                    Rovnice.Operatory prohazovaci;

                    for (int i = 0; i < serazeneOperatory.Count; i++)
                    {
                        switch (serazeneOperatory[i])
                        {
                            case '+':
                                prohazovaci = Rovnice.Operatory.Plus;
                                break;

                            case '-':
                                prohazovaci = Rovnice.Operatory.Minus;
                                break;

                            case '*':
                                prohazovaci = Rovnice.Operatory.Krat;
                                break;

                            case '/':
                                prohazovaci = Rovnice.Operatory.Deleno;
                                break;

                            default:
                                prohazovaci = Rovnice.Operatory.Prazdny;
                                break;
                        }
                        if (i == 0)
                            prvniOperator = prohazovaci;
                        else
                            druhyOperator = prohazovaci;
                    }
                }


                if (druhyOperator == Rovnice.Operatory.Prazdny)
                {
                    return rovnice.ZkontrolujRovnostVetsichCisel(prvniC, druheC, vysled, prvniOperator);
                }

                return rovnice.ZkontrolujRovnost(prvniC, druheC, tretiC, vysled, prvniOperator, druhyOperator);
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Metoda porovná vstup s rovnicí a vygeneruje pole, které určí podbarvení jednotlivých znaků
        /// </summary>
        /// <param name="rovnice">Vygenerovaná rovnice</param>
        /// <param name="vstup">Vstup od uživatele</param>
        /// <returns></returns>
        public int[] PorovnejVstupSRovnici(string rovnice, string vstup)
        {
            int[] signalizacniCisla = new int[vstup.Length];

            for (int i = 0; i < vstup.Length; i++)
            {
                int pocetZnakuVRovnici = 0;
                int pocetZnakuVeVstupu = 0;
                char znak = vstup[i];

                if (rovnice[i] == znak)
                {
                    signalizacniCisla[i] = 1;
                }
                else
                if (rovnice.Contains(znak))
                {
                    for (int j = i; j < vstup.Length; j++)
                    {
                        if (rovnice[j] == znak)
                            pocetZnakuVRovnici++;

                        if (vstup[j] == znak)
                            pocetZnakuVeVstupu++;
                    }

                    if (pocetZnakuVeVstupu <= pocetZnakuVRovnici || pocetZnakuVeVstupu == 1)
                    {
                        signalizacniCisla[i] = 2;
                    }
                }
            }

            return signalizacniCisla;
        }
    }
}

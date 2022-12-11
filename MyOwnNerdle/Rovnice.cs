using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnNerdle
{
    /// <summary>
    /// Třída reprezentuje rovnici
    /// </summary>
    internal class Rovnice
    {
        // Slouží pro vytvoření rovnice o dvou operátorech na levé straně
        public Rovnice(int vysledek, int prvniCislo, int druheCislo, int tretiCislo, Operatory prvniOperator, Operatory druhyOperator)
        {
            Vysledek = vysledek;
            PrvniCislo = prvniCislo;
            DruheCislo = druheCislo;
            TretiCislo = tretiCislo;
            PrvniOperator = prvniOperator;
            DruhyOperator = druhyOperator;            
        }

        // Slouží pro vytvoření rovnice o jednom operátoru na levé straně
        public Rovnice(int vysledek, int prvniCislo, int druheCislo, Operatory prvniOperator)
        {
            Vysledek = vysledek;
            PrvniCislo = prvniCislo;
            DruheCislo = druheCislo;
            PrvniOperator = prvniOperator;            
            DruhyOperator = Operatory.Prazdny;
        }

        // Slouží pro vytvoření instance třídy
        public Rovnice()
        {
            
        }

        public int Vysledek { get; private set; } // Výsledek rovnice
        public int PrvniCislo { get; private set; } // První číslo na levé straně rovnice
        public int DruheCislo { get; private set; } // Druhé číslo na levé straně rovnice
        public int TretiCislo { get; private set; } // Třetí číslo na levé straně ronice
        public enum Operatory { Plus, Minus, Krat, Deleno, Prazdny } // Výčtový typ s druhy operátorů
        public Operatory PrvniOperator { get; private set; } // První operátor na levé straně rovnice
        public Operatory DruhyOperator { get; private set; } // Druhý operátor na levé straně rovnice        

        /// <summary>
        /// Zkontroluje, zda se předané hodnoty sobě rovnají
        /// </summary>
        /// <param name="prvniCislo">První číslo v rovnici</param>
        /// <param name="druheCislo">Druhé číslo v rovnici</param>
        /// <param name="tretiCislo">Třetí číslo v rovnici</param>
        /// <param name="vysledek">Výsledek rovnice</param>
        /// <param name="prvniOperator">První operátor v rovnici</param>
        /// <param name="druhyOperator">Druhý operátor v rovnici</param>
        /// <returns></returns>
        public bool ZkontrolujRovnost(int prvniCislo, int druheCislo, int tretiCislo, int vysledek, Operatory prvniOperator, Operatory druhyOperator)
        {
            switch (prvniOperator)
            {
                case Operatory.Plus:
                    switch (druhyOperator)
                    {
                        case Operatory.Plus:
                            if(prvniCislo + druheCislo + tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Minus:
                            if (prvniCislo + druheCislo - tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Krat:
                            if (prvniCislo + druheCislo * tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Deleno:
                            if (tretiCislo != 0 && prvniCislo + druheCislo / tretiCislo == vysledek && druheCislo % tretiCislo == 0)
                                return true;
                            break;
                    }
                    break;

                case Operatory.Minus:
                    switch (druhyOperator)
                    {
                        case Operatory.Plus:
                            if (prvniCislo - druheCislo + tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Minus:
                            if (prvniCislo - druheCislo - tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Krat:
                            if (prvniCislo - druheCislo * tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Deleno:
                            if (tretiCislo != 0 && prvniCislo - druheCislo / tretiCislo == vysledek && druheCislo % tretiCislo == 0)
                                return true;
                            break;
                    }
                    break;

                case Operatory.Krat:
                    switch (druhyOperator)
                    {
                        case Operatory.Plus:
                            if (prvniCislo * druheCislo + tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Minus:
                            if (prvniCislo * druheCislo - tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Krat:
                            if (prvniCislo * druheCislo * tretiCislo == vysledek)
                                return true;
                            break;

                        case Operatory.Deleno:
                            if (tretiCislo != 0 && prvniCislo * druheCislo / tretiCislo == vysledek && prvniCislo * druheCislo % tretiCislo == 0)
                                return true;
                            break;
                    }
                    break;

                case Operatory.Deleno:
                    if(prvniCislo < 10 && vysledek < 10)
                    {
                        switch (druhyOperator)
                        {
                            case Operatory.Plus:
                                if (druheCislo != 0 && (double)prvniCislo / druheCislo + tretiCislo == vysledek)
                                    return true;
                                break;

                            case Operatory.Minus:
                                if (druheCislo != 0 && (double)prvniCislo / druheCislo - tretiCislo == vysledek)
                                    return true;
                                break;

                            case Operatory.Krat:
                                if (druheCislo != 0 && (double)prvniCislo / druheCislo * tretiCislo == vysledek)
                                    return true;
                                break;

                            case Operatory.Deleno:
                                if (druheCislo != 0 && tretiCislo != 0 && (double)prvniCislo / druheCislo / tretiCislo == vysledek)
                                    return true;
                                break;
                        }
                    }
                    
                    switch (druhyOperator)
                    {
                        case Operatory.Plus:
                            if (druheCislo != 0 && prvniCislo / druheCislo + tretiCislo == vysledek && prvniCislo % druheCislo == 0)
                                return true;
                            break;

                        case Operatory.Minus:
                            if (druheCislo != 0 && prvniCislo / druheCislo - tretiCislo == vysledek && prvniCislo % druheCislo == 0)
                                return true;
                            break;

                        case Operatory.Krat:
                            if (druheCislo != 0 && prvniCislo / druheCislo * tretiCislo == vysledek && prvniCislo % druheCislo == 0)
                                return true;
                            break;

                        case Operatory.Deleno:
                            if (druheCislo != 0 && tretiCislo != 0 && prvniCislo / druheCislo / tretiCislo == vysledek && prvniCislo % druheCislo == 0 && prvniCislo / druheCislo % tretiCislo == 0)
                                return true;
                            break;
                    }
                    break;
            }
            
            return false;
        }

        /// <summary>
        /// Zkontoluje rovnost u rovnice s jedním operátorem
        /// </summary>
        /// <param name="prvniCislo">První číslo v rovnici</param>
        /// <param name="druheCislo">Druhé číslo v rovnici</param>
        /// <param name="vysledek">Výsledek rovnice</param>
        /// <param name="prvniOperator">První operátor v rovnici</param>
        /// <returns></returns>
        public bool ZkontrolujRovnostVetsichCisel(int prvniCislo, int druheCislo, int vysledek, Operatory prvniOperator)
        {
            switch (prvniOperator)
            {
                case Operatory.Plus:
                    if(prvniCislo + druheCislo == vysledek)
                        return true;
                    break;

                case Operatory.Minus:
                    if (prvniCislo - druheCislo == vysledek)
                        return true;
                    break;

                case Operatory.Krat:
                    if (prvniCislo * druheCislo == vysledek)
                        return true;
                    break;

                case Operatory.Deleno:
                    if (druheCislo != 0 && prvniCislo / druheCislo == vysledek && prvniCislo % druheCislo == 0)
                        return true;
                    break;
            }
            
            return false;
        }

        // Vloží operátor do výstupního stringu
        private string VratOperator(Operatory nejakyOperator)
        {
            string zastupOperatoru;            

            switch (nejakyOperator)
            {
                case Operatory.Plus:
                    zastupOperatoru = " + ";
                    break;
                case Operatory.Minus:
                    zastupOperatoru = " - ";
                    break;
                case Operatory.Krat:
                    zastupOperatoru = " * ";
                    break;
                case Operatory.Deleno:
                    zastupOperatoru = " / ";
                    break;
                default:
                    zastupOperatoru = "";
                    break;
            }

            return zastupOperatoru;
        }

        // Vypíš rovnici jako string
        public override string ToString()
        {           
            if(DruhyOperator == Operatory.Prazdny)
            {
                return PrvniCislo.ToString() + VratOperator(PrvniOperator) + DruheCislo.ToString() + " = " + Vysledek.ToString();
            }
            
            return PrvniCislo.ToString() + VratOperator(PrvniOperator) + DruheCislo.ToString() + VratOperator(DruhyOperator) + TretiCislo.ToString() + " = " + Vysledek.ToString();
        }

    }
}

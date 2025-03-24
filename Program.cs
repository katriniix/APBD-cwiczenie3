using System;
using System.Collections.Generic;

namespace cwiczenia3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Statek> statki = new List<Statek>();
            List<Contener> kontenery = new List<Contener>();

            while (true)
            {
                Console.WriteLine("\n--------------------------------------------------------------------------------------------");
                Console.WriteLine("Lista kontenerowcow:");
                if (statki.Count == 0)
                {
                    Console.WriteLine("Brak");
                }
                else
                {
                    for (int i = 0; i < statki.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {statki[i]}");
                    }
                }

                Console.WriteLine("\nLista kontenerow:");
                if (kontenery.Count == 0)
                {
                    Console.WriteLine("Brak");
                }
                else
                {
                    for (int i = 0; i < kontenery.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {kontenery[i]}");
                    }
                }

                Console.WriteLine("\nMozliwe akcje:");
                Console.WriteLine("1. Dodaj kontenerowiec");
                Console.WriteLine("2. Usun kontenerowiec");
                Console.WriteLine("3. Dodaj kontener");
                Console.WriteLine("4. Usun kontener");
                Console.WriteLine("5. Zaladuj kontener na statek");
                Console.WriteLine("6. Rozladuj kontener ze statku");
                Console.WriteLine("7. Zastap kontener na statku innym");
                Console.WriteLine("8. Przenies kontener na inny statek");
                Console.WriteLine("9. Zakoncz");

                Console.Write("\nWybierz operacje: ");
                if (!int.TryParse(Console.ReadLine(), out int operacja))
                {
                    Console.WriteLine("Niepoprawna operacja. Musisz podac liczbe.");
                    continue;
                }

                switch (operacja)
                {
                    case 1:
                        DodajKontenerowiec();
                        break;
                    case 2:
                        UsunKontenerowiec();
                        break;
                    case 3:
                        DodajKontener();
                        break;
                    case 4:
                        UsunKontener();
                        break;
                    case 5:
                        ZaladujKontener();
                        break;
                    case 6:
                        RozladujKontener();
                        break;
                    case 7:
                        ZastapKontenerInnym();
                        break;
                    case 8:
                        PrzeniesKontenerNaInnyStatek();
                        break;
                    case 9:
                        Console.WriteLine("Zakonczenie...");
                        return;
                    default:
                        Console.WriteLine("Niepoprawna operacja.");
                        break;
                }
            }

            // ↓↓↓ Ниже без изменений, только смещения индексов на -1

            void DodajKontenerowiec()
            {
                Console.Write("\nPodaj maksymalna predkosc: ");
                double maksPredkosc = double.Parse(Console.ReadLine());

                Console.Write("Podaj maksymalna liczbe kontenerow: ");
                int maksLiczbaKontenerow = int.Parse(Console.ReadLine());

                Console.Write("Podaj maksymalna wage kontenerow: ");
                double maksWagaKontenerow = double.Parse(Console.ReadLine());

                Statek statek = new Statek(maksPredkosc, maksLiczbaKontenerow, maksWagaKontenerow);
                statki.Add(statek);
            }

            void UsunKontenerowiec()
            {
                if (statki.Count == 0)
                {
                    Console.WriteLine("Brak statkow do usuniecia.");
                    return;
                }

                Console.Write("Podaj numer statku do usuniecia: ");
                int numer = int.Parse(Console.ReadLine()) - 1;

                if (numer < 0 || numer >= statki.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                statki.RemoveAt(numer);
            }

            void DodajKontener()
            {
                Console.WriteLine("\nMozliwe typy kontenera:");
                Console.WriteLine("1. Kontener na plyny");
                Console.WriteLine("2. Kontener na gaz");
                Console.WriteLine("3. Kontener chlodniczy");

                Console.Write("Wybierz typ: ");
                int typ = int.Parse(Console.ReadLine());

                Console.Write("Wysokosc: ");
                double wysokosc = double.Parse(Console.ReadLine());

                Console.Write("Waga wlasna: ");
                double wagaWlasna = double.Parse(Console.ReadLine());

                Console.Write("Glebokosc: ");
                double glebokosc = double.Parse(Console.ReadLine());

                Console.Write("Maksymalna ladownosc: ");
                double maksLadownosc = double.Parse(Console.ReadLine());

                Contener kontener = null;
                switch (typ)
                {
                    case 1:
                        Console.Write("Czy niebezpieczny? (true/false): ");
                        bool isDangerous = bool.Parse(Console.ReadLine());
                        kontener = new LiquidContener(wysokosc, wagaWlasna, glebokosc, maksLadownosc, isDangerous);
                        break;
                    case 2:
                        Console.Write("Cisnienie: ");
                        double cisnienie = double.Parse(Console.ReadLine());
                        kontener = new GasContener(wysokosc, wagaWlasna, glebokosc, maksLadownosc, cisnienie);
                        break;
                    case 3:
                        Console.Write("Rodzaj produktu: ");
                        string produkt = Console.ReadLine();
                        Console.Write("Temperatura: ");
                        double temperatura = double.Parse(Console.ReadLine());
                        kontener = new RefrigeretedContener(wysokosc, wagaWlasna, glebokosc, maksLadownosc, produkt, temperatura);
                        break;
                    default:
                        Console.WriteLine("Nieznany typ.");
                        return;
                }

                kontenery.Add(kontener);
            }

            void UsunKontener()
            {
                if (kontenery.Count == 0)
                {
                    Console.WriteLine("Brak kontenerow do usuniecia.");
                    return;
                }

                Console.Write("Numer kontenera do usuniecia: ");
                int numer = int.Parse(Console.ReadLine()) - 1;

                if (numer < 0 || numer >= kontenery.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                kontenery.RemoveAt(numer);
            }

            void ZaladujKontener()
            {
                if (kontenery.Count == 0 || statki.Count == 0)
                {
                    Console.WriteLine("Brakuje kontenerow lub statkow.");
                    return;
                }

                Console.Write("Numer kontenera do zaladowania: ");
                int numerKontenera = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Numer statku: ");
                int numerStatku = int.Parse(Console.ReadLine()) - 1;

                if (numerKontenera < 0 || numerKontenera >= kontenery.Count ||
                    numerStatku < 0 || numerStatku >= statki.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                statki[numerStatku].DodajKontener(kontenery[numerKontenera]);
            }

            void RozladujKontener()
            {
                if (statki.Count == 0)
                {
                    Console.WriteLine("Brak statkow.");
                    return;
                }

                Console.Write("Numer statku: ");
                int numerStatku = int.Parse(Console.ReadLine()) - 1;

                if (numerStatku < 0 || numerStatku >= statki.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                var statek = statki[numerStatku];
                if (statek.kontenery.Count == 0)
                {
                    Console.WriteLine("Brak kontenerow na statku.");
                    return;
                }

                for (int i = 0; i < statek.kontenery.Count; i++)
                    Console.WriteLine($"{i + 1}. {statek.kontenery[i].numerSeryjny}");

                Console.Write("Numer kontenera do rozladowania: ");
                int numerKontenera = int.Parse(Console.ReadLine()) - 1;

                if (numerKontenera < 0 || numerKontenera >= statek.kontenery.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                statek.RozladujKontener(statek.kontenery[numerKontenera].numerSeryjny);
            }

            void ZastapKontenerInnym()
            {
                if (statki.Count == 0 || kontenery.Count == 0)
                {
                    Console.WriteLine("Brakuje statkow lub kontenerow.");
                    return;
                }

                Console.Write("Numer statku: ");
                int numerStatku = int.Parse(Console.ReadLine()) - 1;
                if (numerStatku < 0 || numerStatku >= statki.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                var statek = statki[numerStatku];

                for (int i = 0; i < statek.kontenery.Count; i++)
                    Console.WriteLine($"{i + 1}. {statek.kontenery[i].numerSeryjny}");

                Console.Write("Numer kontenera do zastapienia: ");
                int staryIndex = int.Parse(Console.ReadLine()) - 1;

                if (staryIndex < 0 || staryIndex >= statek.kontenery.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                Console.Write("Numer nowego kontenera: ");
                int nowyIndex = int.Parse(Console.ReadLine()) - 1;

                if (nowyIndex < 0 || nowyIndex >= kontenery.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                statek.ZaptapKontener(statek.kontenery[staryIndex].numerSeryjny, kontenery[nowyIndex]);
            }

            void PrzeniesKontenerNaInnyStatek()
            {
                if (statki.Count < 2)
                {
                    Console.WriteLine("Potrzeba co najmniej 2 statkow.");
                    return;
                }

                Console.Write("Numer statku zrodlowego: ");
                int zrodlowy = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Numer statku docelowego: ");
                int docelowy = int.Parse(Console.ReadLine()) - 1;

                if (zrodlowy < 0 || zrodlowy >= statki.Count || docelowy < 0 || docelowy >= statki.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                var statek = statki[zrodlowy];
                if (statek.kontenery.Count == 0)
                {
                    Console.WriteLine("Brak kontenerow do przeniesienia.");
                    return;
                }

                for (int i = 0; i < statek.kontenery.Count; i++)
                    Console.WriteLine($"{i + 1}. {statek.kontenery[i].numerSeryjny}");

                Console.Write("Numer kontenera do przeniesienia: ");
                int kontenerIndex = int.Parse(Console.ReadLine()) - 1;

                if (kontenerIndex < 0 || kontenerIndex >= statek.kontenery.Count)
                {
                    Console.WriteLine("Niepoprawny numer.");
                    return;
                }

                string numerSeryjny = statek.kontenery[kontenerIndex].numerSeryjny;
                statki[zrodlowy].PrzeniesKontener(statki[docelowy], numerSeryjny);
            }
        }
    }
}
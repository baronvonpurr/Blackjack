using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Random slump = new Random();
            string Vinnare = null;
            int Spelare;
            int Dator;
            int tal;
            int alternativ;
            string svar;

            void datorkort()
            {
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 2: {tal}");
                Dator += tal;
                Console.WriteLine($"Summa: {Dator}");
            }
            void spelarkort()
            {
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 2: {tal}");
                Spelare += tal;
                Console.WriteLine($"Summa: {Spelare}");
            }
            void Drakort()
            {
                if (Spelare < 21 && Dator < 21)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Vill du dra ett kort?");
                    svar = Console.ReadLine().ToLower();

                    if (svar == "j")
                    {
                        Console.WriteLine();
                        spelarkort();
                        Drakort();
                    }
                    else if (svar == "n")
                    {
                        while (Dator < 17)
                        {
                            Console.WriteLine("");
                            datorkort();
                        }
                        if (Dator > 21)
                        {
                            Drakort();
                        }
                        else if (Dator >= 17 && Dator < 22 && Dator > Spelare)
                        {
                            Console.WriteLine("Datorn vinner!");
                            Console.WriteLine("");
                            meny();
                        }
                        else if (Dator >= 17 && Dator < 22 && Dator < Spelare)
                        {
                            Console.WriteLine("Spelaren vinner!");
                            Console.WriteLine("");
                            meny();
                        }
                        else if (Dator >= 17 && Dator < 22 && Dator == Spelare)
                        {
                            Console.WriteLine("Oavjort!");
                            Console.WriteLine("");
                            meny();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Säg j eller n");
                    }
                }
                else if (Spelare > 21)
                {
                    Console.WriteLine("Du blev tjock, datorn vinner");
                    Vinnare = "Datorn";
                    Console.WriteLine("");
                    meny();
                }
                else if (Dator > 21)
                {
                    Console.WriteLine("Datorn blev tjock, du vinner");
                    Console.WriteLine("Skriv in ditt namn");
                    Vinnare = Console.ReadLine();
                    Console.WriteLine("");
                    meny();
                }
                else if (Spelare == 21)
                {
                    Console.WriteLine("Spelaren vinner!");
                    Console.WriteLine("Skriv in ditt namn");
                    Vinnare = Console.ReadLine();
                    Console.WriteLine("");
                    meny();
                }
            }
            void blackjack()
            {
                Console.WriteLine("");
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 1: {tal}");
                Spelare = tal;
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 2: {tal}");
                Spelare += tal;
                Console.WriteLine($"Summa: {Spelare}");

                Console.WriteLine();
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 1: {tal}");
                Dator = tal;
                tal = slump.Next(1, 11);
                Console.WriteLine($"Kort 2: {tal}");
                Dator += tal;
                Console.WriteLine($"Summa: {Dator}");

                Drakort();
            }
            void meny()
            {
                Console.WriteLine("Välkommen till 21an!");
                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1. Spela 21an");
                Console.WriteLine("2. Visa senaste vinnaren");
                Console.WriteLine("3. Spelets regler");
                Console.WriteLine("4. Avsluta programmet");
                Console.WriteLine("");
                alternativ = int.Parse(Console.ReadLine());

                switch (alternativ)
                {
                    case 1:
                        blackjack();
                        break;
                    case 2:
                        if (Vinnare != null)
                        {
                            Console.WriteLine($"Den förra vinnaren var: {Vinnare}!");
                            meny();
                        }
                        else
                        {
                            Console.WriteLine($"Det finns ingen vinnare ännu!");
                            meny();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                        Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
                        Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                        Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
                        Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                        Console.WriteLine("När du är färdig drar datorn kort till den har");
                        Console.WriteLine("mer poäng än dig eller över 21 poäng.");
                        meny();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Skriv in ett korrekt alternativ");
                        meny();
                        break;
                }
            }
            meny();
        }
    }
}
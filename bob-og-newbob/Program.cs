using System;
using System.Diagnostics;
using System.Xml.Schema;

namespace bob_og_newbob
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //fjerne alt fra siste b-en i bob og til venstre
            //søk i kortere string for gang counter++
            //stringen må bli lik ny string
            //hvilke metoder?

            //oppgave 1
            //kjør programmet for å se om alt er ok

            //oppgave 2
            //Let etter gunnar og ikke bob. hva skjer? må noe endres?
            //
            //Oppgave 3
            //ikke let etter gunnar mer. endre tilbake til bob.
            //stringen bob skal leses inn fra en fil https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
            //lag en stooor textfil. tar det lang tid? lag en enda større fil. test på nytt. fortsett. hvor stor fil kan vi ha?

            //oppgave 4
            //ta tiden på dette. Bruk datetime og datediff https://www.tutorialsteacher.com/articles/get-difference-between-two-dates-in-csharp

            //oppgave 5
            //istedfor å ha alt i main, lag en metode av dette. Hva det letes etter og i hvor det letes skal være parametre. Returtype int

            //oppgave 6
            //lag en metode som heter KlassiskBob. Det er denne bobløsningen som bruker for loops
            //ta tiden på denne og avansert bob. hvem er raskest? her er det viktig at det er samme inputfil som brukes.

            /*int counter = 0;
            string newBob = "";
            int hvor = 0;
            Stopwatch timer = Stopwatch.StartNew();
            var starttime = DateTime.Now;
            while (bob.Contains("bob")) //   while (bob.Contains("gunnar")) 
                //if (bob.Contains("bob"))
            {
                hvor = bob.IndexOf("bob"); // hvor = bob.IndexOf("bob");
                newBob = bob.Substring(hvor + 3,
                    bob.Length - hvor - 3); //overwrite bob | NewBob = bob.Substring(hvor + 6, bob.Length - hvor - 5); 
                bob = newBob;
                counter++;
            }

            var finish = DateTime.Now;
            var difference = finish - starttime;
            timer.Stop();
            Console.WriteLine("bobs found: " + counter);
            Console.WriteLine("Time taken to find bobs Method #1 stopwatch: " + timer.ElapsedMilliseconds + "ms");
            Console.WriteLine("Time taken to find bobs Method #1 datetime: " + difference.TotalMilliseconds + "ms");
            Console.WriteLine("-------------------------------");*/


            string bob = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\words4.txt"); //lese inn fra fil
            string bob2 = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\words4.txt");
            string bob3 = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\words4.txt");

            var starttime = DateTime.Now;
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("---------------------------------------");
            timer.Start();
            Console.WriteLine("Fant bobs Method1: " + Find.FindBob(bob3, "bob"));
            var finish = DateTime.Now;
            var difference = finish - starttime;
            timer.Stop();
            Console.WriteLine("Time taken to find bobs Method1: " + timer.ElapsedMilliseconds + "ms");
            Console.WriteLine(("Time Taken Method 1 starttime: " + difference.TotalMilliseconds + "ms"));
            Console.WriteLine("---------------------------------------");


            Stopwatch timed = Stopwatch.StartNew();
            timed.Start();
            Console.WriteLine("Fant bobs Method2: " + Check.CheckOccurrences(bob2, "bob"));
            timed.Stop();
            Console.WriteLine("Time taken to find bobs Method2: " + timed.ElapsedMilliseconds + "ms");
            Console.WriteLine("---------------------------------------");

            Stopwatch timed2 = new Stopwatch();
            timed2.Start();
            Console.WriteLine("Fant bobs Method3: " + Finn.FinnBob(bob, 'b', 'o', 'b'));
            timed2.Stop();
            Console.WriteLine("Time taken to find bobs Method3: " + timed2.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }
    }

    public static class Find
    {
        public static int FindBob(string str3, string pattern3)
        {
            int counter = 0;
            string newBob = "";
            int hvor = 0;
            while (str3.Contains(pattern3)) //   while (bob.Contains("gunnar")) 
                //if (bob.Contains("bob"))
            {
                hvor = str3.IndexOf(pattern3); // hvor = bob.IndexOf("bob");
                newBob = str3.Substring(hvor + 3,
                    str3.Length - hvor - 3); //overwrite bob | NewBob = bob.Substring(hvor + 6, bob.Length - hvor - 5); 
                str3 = newBob;
                counter++;
            }

            return counter;
        }
    }


    public static class Finn
    {
        public static int FinnBob(string str2, char one, char two, char three)
        {
            int counter2 = 0;
            char[] chars = str2.ToCharArray();
            for (int i = 0; i < chars.Length - 2; i++)
            {
                if (chars[i] == one && chars[i + 1] == two && chars[i + 2] == three)
                {
                    counter2++;
                    i = i + 2;
                }
            }

            return counter2;
        }
    }


    public static class Check
    {
        public static int CheckOccurrences(string str1, string pattern)
        {
            int count = 0;
            int a = 0;
            while ((a = str1.IndexOf(pattern, a)) != -1)
            {
                a += pattern.Length;
                count++;
            }

            return count;
        }
    }
}
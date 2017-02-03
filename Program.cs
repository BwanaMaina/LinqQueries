using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pupils> pupils = new List<Pupils>();
            pupils.Add(new Pupils(1, "John Muhuthia", 335.50, 'M'));
            pupils.Add(new Pupils(8, "Felix Kiprono", 205.00, 'M'));
            pupils.Add(new Pupils(4, "Anne Karanja", 435.50, 'F'));
            pupils.Add(new Pupils(7, "Peter Kipce", 405.00, 'M'));
            pupils.Add(new Pupils(8, "Stella Poi", 345.50, 'F'));
            pupils.Add(new Pupils(4, "Peter Munjogu", 333.00, 'M'));
            pupils.Add(new Pupils(5, "Peter Mbugua", 475.50, 'M'));
            pupils.Add(new Pupils(2, "Prish Karagau", 455.00, 'F'));
            pupils.Add(new Pupils(4, "Anabel Wambui", 360.50, 'F'));
            pupils.Add(new Pupils(1, "Salome Keith", 240.00, 'F'));
            pupils.Add(new Pupils(5, "Kellen Samar", 340.00, 'F'));
            pupils.Add(new Pupils(7, "Salma Puth", 399.50, 'F'));
            //we can perform an order by pupil level
            var byLevel = from p
                          in pupils
                          orderby p.Level
                          select p;
            System.Console.WriteLine(new String('-', 50));
            System.Console.Out.WriteLine("Level \t Pupil Name \t Gender \t Entry Points \t Grade");
            System.Console.WriteLine(new String('-', 50));
            foreach (var p in byLevel.ToList())
            {
                string g = (p.Gender == 'M') ? "Male  " : "Female";
                System.Console.Out.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}",
                    p.Level, p.PupilName, g, p.Entries,
                    Grade(p.Entries));
            }
            System.Console.WriteLine(new String('-', 50));
            //we can get count of pupils by gender
            int totalCount = (from p
                              in pupils
                              select p).Count();
            System.Console.WriteLine($"There are total {totalCount} pupils");
            //we can get count of pupils by gender
            int totalMale = (from p
                           in pupils
                             where p.Gender == 'M'
                             select p).Count();
            System.Console.WriteLine($"There are {totalMale} Male pupils");
            //we can get male with top entry
            double topMale = (from p
                          in pupils
                              where (p.Gender == 'M')
                              select p.Entries).Max();
            System.Console.WriteLine($"Top male pupil has {topMale} entries");
            //we can get lowest entry from female list
            double lowestFemale = (from p
                                  in pupils
                                   where p.Gender == 'F'
                                   select p.Entries).Min();
            System.Console.WriteLine($"Lowest female pupil has {lowestFemale} entries");
            //we can get a list of pupils with more than 400 entry points
            var topList = (from p
                           in pupils
                           orderby p.Entries
                           where p.Entries >= 400
                           select p);
            for (int i = 0; i <= topList.Count() - 1; i++)
            {
                System.Console.WriteLine("{0} is amongst top puplis with {1} entries", topList.ElementAt(i).PupilName, topList.ElementAt(i).Entries);
            }
            //we can get average entry points 
            double avgEntry = (from p
                               in pupils
                               select p.Entries).Average();
            System.Console.WriteLine("Average entry is {0:f2}", avgEntry);
            System.Console.WriteLine(new String('-', 50));
            System.Console.ReadKey();
        }
        protected internal static char Grade(double entry)
        {
            //my stupid grading system
            char e = 'E';
            if (entry >= 400 && entry <= 500)
            { e = 'A'; }
            else if (entry >= 300 && entry <= 400)
            { e = 'B'; }
            else if (entry >= 200 && entry <= 300)
            { e = 'C'; }
            else if (entry >= 100 && entry <= 200)
            { e = 'D'; }
            else { e = 'E'; }
            return e;
        }
    }
}

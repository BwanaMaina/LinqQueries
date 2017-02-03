using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    class Pupils
    {
        public string PupilName { get; set; }
        public double Entries { get; set; }
        public double Level { get; set; }
        public char Gender { get; set; }
        public Pupils(int level, string name, double  entries, char gender)
        {
            this.Level = level;
            this.PupilName = name;
            this.Entries = entries;
            this.Gender = gender;
        }
    }
}

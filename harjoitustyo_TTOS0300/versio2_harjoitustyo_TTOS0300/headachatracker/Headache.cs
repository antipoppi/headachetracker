using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headachatracker
{
    public class Headache
    {
        public List<string> acheTypes = new List<string>();

        public List<string> AcheTypes
        {
            get { return acheTypes; }
            set { acheTypes = value; }
        }


        public Headache()
        {           
            acheTypes.Add("Regular headache");
            acheTypes.Add("Migraine");
            acheTypes.Add("Tension headache");
            acheTypes.Add("Cluster headache");
            acheTypes.Add("Allergic headache");
        }


    }
}

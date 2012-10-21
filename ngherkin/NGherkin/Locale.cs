using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gherkin
{
    class Locale
    {
        private string isoString;
        private string p;
        private string p_2;

        public Locale(string isoString)
        {
            // TODO: Complete member initialization
            this.isoString = isoString;
        }

        public Locale(string p, string p_2)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
        }
    }
}

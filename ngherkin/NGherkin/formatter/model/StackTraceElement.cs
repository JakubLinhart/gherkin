using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGherkin.formatter.model
{
    public class StackTraceElement
    {
        private string p;
        private string p_2;
        private string path;
        private int p_3;

        public StackTraceElement(string p, string p_2, string path, int p_3)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.path = path;
            this.p_3 = p_3;
        }
    }
}

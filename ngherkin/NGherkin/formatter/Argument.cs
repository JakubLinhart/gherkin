using System;

namespace gherkin.formatter
{
    public class Argument : Mappable
    {
        private int? offset;
        private String val;

        public Argument(int offset, String val)
        {
            this.offset = offset;
            this.val = val;
        }

        public String getVal()
        {
            return val;
        }

        public int? getOffset()
        {
            return offset;
        }

        public String toString()
        {
            return getVal();
        }
    }
}
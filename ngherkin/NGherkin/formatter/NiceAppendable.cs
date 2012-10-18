using NGherkin.formatter;
using System;
using System.IO;

namespace gherkin.formatter
{
    /**
     * A nice appendable that doesn't throw checked exceptions
     */
    public class NiceAppendable
    {
        private TextWriter @out;

        public NiceAppendable(TextWriter @out)
        {
            this.@out = @out;
        }

        public NiceAppendable append(string csq)
        {
            this.@out.Write(csq);
            return this;
        }

        public NiceAppendable append(string csq, int start, int end)
        {
            throw new NotImplementedException();
        }

        public NiceAppendable append(char c)
        {
            this.@out.Write(c);

            return this;
        }

        public NiceAppendable println()
        {
            return append(Environment.NewLine);
        }

        public NiceAppendable println(string csq)
        {
            return append(csq).println();
        }

        public void close()
        {
            @out.Dispose();
        }
    }
}
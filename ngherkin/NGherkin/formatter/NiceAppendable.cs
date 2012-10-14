using NGherkin.formatter;
using System;

namespace gherkin.formatter
{
    /**
     * A nice appendable that doesn't throw checked exceptions
     */
    public class NiceAppendable
    {
        public NiceAppendable(Appendable @out)
        {
        }

        public NiceAppendable append(CharSequence csq)
        {
            throw new NotImplementedException();
        }

        public NiceAppendable append(CharSequence csq, int start, int end)
        {
            throw new NotImplementedException();
        }

        public NiceAppendable append(char c)
        {
            throw new NotImplementedException();
        }

        public NiceAppendable println()
        {
            throw new NotImplementedException();
        }

        public NiceAppendable println(CharSequence csq)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }
    }
}
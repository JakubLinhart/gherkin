using System;

namespace gherkin.formatter
{
    public interface Formats
    {
        Format get(String key);

        String up(int n);
    }
}

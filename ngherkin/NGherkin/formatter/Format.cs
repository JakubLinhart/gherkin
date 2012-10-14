using System;

namespace gherkin.formatter
{
    public interface Format
    {
        String text(String text);
    }
}
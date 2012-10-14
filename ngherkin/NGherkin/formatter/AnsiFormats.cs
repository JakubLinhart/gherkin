using System;
using gherkin.formatter.ansi;
namespace gherkin.formatter
{
    public class AnsiFormats : Formats {

    public sealed class ColorFormat : Format {
        public ColorFormat(params AnsiEscapes[] escapes) {
            throw new NotImplementedException();
        }

        public String text(String text) {
            throw new NotImplementedException();
        }
    }

    public Format get(String key) {
        throw new NotImplementedException();
    }

    public String up(int n) {
        throw new NotImplementedException();
    }
}
}
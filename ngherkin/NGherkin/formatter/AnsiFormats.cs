using System;
using gherkin.formatter.ansi;
using System.Collections.Generic;
using System.Text;

namespace gherkin.formatter
{
    public class AnsiFormats : Formats
    {
        private static Dictionary<String, Format> formats = new Dictionary<String, Format>() {
            { "undefined", new ColorFormat(AnsiEscapes.YELLOW) },
            { "undefined_arg", new ColorFormat(AnsiEscapes.YELLOW, AnsiEscapes.INTENSITY_BOLD) }, // Never used, but avoids NPE in formatters.
            { "pending", new ColorFormat(AnsiEscapes.YELLOW) },
            { "pending_arg", new ColorFormat(AnsiEscapes.YELLOW, AnsiEscapes.INTENSITY_BOLD) },
            { "executing", new ColorFormat(AnsiEscapes.GREY) },
            { "executing_arg", new ColorFormat(AnsiEscapes.GREY, AnsiEscapes.INTENSITY_BOLD) },
            { "failed", new ColorFormat(AnsiEscapes.RED) },
            { "failed_arg", new ColorFormat(AnsiEscapes.RED, AnsiEscapes.INTENSITY_BOLD) },
            { "passed", new ColorFormat(AnsiEscapes.GREEN) },
            { "passed_arg", new ColorFormat(AnsiEscapes.GREEN, AnsiEscapes.INTENSITY_BOLD) },
            { "outline", new ColorFormat(AnsiEscapes.CYAN) },
            { "outline_arg", new ColorFormat(AnsiEscapes.CYAN, AnsiEscapes.INTENSITY_BOLD) },
            { "skipped", new ColorFormat(AnsiEscapes.CYAN) },
            { "skipped_arg", new ColorFormat(AnsiEscapes.CYAN, AnsiEscapes.INTENSITY_BOLD) },
            { "comment", new ColorFormat(AnsiEscapes.GREY) },
            { "tag", new ColorFormat(AnsiEscapes.CYAN) },
            { "output", new ColorFormat(AnsiEscapes.BLUE) },
        };

        public sealed class ColorFormat : Format
        {
            private readonly AnsiEscapes[] escapes;

            public ColorFormat(params AnsiEscapes[] escapes)
            {
                this.escapes = escapes;
            }

            public String text(String text)
            {
                StringBuilder sb = new StringBuilder();
                foreach (AnsiEscapes escape in escapes)
                {
                    escape.appendTo(sb);
                }
                sb.Append(text);
                AnsiEscapes.RESET.appendTo(sb);
                return sb.ToString();
            }
        }

        public Format get(String key)
        {
            if (!formats.ContainsKey(key))
            {
                throw new InvalidOperationException("No format for key " + key);
            }

            Format format = formats[key];

            return format;
        }

        public String up(int n)
        {
            return AnsiEscapes.up(n).toString();
        }
    }
}
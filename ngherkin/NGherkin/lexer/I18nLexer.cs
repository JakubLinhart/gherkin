using System;
using NGherkin.formatter;
using System.Text.RegularExpressions;
namespace gherkin.lexer
{
    public class I18nLexer : Lexer
    {
        private static Regex COMMENT_OR_EMPTY_LINE_PATTERN = new Regex("^\\s*#|^\\s*$");
        private static Regex LANGUAGE_PATTERN = new Regex("^\\s*#\\s*language\\s*:\\s*([a-zA-Z\\-]+)");
        private Listener listener;
        private I18n i18n;
        
        public I18nLexer(Listener listener)
            : this(listener, false)
        {
        }

        public I18nLexer(Listener listener, bool forceRubyDummy)
        {
            this.listener = listener;
        }

        /**
         * @return the i18n language from the previous scanned source.
         */
        public I18n getI18nLanguage()
        {
            return i18n;
        }

        public void scan(String source)
        {
            i18n = i18nLanguageForSource(source);
            i18n.lexer(listener).scan(source);
        }

        private I18n i18nLanguageForSource(String source) {
            String key = "en";
            foreach (String line in source.Split('\n')) {
                if (COMMENT_OR_EMPTY_LINE_PATTERN.Match(line).Success) {
                    break;
                }
                var match = LANGUAGE_PATTERN.Match(line);
                if (match.Success) {
                    key = match.Groups[1].Value;
                    break;
                }
            }

            return new I18n(key);
        }
    }
}
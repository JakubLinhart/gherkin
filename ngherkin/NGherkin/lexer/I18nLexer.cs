using System;
namespace gherkin.lexer
{
    public class I18nLexer : Lexer
    {
        public I18nLexer(Listener listener)
            : this(listener, false)
        {
        }

        public I18nLexer(Listener listener, bool forceRubyDummy)
        {
            throw new NotImplementedException();
        }

        /**
         * @return the i18n language from the previous scanned source.
         */
        public I18n getI18nLanguage()
        {
            throw new NotImplementedException();
        }

        public void scan(String source)
        {
            throw new NotImplementedException();
        }
    }
}
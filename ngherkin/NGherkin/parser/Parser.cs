using gherkin.formatter;
using gherkin.lexer;
using System;
using System.Collections.Generic;

namespace gherkin.parser
{
    public class Parser : Listener
    {
        public Parser(Formatter formatter)
            : this(formatter, true)
        {
            throw new NotImplementedException();
        }

        public Parser(Formatter formatter, bool throwOnError)
        {
            throw new NotImplementedException();
        }

        public Parser(Formatter formatter, bool throwOnError, String machineName)
        {
            throw new NotImplementedException();
        }

        public Parser(Formatter formatter, bool throwOnError, String machineName, bool forceRubyDummy)
        {
            throw new NotImplementedException();
        }

        /**
         * @param featureURI the URI where the gherkin originated from. Typically a file path.
         * @param lineOffset the line offset within the uri document the gherkin was taken from. Typically 0.
         */
        public void parse(String gherkin, String featureURI, int lineOffset)
        {
            throw new NotImplementedException();
        }

        public I18n getI18nLanguage()
        {
            throw new NotImplementedException();
        }

        private void pushMachine(String machineName)
        {
            throw new NotImplementedException();
        }

        private void popMachine()
        {
            throw new NotImplementedException();
        }

        public void tag(String tag, int line)
        {
            throw new NotImplementedException();
        }

        public void docString(String contentType, String content, int line)
        {
            throw new NotImplementedException();
        }

        public void feature(String keyword, String name, String description, int line)
        {
            throw new NotImplementedException();
        }

        public void background(String keyword, String name, String description, int line)
        {
            throw new NotImplementedException();
        }

        public void scenario(String keyword, String name, String description, int line)
        {
            throw new NotImplementedException();
        }

        public void scenarioOutline(String keyword, String name, String description, int line)
        {
            throw new NotImplementedException();
        }

        public void examples(String keyword, String name, String description, int line)
        {
            throw new NotImplementedException();
        }

        public void step(String keyword, String name, int line)
        {
            throw new NotImplementedException();
        }

        public void comment(String comment, int line)
        {
            throw new NotImplementedException();
        }

        public void row(List<String> cells, int line)
        {
            throw new NotImplementedException();
        }

        public void eof()
        {
            throw new NotImplementedException();
        }

        public void syntaxError(String state, String @event, List<String> legalEvents, int line)
        {
            throw new NotSupportedException();
        }

        public void syntaxError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new InvalidOperationException("Didn't expect this");
        }
    }
}
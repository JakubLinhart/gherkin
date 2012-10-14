using gherkin.lexer;
using System.Collections.Generic;
using gherkin.formatter.model;
using System;
using gherkin.formatter;
namespace gherkin.parser
{
    public class FormatterListener : Listener
    {
        private class Stash
        {
            public void comment(Comment comment)
            {
                throw new NotImplementedException();
            }

            public void tag(Tag tag)
            {
                throw new NotImplementedException();
            }

            public void reset()
            {
                throw new NotImplementedException();
            }

            public String featureId(String name)
            {
                throw new NotImplementedException();
            }

            public String featureElementId(String name)
            {
                throw new NotImplementedException();
            }

            public String examplesId(String name)
            {
                throw new NotImplementedException();
            }

            private String id(String name)
            {
                throw new NotImplementedException();
            }

            public String nextExampleId()
            {
                throw new NotImplementedException();
            }
        }

        public FormatterListener(Formatter formatter)
        {
            throw new NotImplementedException();
        }

        public void comment(String comment, int line)
        {
            throw new NotImplementedException();
        }

        public void tag(String tag, int line)
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

        public void row(List<String> cells, int line)
        {
            throw new NotImplementedException();
        }

        public void docString(String contentType, String content, int line)
        {
            throw new NotImplementedException();
        }

        public void eof()
        {
            throw new NotImplementedException();
        }

        /**
         * Not part of the API. Used for testing only.
         */
        public void syntaxError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new NotImplementedException();
        }

        private void replayStepsOrExamples()
        {
            throw new NotImplementedException();
        }

    }
}
using System;
using gherkin.formatter.model;
using System.Collections.Generic;
using System.IO;

namespace gherkin.formatter
{
    public class JSONFormatter : Reporter, Formatter
    {
        public JSONFormatter(TextWriter @out)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }

        public void uri(String uri)
        {
            throw new NotImplementedException();
        }

        public void feature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void background(Background background)
        {
            throw new NotImplementedException();
        }

        public void scenario(Scenario scenario)
        {
            throw new NotImplementedException();
        }

        public void scenarioOutline(ScenarioOutline scenarioOutline)
        {
            throw new NotImplementedException();
        }

        public void examples(Examples examples)
        {
            throw new NotImplementedException();
        }

        public void step(Step step)
        {
            throw new NotImplementedException();
        }

        public void match(Match match)
        {
            throw new NotImplementedException();
        }

        public void result(Result result)
        {
            throw new NotImplementedException();
        }

        public void embedding(String mimeType, byte[] data)
        {
            throw new NotImplementedException();
        }

        public void eof()
        {
            throw new NotImplementedException();
        }

        public void syntaxError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new NotSupportedException();
        }
    }
}
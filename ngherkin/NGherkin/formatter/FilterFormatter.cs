using System.Collections;
using System;
using System.Collections.Generic;
using gherkin.formatter.model;

namespace gherkin.formatter
{
    public class FilterFormatter : Formatter
    {
        public FilterFormatter(Formatter formatter, ArrayList filters)
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

        public void table(List<Row> table)
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

        public void close()
        {
            throw new NotImplementedException();
        }
    }
}
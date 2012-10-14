using System;
using System.Collections.Generic;
using gherkin.formatter.model;

namespace gherkin.formatter
{
    /**
     * This class pretty prints feature files like they were in the source, only
     * prettier. That is, with consistent indentation. This class is also a {@link Formatter},
     * which means it can be used to print execution results - highlighting arguments,
     * printing source information and exception information.
     */
    public class PrettyFormatter : Reporter, Formatter
    {
        public PrettyFormatter(Appendable @out, bool monochrome, bool executing)
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

        public void table(IEnumerable<Row> rows)
        {
            throw new NotImplementedException();
        }

        public void row(List<CellResult> cellResults)
        {
            throw new NotImplementedException();
        }

        public void nextRow()
        {
            throw new NotImplementedException();
        }

        public void syntaxError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }

        public void docString(DocString docString)
        {
            throw new NotImplementedException();
        }

        public void eof()
        {
            throw new NotImplementedException();
        }

        public void embedding(String mimeType, byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
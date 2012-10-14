using System.Collections.Generic;
using System;
using NGherkin.formatter;
using gherkin.formatter.model;

namespace gherkin.formatter
{
    public class PatternFilter : Filter
    {
        public PatternFilter(List<Pattern> patterns)
        {
            throw new NotImplementedException();
        }

        public bool eval(List<Tag> tags, List<String> names, List<Range> ranges)
        {
            throw new NotImplementedException();
        }

        public List<ExamplesTableRow> filterTableBodyRows(List<ExamplesTableRow> examplesRows)
        {
            throw new NotImplementedException();
        }
    }
}
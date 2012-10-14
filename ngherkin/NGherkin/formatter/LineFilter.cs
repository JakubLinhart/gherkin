using System;
using System.Collections.Generic;
using gherkin.formatter.model;

namespace gherkin.formatter
{
    public class LineFilter : Filter
    {
        public LineFilter(List<long> lines)
        {
            throw new NotImplementedException();
        }

        public bool eval(List<Tag> tags, List<String> names, List<Range> ranges)
        {
            throw new NotImplementedException();
        }

        public List<ExamplesTableRow> filterTableBodyRows(List<ExamplesTableRow> exampleRows)
        {
            throw new NotImplementedException();

        }
    }
}
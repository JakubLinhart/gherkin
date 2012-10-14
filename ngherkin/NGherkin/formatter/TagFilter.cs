using System;
using System.Collections.Generic;
using gherkin.formatter.model;
namespace gherkin.formatter
{
    public class TagFilter : Filter
    {
        public TagFilter(List<String> tags)
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
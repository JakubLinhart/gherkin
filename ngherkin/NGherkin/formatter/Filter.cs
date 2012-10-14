using System.Collections.Generic;
using System;
using gherkin.formatter.model;
namespace gherkin.formatter
{
    public interface Filter
    {
        bool eval(List<Tag> tags, List<String> names, List<Range> ranges);

        List<ExamplesTableRow> filterTableBodyRows(List<ExamplesTableRow> examplesRows);
    }
}
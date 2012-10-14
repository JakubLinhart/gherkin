using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class ExamplesTableRow : Row
    {
        public ExamplesTableRow(List<Comment> comments, List<String> cells, int line, String id)
            : base(comments, cells, line)
        {
            throw new NotImplementedException();
        }

        public override DiffType getDiffType()
        {
            throw new NotImplementedException();
        }

        public String getId()
        {
            throw new NotImplementedException();
        }
    }
}
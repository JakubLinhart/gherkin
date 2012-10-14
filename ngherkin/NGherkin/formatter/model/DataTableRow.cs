using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class DataTableRow : Row
    {
        public DataTableRow(List<Comment> comments, List<String> cells, int line)
            : this(comments, cells, line, DiffType.NONE)
        {
            throw new NotImplementedException();
        }

        public DataTableRow(List<Comment> comments, List<String> cells, int line, DiffType diffType)
            : base(comments, cells, line)
        {
            throw new NotImplementedException();
        }

        public override DiffType getDiffType()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class DataTableRow : Row
    {
        private static long serialVersionUID = 1L;
        [NonSerialized]
        private DiffType diffType;

        public DataTableRow(List<Comment> comments, List<String> cells, int line)
            : this(comments, cells, line, DiffType.NONE)
        {
        }

        public DataTableRow(List<Comment> comments, List<String> cells, int line, DiffType diffType)
            : base(comments, cells, line)
        {
            this.diffType = diffType;
        }

        public override DiffType getDiffType()
        {
            return diffType;
        }
    }
}
using System;
using System.Collections.Generic;
using NGherkin.formatter.model;
using System.Text.RegularExpressions;

namespace gherkin.formatter.model
{
    public class Step : BasicStatement
    {
        private List<DataTableRow> rows;
        private DocString doc_string;

        public class Builder : gherkin.formatter.model.Builder
        {
            private List<Comment> comments;
            private String keyword;
            private String name;
            private int line;
            private List<DataTableRow> rows;
            private DocString doc_string;

            public Builder(List<Comment> comments, String keyword, String name, int line)
            {
                this.comments = comments;
                this.keyword = keyword;
                this.name = name;
                this.line = line;
            }

            public void row(List<Comment> comments, List<String> cells, int line, String id)
            {
                if (rows == null)
                {
                    rows = new List<DataTableRow>();
                }
                rows.Add(new DataTableRow(comments, cells, line));
            }

            public void replay(Formatter formatter)
            {
                new Step(comments, keyword, name, line, rows, doc_string).replay(formatter);
            }

            public void docString(DocString docString)
            {
                this.doc_string = docString;
            }
        }

        public Step(List<Comment> comments, String keyword, String name, int line, List<DataTableRow> rows, DocString docString)
            : base(comments, keyword, name, line)
        {
            this.rows = rows;
            this.doc_string = docString;
        }

        public override Range getLineRange()
        {
            Range range = base.getLineRange();
            if (getRows() != null)
            {
                range = new Range(range.getFirst(), getRows()[getRows().Count - 1].getLine());
            }
            else if (getDocString() != null)
            {
                range = new Range(range.getFirst(), getDocString().getLineRange().getLast());
            }

            return range;
        }

        public override void replay(Formatter formatter)
        {
            formatter.step(this);
        }

        public List<Argument> getOutlineArgs()
        {
            List<Argument> result = new List<Argument>();
            Regex p = new Regex("<[^<]*>");
            var matches = p.Matches(getName());
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                var argument = new Argument(match.Index, match.Value);
                result.Add(argument);
            }

            return result;
        }

        public Match getOutlineMatch(String location)
        {
            throw new NotImplementedException();
        }

        public List<DataTableRow> getRows()
        {
            return this.rows;
        }

        public DocString getDocString()
        {
            return this.doc_string;
        }

        public StackTraceElement getStackTraceElement(String path)
        {
            return new StackTraceElement("*", getKeyword() + getName(), path, getLine());
        }
    }
}
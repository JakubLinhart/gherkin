using System.Collections.Generic;
using System;

namespace gherkin.formatter.model
{
    public class Examples : TagStatement
    {
        public class Builder : gherkin.formatter.model.Builder
        {
            public Builder(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id)
            {
                throw new NotImplementedException();
            }

            public void row(List<Comment> comments, List<String> cells, int line, String id)
            {
                throw new NotImplementedException();
            }

            public void replay(Formatter formatter)
            {
                throw new NotImplementedException();
            }

            public void docString(DocString docString)
            {
                throw new NotImplementedException();
            }
        }

        public Examples(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id, List<ExamplesTableRow> rows)
            : base(comments, tags, keyword, name, description, line, id)
        {
            throw new NotImplementedException();
        }

        public override void replay(Formatter formatter)
        {
            throw new NotImplementedException();
        }

        public List<ExamplesTableRow> getRows()
        {
            throw new NotImplementedException();
        }

        public void setRows(List<ExamplesTableRow> rows)
        {
            throw new NotImplementedException();
        }
    }
}
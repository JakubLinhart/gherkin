using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public abstract class TagStatement : DescribedStatement
    {
        public TagStatement(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id)
            : base(comments, keyword, name, description, line)
        {
            throw new NotImplementedException();
        }

        public List<Tag> getTags()
        {
            throw new NotImplementedException();
        }

        protected override int getFirstNonCommentLine()
        {
            throw new NotImplementedException();
        }
    }
}
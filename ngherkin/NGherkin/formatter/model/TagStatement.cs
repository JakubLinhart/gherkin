using System;
using System.Linq;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public abstract class TagStatement : DescribedStatement
    {
        private static long serialVersionUID = 1L;

        private List<Tag> tags;
        private String id;

        public TagStatement(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id)
            : base(comments, keyword, name, description, line)
        {
            this.tags = tags;
            this.id = id;
        }

        public List<Tag> getTags()
        {
            return tags;
        }

        protected override int getFirstNonCommentLine()
        {
            if (!getTags().Any())
            {
                return getLine();
            }
            else
            {
                return getTags().First().getLine();
            }
        }
    }
}
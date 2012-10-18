using System;
using System.Collections.Generic;
namespace gherkin.formatter.model
{
    public abstract class DescribedStatement : BasicStatement
    {
        private String description;

        public DescribedStatement(List<Comment> comments, String keyword, String name, String description, int line)
            : base(comments, keyword, name, line)
        {
            this.description = description;
        }

        public String getDescription()
        {
            return description;
        }
    }
}
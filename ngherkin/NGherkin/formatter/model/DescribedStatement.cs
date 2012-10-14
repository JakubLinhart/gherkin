using System;
using System.Collections.Generic;
namespace gherkin.formatter.model
{
    public abstract class DescribedStatement : BasicStatement
    {
        public DescribedStatement(List<Comment> comments, String keyword, String name, String description, int line)
            : base(comments, keyword, name, line)
        {
            throw new NotImplementedException();
        }

        public String getDescription()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{

    public class Background : DescribedStatement
    {
        public Background(List<Comment> comments, String keyword, String name, String description, int line)
            : base(comments, keyword, name, description, line)
        {
            throw new NotImplementedException();
        }

        public override void replay(Formatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
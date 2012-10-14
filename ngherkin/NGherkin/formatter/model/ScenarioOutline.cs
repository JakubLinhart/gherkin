using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class ScenarioOutline : TagStatement
    {
        public ScenarioOutline(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id)
            : base(comments, tags, keyword, name, description, line, id)
        {
            throw new NotImplementedException();
        }

        public override void replay(Formatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
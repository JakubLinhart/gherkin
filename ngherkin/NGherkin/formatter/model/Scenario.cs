using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class Scenario : TagStatement
    {
        private static long serialVersionUID = 1L;
        private String type = "scenario";

        public Scenario(List<Comment> comments, List<Tag> tags, String keyword, String name, String description, int line, String id)
            : base(comments, tags, keyword, name, description, line, id)
        {
        }

        public override void replay(Formatter formatter)
        {
            formatter.scenario(this);
        }
    }
}
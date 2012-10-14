using System.Collections.Generic;
using System;

namespace gherkin
{
    public class TagExpression
    {
        public TagExpression(List<String> tagExpressions)
        {
            throw new NotImplementedException();
        }

        public bool eval(IEnumerable<String> tags)
        {
            throw new NotImplementedException();
        }

        public Dictionary<String, int> limits()
        {
            throw new NotImplementedException();
        }
    }
}
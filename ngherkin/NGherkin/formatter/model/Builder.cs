using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public interface Builder
    {
        void row(List<Comment> comments, List<String> cells, int line, String id);

        void docString(DocString docString);

        void replay(Formatter formatter);
    }
}

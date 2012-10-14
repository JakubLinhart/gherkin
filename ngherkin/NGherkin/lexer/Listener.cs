using System;
using System.Collections.Generic;

namespace gherkin.lexer
{
    public interface Listener
    {
        void comment(String comment, int line);

        void tag(String tag, int line);

        void feature(String keyword, String name, String description, int line);

        void background(String keyword, String name, String description, int line);

        void scenario(String keyword, String name, String description, int line);

        void scenarioOutline(String keyword, String name, String description, int line);

        void examples(String keyword, String name, String description, int line);

        void step(String keyword, String name, int line);

        void row(List<String> cells, int line);

        void docString(String contentType, String content, int line);

        void eof();
    }
}
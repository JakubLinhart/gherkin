using System;

namespace gherkin.lexer
{

    public interface Lexer
    {
        /**
         * Lexes the source.
         *
         * @param source a string containing Gherkin source.
         */
        void scan(String source);
    }
}
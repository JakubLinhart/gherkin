using System;
namespace gherkin.lexer
{

    public class LexingError : Exception
    {
        public LexingError(String message)
            : base(message)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
namespace gherkin.parser
{
    public class ParseError : Exception
    {
        public ParseError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new NotImplementedException();
        }

        public List<String> getLegalEvents()
        {
            throw new NotImplementedException();
        }

        public String getState()
        {
            throw new NotImplementedException();
        }
    }
}
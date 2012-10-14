using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class Match : Mappable
    {
        public static Match UNDEFINED
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Match(List<Argument> arguments, String location)
        {
            throw new NotImplementedException();
        }

        public List<Argument> getArguments()
        {
            throw new NotImplementedException();
        }

        public String getLocation()
        {
            throw new NotImplementedException();
        }

        public void replay(Reporter reporter)
        {
            throw new NotImplementedException();
        }
    }
}
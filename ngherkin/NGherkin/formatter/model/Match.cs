using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public class Match : Mappable
    {
        private static long serialVersionUID = 1L;

        private List<Argument> arguments;
        private String location;

        public static Match UNDEFINED = new Match(new List<Argument>(), null);

        public Match(List<Argument> arguments, String location)
        {
            this.arguments = arguments;
            this.location = location;
        }

        public List<Argument> getArguments()
        {
            return arguments;
        }

        public String getLocation()
        {
            return location;
        }

        public void replay(Reporter reporter)
        {
            reporter.match(this);
        }
    }
}
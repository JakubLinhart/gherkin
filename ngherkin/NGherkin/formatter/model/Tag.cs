using System;
namespace gherkin.formatter.model
{
    public class Tag : Mappable
    {
        private static readonly long serialVersionUID = 1L;
        
        private String name;
        private int line;        

        public Tag(String name, int line)
        {
            this.name = name;
            this.line = line;
        }

        public String getName()
        {
            return this.name;
        }

        public int getLine()
        {
            return this.line;
        }

        public bool equals(Object o)
        {
            if (this == o)
                return true;
            
            if (o == null || GetType() != o.GetType())
                return false;
            
            Tag tag = (Tag)o;
            return name.Equals(tag.name);
        }

        public int hashCode()
        {
            return name.GetHashCode();
        }
    }
}
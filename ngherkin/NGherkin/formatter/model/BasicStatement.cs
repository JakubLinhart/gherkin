using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public abstract class BasicStatement : Mappable, CommentHolder
    {
        private List<Comment> comments;
        private String keyword;
        private String name;
        private int line;
        
        public BasicStatement(List<Comment> comments, String keyword, String name, int line)
        {
            this.comments = comments;
            this.keyword = keyword;
            this.name = name;
            this.line = line;
        }

        public virtual Range getLineRange()
        {
            throw new NotImplementedException();
        }

        protected virtual int getFirstNonCommentLine()
        {
            throw new NotImplementedException();
        }

        public List<Comment> getComments()
        {
            return this.comments;
        }

        public String getKeyword()
        {
            return this.keyword;
        }

        public String getName()
        {
            return this.name;
        }

        public int getLine()
        {
            return this.line;
        }

        public abstract void replay(Formatter formatter);
    }
}
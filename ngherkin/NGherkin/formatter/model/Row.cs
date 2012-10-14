using System;
using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public abstract class Row : Mappable, CommentHolder
    {
        public enum DiffType
        {
            NONE,
            DELETE,
            INSERT
        }

        public Row(List<Comment> comments, List<String> cells, int line)
        {
            throw new NotImplementedException();
        }

        public List<Comment> getComments()
        {
            throw new NotImplementedException();
        }

        public List<String> getCells()
        {
            throw new NotImplementedException();
        }

        public int getLine()
        {
            throw new NotImplementedException();
        }

        public List<CellResult> createResults(String status)
        {
            throw new NotImplementedException();
        }

        public abstract DiffType getDiffType();
    }
}
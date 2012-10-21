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

        private List<Comment> comments;
        private List<String> cells;
        private int line;

        public Row(List<Comment> comments, List<String> cells, int line)
        {
            if (comments == null)
            {
                throw new ArgumentNullException("comments");
            }

            if (cells == null)
            {
                throw new ArgumentNullException("cells");
            }

            this.comments = comments;
            this.cells = cells;
            this.line = line;
        }

        public List<Comment> getComments()
        {
            return this.comments;
        }

        public List<String> getCells()
        {
            return this.cells;
        }

        public int getLine()
        {
            return this.line;
        }

        public List<CellResult> createResults(String status)
        {
            List<CellResult> results = new List<CellResult>();
            foreach (string cell in cells) {
                results.Add(new CellResult(status));
            }

            return results;
        }

        public abstract DiffType getDiffType();
    }
}
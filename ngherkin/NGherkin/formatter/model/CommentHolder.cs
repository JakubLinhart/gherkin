using System.Collections.Generic;

namespace gherkin.formatter.model
{
    public interface CommentHolder
    {
        List<Comment> getComments();
    }
}
using System.Collections.Generic;
using System;
using System.Linq;
using gherkin.formatter.model;

namespace gherkin
{
    public class TagExpression
    {
        private Dictionary<String, int> _limits = new Dictionary<String, int>();
        private And and = new And();

        public TagExpression(List<String> tagExpressions)
        {
            foreach (String tagExpression in tagExpressions)
            {
                add(tagExpression.Split(new string[] { "\\s*,\\s*" }, StringSplitOptions.None));
            }
        }

        private void add(String[] tags)
        {
            Or or = new Or();
            foreach (String tag in tags)
            {
                bool negation;
                string trimmedTag = tag.Trim();
                if (trimmedTag.StartsWith("~"))
                {
                    trimmedTag = trimmedTag.Substring(1);
                    negation = true;
                }
                else
                {
                    negation = false;
                }
                String[] tagAndLimit = trimmedTag.Split(':');
                if (tagAndLimit.Length == 2)
                {
                    trimmedTag = tagAndLimit[0];
                    int limit = int.Parse(tagAndLimit[1]);
                    if (_limits.ContainsKey(trimmedTag) && _limits[trimmedTag] != limit)
                    {
                        throw new BadTagLimitException(trimmedTag, _limits[trimmedTag], limit);
                    }
                    _limits[trimmedTag] = limit;
                }

                if (negation)
                {
                    or.add(new Not(new TagExp(trimmedTag)));
                }
                else
                {
                    or.add(new TagExp(trimmedTag));
                }
            }
            and.add(or);
        }

        public bool eval(IEnumerable<Tag> tags)
        {
            return and.isEmpty() || this.and.eval(tags);
        }

        public Dictionary<String, int> limits()
        {
            return this._limits;
        }

        private interface Expression
        {
            bool eval(IEnumerable<Tag> tags);
        }

        private class Not : Expression
        {
            private Expression expression;

            public Not(Expression expression)
            {
                this.expression = expression;
            }

            public bool eval(IEnumerable<Tag> tags)
            {
                return !expression.eval(tags);
            }
        }

        private class And : Expression
        {
            private List<Expression> expressions = new List<Expression>();

            public void add(Expression expression)
            {
                expressions.Add(expression);
            }

            public bool eval(IEnumerable<Tag> tags)
            {
                bool result = true;
                foreach (Expression expression in expressions)
                {
                    result = expression.eval(tags);
                    if (!result)
                        break;
                }
                return result;
            }

            public bool isEmpty()
            {
                return !this.expressions.Any();
            }
        }

        private class Or : Expression
        {
            private List<Expression> expressions = new List<Expression>();

            public void add(Expression expression)
            {
                expressions.Add(expression);
            }

            public bool eval(IEnumerable<Tag> tags)
            {
                bool result = false;
                foreach (Expression expression in expressions)
                {
                    result = expression.eval(tags);
                    if (result)
                        break;
                }
                return result;
            }
        }

        private class TagExp : Expression
        {
            private String tagName;

            public TagExp(String tagName)
            {
                if (!tagName.StartsWith("@"))
                {
                    throw new BadTagException(tagName);
                }
                this.tagName = tagName;
            }

            public bool eval(IEnumerable<Tag> tags)
            {
                foreach (Tag tag in tags)
                {
                    if (tagName.Equals(tag.getName()))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private class BadTagException : Exception
        {
            public BadTagException(String tagName)
                : base("Bad tag: \"" + tagName + "\"")
            {
            }
        }

        private class BadTagLimitException : Exception
        {
            public BadTagLimitException(String tag, int limitA, int limitB)
                : base("Inconsistent tag limits for " + tag + ": " + limitA + " and " + limitB)
            {
            }
        }
    }
}
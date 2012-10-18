using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using gherkin.formatter.model;
using System.Threading;

namespace gherkin.formatter
{
    [TestClass]
    public class PrettyFormatterTest
    {
        private static List<Comment> NO_COMMENTS = new List<Comment>();
        private static List<Tag> NO_TAGS = new List<Tag>();

        [TestMethod]
        public void prints_nice_colors()
        {
            PrettyFormatter f = new PrettyFormatter(Console.Out, false, false);
            f.scenario(new Scenario(NO_COMMENTS, NO_TAGS, "Scenario", "a scenario", "", 1, "a-scenario"));
            f.step(new Step(new List<Comment>(), "Given ", "I have 6 cukes", 1, null, null));
            Thread.Sleep(1000);
            f.match(new Match(new List<Argument>() { new Argument(7, "6") }, "somewhere.brainfuck"));
            Thread.Sleep(1000);
            f.result(new Result("failed", 55L, "Something\nbad\nhappened"));
        }

        [TestMethod]
        public void prints_table()
        {
            throw new NotImplementedException();
            //PrettyFormatter f = new PrettyFormatter(System.out, false, false);
            //f.scenario(new Scenario(NO_COMMENTS, Collections.<Tag>emptyList(), "Scenario", "a scenario", "", 1, "a-scenario"));
            //ArrayList<DataTableRow> rows = new ArrayList<DataTableRow>() {{
            //    add(new DataTableRow(NO_COMMENTS, asList("un", "deux"), 1, Row.DiffType.NONE));
            //    add(new DataTableRow(NO_COMMENTS, asList("one", "two"), 1, Row.DiffType.DELETE));
            //    add(new DataTableRow(NO_COMMENTS, asList("en", "to"), 1, Row.DiffType.INSERT));
            //}};
            //Step step = new Step(new ArrayList<Comment>(), "Given ", "I have 6 cukes", 1, rows, null);
            //f.step(step);
            //Thread.sleep(1000);
            //f.match(new Match(Arrays.asList(new Argument(7, "6")), "somewhere.brainfuck"));
            //Thread.sleep(1000);
            //f.result(new Result("failed", 55L, "Something\nbad\nhappened"));
        }
    }
}
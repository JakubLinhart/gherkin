using System;
using System.Linq;
using System.Collections.Generic;
using gherkin.formatter.model;
using System.IO;
using gherkin.util;
using System.Text;

namespace gherkin.formatter
{
    /**
     * This class pretty prints feature files like they were in the source, only
     * prettier. That is, with consistent indentation. This class is also a {@link Formatter},
     * which means it can be used to print execution results - highlighting arguments,
     * printing source information and exception information.
     */
    public class PrettyFormatter : Reporter, Formatter
    {
        private StepPrinter stepPrinter = new StepPrinter();
        private NiceAppendable @out;
        private bool monochrome;
        private bool executing;

        private String _uri;
        private Formats formats;
        private Match _match;
        private int[,] cellLengths;
        private int[] maxLengths;
        private int rowIndex;
        private IEnumerable<Row> rows;
        private int? rowHeight = null;
        private bool rowsAbove = false;

        private List<Step> _steps = new List<Step>();
        private List<int> indentations = new List<int>();
        private DescribedStatement _statement;

        public PrettyFormatter(TextWriter @out, bool monochrome, bool executing)
        {
            this.@out = new NiceAppendable(@out);
            this.executing = executing;
            setMonochrome(monochrome);
        }

        public void setMonochrome(bool monochrome)
        {
            this.monochrome = monochrome;
            if (monochrome)
            {
                formats = new MonochromeFormats();
            }
            else
            {
                formats = new AnsiFormats();
            }
        }

        public void uri(string uri)
        {
            throw new NotImplementedException();
        }

        public void feature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void background(Background background)
        {
            throw new NotImplementedException();
        }

        private Format getArgFormat(String key)
        {
            return formats.get(key + "_arg");
        }

        private void printStep(String status, List<Argument> arguments, String location, bool proceed)
        {
            //Step step = proceed ? steps.remove(0) : steps.get(0);
            Step step = _steps.First();
            if (proceed)
            {
                _steps.RemoveAt(0);
            }

            Format textFormat = getFormat(status);
            Format argFormat = getArgFormat(status);

            printComments(step.getComments(), "    ");
            this.@out.append("    ");
            this.@out.append(textFormat.text(step.getKeyword()));
            stepPrinter.writeStep(this.@out, textFormat, argFormat, step.getName(), arguments);
            this.@out.append(indentedLocation(location, proceed));

            this.@out.println();
            if (step.getRows() != null)
            {
                table((IEnumerable<Row>)step.getRows());
            }
            else if (step.getDocString() != null)
            {
                docString(step.getDocString());
            }
        }

        private void printSteps()
        {
            while (_steps.Any())
            {
                printStep("skipped", new List<Argument>(), null, true);
            }
        }

        private void calculateLocationIndentations()
        {
            int[] lineWidths = new int[_steps.Count + 1];
            int i = 0;

            List<BasicStatement> statements = new List<BasicStatement>();
            statements.Add(this._statement);
            _steps.ForEach(x => statements.Add(x));
            int maxLineWidth = 0;
            foreach (BasicStatement statement in statements)
            {
                int stepWidth = statement.getKeyword().Count() + statement.getName().Length;
                lineWidths[i++] = stepWidth;
                maxLineWidth = Math.Max(maxLineWidth, stepWidth);
            }
            foreach (int lineWidth in lineWidths)
            {
                indentations.Add(maxLineWidth - lineWidth);
            }
        }

        private void printComments(List<Comment> comments, String indent)
        {
            foreach (Comment comment in comments)
            {
                this.@out.append(indent);
                this.@out.println(comment.getValue());
            }
        }

        private void printTags(List<Tag> tags, String indent)
        {
            if (!tags.Any())
                return;
            @out.append(indent);

            @out.println(FixJava.join(tags.Select(x => x.getName()).ToList(), " "));
        }

        private Format getFormat(String key)
        {
            return formats.get(key);
        }

        private String indentedLocation(String location, bool proceed)
        {
            StringBuilder sb = new StringBuilder();

            //int indentation = proceed ? indentations.Remove(0) : indentations.First();
            int indentation = indentations.First();
            if (proceed)
            {
                indentations.RemoveAt(0);
            }

            if (location == null)
            {
                return string.Empty;
            }

            for (int i = 0; i < indentation; i++)
            {
                sb.Append(' ');
            }
            sb.Append(' ');
            sb.Append(getFormat("comment").text("# " + location));

            return sb.ToString();
        }

        private static readonly System.Text.RegularExpressions.Regex START = new System.Text.RegularExpressions.Regex("^", System.Text.RegularExpressions.RegexOptions.Multiline);

        private static String indent(String s, String indentation)
        {
            return START.Replace(s, indentation);
        }

        private void printDescription(String description, String indentation, bool newline)
        {
            if (!"".Equals(description))
            {
                this.@out.println(indent(description, indentation));
                if (newline)
                {
                    this.@out.println();
                }
            }
        }

        private void printStatement()
        {
            if (_statement == null)
            {
                return;
            }
            calculateLocationIndentations();
            @out.println();
            printComments(_statement.getComments(), "  ");
            if (_statement is TagStatement)
            {
                printTags(((TagStatement)_statement).getTags(), "  ");
            }
            @out.append("  ");
            @out.append(_statement.getKeyword());
            @out.append(": ");
            @out.append(_statement.getName());
            String location = executing ? _uri + ":" + _statement.getLine() : null;
            @out.println(indentedLocation(location, true));
            printDescription(_statement.getDescription(), "    ", true);
            _statement = null;
        }

        private void replay()
        {
            printStatement();
            printSteps();
        }

        public void scenario(Scenario scenario)
        {
            replay();
            _statement = scenario;
        }

        public void scenarioOutline(ScenarioOutline scenarioOutline)
        {
            throw new NotImplementedException();
        }

        public void examples(Examples examples)
        {
            throw new NotImplementedException();
        }

        public void step(Step step)
        {
            _steps.Add(step);
        }

        public void match(Match match)
        {
            this._match = match;
            printStatement();
            if (!monochrome)
            {
                printStep("executing", match.getArguments(), match.getLocation(), false);
            }
        }

        private void printError(Result result)
        {
            Format failed = formats.get("failed");
            @out.println(indent(failed.text(result.getErrorMessage()), "      "));
        }

        public void result(Result result)
        {
            if (!monochrome)
            {
                @out.append(formats.up(1));
            }
            if (_match != null)
            {
                printStep(result.getStatus(), _match.getArguments(), _match.getLocation(), true);
            }
            //Match should only be null if there's an error in something that's not a step, so this should be safe
            if (result.getErrorMessage() != null)
            {
                printError(result);
            }
        }


        private void prepareTable(IEnumerable<Row> rows)
        {
            this.rows = rows;
            int columnCount = rows.First().getCells().Count;
            cellLengths = new int[rows.Count(), columnCount];
            maxLengths = new int[columnCount];
            for (int rowIndex = 0; rowIndex < rows.Count(); rowIndex++) {
                Row row = rows.Skip(rowIndex).First();
                List<String> cells = row.getCells();
                for (int colIndex = 0; colIndex < columnCount; colIndex++) {
                    String cell = cells[colIndex];
                    int length = escapeCell(cell).Length;
                    cellLengths[rowIndex, colIndex] = length;
                    maxLengths[colIndex] = Math.Max(maxLengths[colIndex], length);
                }
            }
            this.rowIndex = 0;
        }

        public void table(IEnumerable<Row> rows)
        {
            prepareTable(rows);
            if (!executing) {
                foreach (Row row in rows) {
                    this.row(row.createResults("skipped"));
                    nextRow();
                }
            }
        }
        
        private String escapeCell(String cell)
        {
            return cell.Replace("\\\\(?!\\|)", "\\\\\\\\").Replace("\\n", "\\\\n").Replace("\\|", "\\\\|");
        }

        private void padSpace(int indent) {
            for (int i = 0; i < indent; i++) {
                @out.append(" ");
            }
    }
        public void row(List<CellResult> cellResults)
        {
            Row row = rows.Skip(rowIndex).First();
            if (rowsAbove) {
                @out.append(formats.up(rowHeight));
            }
            else
            {
                rowsAbove = true;
            }

            rowHeight = 1;

            foreach (Comment comment in row.getComments()) {
                @out.append("      ");
                @out.println(comment.getValue());
                rowHeight++;
            }

            switch (row.getDiffType()) {
                case gherkin.formatter.model.Row.DiffType.NONE:
                    @out.append("      | ");
                    break;
                case gherkin.formatter.model.Row.DiffType.DELETE:
                    @out.append("    ").append(formats.get("skipped").text("-")).append(" | ");
                    break;
                case gherkin.formatter.model.Row.DiffType.INSERT:
                    @out.append("    ").append(formats.get("comment").text("+")).append(" | ");
                    break;
            }

            for (int colIndex = 0; colIndex < maxLengths.Length; colIndex++) {
                String cellText = escapeCell(row.getCells()[colIndex]);
                String status = null;
                switch (row.getDiffType()) {
                    case gherkin.formatter.model.Row.DiffType.NONE:
                        status = cellResults[colIndex].getStatus();
                        break;
                    case gherkin.formatter.model.Row.DiffType.DELETE:
                        status = "skipped";
                        break;
                    case gherkin.formatter.model.Row.DiffType.INSERT:
                        status = "comment";
                        break;
                }
                Format format = formats.get(status);
                @out.append(format.text(cellText));
                int padding = maxLengths[colIndex] - cellLengths[rowIndex, colIndex];
                padSpace(padding);
                if (colIndex < maxLengths.Length - 1) {
                    @out.append(" | ");
                } else {
                    @out.append(" |");
                }
            }

            @out.println();
            rowHeight++;
            ISet<Result> seenResults = new HashSet<Result>();
            foreach (CellResult cellResult in cellResults) {
                foreach (Result result in cellResult.getResults()) {
                    if (result.getErrorMessage() != null && !seenResults.Contains(result)) {
                        printError(result);
                        rowHeight += result.getErrorMessage().Split('\n').Length;
                        seenResults.Add(result);
                    }
                }
            }
        }

        public void nextRow()
        {
            rowIndex++;
            rowsAbove = false;
        }

        public void syntaxError(String state, String @event, List<String> legalEvents, String uri, int line)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }

        public void docString(DocString docString)
        {
            throw new NotImplementedException();
        }

        public void eof()
        {
            throw new NotImplementedException();
        }

        public void embedding(String mimeType, byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
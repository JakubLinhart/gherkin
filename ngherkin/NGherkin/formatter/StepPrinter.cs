using System;
using System.Collections.Generic;

namespace gherkin.formatter
{
    public class StepPrinter
    {
        public void writeStep(NiceAppendable @out, Format textFormat, Format argFormat, String stepName, List<Argument> arguments)
        {
            int textStart = 0;
            foreach (Argument argument in arguments) {
                if (argument.getOffset() != null) {
                    String text = stepName.Substring(textStart, argument.getOffset().Value - textStart);
                    @out.append(textFormat.text(text));
                }
                // val can be null if the argument isn't there, for example @And("(it )?has something")
                if (argument.getVal() != null) {
                    @out.append(argFormat.text(argument.getVal()));
                    textStart = argument.getOffset().Value + argument.getVal().Length;
                }
            }
            if (textStart != stepName.Length) {
                String text = stepName.Substring(textStart, stepName.Length - textStart);
                @out.append(textFormat.text(text));
            }
        }
    }
}
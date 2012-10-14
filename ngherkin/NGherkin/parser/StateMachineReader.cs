using System;
using gherkin.lexer;
using System.Collections.Generic;
namespace gherkin.parser
{
public class StateMachineReader : Listener {
    public StateMachineReader(String name) {
        throw new NotImplementedException();
    }

    public List<List<String>> transitionTable() {
        throw new NotImplementedException();
    }

    public void tag(String tag, int line) {
    }

    public void comment(String comment, int line) {
    }

    public void feature(String keyword, String name, String description, int line) {
    }

    public void background(String keyword, String name, String description, int line) {
    }

    public void scenario(String keyword, String name, String description, int line) {
    }

    public void scenarioOutline(String keyword, String name, String description, int line) {
    }

    public void examples(String keyword, String name, String description, int line) {
    }

    public void step(String keyword, String name, int line) {
    }

    public void docString(String contentType, String content, int line) {
    }

    public void eof() {
    }

    public void row(List<String> cells, int line) {
        throw new NotImplementedException();
    }
}
}
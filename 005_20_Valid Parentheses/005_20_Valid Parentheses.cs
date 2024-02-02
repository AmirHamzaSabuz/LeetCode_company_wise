
using System.Collections.Generic;

public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s) {
            if (IsOpenBracket(c)) {
                stack.Push(c);
            } else {
                if (stack.Count == 0 || !MatchBrackets(stack.Peek(), c)) {
                    return false;
                }
                stack.Pop();
            }
        }

        return stack.Count == 0;
    }

    private bool IsOpenBracket(char c) {
        return c == '(' || c == '{' || c == '[';
    }

    private bool MatchBrackets(char open, char close) {
        return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
    }
}

using System;

namespace BracketChecker {
    class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();

            string[] testStrings = {
                "()[]{}",  // Valid
                "([)]{}",  // Invalid
                "({[]})",  // Valid
                "([)]",     // Invalid
                "([]",      // Invalid
            };

            foreach (string s in testStrings) {
                bool isValid = solution.IsValid(s);
                Console.WriteLine($"{s} is {(isValid ? "valid" : "invalid")}.");
            }
        }
    }
}

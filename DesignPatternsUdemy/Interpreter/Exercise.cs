using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsUdemy.Interpreter
{
    public class Exercise
    {
        public static void Demo()
        {
            var input = "(13+4)-(12+1+xy)";
            //var input = "2+4+x";
            var Variables = new Dictionary<char, int>
            {
                { 'x', 4 }
            };

            new ExpressionProcessor
            {
                Variables = Variables
            }.Calculate(input);
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var tokens = Interpreter.Lex(expression);
            Console.WriteLine(string.Join("\t", tokens));

            var parsed = Interpreter.Parse(tokens, Variables);
            Console.WriteLine($"{expression} = {parsed.Value}");
            return parsed.Value;
        }
    }

    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition,
            Subtraction
        }

        public Type MyType;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (MyType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Subtraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen, Variable
        }

        public Type MyType;
        public string Text;

        public Token(Type type, string text)
        {
            MyType = type;
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }

    public class Interpreter
    {
        public static List<Token> Lex(string input)
        {
            var result = new List<Token>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.Type.Lparen, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.Rparen, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        var type = char.IsDigit(input[i]) ? Token.Type.Integer : Token.Type.Variable;

                        for (int j = i + 1; j < input.Length; ++j)
                        {
                            // integer or variable
                            if (char.IsLetterOrDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            {
                                result.Add(new Token(type, sb.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }
            return result;
        }

        public static IElement Parse(IReadOnlyList<Token> tokens, IDictionary<char, int> Variables)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            bool invalidVariable = false;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                // look at the type of token
                switch (token.MyType)
                {
                    case Token.Type.Variable:
                        var variableChar = token.Text.ToString();
                        invalidVariable = variableChar.Length > 1 || !Variables.ContainsKey(variableChar[0]) ? true : false;

                        if (invalidVariable)
                        {
                            break;
                        }
                        else
                        {
                            int variableValue = 0;
                            Variables.TryGetValue(variableChar[0], out variableValue);
                            token.Text = variableValue.ToString();
                            goto case Token.Type.Integer;
                        }
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.Type.Lparen:
                        if (invalidVariable)
                        {
                            return new Integer(0);
                        }
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].MyType == Token.Type.Rparen)
                                break; // found it!
                                        // process subexpression w/o opening (
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression, Variables);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else result.Right = element;
                        i = j; // advance
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return invalidVariable ? new Integer(0) : result;
        }
    }

}

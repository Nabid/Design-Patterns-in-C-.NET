using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsUdemy
{
    public class BuilderExercise
    {
        public BuilderExercise()
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");

            Console.WriteLine(cb);
        }

        public class ClassType
        {
            public string ClassName;
            public List<ClassElement> ClassElements = new List<ClassElement>();
            private const int indentSize = 2;

            public class ClassElement
            {
                public string PropertyType, PropertyName;

                public ClassElement(string type, string name)
                {
                    PropertyType = type;
                    PropertyName = name;
                }
            }

            private string ToStringImpl(int indent)
            {
                var sb = new StringBuilder();
                //var i = new string(' ', indentSize * indent);
                sb.AppendLine($"public class {ClassName}");
                sb.AppendLine("{");

                foreach (var element in ClassElements)
                {
                    sb.Append(new string(' ', indentSize * (indent+1)));
                    sb.AppendLine($"public {element.PropertyType} {element.PropertyName};");
                }

                sb.Append("}");
                return sb.ToString();
            }

            public override string ToString()
            {
                return ToStringImpl(0);
            }
        }

        public interface ICodeBuilder
        {
            ICodeBuilder AddField(string name, string type);
        }

        public class CodeBuilder : ICodeBuilder
        {
            ClassType _class = new ClassType();

            public CodeBuilder(string name)
            {
                _class.ClassName = name;
            }

            public ICodeBuilder AddField(string name, string type)
            {
                _class.ClassElements.Add(new ClassType.ClassElement(type, name));
                return this;
            }

            public override string ToString()
            {
                return _class.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetSpec.Core;

namespace NetSpec.CodeHelper
{
    public class CodeBuilder
    {
        public static string Builder(string specification, string className)
        {
            if (string.IsNullOrWhiteSpace(specification))
                return string.Empty;

            var code = new StringBuilder();

            code.AppendLine("[TestClass]");
            code.AppendLine("public class NetSpecTestClass");
            code.AppendLine("{");
            code.AppendLine("    [TestMethod]");
            code.AppendLine("    public void StartTest()");
            code.AppendLine("    {");
            code.Append("        const string specification = @\"");
            code.Append(specification);
            code.AppendLine("\";");
            code.AppendLine();
            code.AppendLine("        SpecificationBuilder.Builder(specification).TryExecute(this);");
            code.AppendLine("    }");

            // methods
            var spec = SpecificationBuilder.Builder(specification);
            spec.LineSpecCollection.ToList()
                .Where(l => l.GetLineType() == LineType.Executable).ToList()
                    .ForEach(execL =>
                    {
                        code.AppendLine();
                        code.AppendLine(string.Format("    public void {0}()", ConvertToPascalCase(execL.AnNormalizedSpecificationLine)));
                        code.AppendLine("    {");
                        code.AppendLine("        throw new NotImplementedException();");
                        code.AppendLine("    }");
                    });

            code.Append("}");

            return code.ToString();
        }

        public static string ConvertToPascalCase(string str)
        {
            if (str == null) throw new ArgumentNullException("str", "Null text cannot be converted!");
            if (str.Length == 0) return str;
            var words = str.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    var word = words[i];

                    var firstLetter = char.ToUpper(word[0]);

                    words[i] = firstLetter + word.Substring(1);
                }
            }

            return string.Join(string.Empty, words);
        }
    }
}

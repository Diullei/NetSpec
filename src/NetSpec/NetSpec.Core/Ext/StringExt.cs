namespace NetSpec.Core.Ext
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using Infrastructure;

    public static class StringExt
    {
        #region " Métodos "

        /// <summary>
        /// Identifica se o string inicia com um espaço em branco.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StartWithWhiteSpace(this string str)
        {
            return str != null && str.StartsWith(" ");
        }

        /// <summary>
        /// Identifica se o string inicia com uma tabulação.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StartWithTab(this string str)
        {
            return str != null && str.StartsWith(new string(new char[] { '\t' }));
        }

        /// <summary>
        /// Identifica se a linha inicia com um espaço em branco 
        /// ou com uma tabulação.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StartWithTabOrWhiteSpace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            return str.StartWithWhiteSpace() || str.StartWithTab();
        }

        /// <summary>
        /// Separa o string sempre que um padrão CamelCase for encontrado.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="symbol">Um simbolo a ser usado na separação</param>
        /// <returns></returns>
        public static string SplitCamelCase(this string str, char symbol = ' ')
        {
            return new string(
                str.SelectMany((x, i) => i > 0 && (char.IsUpper(x))
                                             ? new char[] { symbol, x }
                                             : new char[] { x }).ToArray());
        }

        public static bool IsMatch(this string str, MethodInfo methodInfo)
        {
            if (methodInfo.IsNull())
                return false;

            var methodName = methodInfo.Name.Replace("_", "(.*)");

            if (methodName.IndexOf("(.*)") == -1)
                return str.RemoveAccents().ToUpper() == methodName.RemoveAccents().SplitCamelCase().ToUpper();

            return Regex.IsMatch(str.RemoveAccents().ToUpper(), "^" + methodName.RemoveAccents().SplitCamelCase().ToUpper());
        }

        /// <summary>
        /// Remove os acentos da string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string str)
        {
            var s = str.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            foreach (var t in s)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Estrai os parâmetros encontrados na string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="methodSpec"></param>
        /// <returns></returns>
        public static List<object> ExtractParameters(this string str, MethodSpec methodSpec)
        {
            var strParList = new List<string>();

            var matches = Regex.Matches(str.RemoveAccents(), methodSpec.MethodPatternName.RemoveAccents(), RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                if (matches[0].Groups.Count > 1)
                {
                    for (var i = 1; i < matches[0].Groups.Count; i++)
                    {
                        var substring = str.Substring(matches[0].Groups[i].Index, matches[0].Groups[i].Value.Length);
                        strParList.Add(substring.Trim());
                    }
                }

                var customConvert = methodSpec.ConvertAttributeCollection.ToList().Select(t => t.ConvertClass).ToList();
                return strParList.Select((t, i) => Parameter.Create(t, methodSpec.ParameterCollection[i]).TryConvert(customConvert)).ToList();
            }

            return new List<object>(); ;
        }

        public static IList<string> MultiLineAsList(this string str)
        {
            return new List<string>(Regex.Split(str, Environment.NewLine));
        }

        public static IList<string> ListOfMethodName(this Type type)
        {
            return type.GetMethods().ToList().Select(m => m.Name).ToList();
        }

        public static string GetLongestString(this List<string> listStr)
        {
            var longest = string.Empty;
            listStr.ForEach(x =>
                                {
                                    longest = x.Length > longest.Length ? x : longest;
                                });

            return longest;
        }

        public static string Repeat(this string str, int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                result.Append(str);
            }

            return result.ToString();
        }

        #endregion
    }
}

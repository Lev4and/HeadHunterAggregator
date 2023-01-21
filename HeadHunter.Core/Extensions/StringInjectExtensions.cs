using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HeadHunter.Core.Extensions
{
    public static class StringInjectExtensions
    {
        public static string Inject(this string formatString, object injectionObject)
        {
            return formatString.Inject(GetPropertyHash(injectionObject));
        }

        public static string Inject(this string formatString, IDictionary dictionary)
        {
            return formatString.Inject(new Hashtable(dictionary));
        }

        public static string Inject(this string formatString, Hashtable attributes)
        {
            var result = formatString;

            if (attributes == null || formatString == null) return result;

            foreach (var attributeKey in attributes.Keys)
            {
                result = result.InjectSingleValue(attributeKey.ToString(), attributes[attributeKey]);
            }

            return result;
        }

        public static string InjectSingleValue(this string formatString, string key, object replacementValue)
        {
            var result = formatString;
            var attributeRegex = new Regex("{(" + key + ")(?:}|(?::(.[^}]*)}))");

            foreach (Match match in attributeRegex.Matches(formatString))
            {
                var replacement = match.ToString();

                if (match.Groups[2].Length > 0)
                {
                    var attributeFormatString = string.Format(CultureInfo.InvariantCulture, "{{0:{0}}}", match.Groups[2]);

                    replacement = string.Format(CultureInfo.CurrentCulture, attributeFormatString, replacementValue);
                }
                else replacement = (replacementValue ?? string.Empty).ToString();

                result = result.Replace(match.ToString(), replacement);
            }

            return result;
        }

        private static Hashtable? GetPropertyHash(object properties)
        {
            if (properties != null)
            {
                var values = new Hashtable();
                var props = TypeDescriptor.GetProperties(properties);

                foreach (PropertyDescriptor prop in props)
                {
                    values.Add(prop.Name, prop.GetValue(properties));
                }

                return values;
            }

            return null;
        }
    }
}

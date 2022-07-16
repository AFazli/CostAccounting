using Pluralize.NET.Core;

namespace Shoniz.Framework.Utility
{
    public static class StringExtension
    {
        public static string ToPlural(this string word)
        {
            return new Pluralizer().Pluralize(word);
        }
    }
}
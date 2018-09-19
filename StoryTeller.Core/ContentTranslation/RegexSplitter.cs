using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StoryTeller.Core.ContentTranslation
{
    public class RegexSplitter
    {
        public string[] Split(string content, string pattern)
        {
            var split = Regex.Split(content, pattern).ToArray();

            var auxContents = new List<string>();

            for (int i = 0; i < split.Length; i++)
            {
                var currCont = split[i];
                var formatted = currCont;

                if (string.IsNullOrWhiteSpace(currCont))
                    continue;

                var prevCont = split[i];
                var nextCont = split[i];

                if ((i + 1) < split.Length)
                {
                    nextCont = split[i + 1];
                }
                if ((i - 1) >= 0)
                {
                    prevCont = split[i - 1];
                }

                if (string.IsNullOrWhiteSpace(prevCont))
                {
                    formatted = $"{prevCont}{currCont}";
                }

                if (string.IsNullOrWhiteSpace(nextCont))
                {
                    formatted = $"{currCont}{nextCont}";
                }

                auxContents.Add(formatted);
            }

            return auxContents.ToArray();
        }
    }
}

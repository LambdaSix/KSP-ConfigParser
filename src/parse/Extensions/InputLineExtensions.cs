using System.Collections.Generic;
using parse.Models;

namespace parse.Extensions
{
    public static class InputLineExtensions
    {
        ///<summary>Sometimes we get input lines that contain multiple
        ///curly braces.  Those curly braces should always be on their
        ///own line, so we need to split the existing line object into
        ///multiple line objects.</summary>
        public static IEnumerable<InputLine> SplitLineDataOnBraces(this InputLine line)
        {

            var result = new List<InputLine>();

            var braceIndex = FindNextBrace(line.Data);
            while (braceIndex >= 0)
            {                
                // Is there anything before the brace that is not whitespace?
                if (braceIndex > 0) 
                { 
                    var newData = line.Data.Substring(0, braceIndex).Trim();
                    if (!string.IsNullOrWhiteSpace(newData)) result.Add(new InputLine{ Data = newData }); 
                }

                // Add the brace as a new element
                result.Add(new InputLine{ Data = line.Data.Substring(braceIndex, 1) });

                // Trim everything up to and including the found brace off the input
                if (line.Data.Length >= braceIndex + 1)
                    line.Data = line.Data.Substring(braceIndex + 1).Trim();

                braceIndex = FindNextBrace(line.Data);
            }
            // Was there anything left-over after the last brace?
            line.Data = line.Data.Trim();
            if (!string.IsNullOrWhiteSpace(line.Data)) result.Add(line);
            
            return result;
        }

        private static int FindNextBrace(string input)
        {
            var openIndex = input.IndexOf(Constants.OpeningBrace);
            var closeIndex = input.IndexOf(Constants.ClosingBrace);

            if (openIndex == -1) return closeIndex;
            if (closeIndex == -1) return openIndex;
            return (closeIndex < openIndex) ? closeIndex : openIndex;
        }
    }
}
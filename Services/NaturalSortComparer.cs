using System.Text.RegularExpressions;

namespace IPSDesk.Services;

public class NaturalSortComparer : IComparer<string?>
{
    private static readonly Regex ChunkRegex = new(@"(\d+|\D+)", RegexOptions.Compiled);

    public int Compare(string? x, string? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        var xMatches = ChunkRegex.Matches(x);
        var yMatches = ChunkRegex.Matches(y);

        int count = Math.Min(xMatches.Count, yMatches.Count);
        for (int i = 0; i < count; i++)
        {
            string xPart = xMatches[i].Value;
            string yPart = yMatches[i].Value;

            bool xIsNum = char.IsDigit(xPart[0]);
            bool yIsNum = char.IsDigit(yPart[0]);

            if (xIsNum && yIsNum)
            {
                if (long.TryParse(xPart, out long xVal) && long.TryParse(yPart, out long yVal))
                {
                    int diff = xVal.CompareTo(yVal);
                    if (diff != 0) return diff;
                }

                // If numeric value is identical, compare text length (handles leading zeroes like "01" vs "1")
                int lenDiff = xPart.Length.CompareTo(yPart.Length);
                if (lenDiff != 0) return lenDiff;
            }
            else
            {
                int strDiff = string.Compare(xPart, yPart, StringComparison.OrdinalIgnoreCase);
                if (strDiff != 0) return strDiff;
            }
        }

        return xMatches.Count.CompareTo(yMatches.Count);
    }
}

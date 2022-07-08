namespace KysectAcademyTask;

public class LevenshteinDistance
{
    private static int CalculateDictance(string string1, string string2)
    {
        if (string1 == null) throw new ArgumentNullException(nameof(string1));
        if (string2 == null) throw new ArgumentNullException(nameof(string2));
        int[,] m = new int[string1.Length + 1, string2.Length + 1];

        for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
        for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

        for (int i = 1; i <= string1.Length; i++)
        {
            for (int j = 1; j <= string2.Length; j++)
            {
                int diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
            }
        }
        return m[string1.Length, string2.Length];
    }

    public static double CalculateSimilarity(string? source, string? target)
    {
        if (source == null || target == null) return 0.0;
        if (source.Length == 0 || target.Length == 0) return 0.0;
        if (source == target) return 1.0;
   
        int stepsToSame = CalculateDictance(source, target);
        return 1.0 - ((double)stepsToSame / Math.Max(source.Length, target.Length));
    }
}
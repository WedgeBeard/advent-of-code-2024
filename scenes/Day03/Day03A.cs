
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Godot;

namespace Day03;

public class Day03A {
    public void ComputeDay03A(string directory)
    {
        string filePath = Path.Combine(directory, "scenes\\Day03\\day03b.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);

        int total = AccumulateTotals(fileStrings);

        GD.Print("Grand total Day 3 part 1: " + total);
    }

    private static int AccumulateTotals(List<string> results)
    {
        string mulpattern = @"mul\(\d{1,3},\d{1,3}\)";
        Regex mulRegex = new Regex(mulpattern);

        string numPattern = @"\d{1,3}";
        Regex numRegex = new Regex(numPattern);

        int total = 0;

        for (int i = 0; i < results.Count; i++)
        {
            MatchCollection mulMatches = mulRegex.Matches(results[i]);
            foreach (Match mulMatch in mulMatches)
            {
                MatchCollection numMatches = numRegex.Matches(mulMatch.Value);
                total += int.Parse(numMatches[0].Value) * int.Parse(numMatches[1].Value);
            }
        }
        return total;
    }
}
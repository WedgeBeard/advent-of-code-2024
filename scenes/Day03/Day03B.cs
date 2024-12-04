
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Godot;

namespace Day03;

public class Day03B {
    public void ComputeDay03B(string directory)  {
        string filePath = Path.Combine(directory, "scenes\\Day03\\day03a.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);
        
        List<string> doStrings = GetDoStrings(fileStrings);
        int total = AccumulateTotals(doStrings);

        GD.Print("Grand total Day 3 part 2: " + total);
    }

    private List<string> GetDoStrings(List<string> fileStrings)
    {
        List<string> doStrings = new List<string>();
        string doString = "do()";
        string dontString = "don't()";
        foreach (string line in fileStrings) {
            string command = line;
            int indexHead = 0;
            while (command.Length > 0) {
                int indexTail = command.IndexOf(dontString);
                if (indexTail > 0) {
                    doStrings.Add(command.Substr(indexHead, indexTail));
                    command = command.Substr(indexTail + 7, command.Length - 1);
                } else {
                    doStrings.Add(command);
                    command = "";
                }

                indexTail = command.IndexOf(doString);
                if (indexTail > 0) {
                    command = command.Substr(indexTail + 4, command.Length - 1);
                } else {
                    command = "";
                }
            }

            foreach(string item in doStrings) {
                GD.Print($"do strings: {item}");
            }
            // doStrings.Clear();
            // GD.Print("===========================================");
        }
        return doStrings;
    }

    private static int AccumulateTotals(List<string> results)
    {
        string mulpattern = @"mul\(\d{1,3},\d{1,3}\)";
        Regex mulRegex = new Regex(mulpattern);

        string numPattern = @"\d{1,3}";
        Regex numRegex = new Regex(numPattern);

        int total = 0;

        foreach (string value in results)
        {
            MatchCollection mulMatches = mulRegex.Matches(value);
            foreach (Match mulMatch in mulMatches)
            {
                MatchCollection numMatches = numRegex.Matches(mulMatch.Value);
                total += int.Parse(numMatches[0].Value) * int.Parse(numMatches[1].Value);
            }
        }

        return total;
    }
// try 1: too high, 61636489
// try 2: too low,  48459518
}
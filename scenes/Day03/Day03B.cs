
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using Godot;

namespace Day03;

public class Day03B {
    public void ComputeDay03B(string directory)  {
        string filePath = Path.Combine(directory, "scenes\\Day03\\day03a.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);
        
        int total = SumMuls(fileStrings);
        GD.Print("Grand total Day 3 part 2 (updated): " + total);
    }

    private int SumMuls(List<string> fileStrings)
    {
        int total = 0;
        string command = "";

        string doPattern = @"do\(\)";
        Regex doRegex = new Regex(doPattern);
        string dontPattern = @"don't\(\)";
        Regex dontRegex = new Regex(dontPattern);
        string mulPattern = @"mul\(\d{1,3},\d{1,3}\)";
        Regex mulRegex = new Regex(mulPattern);
        string numPattern = @"\d{1,3}";
        Regex numRegex = new Regex(numPattern);

        bool enabled = true;

        foreach (string line in fileStrings) {
            command = line;
            Dictionary<int, string> allMatches = new Dictionary<int, string>();

            MatchCollection mulMatches = mulRegex.Matches(line);
            MatchCollection doMatches = doRegex.Matches(line);
            MatchCollection dontMatches = dontRegex.Matches(line);

            foreach(Match match in mulMatches) { allMatches.Add(match.Index, match.Value); }
            foreach(Match match in doMatches) { allMatches.Add(match.Index, match.Value); }
            foreach(Match match in dontMatches) { allMatches.Add(match.Index, match.Value); }

            SortedDictionary<int, string> sortedMatches = new SortedDictionary<int, string>(allMatches);

            foreach (var kvp in sortedMatches) {
                if (kvp.Value == "do()") {
                    enabled = true;
                }
                else if (kvp.Value == "don't()") { 
                    enabled = false; 
                }
                else 
                    if(enabled) {
                        MatchCollection numMatches = numRegex.Matches(kvp.Value);
                        int val1 = int.Parse(numMatches[0].Value);
                        int val2 = int.Parse(numMatches[1].Value);
                        total += val1 * val2;
                    } else { // do nothing } 
                }
            }
        }
        return total;
    }
}
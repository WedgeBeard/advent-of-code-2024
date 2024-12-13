
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Godot;

namespace Day07;

public class Day07A {
    public void ComputeDay07A(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day07\\day07atest.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);
        
        string totalPattern = @"(\d+)(?=:)";
        string factorsPattern = @"(?<=:\s|\G\s)\d+";
        Regex totalRegex = new Regex(totalPattern);
        Regex factorsRegex = new Regex(factorsPattern);

        for (int i = 0; i < fileStrings.Count; i++) {
            string line = fileStrings[i];
            long total = long.Parse(totalRegex.Match(line).Value);
            List<long> factors = new List<long>();
            MatchCollection factorsMatches = factorsRegex.Matches(line);
            
            foreach(Match match in factorsMatches) { factors.Add(long.Parse(match.Value)); }

            List<string> operators = new List<string>();
            GenerateOperators("", factors.Count - 1, operators);

            long sum = 0;
            foreach(long factor in factors) {
                // do all the math stuff
            }
        }

        GD.Print("Day 07 Part 2: ");
    }

    private void GenerateOperators(string prefix, int length, List<string> permutations)
    {
        if (length == 0) {
            permutations.Add(prefix); 
            return; 
        }
        
        GenerateOperators(prefix + "+", length - 1, permutations);
        GenerateOperators(prefix + "*", length - 1, permutations);
    }
}
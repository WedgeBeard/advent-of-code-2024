using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Godot;

namespace utils;

public static class FileReader {

    public static string directory = AppDomain.CurrentDomain.BaseDirectory;

    public static List<string> ToStringList(string filePath) {
        List<string> results = File.ReadAllLines(filePath).ToList<string>();
        return results;
    }

    public static void GetRulesAndPages(string filePath, ref List<Vector2I> rules, ref List<List<int>> pages) {
        bool switcher = false;
        StreamReader reader = new StreamReader(filePath);
        string patternRules = @"\d{2}";
        string patternPages = @"\b\d{2}\b";
        Regex regexRules = new Regex(patternRules);
        Regex regexPages = new Regex(patternPages);
        MatchCollection matchRules;
        MatchCollection matchPages;
        string line;

        while ((line = reader.ReadLine()) != null) {
            if (line.Length == 0) { switcher = true; continue; }
            if (switcher) {
                matchPages = regexPages.Matches(line);
                List<int> tempPagesList = new List<int>();
                foreach (Match pageMatch in matchPages) {
                    tempPagesList.Add(int.Parse(pageMatch.Value));
                }
                pages.Add(tempPagesList);
            }
            else {
                matchRules = regexRules.Matches(line);
                rules.Add(new Vector2I(int.Parse(matchRules[0].Value), int.Parse(matchRules[1].Value)));
            }
        }
    }
}
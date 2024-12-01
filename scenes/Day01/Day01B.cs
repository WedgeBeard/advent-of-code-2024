using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day01;

public class Day01B {

    List<string> intNames = new List<string>{"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    Dictionary<string, string> converstionTable = new Dictionary<string, string>()
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };

    public void ComputeDay01B(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day01\\day01a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int total = 0;

        foreach (string value in results) {
            string numbers = string.Empty;
            string newValue = ReplaceSubstringsWithInts(value);

            foreach (char item in newValue) {
                if (char.IsDigit(item)) {
                    numbers += item;
                }
            }

            if(numbers.Length != 0) {
                string num = string.Empty;
                num += numbers[0];
                num += numbers[numbers.Length-1];
                int combined = int.Parse(num);
                total += (combined);
            }
        }
        GD.Print("Grand total part 2: " + total);
    }

    private string ReplaceSubstringsWithInts(string value)
    {
        string currentString = value;
        int startIndex = 0;
        Dictionary<int, string> foundWords = new Dictionary<int, string>();

        foreach (string word in intNames){
            int matchIndex = currentString.IndexOf(word, startIndex);
            while (matchIndex >= 0) {
                foundWords.Add(matchIndex, word);
                startIndex = matchIndex + word.Length;
                matchIndex = currentString.IndexOf(word, startIndex);
            }
            currentString = value;
            startIndex = 0;
        }

        List<int> keys = new List<int>();

        foreach(KeyValuePair<int, string> entry in foundWords) {
            keys.Add(entry.Key);
        }

        keys.Sort();

        for (int i = 0; i < keys.Count; i++) {
            string targetWord = foundWords[keys[i]];
            currentString = currentString.Replace(targetWord, converstionTable[targetWord]);
        }

        return currentString; 
    }
}
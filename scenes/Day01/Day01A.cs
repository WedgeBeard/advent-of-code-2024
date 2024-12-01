
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day01;

public class Day01A {

    public void ComputeDay01A(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day01\\day01a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int total = 0;

        foreach (string value in results) {
            string numbers = string.Empty;

            foreach (char item in value) {
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
        GD.Print("Grand total part 1: " + total);
    }
}
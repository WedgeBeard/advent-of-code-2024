
using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day01;

public class Day01A {

    public void ComputeDay01A(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day01\\day01a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int total = 0;

        List<int> columnA = new List<int>();
        List<int> columnB = new List<int>();

        foreach (string value in results) {
            string[] pair = value.Split("   ");
            columnA.Add(int.Parse(pair[0]));
            columnB.Add(int.Parse(pair[1]));
        }

        columnA.Sort();
        columnB.Sort();

        for(int i = 0; i < columnA.Count; i++){
            total += Math.Abs(columnA[i] - columnB[i]);
        }

        GD.Print("Grand total part 1: " + total);
    }
}
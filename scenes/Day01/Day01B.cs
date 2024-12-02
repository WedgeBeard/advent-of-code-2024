using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day01;

public class Day01B {

   public void ComputeDay01B(string directory) { 
        string filePath = Path.Combine(directory, "scenes\\Day01\\day01b.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        List<int> columnA = new List<int>();
        List<int> columnB = new List<int>();

        foreach (string value in results) {
            string[] pair = value.Split("   ");
            columnA.Add(int.Parse(pair[0]));
            columnB.Add(int.Parse(pair[1]));
        }

        columnA.Sort();
        columnB.Sort();

        int count = 0;
        int runningTotal = 0;
        for(int i = 0; i < columnA.Count; i++){
            for(int j = 0; j < columnB.Count; j++){
                if(columnA[i] == columnB[j]) {
                    count++;
                }
            }
            runningTotal += columnA[i] * count;
            count = 0;
        }

        GD.Print("Grand total Day 1 part 2: " + runningTotal);
    }   
}
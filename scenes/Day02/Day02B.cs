using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day02;

public class Day02B {

    public void ComputeDay02B(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day02\\day02a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int safeTotal = 0;

        foreach(string line in results) {
            int safeCount = 0;
            int exception = 0;
            string[] sequence = line.Split(' ');
            int sequenceLength = sequence.Length;
            for(int i = 0; i < sequenceLength - 1; i++) {
                int curr = int.Parse(sequence[i]);
                int next = int.Parse(sequence[i+1]);
                if (curr < next && next - curr >= 1 && next - curr <= 3) {
                    safeCount++;
                } else if (curr > next && curr - next >= 1 && curr - next <= 3) {
                    safeCount--;
                } else {
                    exception++;
                }
            }
            if(Math.Abs(safeCount) == sequenceLength-1 ||
                ((Math.Abs(safeCount) == sequenceLength-2) && exception == 1)) {
                safeTotal++;
            }
            exception = 0;
        }

        GD.Print("Grand total Day 2 part 2: " + safeTotal);
    }
}
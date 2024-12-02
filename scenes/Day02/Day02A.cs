using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day02;

public class Day02A {

    public void ComputeDay02A(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day02\\day02a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int safeTotal = 0;

        foreach(string line in results) {
            int safeCount = 0;
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
                    break;
                }
            }
            if(Math.Abs(safeCount) == sequenceLength-1) {
                safeTotal++;
            }
        }

        GD.Print("Grand total Day 2 part 1: " + safeTotal);
    }
}
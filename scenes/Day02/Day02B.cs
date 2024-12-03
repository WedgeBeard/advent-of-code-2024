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
            string[] sequence = line.Split(' ');
            if (CheckSafety(sequence)) { 
                safeTotal++;
            }
            else {
                bool anySafe = false;
                for (int i = 0; i < sequence.Length - 1; i++) {
                    string[] testSequence = RemoveElement(sequence, i);
                    if(CheckSafety(testSequence)) { anySafe = true; }
                }
                if(anySafe) { safeTotal++; }
            }
        }

        GD.Print("Grand total Day 2 part 2: " + safeTotal);
    }

    private string[] RemoveElement(string[] str, int index)
    {
        int newIndex = 0;
        string[] newSequence = new string[str.Length - 1];
        for (int i = 0; i < str.Length; i++) {
            if (i != index) {
                newSequence[newIndex] = str[i];
                newIndex++;
            }
        }

        return newSequence;
    }


    private bool CheckSafety(string[] sequence) {
        bool safe = false;
         int safeCount = 0;
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
                safe = true;
            }

        return safe;
    }
}
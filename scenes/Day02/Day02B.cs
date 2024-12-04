using System;
using System.Collections.Generic;
using System.IO;
using Godot;
using Microsoft.Win32.SafeHandles;

namespace Day02;

public class Day02B {

    public void ComputeDay02B(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day02\\day02a.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int safeTotal = 0;

        foreach(string line in results) {
            string[] sequence = line.Split(' ');
            if(IsAscending(sequence) && IsSafe(sequence)) { safeTotal++; }
            else if (IsDescending(sequence) && IsSafe(sequence)) { safeTotal++; }
            else if (TryRemoval(sequence)) { safeTotal++; }
        }
        GD.Print("Grand total Day 2 part 2: " + safeTotal);
    }

    public bool IsAscending(string[] sequence) {
        bool ascending = true;

        for(int i = 0; i < sequence.Length - 1; i++) {
            int curr = int.Parse(sequence[i]);
            int next = int.Parse(sequence[i+1]);
            if (curr > next) { ascending = false; }
        }

        return ascending;
    }

    public bool IsDescending(string[] sequence) {
        bool descending = true;

        for(int i = 0; i < sequence.Length - 1; i++) {
            int curr = int.Parse(sequence[i]);
            int next = int.Parse(sequence[i+1]);
            if (curr < next) { descending = false; }
        }

        return descending;
    }

    public bool IsSafe(string[] sequence) {
        bool safe = true;

         for(int i = 0; i < sequence.Length - 1; i++) {
            int curr = int.Parse(sequence[i]);
            int next = int.Parse(sequence[i+1]);
            if (Math.Abs(curr - next) < 1 || Math.Abs(curr - next) > 3) { safe = false; }
        }

        return safe;
    }

    private bool TryRemoval(string[] sequence) {
        bool safe = false;

        for(int i = 0; i < sequence.Length; i++) {
            string[] testSequence = RemoveElement(sequence, i);
            if(IsAscending(testSequence) && IsSafe(testSequence)) { safe = true; }
            else if (IsDescending(testSequence) && IsSafe(testSequence)) { safe = true; }
        }

        return safe;
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
}
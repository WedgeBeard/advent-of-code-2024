
using System;
using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day07;

public class Day07B {
    public void ComputeDay07B(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day07\\day07atest.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);
        
        List<string> permutations = new List<string>(); 
        GeneratePermutations("", 6, permutations); 
        GD.Print("All permutations of length 6:"); 
        foreach (var permutation in permutations) { 
            GD.Print(permutation); 
        }
        GD.Print("Day 07 Part 2: ");
    }

    private void GeneratePermutations(string prefix, int length, List<string> permutations)
    {
        if (length == 0) { 
            permutations.Add(prefix); 
            return; 
        } 
        
        GeneratePermutations(prefix + "+", length - 1, permutations); 
        GeneratePermutations(prefix + "*", length - 1, permutations);
    }
}
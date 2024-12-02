using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day02;

public class Day02B {

    public void ComputeDay02B(string directory) {
        string filePath = Path.Combine(directory, "scenes\\Day02\\day02btest.txt");
        List<string> results = utils.FileReader.ToStringList(filePath);
        int total = 0;


        GD.Print("Grand total Day 2 part 2: " + total);
    }
}
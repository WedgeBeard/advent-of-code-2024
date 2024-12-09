using Godot;
using System;
using System.Collections.Generic;
using System.IO;

namespace Day05;

public class Day05A
{
	public void ComputeDay05A(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day05\\day05atest.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);

		GD.Print($"Day 05 part 1: ");
	}
}

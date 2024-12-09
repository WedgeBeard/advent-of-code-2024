using System.Collections.Generic;
using System.IO;
using Godot;

namespace Day04;

public class Day04B
{
	public void ComputeDay04B(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day04\\day04a.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);

		int maxRows = fileStrings.Count - 1;
		int maxCols = fileStrings[0].Length - 1;
		char match = 'A';
		int total = 0;

		for (int currRow = 1; currRow < maxRows; currRow++) {
			for (int currCol = 1; currCol < maxCols; currCol++) {
				if (fileStrings[currRow][currCol] == match) {
					char upLeft = fileStrings[currRow - 1][currCol - 1];
					char upRight = fileStrings[currRow - 1][currCol + 1];
					char downLeft = fileStrings[currRow + 1][currCol - 1];
					char downRight = fileStrings[currRow + 1][currCol + 1];
					if (((upLeft == 'M' && downRight == 'S') || (upLeft == 'S' && downRight == 'M')) &&
						((upRight == 'M' && downLeft == 'S') || (upRight == 'S' && downLeft == 'M'))) {
							total++;
					}
				}
			}
		}
		GD.Print("Day 4 part 2 total: " + total);
	}
}

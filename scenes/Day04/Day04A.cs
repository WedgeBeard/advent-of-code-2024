using Godot;
using System;
using System.Collections.Generic;
using System.IO;

namespace Day04;
// 2410 - too low
// 2454 - got it

public class Day04A
{
	public void ComputeDay04A(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day04\\day04a.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);

		int maxRows = fileStrings.Count;
		int maxCols = fileStrings[0].Length;
		string searchString = "XMAS";
		int searchStringSize = searchString.Length;
		int total = 0;
		
		for (int row = 0; row < maxRows; row++) {
			for (int col = 0; col < maxCols; col++) {
				string firstSearchLetter = searchString[0].ToString();
				string currentLetter = fileStrings[row][col].ToString();
				if (firstSearchLetter == currentLetter) {
					total += CheckUp(searchString, row, col, searchStringSize, fileStrings); // 2 X
					total += CheckUpRight(searchString, row, col, maxCols, searchStringSize, fileStrings); // 4 X
					total += CheckRight(searchString, row, col, maxCols, searchStringSize, fileStrings); // 3 X
					total += CheckDownRight(searchString, row, col, maxRows, maxCols, searchStringSize, fileStrings); // 1 X
					total += CheckDown(searchString, row, col, maxRows, searchStringSize, fileStrings); // 1 X
					total += CheckDownLeft(searchString, row, col, maxRows, searchStringSize, fileStrings); // 1 X
					total += CheckLeft(searchString, row, col, searchStringSize, fileStrings); // 2
					total += CheckUpLeft(searchString, row, col, searchStringSize, fileStrings); // 4
				}
			}
		}

		GD.Print($"Day 4 part 1 total: {total}");
	}

    private int CheckUpLeft(string searchString, int row, int col, int size, List<string> fileStrings)
    {
		string test = "";
		if (row >= size - 1 && col >= size - 1) {
			int currCol = col;
			for (int currRow = row; currRow > row - size; currRow--) {
				test += fileStrings[currRow][currCol].ToString();
				currCol--;
			}
			if (test == searchString) { return 1; }
		} 
		else { return 0; }
		return 0;
    }

    private int CheckLeft(string searchString, int row, int col, int size, List<string> fileStrings)
    {
        string test = "";
		if (col >= size - 1) {
			for (int currCol = col; currCol > col - size; currCol--) {
				test += fileStrings[row][currCol].ToString();
			}
			if (test == searchString) { return 1; }
		} 
		else { return 0; }
		return 0;
    }

    private int CheckDownLeft(string searchString, int row, int col, int maxRows, int size, List<string> fileStrings)
    {
       string test = "";
		if(row <= maxRows - size && col >= size - 1) {
			int currCol = col;
			for (int currRow = row; currRow < row + size; currRow++) {
				test += fileStrings[currRow][currCol].ToString();
				currCol--;
			}
			if (test == searchString) { return 1; }
			else { return 0; }
		}
		return 0;
    }

    private int CheckDown(string searchString, int row, int col, int maxRows, int size, List<string> fileStrings)
    {
		string test = "";
		if(row <= maxRows - size) {
			for (int index = row; index < row + size; index++) {
				test += fileStrings[index][col].ToString();
			}
			if (test == searchString) { return 1; }
			else { return 0; }
		}
		return 0;
    }

    private int CheckDownRight(string searchString, int row, int col, int maxRows, int maxCols, int size, List<string> fileStrings)
    {
        string test = "";
		if(row <= maxRows - size && col <= maxCols - size) {
			int currCol = col;
			for (int index = row; index < row + size; index++) {
				test += fileStrings[index][currCol].ToString();
				currCol++;
			}
			if (test == searchString) { return 1; }
			else { return 0; }
		}
		return 0;
    }

    private int CheckRight(string searchString, int row, int col, int maxCols, int size, List<string> fileStrings)
    {
		string test = "";
		if (col <= maxCols - size) {
			for (int currCol = col; currCol < col + size; currCol++) {
				test += fileStrings[row][currCol].ToString();
			}
			if (test == searchString) { return 1; }
		} 
		else { return 0; }
		return 0;
    }

    private int CheckUpRight(string searchString, int row, int col, int maxCols, int size, List<string> fileStrings)
    {
		string test = "";
		if (row >= size - 1 && col <= maxCols - size) {
			int currCol = col;
			for (int currRow = row; currRow > row - size; currRow--) {
				test += fileStrings[currRow][currCol].ToString();
				currCol++;
			}
			if (test == searchString) { return 1; }
		} 
		else { return 0; }
		return 0;
    }

    private int CheckUp(string searchString, int row, int col, int size, List<string> fileStrings)
    {
		string test = "";
		if (row >= size - 1) {
			for (int index = row; index > row - size; index--) {
				test += fileStrings[index][col].ToString();
			}
			if (test == searchString) { return 1; }
		} 
		else { return 0; }
		return 0;
    }
}

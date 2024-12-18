using Godot;
using System;
using utils;
using System.Collections.Generic;
using System.IO;

namespace Day06;

public class Day06A
{
	public void ComputeDay06A(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day06\\day06atest.txt");
		int maxRows = 0;
		int maxCols = 0;
		char[,] grid = utils.FileReader.To2dCharArray(filePath, ref maxRows, ref maxCols);

		List<Pair> direction = new List<Pair> {
			new Pair (-1, 0),	// up
			new Pair (0, 1),	// right
			new Pair (1, 0),	// down
			new Pair (0, -1)	// left
		};
		
		int dirIndex = 0;

		Pair currPos = GetStartingPosition(grid, maxRows, maxCols);
		grid[currPos.row, currPos.col] = 'X';

		bool outOfBounds = false;
		while (!outOfBounds) {
			int nextRow = currPos.row + direction[dirIndex].row;
			int nextCol = currPos.col + direction[dirIndex].col;
			Pair nextPos = new Pair(nextRow, nextCol);
			// GD.Print($"Looking at {nextPos.row},{nextPos.col}");
			if (nextPos.row >= maxRows ||
					nextPos.row < 0 ||
					nextPos.col >= maxCols ||
					nextPos.col < 0) {
				// GD.Print("LEAVING AREA");
				outOfBounds = true;
			}
			else if (grid[nextPos.row,nextPos.col] == '#') {
				dirIndex = (dirIndex > direction.Count - 2) ? 0 : dirIndex + 1;
				// GD.Print($"TURN @ {currPos.row}, {currPos.col}");
			}
			else if (grid[nextPos.row,nextPos.col] == '.' || 
			grid[nextPos.row,nextPos.col] == 'X') {
				currPos.row = nextPos.row;
				currPos.col = nextPos.col;
				grid[currPos.row, currPos.col] = 'X';
				// GD.Print($"Leaving X @ {currPos.row},{currPos.col}");
			}
		}
		
		// print grid
		string finishedGrid = "";
		for (int i = 0; i < maxRows; i++) {
			for (int j = 0; j <maxCols; j++) {
				finishedGrid += grid[i, j];
			}
			GD.Print(finishedGrid);
			finishedGrid = "";
		}

		// total grid
		int total = 0;
		for (int i = 0; i < maxRows; i++) {
			for (int j = 0; j <maxCols; j++) {
				if (grid[i, j] == 'X') {
					total++;
				}
			}
		}

		GD.Print($"Day 06 part 1: {total}");
	}

    private Pair GetStartingPosition(char[,] grid, int maxRows, int maxCols)
    {
        for (int i = 0; i < maxRows; i++) {
			for (int j = 0; j < maxCols; j++) {
				if (grid[i,j] == '^') {
					return new Pair(i, j);
				}
			}
		}
		return new Pair(-1, -1);;
    }

}

using Godot;
using System;
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

		List<Vector2> directions = new List<Vector2>{
			new Vector2 (0, -1),
			new Vector2 (0, 1),
			new Vector2 (1, 0),
			new Vector2 (-1, 0)
		};
		int directionIndex = 0;

		Vector2 currPos = GetStartingPosition(grid, maxRows, maxCols);
		bool outOfBounds = false;
		while (!outOfBounds) {
			// Vector2 nextPos = new Vector2 (currPos[0] + directions[directionIndex][0], currPos[1] + directions[directionIndex][1]);
			int nextRow = currPos[0] + directions[directionIndex][0];
			int nextRow = currPos[1] + directions[directionIndex][1];
			// if (grid[nextPos[0],nextPos[1]]) {

			// }
		}
		
		GD.Print($"Day 06 part 1: ");
	}

    private Vector2 GetStartingPosition(char[,] grid, int maxRows, int maxCols)
    {
        for (int i = 0; i < maxRows; i++) {
			for (int j = 0; j < maxCols; j++) {
				if (grid[i,j] == '^') {
					return new Vector2(i, j);
				}
			}
		}
		return Vector2.Zero;
    }

}

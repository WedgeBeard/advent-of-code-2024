using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using utils;

namespace Day06;

public class Day06B
{
	public void ComputeDay06B(string directory)
    {
        string filePath = Path.Combine(directory, "scenes\\Day06\\day06a.txt");
        int maxRows = 0;
        int maxCols = 0;
        char[,] originalGrid = utils.FileReader.To2dCharArray(filePath, ref maxRows, ref maxCols);
        char[,] grid = new char[maxRows, maxCols];
        Array.Copy(originalGrid, grid, originalGrid.Length);

        List<Pair> direction = new List<Pair> {
            new Pair (-1, 0),	// up
			new Pair (0, 1),	// right
			new Pair (1, 0),	// down
			new Pair (0, -1)	// left
		};

        int dirIndex = 0;
        int loops = 0;
        Pair startPos = GetStartingPosition(grid, maxRows, maxCols);
        Pair currPos = new Pair(startPos.row, startPos.col);
        grid[currPos.row, currPos.col] = '.';

        HashSet<Pair> possibleBlockNodes = GetTraversedNodes(maxRows, maxCols, grid, direction, dirIndex, currPos);

        foreach(Pair pair in possibleBlockNodes) {
            char[,] testGrid = new char[maxRows, maxCols];
            Array.Copy(grid, testGrid, originalGrid.Length);
            testGrid[pair.row, pair.col] = '#';
            Pair startPosCopy = new Pair(startPos);
            if (CheckForLoop(testGrid, maxRows, maxCols, direction, dirIndex, startPosCopy)) {
                loops++;
            }
        }
 
        GD.Print($"Day 06 part 1: {loops}");
    }

    private bool CheckForLoop(char[,] testGrid, int maxRows, int maxCols, List<Pair> direction, int dirIndex, Pair currPos)
    {
        bool outOfBounds = false;
        Dictionary<Pair, List<int>> collisions = new Dictionary<Pair, List<int>>();
        while (!outOfBounds)
        {
            int nextRow = currPos.row + direction[dirIndex].row;
            int nextCol = currPos.col + direction[dirIndex].col;
            Pair nextPos = new Pair(nextRow, nextCol);
            if (nextPos.row >= maxRows ||
                    nextPos.row < 0 ||
                    nextPos.col >= maxCols ||
                    nextPos.col < 0) {
                outOfBounds = true;
            }
            else if (testGrid[nextPos.row, nextPos.col] == '#') {
                if (collisions.ContainsKey(nextPos) && collisions[nextPos].Contains(dirIndex)) {
                    return true;
                } else if (collisions.ContainsKey(nextPos)) {
                    collisions[nextPos].Add(dirIndex);
                } else {
                    collisions.Add(nextPos, new List<int>{dirIndex});
                }
                dirIndex = (dirIndex > direction.Count - 2) ? 0 : dirIndex + 1;
            } else if (testGrid[nextPos.row,nextPos.col] == '.') {
				currPos.row = nextPos.row;
				currPos.col = nextPos.col;
            }
        }
        return false;
    }

    private HashSet<Pair> GetTraversedNodes(int maxRows, int maxCols, char[,] grid, 
									List<Pair> direction, int dirIndex, Pair currPos)
    {
		HashSet<Pair> traversed = new HashSet<Pair>();
        Pair startPos = new Pair(currPos.row, currPos.col);
        bool outOfBounds = false;
        while (!outOfBounds)
        {
            int nextRow = currPos.row + direction[dirIndex].row;
            int nextCol = currPos.col + direction[dirIndex].col;
            Pair nextPos = new Pair(nextRow, nextCol);
            if (nextPos.row >= maxRows ||
                    nextPos.row < 0 ||
                    nextPos.col >= maxCols ||
                    nextPos.col < 0) {
                outOfBounds = true;
            }
            else if (grid[nextPos.row, nextPos.col] == '#') {
                dirIndex = (dirIndex > direction.Count - 2) ? 0 : dirIndex + 1;
            }
            else if (grid[nextPos.row, nextPos.col] == '.' || 
                    grid[nextPos.row, nextPos.col] == 'X') {
                currPos.row = nextPos.row;
                currPos.col = nextPos.col;
                if (!traversed.Contains(new Pair(currPos.row, currPos.col))) {
                    traversed.Add(new Pair(currPos.row, currPos.col));
                }
            }
        }
        traversed.Remove(startPos);
		return traversed;
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

using Godot;
using System.Collections.Generic;
using System.IO;
using utils;

namespace Day06;

public class Day06B
{
	public void ComputeDay06B(string directory)
    {
        string filePath = Path.Combine(directory, "scenes\\Day06\\day06atest.txt");
        int maxRows = 0;
        int maxCols = 0;
        char[,] originalGrid = utils.FileReader.To2dCharArray(filePath, ref maxRows, ref maxCols);
        char[,] grid = originalGrid;

        List<Pair> direction = new List<Pair> {
            new Pair (-1, 0),	// up
			new Pair (0, 1),	// right
			new Pair (1, 0),	// down
			new Pair (0, -1)	// left
		};

        int dirIndex = 0;

        Pair startPos = GetStartingPosition(grid, maxRows, maxCols);
        Pair currPos = startPos;
        grid[currPos.row, currPos.col] = 'X';

        Dictionary<Pair, int> traversed = CreateTraversedGrid(maxRows, maxCols, grid, direction, dirIndex, currPos);

        // remove start position - not included in possibilities for obstacle
        if (traversed.ContainsKey(startPos)) { traversed.Remove(startPos); }

        PrintGrid(maxRows, maxCols, grid);
        int total = AccumulateTotal(maxRows, maxCols, grid);

        GD.Print($"Day 06 part 1: {total}");
    }

    private Dictionary<Pair, int> CreateTraversedGrid(int maxRows, int maxCols, char[,] grid, 
									List<Pair> direction, int dirIndex, Pair currPos)
    {
		Dictionary<Pair, int> traversed = new Dictionary<Pair, int>();
        bool outOfBounds = false;
        while (!outOfBounds)
        {
            int nextRow = currPos.row + direction[dirIndex].row;
            int nextCol = currPos.col + direction[dirIndex].col;
            Pair nextPos = new Pair(nextRow, nextCol);
            // GD.Print($"Looking at {nextPos.row},{nextPos.col}");
            if (nextPos.row >= maxRows ||
                    nextPos.row < 0 ||
                    nextPos.col >= maxCols ||
                    nextPos.col < 0)
            {
                // GD.Print("LEAVING AREA");
                outOfBounds = true;
            }
            else if (grid[nextPos.row, nextPos.col] == '#')
            {
                dirIndex = (dirIndex > direction.Count - 2) ? 0 : dirIndex + 1;
                // when you hit a wall and change direction, record that wall
                // position and where it was hit from. if it happens again, you
                // are repeating the loop

                // GD.Print($"TURN @ {currPos.row}, {currPos.col}");
            }
            else if (grid[nextPos.row, nextPos.col] == '.' ||
            grid[nextPos.row, nextPos.col] == 'X')
            {
                currPos.row = nextPos.row;
                currPos.col = nextPos.col;
                grid[currPos.row, currPos.col] = 'X';
                traversed.TryAdd(currPos, 0);
                // GD.Print($"Leaving X @ {currPos.row},{currPos.col}");
            }
        }
		return traversed;
    }

    private static int AccumulateTotal(int maxRows, int maxCols, char[,] grid)
    {
        int total = 0;
        for (int i = 0; i < maxRows; i++)
        {
            for (int j = 0; j < maxCols; j++)
            {
                if (grid[i, j] == 'X')
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static void PrintGrid(int maxRows, int maxCols, char[,] grid)
    {
        string finishedGrid = "";
        for (int i = 0; i < maxRows; i++)
        {
            for (int j = 0; j < maxCols; j++)
            {
                finishedGrid += grid[i, j];
            }
            GD.Print(finishedGrid);
            finishedGrid = "";
        }
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

using System;

namespace utils;

public class Pair {
    private Pair startPos;


    public int row { get; set; }
    public int col { get; set; }

    public Pair(int n1, int n2) {
        row = n1;
        col = n2;
    }

    public Pair(Pair copyPair)
    {
        this.row = copyPair.row;
        this.col = copyPair.col;
    }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        Pair other = (Pair)obj;
        return row == other.row && col == other.col;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(row, col);
    }
}
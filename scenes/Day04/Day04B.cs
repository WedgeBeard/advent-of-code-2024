using System.Collections.Generic;
using System.IO;

namespace Day04;

public class Day04B
{
	public void ComputeDay04B(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day04\\day04a.txt");
        List<string> fileStrings = utils.FileReader.ToStringList(filePath);

		int maxRows = fileStrings.Count;
		int maxCols = fileStrings[0].Length;
		char match = 'A';

	}
}

using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Day05;

public class Day05A
{
	public void ComputeDay05A(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day05\\day05atest.txt");
		List<Vector2I> rules = new List<Vector2I>();
		List<List<int>> pages = new List<List<int>>();
        utils.FileReader.GetRulesAndPages(filePath, ref rules, ref pages);
		
		GD.Print("RULES:");
		foreach(Vector2I rule in rules) {
			GD.Print(rule);
		}

		GD.Print("PAGES:");
		foreach(List<int> pagesList in pages) {
			
			GD.Print("NEW GROUP");
			if(PageOrderCorrect(pagesList, rules)) {
				// get middle page, add it to total
			}
		}

		GD.Print($"Day 05 part 1: ");
	}

    private bool PageOrderCorrect(List<int> pagesList, List<Vector2I> rules)
    {
        bool ordered = false;

        for (int i = 0; i < pagesList.Count; i++)
        {
            int page = pagesList[i];
            // find matching rules for it
            	// for each rule 

        }

		return ordered;
    }
}

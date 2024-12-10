using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Day05;

public class Day05A
{
	public void ComputeDay05A(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day05\\day05a.txt");
		List<Vector2I> rules = new List<Vector2I>();
		List<List<int>> pages = new List<List<int>>();
        utils.FileReader.GetRulesAndPages(filePath, ref rules, ref pages);
		int total = 0;

		foreach(List<int> pagesList in pages) {
			if(PageOrderCorrect(pagesList, rules)) {
				total += pagesList[pagesList.Count/2];
			}
		}

		GD.Print($"Day 05 part 1: {total}");
	}

    private bool PageOrderCorrect(List<int> listOfPages, List<Vector2I> rules)
    {
        bool ordered = true;

        for (int pageIndex = 0; pageIndex < listOfPages.Count; pageIndex++)
        {
            int page = listOfPages[pageIndex];
			foreach (Vector2I rule in rules) {
				if (page == rule[0] && ComesBefore(listOfPages, pageIndex, rule[1])) {
					return false;
				} else if (page == rule[1] && ComesAfter(listOfPages, pageIndex, rule[0])) {
					return false;
				} 
			}
        }
		return ordered;
    }

    private bool ComesAfter(List<int> listOfPages, int pageIndex, int laterPage)
    {
    	int page = listOfPages[pageIndex];
		for (int i = pageIndex +1; i < listOfPages.Count; i++) {
			if (listOfPages[i] == laterPage) {
				return true;
			}
	   	}
	   return false;
    }

	private  bool ComesBefore(List<int> listOfPages, int pageIndex, int earlierPage) {
		int page = listOfPages[pageIndex];
		for (int i = pageIndex -1; i >= 0; i--) {
			if (listOfPages[i] == earlierPage) {
				return true;
			}
	   	}
		return false;
	}
}

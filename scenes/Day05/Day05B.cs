using Godot;
using System;
using System.Collections.Generic;
using System.IO;

namespace Day05;

public class Day05B
{
	public void ComputeDay05B(string directory) {
		string filePath = Path.Combine(directory, "scenes\\Day05\\day05a.txt");
		List<Vector2I> rules = new List<Vector2I>();
		List<List<int>> pages = new List<List<int>>();
        utils.FileReader.GetRulesAndPages(filePath, ref rules, ref pages);
		int total = 0;

		foreach(List<int> pagesList in pages) {
			List<int> currPagesList = pagesList;
			bool swapped = false;
			while (!PageOrderCorrect(currPagesList, rules)) {
				SwapOutOfOrderPages(ref currPagesList, rules);
				swapped = true;
			}
			if (swapped) { total += currPagesList[currPagesList.Count/2]; }
		}

		GD.Print($"Day 05 part 2: {total}");
	}

    private void SwapOutOfOrderPages(ref List<int> listOfPages, List<Vector2I> rules)
    {
        for (int pageIndex = 0; pageIndex < listOfPages.Count; pageIndex++)
        {
            int page = listOfPages[pageIndex];
			foreach (Vector2I rule in rules) {
				int beforeIndex = ComesBefore(listOfPages, pageIndex, rule[1]);
				int afterIndex = ComesAfter(listOfPages, pageIndex, rule[0]);
				if (page == rule[0] && beforeIndex >= 0) {
					int temp = listOfPages[pageIndex];
					listOfPages[pageIndex] = rule[1];
					listOfPages[beforeIndex] = temp;
				} else if (page == rule[1] && afterIndex >= 0) {
					int temp = listOfPages[pageIndex];
					listOfPages[pageIndex] = rule[0];
					listOfPages[afterIndex] = temp;
				}
			}
        }
    }

    private bool PageOrderCorrect(List<int> listOfPages, List<Vector2I> rules)
    {
        bool ordered = true;

        for (int pageIndex = 0; pageIndex < listOfPages.Count; pageIndex++)
        {
            int page = listOfPages[pageIndex];
			foreach (Vector2I rule in rules) {
				if (page == rule[0] && ComesBefore(listOfPages, pageIndex, rule[1]) >= 0) {
					return false;
				} else if (page == rule[1] && ComesAfter(listOfPages, pageIndex, rule[0]) >= 0) {
					return false;
				} 
			}
        }
		return ordered;
    }

    private int ComesAfter(List<int> listOfPages, int pageIndex, int laterPage)
    {
    	int page = listOfPages[pageIndex];
		for (int i = pageIndex +1; i < listOfPages.Count; i++) {
			if (listOfPages[i] == laterPage) {
				return i;
			}
	   	}
	   return -1;
    }

	private int ComesBefore(List<int> listOfPages, int pageIndex, int earlierPage) {
		int page = listOfPages[pageIndex];
		for (int i = pageIndex -1; i >= 0; i--) {
			if (listOfPages[i] == earlierPage) {
				return i;
			}
	   	}
		return -1;
	}
}

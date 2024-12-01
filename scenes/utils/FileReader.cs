using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Godot;

namespace utils;

public static class FileReader {

    public static string directory = AppDomain.CurrentDomain.BaseDirectory;

    public static List<string> ToStringList(string filePath) {
        List<string> results = File.ReadAllLines(filePath).ToList<string>();
        return results;
    }

}
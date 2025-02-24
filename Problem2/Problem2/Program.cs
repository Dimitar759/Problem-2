using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\dimit\OneDrive\Documents\GitHub\Problem-2\";

        List<string> txtFiles = new List<string>();
        GetTxtFiles(directoryPath, txtFiles);

        foreach (var file in txtFiles)
        {
            AppendTextToFile(file, "ASPEKT");
        }
    }

    static void GetTxtFiles(string directoryPath, List<string> txtFiles)
    {
        try
        {
            string[] files = Directory.GetFiles(directoryPath, "*.txt");
            txtFiles.AddRange(files);

            string[] subdirectories = Directory.GetDirectories(directoryPath);
            foreach (string subdirectory in subdirectories)
            {
                GetTxtFiles(subdirectory, txtFiles);
            }
        }
        catch (UnauthorizedAccessException)
        {
            // To just skiop
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing {directoryPath}: {ex.Message}");
        }
    }

    static void AppendTextToFile(string filePath, string textToAppend)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(textToAppend);
            }
            Console.WriteLine($"Successfully appended to: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to {filePath}: {ex.Message}");
        }
    }
}

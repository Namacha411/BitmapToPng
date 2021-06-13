using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace bmp2png
{
    class Program
    {
        static void Main(string[] args)
        {
			var path = args[0];
			var bpmFiles = GetDirList(path);

            // files check
			Console.WriteLine($"\n{path}'s BPM are ...");
			foreach (var bpmFile in bpmFiles) {
				Console.WriteLine($"{bpmFile}");
			}

            // convert
			Console.WriteLine("Convert Start.");
			foreach (var bpmFile in bpmFiles) {
				BpmSaveAsPng(bpmFile);
			}

			Console.WriteLine("Finished!");
		}

        private static void BpmSaveAsPng(string bpmPath) {
			var bitmap = new Bitmap(bpmPath);
			var filename = $@"{Path.GetDirectoryName(bpmPath)}\{Path.GetFileNameWithoutExtension(bpmPath)}.png";
            if (File.Exists(filename)) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Error.WriteLine($"{filename} is already exist.");
				Console.ResetColor();
				return;
			}
			bitmap.Save(filename, ImageFormat.Png);
            Console.WriteLine($"{Path.GetFileNameWithoutExtension(filename)} Converted");
		}

        private static List<String> GetDirList(string path) {
			var directoryInfo = new DirectoryInfo(path);
			var files = directoryInfo.GetFiles();
			return files
				.Select(file => file.FullName)
				.Where(name => Path.GetExtension(name) is ".bmp" or ".BMP")
				.ToList();
		}
    }
}

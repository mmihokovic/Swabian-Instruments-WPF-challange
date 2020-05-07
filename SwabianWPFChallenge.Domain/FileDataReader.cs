using System;
using System.Collections.Generic;
using System.IO;

namespace SwabianWPFChallenge.Domain
{
    public class FileDataReader: IDataSource
    {
        private readonly List<Point> points;

        public FileDataReader(string filename)
        {
            points = LoadData(filename);
        }

        public List<Point> GetPoints => points;

        private List<Point> LoadData(string fileLocation)
        {
            var textData = File.ReadAllText(fileLocation);
            var lines = textData.Split(System.Environment.NewLine);

            var points = new List<Point>();

            foreach(var line in lines)
            {
                try
                {
                    var splittedLine = line.Split(';');
                    var point = new Point(splittedLine[0], splittedLine[1]);
                    points.Add(point);
                }
                catch(Exception e)
                {
                    throw new Exception("Error parsing input data", e);
                }
            }
            return points;
        }
    }
}

using SwabianWPFChallenge.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SwabianWPFChallenge
{
    public static class DataReader
    {
        public List<Point> LoadData(string fileLocation)
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

                }
            }
            return points;
        }
    }
}

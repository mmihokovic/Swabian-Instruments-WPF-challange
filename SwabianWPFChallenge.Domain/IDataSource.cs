using System;
using System.Collections.Generic;
using System.Text;

namespace SwabianWPFChallenge.Domain
{
    public interface IDataSource
    {
        List<Point> GetPoints { get; }
    }
}

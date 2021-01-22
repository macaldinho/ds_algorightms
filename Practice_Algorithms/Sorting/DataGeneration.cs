using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace Sorting
{
    public static class DataGeneration
    {
        private static readonly Fixture Fixture = new Fixture();

        public static IList<int> GetData(int count)
        {
            return Fixture.CreateMany<int>(count).ToList();
        }
    }
}
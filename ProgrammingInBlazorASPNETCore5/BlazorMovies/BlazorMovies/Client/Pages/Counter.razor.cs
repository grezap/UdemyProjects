using MathNet.Numerics.Statistics;
using System;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        public void IncrementCount()
        {
            var array = new double[] { 1, 2, 3, 4, 5 };
            var max = array.Maximum();
            var min = array.Minimum();

            Console.WriteLine($"Min: {min}, Max: {max}");

            currentCount++;
        }

    }
}

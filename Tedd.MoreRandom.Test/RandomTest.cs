using System;
using Xunit;

namespace Tedd.MoreRandom.Test
{
    public class RandomTest
    {
        private Tedd.MoreRandom.Random _trueRandom = new Tedd.MoreRandom.Random();
        private System.Random _systemRandom = new System.Random();
        private const int TestIterations = 10000000;

        [Fact]
        public void NextDouble()
        {
            decimal accumulated = 0;
            for (int i = 0; i < TestIterations; i++)
            {
                accumulated+= (decimal)_trueRandom.NextDouble();
            }
            accumulated /= TestIterations;

            // We expect average of high amount of random numbers to be close to 0.5D.
            Assert.True(Math.Abs((double)accumulated - 0.5D) < 0.01D);
        }

        [InlineData(1)]
        [InlineData(3)]
        [InlineData(177)]
        [Theory]
        public void NextBytes(int size)
        {
            decimal accumulated = 0;
            
            for (int i = 0; i < TestIterations; i++)
            {
                var buffer = new byte[size];
                _trueRandom.NextBytes(buffer);

                ulong t = 0;
                foreach (var b in buffer)
                {
                    t += b;
                }

                accumulated += (decimal)t / (decimal)size;
            }
            accumulated /= TestIterations;

            // We expect average of high amount of random numbers to be close to 127.5D.
            Assert.True(Math.Abs((double)accumulated - 127.5D) < 0.01D);
        }

    }
}

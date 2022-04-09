using DanceTask;
using System;
using Xunit;

namespace DanceTaskTests
{
    public class LatinoTests
    {
        [Fact]
        public void DanceMove_CallingMethod_ReturnString()
        {
            // arrange
            Latino latino = new Latino();
            string result = "Latino dance.";

            // act
            string action = latino.DanceMove();

            // assert
            Assert.Equal(result, action);
        }
    }
    public class RockTests
    {
        [Fact]
        public void DanceMove_CallingMethod_ReturnString()
        {
            // arrange
            Rock rock = new Rock();
            string result = "Rock dance.";

            // act
            string action = rock.DanceMove();

            // assert
            Assert.Equal(result, action);
        }
    }

    public class HardbassTests
    {
        [Fact]
        public void DanceMove_CallingMethod_ReturnString()
        {
            // arrange
            Hardbass hardbass = new Hardbass();
            string result = "Elbow dance.";

            // act
            string action = hardbass.DanceMove();

            // assert
            Assert.Equal(result, action);
        }
    }
}

using System;
using TheSpacePort;
using Xunit;

namespace TheSpaceport.Tests
{
    public class SpacePortTest
    {
        [Fact]
        public void getPersonFromApi_LukeSkywalker_True()
        {
            API api = new API();
            var person = api.GetPerson("Luke Skywalker");

            Assert.NotNull(person);
        }

        [Fact]
        public void getPersonFromApi_LukeSkywalker_True()
        {
            API api = new API();
            var person = api.GetPerson("Luke Skywalker");

            Assert.NotNull(person);
        }
    }
}

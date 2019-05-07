using NUnit.Framework;
using System;
using RoadLibrary;

namespace Tests
{
    class RoadTests
    {
        // Method_Scenario_ExpectedResult

        [Test]
        public void Road_ElementWithSpaces_SpacesDeleted()
        {
            var roadToCheck = new Road("  Пункт 1  ", "  Пункт 2  ");
            var expected = new Road("Пункт 1", "Пункт 2");

            if (roadToCheck.From != expected.From || roadToCheck.To != expected.To)
                Assert.Fail();
        }

        [Test]
        public void Road_ElementWithEmpryFromField_ThrowException()
        {
            var expected = new Exception("Element's From property can't be empty");
            var result = Assert.Throws<Exception>(() => new Road("", "Пункт 2"));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }

        [Test]
        public void Road_ElementWithEmpryToField_ThrowException()
        {
            var expected = new Exception("Element's To property can't be empty");
            var result = Assert.Throws<Exception>(() => new Road("Пункт 1", ""));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }
    }
}

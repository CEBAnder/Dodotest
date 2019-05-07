using NUnit.Framework;
using System;
using System.Collections.Generic;
using RoadLibrary;

namespace Tests
{
    public class RoadBuilderTests
    {
        // Method_Scenario_ExpectedResult

        [Test]
        public void Sort_OneElement_ThrowException()
        {
            var setupList = Road.GenerateRoadList(new Road("����� 1", "����� 2"));
            var expected = new Exception("Nothing to sort here");
            var result = Assert.Throws<Exception>(() => RoadBuilder.Sort(setupList));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }

        [Test]
        public void Sort_EmptyList_ThrowException()
        {
            var setupList = new List<Road>();
            var expected = new Exception("Nothing to sort here");
            var result = Assert.Throws<Exception>(() => RoadBuilder.Sort(setupList));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }

        [Test]
        public void Sort_UnsortedListWithBreak_ThrowException()
        {
            var setupList = Road.GenerateRoadList(new Road("������������", "���������"),
                                                  new Road("������������", "�������������"));
            var expected = new Exception("Input data had circle or break");
            var result = Assert.Throws<Exception>(() => RoadBuilder.Sort(setupList));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }

        [Test]
        public void Sort_UnsortedListWithCycle_ThrowException()
        {
            var setupList = Road.GenerateRoadList(new Road("������������", "���������"),
                                                  new Road("������������", "�������������"),
                                                  new Road("���������", "������������"),
                                                  new Road("���������", "��������� ����"));
            var expected = new Exception("Input data had circle or break");
            var result = Assert.Throws<Exception>(() => RoadBuilder.Sort(setupList));

            Assert.That(expected.Message, Is.EqualTo(result.Message));
        }

        [Test]
        public void Sort_UnsortedShortList_SortList()
        {
            var setupList = Road.GenerateRoadList(new Road("������������", "���������"),
                                                  new Road("������������", "�������������"),
                                                  new Road("���������", "������������"));
            var expected = Road.GenerateRoadList(new Road("������������", "���������"),
                                                 new Road("���������", "������������"),
                                                 new Road("������������", "�������������"));
            var result = RoadBuilder.Sort(setupList);

            CompareTwoRoadLists(expected, result);
        }

        [Test]
        public void Sort_UnsortedLongList_SortList()
        {
            var setupList = Road.GenerateRoadList(new Road("����� 1", "����� 5"),
                                                  new Road("����� 2", "����� 8"),
                                                  new Road("����� 3", "����� 2"),
                                                  new Road("����� 4", "����� 9"),
                                                  new Road("����� 5", "����� 7"),
                                                  new Road("����� 6", "����� 3"),
                                                  new Road("����� 7", "����� 4"),
                                                  new Road("����� 9", "����� 6"));
            var expected = Road.GenerateRoadList(new Road("����� 1", "����� 5"),
                                                 new Road("����� 5", "����� 7"),
                                                 new Road("����� 7", "����� 4"),
                                                 new Road("����� 4", "����� 9"),
                                                 new Road("����� 9", "����� 6"),
                                                 new Road("����� 6", "����� 3"),
                                                 new Road("����� 3", "����� 2"),
                                                 new Road("����� 2", "����� 8"));
            var result = RoadBuilder.Sort(setupList);

            CompareTwoRoadLists(expected, result);
        }

        /// <summary>
        /// Compares two lists of Road elements
        /// </summary>
        /// <param name="firstList">First list to compare</param>
        /// <param name="secondList">Second list to compare</param>
        private static void CompareTwoRoadLists(List<Road> firstList, List<Road> secondList)
        {
            // Lists are not equal if the have diffrent element count
            if (firstList.Count != secondList.Count)
                Assert.Fail();

            // Compare elements property values and not their refs
            for (int i = 0; i < firstList.Count; i++)
            {
                if ((firstList[i].From != secondList[i].From) || (firstList[i].To != secondList[i].To))
                    Assert.Fail();
            }
        }
    }
}
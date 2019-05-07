using System;
using System.Collections.Generic;

namespace RoadLibrary
{
    public class RoadBuilder
    {
        /// <summary>
        /// Sorts list of Road elements
        /// </summary>
        /// <param name="unsortedRoad">List to sort</param>
        /// <returns>Retutns list of elements sorted in From -> To order</returns>
        public static List<Road> Sort(List<Road> unsortedRoad)
        {
            // No need to sort empty list or list with just one element
            if (unsortedRoad.Count < 2)
                throw new Exception("Nothing to sort here");

            var sortedRoad = new List<Road>();
            // Get list's first element as starting point
            MoveFromUnsortedToSorted(ref unsortedRoad, 0, ref sortedRoad, 0);

            string sortedFrom = GetSortedFrom(ref sortedRoad);
            string sortedTo = GetSortedTo(ref sortedRoad);

            // Keep joining new elements until unsorted list is empty
            while (unsortedRoad.Count != 0)
            {
                for (int i = 0; i < unsortedRoad.Count; i++)
                {
                    // If element's To property equals sorted list From value join it at the beginning of list 
                    if (unsortedRoad[i].To == sortedFrom)
                    {
                        MoveFromUnsortedToSorted(ref unsortedRoad, i, ref sortedRoad, 0);
                        sortedFrom = GetSortedFrom(ref sortedRoad);
                        continue;
                    }
                    // if element's From property equals sorted list To value join it at the end of list
                    if (unsortedRoad[i].From == sortedTo)
                    {
                        MoveFromUnsortedToSorted(ref unsortedRoad, i, ref sortedRoad, sortedRoad.Count);
                        sortedTo = GetSortedTo(ref sortedRoad);
                        continue;
                    }
                    // We got some incorrect data if some elements can't be joined
                    if (i == unsortedRoad.Count - 1)
                        throw new Exception("Input data had circle or break");
                }
            }
            return sortedRoad;
        }

        /// <summary>
        /// Moves element from unsorted list to sorted one
        /// </summary>
        /// <param name="unsortedList">List to get element from</param>
        /// <param name="unsortedPos">Position of element, which must be inserted into sorted list</param>
        /// <param name="sortedList">List to insert new element</param>
        /// <param name="sortedPos">Position of element to insert from unsorted list</param>
        private static void MoveFromUnsortedToSorted(ref List<Road> unsortedList, int unsortedPos, ref List<Road> sortedList, int sortedPos)
        {
            sortedList.Insert(sortedPos, unsortedList[unsortedPos]);
            unsortedList.RemoveAt(unsortedPos);
        }

        /// <summary>
        /// Get road's beginning
        /// </summary>
        /// <param name="sortedList">List to find beginning</param>
        /// <returns>Returns list's first element's From property value</returns>
        private static string GetSortedFrom(ref List<Road> sortedList)
        {
            return sortedList[0].From;
        }

        /// <summary>
        /// Get road's destination
        /// </summary>
        /// <param name="sortedList">List to find destination</param>
        /// <returns>Returns list's last element's To property value</returns>
        private static string GetSortedTo(ref List<Road> sortedList)
        {
            return sortedList[sortedList.Count - 1].To;
        }
    }
}

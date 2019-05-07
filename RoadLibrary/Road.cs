using System;
using System.Collections.Generic;

namespace RoadLibrary
{
    public class Road
    {
        private string _from;
        private string _to;

        /// <summary>
        /// The From property represents road's starting point.
        /// </summary>
        /// <value>The From property has value of _from field with deleted spaces</value>
        /// <exception cref="System.Exception">Thrown when user tries to save empty value</exception>
        public string From
        {
            get { return _from; }
            set
            {
                if (value.Length != 0)
                    _from = value.Trim();
                else
                    throw new Exception("Element's From property can't be empty");
            }
        }

        /// <summary>
        /// The To property represents road's destination point.
        /// </summary>
        /// <value>The To property has value of _to field with deleted spaces</value>
        /// <exception cref="System.Exception">Thrown when user tries to save empty value</exception>
        public string To
        {
            get { return _to; }
            set
            {
                if (value.Length != 0)
                    _to = value.Trim();
                else
                    throw new Exception("Element's To property can't be empty");
            }
        }

        /// <summary>
        /// Simple Road class constructor
        /// </summary>
        /// <param name="from">Value that will become object's From property</param>
        /// <param name="to">Value that will become object's To property</param>
        public Road(string from, string to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Creates list of Road elements
        /// </summary>
        /// <param name="ArrayOfRoads">Array of Road </param>
        /// <returns>Returns linked list with Road elements</returns>
        public static List<Road> GenerateRoadList(params Road[] ArrayOfRoads)
        {
            var result = new List<Road>();
            foreach (var elem in ArrayOfRoads)
            {
                result.Add(elem);
            }
            return result;
        }
    }
}

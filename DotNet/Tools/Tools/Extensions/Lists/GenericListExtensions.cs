using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Extensions.Lists
{
    public static class GenericListExtensions
    {
        /// <summary>
        /// Returns the first item in the list or the default value.
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list"></param>
        /// <param name="value">The default value</param>
        /// <param name="expersion">An optional search expression.</param>
        /// <returns></returns>
        public static T FirstOrValue<T>(this List<T> list, T value, Func<T, bool> expersion = null)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (list == null)
                return value;

            var first = expersion == null ? list.FirstOrDefault() : list.FirstOrDefault(expersion);

            if (first == null)
                return value;

            return first;
        }
        
        public static bool In<T>(this T item, params T[] values)
        {
            return values.Contains(item);
        }

        public static bool In<T>(this T item, IEnumerable<T> values)
        {
            return values.Contains(item);
        }
        
        public static void InsertRange<T>(this List<T> target, int startingIndex, List<T> source)
	{
            for(var i = source.Count() - 1; i > -1; i--)
            {
                target.Insert(startingIndex, source[i]);
            }
	}
    }
}

/* Copyright 2021 Timothy Beckett
 * * * * * * * * * * * * * * * * */

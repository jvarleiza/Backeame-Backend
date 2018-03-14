﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Magic.Helpers
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// True if IEnumerable is not empty or null.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) return false;
            return source.Any();
        }

        /// <summary>
        /// True if IEnumerable is empty or null.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) return true;
            return (source.Any() == false);
        }

        /// <summary>
        /// Safe count objects in IEnumerable. If null then count is 0.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int SafeCount<TSource>(this IEnumerable<TSource> source)
        {
            return source.IsEmpty() ? 0 : source.Count();
        }
    }
}

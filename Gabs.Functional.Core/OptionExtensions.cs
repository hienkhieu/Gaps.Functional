using System;
using System.Collections.Generic;
using System.Linq;

namespace Gabs.Functional.Core
{
    public static class OptionExtensions
    {
        public static Option<T> Map<T>(this Option<T> o, Func<T, T> func) => Option<T>.Of(func(o.Get()));
        public static IEnumerable<Option<T>> Map<T>(this IEnumerable<Option<T>> o, Func<T, T> func)
            => o.Select(x => x.Map(func));
    }
}
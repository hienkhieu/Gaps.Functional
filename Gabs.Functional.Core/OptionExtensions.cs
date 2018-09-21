using System;
using System.Collections.Generic;
using System.Linq;

namespace Gabs.Functional.Core
{
    public static class OptionExtensions
    {
        public static Option<R> Map<T, R>(this Option<T> o, Func<T, R> func) => Option<R>.Of(func(o.Get()));
        public static IEnumerable<Option<R>> Map<T, R>(this IEnumerable<Option<T>> o, Func<T, R> func)
            => o.Select(x => x.Map(func));
        public static void Do<T>(this Option<T> o, Action<T> action) => action(o.Get());
        public static Option<R> Bind<T, R>(this Option<T> o, Func<T, Option<R>> func) => func(o.Get());
        public static IEnumerable<Option<R>> Bind<T, R>(this IEnumerable<T> o, Func<T, Option<R>> func)
            => o.Select(x => func(x));
        public static Option<T> Where<T>(this Option<T> o, Func<T, bool> func)
            => func(o.Get()) ? Option<T>.Of(o.Get()) : Option<T>.Of(default(T));
        public static IEnumerable<Option<T>> Where<T>(this IEnumerable<Option<T>> o, Func<T, bool> func)
            => o.Where(x => func(x.Get()));
    }
}
using System;

namespace Gabs.Functional.Core
{
    public class Option<T>
    {
        private readonly T value;
        public bool HasValue { get; }

        public Option(T value)
        {
            this.value = value;
            this.HasValue = value != null;
        }

        public static Option<T> Of(T value) => new Option<T>(value);

        public T Get() => value;

        public static implicit operator Option<T>(T value) => new Option<T>(value);
    }
}
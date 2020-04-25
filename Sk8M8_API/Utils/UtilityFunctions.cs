using System;

namespace Sk8M8_API.Utils
{
    public static class UtilityFunctions
    {
        public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1, Func<T, TReturn1> func2)
        {
            return x => func1(func2(x));
        }
    }
}

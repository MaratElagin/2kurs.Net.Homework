using System;
using System.Collections.Generic;

namespace WebApplicationLearn.MyHtmlServices
{
    public static class IntTypes
    {
        private static readonly HashSet<Type> IntegerTypes = new()
        {
            typeof(int),
            typeof(uint),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(long),
            typeof(ulong)
        };

        public static bool IsIntegerType(this Type type) =>
            IntegerTypes.Contains(type) || IntegerTypes.Contains(Nullable.GetUnderlyingType(type));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Helpers
{
    public static class EnumHelpers
    {
        public static T Parse<T>(string enumType) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            T value;
            if (!(Enum.TryParse(enumType, true, out value) && Enum.IsDefined(typeof(T), value)))
                throw new ArgumentOutOfRangeException(enumType);

            return value;
        }

        public static bool TryParse<T>(string enumType, out T value, bool ignoreCase = true) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.TryParse(enumType, ignoreCase, out value) && Enum.IsDefined(typeof(T), value);
        }

        public static bool TryParse<T>(int enumValue, out T value) where T : struct, IConvertible
        {
            value = default(T);

            if (!typeof(T).IsEnum)
                return false;

            var success = Enum.IsDefined(typeof(T), enumValue);

            if (success)
            {
                value = (T)Enum.ToObject(typeof(T), enumValue);
            }

            return success;
        }
    }
}

/* Copyright 2021 Timothy Beckett
 * * * * * * * * * * * * * * * * */

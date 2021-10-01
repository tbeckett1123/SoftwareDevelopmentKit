using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Helpers;

namespace Tools.Extensions.Enums
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string inputValue) where T : struct, IConvertible => EnumHelpers.TryParse(inputValue, out T outputValue) ? outputValue : throw new Exception($"Could not parse value {inputValue} to enum {typeof(T).Name}");

        public static T ToEnum<T>(this int inputValue) where T : struct, IConvertible => EnumHelpers.TryParse(inputValue, out T outputValue) ? outputValue : throw new Exception($"Could not parse value {inputValue} to enum {typeof(T).Name}");
    }
}

/* Copyright 2021 Timothy Beckett
 * * * * * * * * * * * * * * * * */

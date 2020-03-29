using System;

    public static class ArrayExtensions
    {
        public static T[] Add<T>(this T[] array, params T[] add)
        {
            for (int i = 0; i < add.Length; i++)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = add[i];
            }
            return array;
        }
    }


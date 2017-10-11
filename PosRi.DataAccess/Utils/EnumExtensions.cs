using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PosRi.DataAccess.Utils
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription<TEnum>(this TEnum item) where TEnum : struct
        {
            var descriptionAttr = item.GetType()
                .GetField(item.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();
            return descriptionAttr == null ? string.Empty : descriptionAttr.Description;
        }

        public static void SeedEnumValues<T, TEnum>(this IDbSet<T> dbSet, Func<TEnum, T> converter) where T : class
        {
            Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(v => converter((TEnum)v))
                .ToList()
                .ForEach(instance => dbSet.AddOrUpdate(instance));
        }
    }
}

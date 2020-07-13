using System;

namespace ProjectControl.Core.PrismUtilities
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependentViewAttribute : Attribute
    {
        public DependentViewAttribute(string region, Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Region = region ?? throw new ArgumentNullException(nameof(region));
            Type = type;
        }

        public string Region { get; set; }

        public Type Type { get; set; }
    }
}
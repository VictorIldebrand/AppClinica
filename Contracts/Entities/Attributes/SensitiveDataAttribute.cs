using System;

namespace Contracts.Entities.Attributes {
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SensitiveDataAttribute : Attribute
    {
    }
}

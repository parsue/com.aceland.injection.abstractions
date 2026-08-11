using System;

namespace AceLand.Injection
{
    /// <summary>Marks a constructor, field, property, method or parameter as an injection point.</summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Method | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public sealed class InjectAttribute : Attribute
    {
        /// <summary>Do not throw when the dependency is missing (value stays null/default).</summary>
        public bool Optional { get; set; }

        /// <summary>Disambiguates several registrations of the same contract.</summary>
        public object Id { get; set; }
    }
}
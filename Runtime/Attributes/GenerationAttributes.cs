// GenerationAttributes.cs
using System;

namespace AceLand.Injection
{
    /// <summary>Generate an injector plan even when the type has no [Inject] members
    /// (e.g. plain constructor injection).</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class InjectableAttribute : Attribute { }

    /// <summary>Skip code generation for this type (always use reflection).</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class NoInjectorAttribute : Attribute { }

    /// <summary>[assembly: GenerateInjectorFor(typeof(SomeTypeInThisAssembly))]</summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class GenerateInjectorForAttribute : Attribute
    {
        public Type Type { get; }
        public GenerateInjectorForAttribute(Type type) => Type = type;
    }
}
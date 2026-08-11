using System;

namespace AceLand.Injection
{
    public enum DependencyKind { Constructor, Field, Property, MethodParameter, Component }

    public readonly struct InjectDependency
    {
        public readonly Type ContractType;
        public readonly object Id;
        public readonly bool Optional;
        public readonly DependencyKind Kind;
        public readonly string MemberName;
        public readonly ComponentSource ComponentSource;

        public InjectDependency(Type contractType, DependencyKind kind, string memberName,
                                bool optional = false, object id = null,
                                ComponentSource componentSource = ComponentSource.Self)
        {
            ContractType = contractType; Kind = kind; MemberName = memberName;
            Optional = optional; Id = id; ComponentSource = componentSource;
        }
    }

    /// <summary>Compiled injection plan produced by AceLand.Injection.SourceGenerator.</summary>
    public interface IInjectorPlan
    {
        Type TargetType { get; }
        bool CanCreateInstance { get; }
        bool HasMultipleConstructors { get; }
        InjectDependency[] Dependencies { get; }

        object CreateInstance(IObjectResolver resolver, object[] extraArgs);
        void Inject(object instance, IObjectResolver resolver);
    }
}
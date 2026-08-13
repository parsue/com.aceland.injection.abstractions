using System;
using System.Collections.Generic;

namespace AceLand.Injection
{
    public enum RegistrationKind
    {
        Type,       // Register<TContract, TImpl>()
        Instance,   // RegisterInstance()
        Factory,    // RegisterFactory() — contents are opaque
        Container   // the container's self-binding
    }

    public readonly struct RegistrationInfo
    {
        /// <summary>Stable identity within a session. Use it as a graph node key.</summary>
        public readonly int Serial;
        public readonly Type[] ContractTypes;
        public readonly Type ImplementationType;
        public readonly Lifetime Lifetime;
        public readonly object Id;
        public readonly RegistrationKind Kind;
        public readonly bool IsInstantiated;
        public readonly InstallerInfo? Source;

        public RegistrationInfo(int serial, Type[] contracts, Type implementation, Lifetime lifetime,
                                object id, RegistrationKind kind, bool isInstantiated, InstallerInfo? source)
        {
            Serial = serial; ContractTypes = contracts; ImplementationType = implementation;
            Lifetime = lifetime; Id = id; Kind = kind; IsInstantiated = isInstantiated;
            Source = source;
        }

        public string DisplayName =>
            ImplementationType != null ? TypeNames.Short(ImplementationType)
            : ContractTypes != null && ContractTypes.Length > 0 ? TypeNames.Short(ContractTypes[0])
            : "?";
    }

    /// <summary>Read-only view of a container, for tooling. Never used during resolution.</summary>
    public interface IContainerIntrospection
    {
        string Label { get; }
        int Depth { get; }
        IObjectResolver ParentResolver { get; }

        /// <summary>Registrations declared on this container only — not inherited.</summary>
        IReadOnlyList<RegistrationInfo> LocalRegistrations { get; }

        /// <summary>Which registration, on which container, would satisfy the request.</summary>
        bool TryDescribeResolution(Type contract, object id,
                                   out RegistrationInfo info, out IObjectResolver owner);
        
        /// <summary>Installers that contributed to this container, in execution order.</summary>
        IReadOnlyList<InstallerInfo> Installers { get; }
    }
    
    public readonly struct InstallerInfo
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly object Asset;        // MonoInstaller / ScriptableObjectInstaller, untyped
        public readonly int Ordinal;         // position in this container's installer list

        public InstallerInfo(string name, Type type, object asset, int ordinal)
        {
            Name = name; Type = type; Asset = asset; Ordinal = ordinal;
        }

        /// <summary>Stable within a container — survives rescans, unique per instance.</summary>
        public string Key => Ordinal + ":" + (Type?.FullName ?? Name ?? "?");
    }
}
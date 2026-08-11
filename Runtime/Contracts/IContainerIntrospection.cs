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

        public RegistrationInfo(int serial, Type[] contracts, Type implementation, Lifetime lifetime,
                                object id, RegistrationKind kind, bool isInstantiated)
        {
            Serial = serial; ContractTypes = contracts; ImplementationType = implementation;
            Lifetime = lifetime; Id = id; Kind = kind; IsInstantiated = isInstantiated;
        }

        public string DisplayName =>
            ImplementationType != null ? ImplementationType.Name
            : ContractTypes is { Length: > 0 } ? ContractTypes[0].Name
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
    }
}
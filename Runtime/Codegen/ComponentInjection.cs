using System;

namespace AceLand.Injection
{
    /// <summary>
    /// Indirection so generated code (and abstraction-only assemblies) can perform
    /// [Self]/[Parent]/[Child]/[FromScene]/[AddComponent] lookups without referencing the runtime.
    /// AceLand.Injection sets <see cref="Resolver"/> at load time.
    /// </summary>
    public static class ComponentInjection
    {
        public delegate object ResolveDelegate(object owner, ComponentSource source, Type memberType,
                                               bool optional, bool includeInactive, string memberName);

        public static ResolveDelegate Resolver;

        public static object Resolve(object owner, ComponentSource source, Type memberType,
                                     bool optional, bool includeInactive, string memberName)
        {
            var r = Resolver;
            if (r == null)
                throw new InjectionException(
                    "Component injection requires the 'com.aceland.injection' runtime package " +
                    "(only the Abstractions package is installed).");
            return r(owner, source, memberType, optional, includeInactive, memberName);
        }
    }
}
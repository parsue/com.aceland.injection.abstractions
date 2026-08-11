using System;

namespace AceLand.Injection
{
    /// <summary>
    /// Weak link between abstraction-only packages and the AceLand.Injection runtime.
    /// If the runtime package is absent, everything degrades to false/null instead of throwing.
    /// </summary>
    public static class InjectionBridge
    {
        static Func<IObjectResolver> _provider;

        public static bool IsAvailable => _provider != null;

        public static IObjectResolver Global
        {
            get
            {
                var r = _provider?.Invoke();
                return r is { IsDisposed: false } ? r : null;
            }
        }

        /// <summary>Called by AceLand.Injection at startup. Not for game code.</summary>
        public static void SetGlobalProvider(Func<IObjectResolver> provider) => _provider = provider;

        public static bool TryResolve<T>(out T instance, object id = null)
        {
            var g = Global;
            if (g != null) return g.TryResolve(out instance, id);
            instance = default;
            return false;
        }

        public static bool TryInject(object target)
        {
            var g = Global;
            if (g == null || target == null) return false;
            g.Inject(target);
            return true;
        }
    }
}
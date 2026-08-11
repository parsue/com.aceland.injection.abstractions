using System;

namespace AceLand.Injection
{
    public static class InjectorPlanUtil
    {
        public static T Required<T>(IObjectResolver r, string owner, string member, object id = null)
        {
            if (r.TryResolve<T>(out var value, id)) return value;
            throw new InjectionException(
                $"Cannot inject '{owner}.{member}': {typeof(T).Name}" +
                (id != null ? $" #{id}" : "") + " is not registered.");
        }

        public static T Optional<T>(IObjectResolver r, object id = null)
            => r.TryResolve<T>(out var value, id) ? value : default;

        public static object PickExtra(object[] extraArgs, Type type)
        {
            if (extraArgs == null) return null;
            foreach (var t in extraArgs)
                if (t != null && type.IsInstanceOfType(t)) return t;

            return null;
        }

        public static T Arg<T>(IObjectResolver r, object[] extraArgs, string owner, string member, object id = null)
        {
            var extra = PickExtra(extraArgs, typeof(T));
            return extra != null ? (T)extra : Required<T>(r, owner, member, id);
        }
    }
}
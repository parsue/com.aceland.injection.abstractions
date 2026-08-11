using System;

namespace AceLand.Injection
{
    /// <summary>Runtime face of a container. Fully usable from plain C# — no Unity types involved.</summary>
    public interface IObjectResolver : IDisposable
    {
        bool IsDisposed { get; }

        object Resolve(Type contract, object id = null);
        T Resolve<T>(object id = null);
        bool TryResolve(Type contract, out object instance, object id = null);
        bool TryResolve<T>(out T instance, object id = null);
        bool CanResolve(Type contract, object id = null);

        /// <summary>Member + method injection into an existing object
        /// (POCO, MonoBehaviour, ScriptableObject, editor window...).</summary>
        void Inject(object instance);

        /// <summary>Constructs an unregistered type, resolving its constructor parameters.
        /// Values in <paramref name="extraArgs"/> win by assignable type.</summary>
        object CreateInstance(Type type, params object[] extraArgs);
        T CreateInstance<T>(params object[] extraArgs);

        IObjectResolver CreateScope(Action<IContainerBuilder> configure = null);
    }
}
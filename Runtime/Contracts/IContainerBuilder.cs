// IContainerBuilder.cs
using System;

namespace AceLand.Injection
{
    public interface IContainerBuilder
    {
        IRegistrationBuilder Register(Type implementationType, Lifetime lifetime);
        IRegistrationBuilder RegisterInstance(Type contractType, object instance, bool ownsInstance = false);
        IRegistrationBuilder RegisterFactory(Type contractType, Func<IResolver, object> factory, Lifetime lifetime);

        void AddEntryPoint(Type type);
        void RegisterBuildCallback(Action<IResolver> callback);
        void AddFallbackResolver(IExternalResolver resolver);

        bool Contains(Type contract, object id = null, bool includeParent = true);
    }
}
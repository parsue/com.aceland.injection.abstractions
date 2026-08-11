// IExternalResolver.cs
using System;

namespace AceLand.Injection
{
    /// <summary>Bridges a foreign container/service locator into resolution.</summary>
    public interface IExternalResolver
    {
        bool TryResolve(Type contract, object id, out object instance);
    }

    public sealed class ServiceProviderResolver : IExternalResolver
    {
        readonly IServiceProvider _provider;
        public ServiceProviderResolver(IServiceProvider provider) => _provider = provider;

        public bool TryResolve(Type contract, object id, out object instance)
        {
            instance = id == null ? _provider.GetService(contract) : null;
            return instance != null;
        }
    }
}
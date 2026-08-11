using System;

namespace AceLand.Injection
{
    public interface IObjectPool<T> : IDisposable
    {
        int CountInactive { get; }
        int CountActive { get; }

        T Rent();
        /// <summary>using (pool.Rent(out var item)) { ... }</summary>
        PooledObject<T> Rent(out T item);
        void Return(T item);
        void Prewarm(int count);
        void Clear();
    }
}
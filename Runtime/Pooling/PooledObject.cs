using System;

namespace AceLand.Injection
{
    public readonly struct PooledObject<T> : IDisposable
    {
        readonly T _value;
        readonly IObjectPool<T> _pool;
        public PooledObject(T value, IObjectPool<T> pool) { _value = value; _pool = pool; }
        public T Value => _value;
        public void Dispose() => _pool?.Return(_value);
    }
}
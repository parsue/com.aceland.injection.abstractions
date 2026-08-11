using System;

namespace AceLand.Injection
{
    public class InjectionException : Exception
    {
        public InjectionException(string message) : base(message) { }
        public InjectionException(string message, Exception inner) : base(message, inner) { }
    }
}
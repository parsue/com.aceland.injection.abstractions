// IRegistrationBuilder.cs
using System;

namespace AceLand.Injection
{
    public interface IRegistrationBuilder
    {
        Type ImplementationType { get; }

        IRegistrationBuilder As(Type contract);
        IRegistrationBuilder AsSelf();
        IRegistrationBuilder AsImplementedInterfaces();
        IRegistrationBuilder WithId(object id);

        // --- explicit plan: for types you cannot annotate (3rd-party / external packages) ---
        IRegistrationBuilder UsingConstructor(params Type[] parameterTypes);
        IRegistrationBuilder WithParameter(string name, object value);
        IRegistrationBuilder WithParameter(string name, Func<IObjectResolver, object> factory);
        IRegistrationBuilder WithParameter(Type parameterType, object value);
        IRegistrationBuilder WithParameter(Type parameterType, Func<IObjectResolver, object> factory);
        IRegistrationBuilder InjectMember(string name, object value = null, bool optional = false);
        IRegistrationBuilder InjectMember(string name, Func<IObjectResolver, object> factory, bool optional = false);
        IRegistrationBuilder InvokeMethod(string name, params object[] explicitArgs);
        IRegistrationBuilder IgnoreAttributes();

        IRegistrationBuilder OnActivated(Action<IObjectResolver, object> callback);
    }
}
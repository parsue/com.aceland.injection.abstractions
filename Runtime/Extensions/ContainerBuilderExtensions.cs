using System;

namespace AceLand.Injection
{
    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder Register<TImpl>(this IContainerBuilder b, Lifetime lifetime)
            => b.Register(typeof(TImpl), lifetime).AsSelf();

        public static IRegistrationBuilder Register<TContract, TImpl>(this IContainerBuilder b, Lifetime lifetime)
            where TImpl : TContract
            => b.Register(typeof(TImpl), lifetime).As(typeof(TContract));

        public static IRegistrationBuilder RegisterInstance<T>(this IContainerBuilder b, T instance,
                                                               bool ownsInstance = false)
            => b.RegisterInstance(typeof(T), instance, ownsInstance);

        public static IRegistrationBuilder RegisterFactory<T>(this IContainerBuilder b,
                                                              Func<IObjectResolver, T> factory, Lifetime lifetime)
            => b.RegisterFactory(typeof(T), r => factory(r), lifetime);

        public static IRegistrationBuilder RegisterEntryPoint<T>(this IContainerBuilder b)
        {
            b.RegisterEntryPoint(typeof(T));
            return b.Register(typeof(T), Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }

        /// <summary>Register only if nothing else already provides the contract — the polite way for packages.</summary>
        public static IRegistrationBuilder RegisterIfMissing<TContract, TImpl>(this IContainerBuilder b,
                                                                               Lifetime lifetime)
            where TImpl : TContract
            => b.Contains(typeof(TContract)) ? null : b.Register(typeof(TImpl), lifetime).As(typeof(TContract));

        public static IRegistrationBuilder RegisterIfMissing<T>(this IContainerBuilder b, Lifetime lifetime)
            => b.Contains(typeof(T)) ? null : b.Register(typeof(T), lifetime).AsSelf();

        // null-safe chaining (so RegisterIfMissing(...).As<X>() is legal)
        public static IRegistrationBuilder As<T>(this IRegistrationBuilder r) => r?.As(typeof(T));
        public static IRegistrationBuilder WithParameter<T>(this IRegistrationBuilder r, T value)
            => r?.WithParameter(typeof(T), value);
    }
}
// InstallerAttributes.cs
using System;

namespace AceLand.Injection
{
    /// <summary>Marks an IGlobalInstaller for automatic discovery.</summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AutoInstallAttribute : Attribute
    {
        public int Order { get; }
        public AutoInstallAttribute(int order = 0) => Order = order;
    }

    /// <summary>[assembly: InjectionInstaller(typeof(MyInstaller), -100)]</summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class InjectionInstallerAttribute : Attribute
    {
        public Type InstallerType { get; }
        public int Order { get; }
        public InjectionInstallerAttribute(Type installerType, int order = 0)
        { InstallerType = installerType; Order = order; }
    }
}
// IInstaller.cs
namespace AceLand.Injection
{
    public interface IInstaller { void Install(IContainerBuilder builder); }

    /// <summary>Installer for the process-wide container. Mark with [AutoInstall] for
    /// automatic discovery, or declare [assembly: InjectionInstaller(typeof(X))].</summary>
    public interface IGlobalInstaller : IInstaller { }
}
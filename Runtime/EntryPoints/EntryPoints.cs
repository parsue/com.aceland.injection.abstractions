using System.Threading;
using System.Threading.Tasks;

namespace AceLand.Injection
{
    public interface IInitializable { void Initialize(); }
    public interface ITickable      { void Tick(); }
    public interface IFixedTickable { void FixedTick(); }
    public interface ILateTickable  { void LateTick(); }

    /// <summary>
    /// Async startup driven by plain System.Threading.Tasks (no UniTask required).
    /// Awaited on the Unity main thread: continuations resume on the main thread because
    /// Unity installs a SynchronizationContext there.
    /// The token is cancelled when the owning scope is disposed / the app quits.
    /// </summary>
    public interface IAsyncStartable
    {
        Task StartAsync(CancellationToken cancellationToken);
    }

    /// <summary>Ordering hint for entry points (lower runs first). Default 0.</summary>
    public interface IOrderedEntryPoint { int Order { get; } }
}
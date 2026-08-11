namespace AceLand.Injection
{
    public enum Lifetime
    {
        /// <summary>New instance on every resolve.</summary>
        Transient,
        /// <summary>One instance per resolving scope.</summary>
        Scoped,
        /// <summary>One instance shared by the owning container and all children.</summary>
        Singleton
    }
}
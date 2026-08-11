using System;

namespace AceLand.Injection
{
    public enum ComponentSource { Self, Parent, Child, Scene, AddComponent }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
    public abstract class ComponentInjectAttribute : Attribute
    {
        public bool Optional { get; set; }
        public bool IncludeInactive { get; set; } = true;
        public abstract ComponentSource Source { get; }
    }

    /// <summary>GetComponent on the same GameObject.</summary>
    public sealed class SelfAttribute : ComponentInjectAttribute
    { public override ComponentSource Source => ComponentSource.Self; }

    /// <summary>GetComponentInParent (includes self).</summary>
    public sealed class ParentAttribute : ComponentInjectAttribute
    { public override ComponentSource Source => ComponentSource.Parent; }

    /// <summary>GetComponentInChildren (includes self).</summary>
    public sealed class ChildAttribute : ComponentInjectAttribute
    { public override ComponentSource Source => ComponentSource.Child; }

    /// <summary>FindObjectOfType / FindObjectsOfType.</summary>
    public sealed class FromSceneAttribute : ComponentInjectAttribute
    { public override ComponentSource Source => ComponentSource.Scene; }

    /// <summary>GetComponent, or AddComponent when missing.</summary>
    public sealed class AddComponentAttribute : ComponentInjectAttribute
    { public override ComponentSource Source => ComponentSource.AddComponent; }
}
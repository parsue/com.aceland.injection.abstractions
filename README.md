# AceLand Injection Abstractions

Attributes and interfaces for AceLand Injection — no container, no engine dependency, ~15 KB.

## What Is This

Reference this package from libraries and service packages that want to *declare* their
dependency-injection surface (attributes, entry points, installers) **without** taking a
dependency on the full runtime. It contains only contracts:

- `[Inject]`, `[Self]`, `[Parent]`, `[Child]`, `[FromScene]`, `[AddComponent]` attributes
- `IObjectResolver`, `IContainerBuilder`, `IRegistrationBuilder`, `IInstaller` / `IGlobalInstaller`
- Entry-point interfaces: `IInitializable`, `ITickable`, `IFixedTickable`, `ILateTickable`, `IAsyncStartable`
- `InjectionBridge` — a soft link that returns `null`/`false` when the runtime is absent

If the `com.aceland.injection` runtime is installed, everything is wired automatically.
If it is not, code that only references the abstractions still compiles and degrades safely.

## Documents

We use GitBook as the public documentation for our packages.

> Visit our [GitBook](https://aceland-workshop.gitbook.io/aceland-unity-packages/)

Please visit our GitBook for details.

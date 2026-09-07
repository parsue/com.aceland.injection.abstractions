# AceLand Injection Abstractions

[![Sponsor](https://img.shields.io/badge/Sponsor-%E2%9D%A4-db61a2?logo=githubsponsors&logoColor=white)](https://github.com/sponsors/parsue)
[![Discord](https://img.shields.io/badge/Discord-Join-5865F2?logo=discord&logoColor=white)](https://discord.gg/XsCYGnYzuc)
[![Docs](https://img.shields.io/badge/Docs-GitBook-3884FF?logo=gitbook&logoColor=white)](https://docs.parsue.io/aceland-unity-packages)

Attributes and interfaces for **AceLand Injection** — no container, no engine dependency, ~15 KB.

## About AceLand Injection

[**AceLand Injection**](https://github.com/parsue/com.aceland.injection) is a lightweight,
zero-reflection dependency injection container for modern Unity. It uses a Roslyn
incremental generator to emit injector code at compile time (no reflection on the hot
path), exposes a single global container (`DI`) shared across packages, and validates the
object graph at build time. It targets the no-domain-reload / CoreCLR direction of Unity.

This package holds only the **contracts**. Reference it from libraries and service
packages that want to *declare* their DI surface — attributes, entry points, installers —
**without** taking a dependency on the full runtime.

## What Is This

It contains only contracts:

- `[Inject]`, `[Self]`, `[Parent]`, `[Child]`, `[FromScene]`, `[AddComponent]` attributes
- `IResolver`, `IContainerBuilder`, `IRegistrationBuilder`, `IInstaller` / `IGlobalInstaller`
- Entry-point interfaces: `IInitializable`, `ITickable`, `IFixedTickable`, `ILateTickable`, `IAsyncEntryPoint`
- `InjectionBridge` — a soft link that returns `null`/`false` when the runtime is absent

If the [`com.aceland.injection`](https://github.com/parsue/com.aceland.injection) runtime is
installed, everything is wired automatically. If it is not, code that only references the
abstractions still compiles and degrades safely.

## Documents

We use GitBook as the public documentation for our packages.

> Visit our [GitBook](https://docs.parsue.io/aceland-unity-packages)

Please visit our GitBook for details.

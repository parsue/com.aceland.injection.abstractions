# AceLand Injection Abstractions
Contracts-only companion for AceLand Injection.

## In One Line
Speak DI without dragging the whole container along.

## Documentation has moved

`com.aceland.injection.abstractions` is documented **together with the runtime** in the single
**AceLand Injection** GitBook space — both packages share the `AceLand.Injection` namespace, so
their docs live in one place.

Start here:

- **[AceLand Injection](../../com.aceland.injection/gitbook_doc~/README.md)** — overview, both
  package tables and the full documentation map.
- **[For Package Authors](../../com.aceland.injection/gitbook_doc~/for-package-authors.md)** — the
  contracts layer this package provides: `InjectionBridge`, `RegisterIfMissing`,
  `[assembly: InjectionInstaller]`, and how to depend on contracts only.

{% hint style="info" %}
Reference **this** package (contracts only) from a reusable library, and let the consuming
application reference the runtime `com.aceland.injection`. See
[For Package Authors](../../com.aceland.injection/gitbook_doc~/for-package-authors.md) for the full
pattern.
{% endhint %}

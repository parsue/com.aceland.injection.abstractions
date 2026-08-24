using System;
using System.Collections.Generic;

namespace AceLand.Injection
{
    /// <summary>
    /// Compile-time discovered global installers. Populated by generated module
    /// initializers so the runtime avoids a full-reflection assembly scan at cold start.
    /// </summary>
    public static class GlobalInstallerRegistry
    {
        public readonly struct Entry
        {
            public readonly Type InstallerType;
            public readonly int Order;
            public Entry(Type installerType, int order)
            {
                InstallerType = installerType;
                Order = order;
            }
        }

        private static readonly List<Entry> entries = new();
        private static readonly HashSet<Type> seen = new();
        private static readonly object sync = new();

        public static int Count { get { lock (sync) return entries.Count; } }

        /// <summary>Called from generated module initializers. Safe to call twice.</summary>
        public static void Register(Type installerType, int order = 0)
        {
            if (installerType == null) return;
            lock (sync)
            {
                if (!seen.Add(installerType)) return;   // dedupe
                entries.Add(new Entry(installerType, order));
            }
        }

        public static IEnumerable<Entry> All()
        {
            lock (sync) return new List<Entry>(entries);
        }
    }
}

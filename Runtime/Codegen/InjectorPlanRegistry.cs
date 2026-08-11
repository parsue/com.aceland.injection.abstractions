using System;
using System.Collections.Generic;

namespace AceLand.Injection
{
    public static class InjectorPlanRegistry
    {
        static readonly Dictionary<Type, IInjectorPlan> Plans = new Dictionary<Type, IInjectorPlan>();
        static readonly object Sync = new object();

        public static int Count { get { lock (Sync) return Plans.Count; } }

        /// <summary>Called from generated module initializers. Safe to call twice.</summary>
        public static void Register(IInjectorPlan plan)
        {
            if (plan?.TargetType == null) return;
            lock (Sync) Plans[plan.TargetType] = plan;
        }

        public static bool TryGet(Type type, out IInjectorPlan plan)
        {
            lock (Sync) return Plans.TryGetValue(type, out plan);
        }

        public static IEnumerable<IInjectorPlan> All()
        {
            lock (Sync) return new List<IInjectorPlan>(Plans.Values);
        }
    }
}
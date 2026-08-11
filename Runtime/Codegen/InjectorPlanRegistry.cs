using System;
using System.Collections.Generic;

namespace AceLand.Injection
{
    public static class InjectorPlanRegistry
    {
        private static readonly Dictionary<Type, IInjectorPlan> plans = new();
        private static readonly object sync = new();

        public static int Count { get { lock (sync) return plans.Count; } }

        /// <summary>Called from generated module initializers. Safe to call twice.</summary>
        public static void Register(IInjectorPlan plan)
        {
            if (plan?.TargetType == null) return;
            lock (sync) plans[plan.TargetType] = plan;
        }

        public static bool TryGet(Type type, out IInjectorPlan plan)
        {
            lock (sync) return plans.TryGetValue(type, out plan);
        }

        public static IEnumerable<IInjectorPlan> All()
        {
            lock (sync) return new List<IInjectorPlan>(plans.Values);
        }
    }
}
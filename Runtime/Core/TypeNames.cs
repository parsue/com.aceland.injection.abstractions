using System;
using System.Text;

namespace AceLand.Injection
{
    /// <summary>Readable type names for diagnostics and tooling.</summary>
    public static class TypeNames
    {
        /// <summary>IObjectPool&lt;Bullet&gt;</summary>
        public static string Short(Type type) => Build(type, false);

        /// <summary>AceLand.Injection.IObjectPool&lt;MyGame.Bullet&gt;</summary>
        public static string Full(Type type) => Build(type, true);

        static string Build(Type type, bool full)
        {
            if (type == null) return "null";

            if (type.IsArray)
            {
                var rank = type.GetArrayRank();
                return Build(type.GetElementType(), full) + "[" + new string(',', rank - 1) + "]";
            }

            if (type.IsByRef) return Build(type.GetElementType(), full);

            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null) return Build(nullable, full) + "?";

            var alias = Alias(type);
            if (alias != null) return alias;

            var name = StripArity(type.Name);

            if (type.DeclaringType != null)
                name = Build(type.DeclaringType, full) + "." + name;
            else if (full && !string.IsNullOrEmpty(type.Namespace))
                name = type.Namespace + "." + name;

            if (!type.IsGenericType) return name;

            var sb = new StringBuilder(name).Append('<');
            var args = type.GetGenericArguments();
            for (int i = 0; i < args.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(type.IsGenericTypeDefinition ? args[i].Name : Build(args[i], full));
            }
            return sb.Append('>').ToString();
        }

        static string StripArity(string name)
        {
            var tick = name.IndexOf('`');
            return tick > 0 ? name.Substring(0, tick) : name;
        }

        static string Alias(Type t)
        {
            if (t == typeof(int))    return "int";
            if (t == typeof(float))  return "float";
            if (t == typeof(bool))   return "bool";
            if (t == typeof(string)) return "string";
            if (t == typeof(long))   return "long";
            if (t == typeof(double)) return "double";
            if (t == typeof(byte))   return "byte";
            if (t == typeof(object)) return "object";
            return null;
        }
    }
}
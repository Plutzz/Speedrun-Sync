using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BossTrackerMod
{
    public class GlobalSettings
    {
        public bool SyncNailDamage = true;
        public bool SyncGrimmchildUpgrades = true;

        private static readonly Dictionary<string, FieldInfo> fields = typeof(GlobalSettings)
            .GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(f => f.FieldType == typeof(bool))
            .ToDictionary(f => f.Name, f => f);

        public bool GetFieldByName(string fieldName)
        {
            if (fields.TryGetValue(fieldName, out FieldInfo field))
            {
                return (bool)field.GetValue(this);
            }
            return false;
        }

        public Dictionary<string, bool> trackInteropPool = new();

        public bool AnyEnabled()
        {
            return fields.Keys.Any(f => GetFieldByName(f)) || trackInteropPool.Values.Any(interop => interop);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace UnityAsyncAwaitUtil
{
    public class VmManager
    {
        private static List<object> objs = new List<object>();
        
        public static void Add<T>(object obj)
        {
            objs.Add(obj);
        }

        public static T Get<T>()
        {
            return objs.OfType<T>().First();
        }
    }
}
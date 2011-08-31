using System;
using System.Web.Configuration;

namespace KirkChen.Library.Helper
{
    public class CacheHelper
    {
        static public object GetCache(string CacheId)
        {
            object objCache = System.Web.HttpRuntime.Cache.Get(CacheId);
            
            return objCache;
        }

        static public void SetCache(string CacheId, object objCache, TimeSpan timeout)
        {
            if (objCache != null)
            {
                System.Web.HttpRuntime.Cache.Insert(
                    CacheId,
                    objCache,
                    null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                    timeout,
                    System.Web.Caching.CacheItemPriority.High,
                    null);
            }
        }
    }
}

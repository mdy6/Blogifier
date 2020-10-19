using CVBuilder.Model;
using System.Collections.Generic;
using System.Linq;

namespace CVBuilder.HtmlBuilder
{
    public static class HtmlComponentHelper
    {
        public static IDictionary<int, IList<T>> Pager<T>(ZoneCollection collection, int pageLimit) where T : IZoneValue
        {
            var genericValues = collection.GetZoneObjectsByZone(Zone.Skills).ToList();
            var pager = new Dictionary<int, List<T>>();
            int page = 1;
            int iter = 0;
            var genericValueList = new List<T>();
            for (int i = 0; i < genericValues.Count; i++)
            {
                genericValueList.Add((T)genericValues[i].Value);
                if (iter == pageLimit)
                {
                    pager.Add(page, genericValueList);
                    iter = 0;
                    genericValueList = new List<T>();
                    page++;
                }
                else
                {
                    iter++;
                }
            }
            return (IDictionary<int, IList<T>>)pager;
        }
    }
}

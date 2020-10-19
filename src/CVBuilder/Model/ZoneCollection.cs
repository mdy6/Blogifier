using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CVBuilder.Model
{
    public class ZoneCollection
    {
        private IList<ZoneObject> zoneCollection = new List<ZoneObject>();

        private IdGenerator idGenerator = new IdGenerator();

        public int Count => zoneCollection.Count; 
        public ZoneCollection()
        {
        }

        public ZoneObject AddOrEdit(ZoneObject zoneObject)
        {
            if(zoneObject.Id> 0)
            {
                var index = zoneCollection.ToList().FindIndex(item => item.Id == zoneObject.Id);
                zoneCollection[index] = zoneObject;
                return zoneObject;
            }
            zoneObject.Id = idGenerator.Next; 
            zoneCollection.Add(zoneObject);
            return zoneObject;
        }

        public List<ZoneObject> GetZoneObjects => zoneCollection.ToList();

        public List<ZoneObject> GetZoneObjectsByZone(Zone zone)
        {
            return zoneCollection.Where(item => item.Zone == zone).OrderByDescending(item => item.UpdateDate).ToList();
        }

        public bool Delete(ZoneObject zoneObject)
        {
            return zoneCollection.Remove(zoneObject);
        }

    }
}
using CVBuilder.Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace CVBuilder.HtmlBuilder
{
    public class ProfileComponent : IHtmlComponent
    {
        private readonly ZoneCollection zoneCollection;

        public ProfileComponent(ZoneCollection zoneCollection)
        {
            this.zoneCollection = zoneCollection;
            Order = 2;
        }

        public int Order { get; set; }

        public string Write()
        {
            var profil = zoneCollection.GetZoneObjectsByZone(Zone.Description).FirstOrDefault();
            var value = $@"
					<div class=""yui - gf"">
                          < div class=""yui-u first"">
							<h2>Profile</h2>
						</div>
						<div class=""yui-u"">
							<p class=""enlarge"">
								{profil.Value.Content}
							</p>
						</div>
					</div>";
            return value;
        }
    }
}

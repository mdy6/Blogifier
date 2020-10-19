using CVBuilder.Model;
using System.Linq;

namespace CVBuilder.HtmlBuilder
{
    public class UserComponent : IHtmlComponent
    {
        private readonly UserProfil userProfil;
        private readonly ZoneCollection zoneCollection;

        public UserComponent(UserProfil userProfil, ZoneCollection zoneCollection)
        {
            this.userProfil = userProfil;
            this.zoneCollection = zoneCollection;
            Order = 1;
        }

        public int Order { get; set; }

        public string Write()
        {

            var profil = zoneCollection.GetZoneObjectsByZone(Zone.Profil);

            var value =
                @$"
		<div id=""hd"">
            < div class=""yui-gc"">
				<div class=""yui-u first"">
					<h1>{userProfil.FirstName} {userProfil.LastName}</h1>
					<h2>{string.Join(',',profil.Select(item => item.Value.Content))}</h2>
				</div>

				<div class=""yui-u"">
					<div class=""contact-info"">
						<h3><a id=""pdf"" href=""#"">Download PDF</a></h3>
						<h3><a href=""mailto:name@yourdomain.com"">name@yourdomain.com</a></h3>
						<h3>(313) - 867-5309</h3>
					</div><!--// .contact-info -->
				</div>
			</div><!--// .yui-gc -->
		</div>
";
            return value;
        }
    }
}

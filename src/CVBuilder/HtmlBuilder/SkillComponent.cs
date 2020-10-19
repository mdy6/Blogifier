using CVBuilder.Model;
using System.Linq;
using System.Text;

namespace CVBuilder.HtmlBuilder
{
    public class SkillComponent : IHtmlComponent
    {
        private readonly ZoneCollection zoneCollection;

        public int Order { get; set; }

        public SkillComponent(ZoneCollection zoneCollection)
        {
            Order = 3;
            this.zoneCollection = zoneCollection;
        }

        public string Write()
        {
            return @$"
                    <div class=""yui-gf"">
                            <div class=""yui-u first"">
							    <h2>Skills</h2>
						    </div>
						{WriteSkills()}
					</div>";
        }


        private string WriteSkills()
        {
            var skills = zoneCollection.GetZoneObjectsByZone(Zone.Skills).ToList();
            var stringBuilder = new StringBuilder();
            var pages = HtmlComponentHelper.Pager<SkillsValue>(zoneCollection,3);

            pages.Keys.ToList().ForEach(item1 =>
            {
                stringBuilder.AppendLine($@"<div class=""yui-u"">");
                pages[item1].ToList().ForEach(item2 =>
                {
                    stringBuilder.AppendLine($@"	
                                <div class=""talent"">
									<h2>{item2.Title}</h2>
									<p>{item2.Content}.</p>
								</div>");
                });
                stringBuilder.AppendLine($@"</div>");
            });

            return stringBuilder.ToString();
        }
    }
}

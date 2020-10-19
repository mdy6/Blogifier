using CVBuilder.Model;
using System.Linq;
using System.Text;

namespace CVBuilder.HtmlBuilder
{
    public class TechnicalComponent : IHtmlComponent
    {
        private readonly ZoneCollection zoneCollection;

        public int Order { get; set; }

        public TechnicalComponent(ZoneCollection zoneCollection)
        {
            Order = 4;
            this.zoneCollection = zoneCollection;
        }

        public string Write()
        {
            return $@"<div class=""yui - gf"">
                          < div class=""yui-u first"">
							<h2>Technical</h2>
						</div>
						{WriteTechnical()}
					</div>";
        }

        private string WriteTechnical()
        {
            var technicals = zoneCollection.GetZoneObjectsByZone(Zone.Technical).ToList();
            var pagestechnical = HtmlComponentHelper.Pager<TechnicalValue>(zoneCollection, 3);
            var stringBuilder = new StringBuilder();
            pagestechnical.Keys.ToList().ForEach(item1 =>
            {
                stringBuilder.AppendLine($@"<div class=""yui-u"">
                                            <ul class=""talent"">");
                var techs = pagestechnical[item1].ToList();
                for(int i =0; i< techs.Count; i++)
                {

                    if(i+1 >= techs.Count)
                        stringBuilder.AppendLine($@"<li class=""last"">{techs[i].Content}</li>");
                    else
                        stringBuilder.AppendLine($@"<li>{techs[i].Content}</li>");
                }
                stringBuilder.AppendLine($@"</ul>");
                stringBuilder.AppendLine($@"</div>");
            });
            return stringBuilder.ToString();

        }
    }
}

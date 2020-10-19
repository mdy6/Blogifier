using CVBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.HtmlBuilder
{

    public class HtmlLayout : IHtmlLayout
    {
        private readonly ZoneCollection zoneCollection;
        private readonly UserProfil userProfil;

        public HtmlLayout(ZoneCollection zoneCollection, UserProfil userProfil, string path)
        {
            this.zoneCollection = zoneCollection;
            this.userProfil = userProfil;
        }
        
        public string Build(IEnumerable<IHtmlComponent> htmlComponents)
        {
            return AggregateHtml(htmlComponents);
        }

        private string AddHead()
        {
            return $@"
<head>
	<title>{userProfil.FirstName} {userProfil.LastName} | Web Designer, Director | name@yourdomain.com</title>
	<meta http-equiv=""content - type"" content=""text / html; charset = utf - 8"" />
            <meta name =""keywords"" content ="""" />
               <meta name = ""description"" content = """" />
                  <link rel = ""stylesheet"" type = ""text/css"" href = ""http://yui.yahooapis.com/2.7.0/build/reset-fonts-grids/reset-fonts-grids.css"" media = ""all"" />
                  <link rel = ""stylesheet"" type = ""text/css"" href = ""resume.css"" media = ""all"" />
</head> ";
        }

        private string AggregateHtml(IEnumerable<IHtmlComponent> htmlComponents)
        {
            var stringHtmlBuilder = new StringBuilder();

            stringHtmlBuilder.AppendLine("<html>");
            stringHtmlBuilder.AppendLine(AddHead());
            stringHtmlBuilder.AppendLine("<body>");
            stringHtmlBuilder.AppendLine(@"<div id=""doc2"" class=""yui-t7"">");
            stringHtmlBuilder.AppendLine(@"<div id=""inner"">");

            htmlComponents.OrderBy(item => item.Order).ToList().ForEach(item => { stringHtmlBuilder.AppendLine(item.Write()); });


            
            stringHtmlBuilder.AppendLine("</body>");
            stringHtmlBuilder.AppendLine("</html>");

            return stringHtmlBuilder.ToString();
        }
    }
}

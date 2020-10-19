using System.Collections.Generic;

namespace CVBuilder.HtmlBuilder
{
    public interface IHtmlLayout
    {
        public string Build(IEnumerable<IHtmlComponent> htmlComponents);
    }
}

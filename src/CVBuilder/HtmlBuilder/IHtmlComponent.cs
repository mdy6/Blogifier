namespace CVBuilder.HtmlBuilder
{
    public interface IHtmlComponent
    {
        public int Order { get; set; }
        public string Write();
    }
}

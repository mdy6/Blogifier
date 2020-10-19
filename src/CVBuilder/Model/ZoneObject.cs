namespace CVBuilder.Model
{
    public class ZoneObject : ModelObject
    {
        public Zone Zone { get; set; }
        public IZoneValue Value { get; set; }

        public bool IsEditable { get; set; } = true;

        public void Edit()
        {
            IsEditable = true;
        }
        public void Close()
        {
            IsEditable = false;
        }
    }
}
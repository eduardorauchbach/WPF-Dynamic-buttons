namespace FromZero.Desktop.Domain.Models
{
    public class MosaicItem
    {
        public string Title { get; set; }
        public string? Title2 { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int IconIndex { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public string ButtonName { get { return "btnMosaicItem" + IconIndex; } }
        public string ImageName { get { return "imgMosaicItem" + IconIndex; } }

        public MosaicItem(string title, string description, string icon, int iconIndex)
        {
            Title = title;
            Description = description;
            Icon = @"/Domain/Component/Icons/" + icon;
            IconIndex = iconIndex;
        }
    }
}

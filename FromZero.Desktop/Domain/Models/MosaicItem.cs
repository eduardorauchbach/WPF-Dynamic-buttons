using FromZero.Desktop.Domain.Constants;

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

        public bool IsUserEnabled { get; set; }
        public bool IsOfflineEnabled { get; set; }
        public bool IsFiltered { get; set; }

        public string TagButton { get { return ButtonDefault.MosaicButtonPrefix + "MosaicItem" + IconIndex; } }
        public string TagImage { get { return ButtonDefault.MosaicButtonImagePrefix + "MosaicItem" + IconIndex; } }
        public string TagBackground { get { return ButtonDefault.MosaicButtonBackgroundPrefix + "MosaicItem" + IconIndex; } }
        public string TagLabel { get { return ButtonDefault.MosaicButtonLabelPrefix + "MosaicItem" + IconIndex; } }

        public MosaicItem(string title, string description, string icon, bool isOfflineEnabled, int iconIndex)
        {
            Title = title;
            Description = description;
            Icon = @"/Domain/Component/Icons/" + icon;

            IsUserEnabled = true;
            IsFiltered = true;         
            IsOfflineEnabled = isOfflineEnabled;

            IconIndex = iconIndex;
        }
    }
}

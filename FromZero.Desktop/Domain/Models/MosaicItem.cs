using FromZero.Desktop.Domain.Constants;
using static FromZero.Desktop.Domain.Constants.MosaicDefault;

namespace FromZero.Desktop.Domain.Models
{
    public class MosaicItem
    {
        public string Title { get; set; }
        public string? Title2 { get; set; }
        public string Description { get; set; }
        public MosaicTargets Target { get; set; }
        public string Icon { get; set; }
        public int IconIndex { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsUserEnabled { get; set; }
        public bool IsOfflineEnabled { get; set; }
        public bool IsFiltered { get; set; }

        public string TagButton { get { return NamesDefault.MosaicButtonPrefix + "MosaicItem" + IconIndex; } }
        public string TagImage { get { return NamesDefault.MosaicButtonImagePrefix + "MosaicItem" + IconIndex; } }
        public string TagBackground { get { return NamesDefault.MosaicButtonBackgroundPrefix + "MosaicItem" + IconIndex; } }
        public string TagLabel { get { return NamesDefault.MosaicButtonLabelPrefix + "MosaicItem" + IconIndex; } }

        public MosaicItem(MosaicTargets target, string title, string description, string icon, bool isOfflineEnabled, int iconIndex)
        {
            Target = target;

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

namespace FromZero.Desktop.Domain.ViewModels
{
    public class AttendanceViewModel : MasterViewModel
    {
        public AttendanceViewModel(MasterViewModel masterView) : base(masterView)
        {
            GlobalProperties = masterView.GlobalProperties;
        }
    }
}

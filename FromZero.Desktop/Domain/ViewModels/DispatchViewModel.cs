namespace FromZero.Desktop.Domain.ViewModels
{
    public class DispatchViewModel : MasterViewModel
    {
        public DispatchViewModel(MasterViewModel masterView) : base(masterView)
        {
            GlobalProperties = masterView.GlobalProperties;
        }
    }
}

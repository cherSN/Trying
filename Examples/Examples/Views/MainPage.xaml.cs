using Core.Viewmodels;
using MVVMbasics.Views;

namespace Examples.Views
{
    public sealed partial class MainPage : BackButtonAwareBaseView, IBindableView<MainViewmodel>
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public MainViewmodel Vm { get; set; }
    }
}

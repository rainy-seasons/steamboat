using Steamboat.ViewModels;
using System.Windows;

namespace Steamboat.Views
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        public EditAccount()
        {
            InitializeComponent();
            DataContext = vm = new EditAccountViewModel();
        }

        private EditAccountViewModel vm;
    }
}
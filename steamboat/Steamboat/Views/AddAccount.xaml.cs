﻿using Steamboat.ViewModels;
using System.Windows;

namespace Steamboat.Views
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
            DataContext = vm = new AddAccountViewModel();
        }

        private AddAccountViewModel vm;
    }
}
﻿using Sispakcf.Pages;

namespace Sispakcf
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
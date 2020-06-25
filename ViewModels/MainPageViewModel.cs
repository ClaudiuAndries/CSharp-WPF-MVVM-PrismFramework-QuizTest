using AutolocatorWPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutolocatorWPF.ViewModels
{
        class MainPageViewModel : BindableBase
        {
                private string _title = "Test Grila";
                public static  string _NameInsertion = "";

                public static int _GetIndexLevel = -1;
                public int GetIndexLevel
                {
                        get 
                        {
                                return _GetIndexLevel;
                        }
                        set
                        {
                                SetProperty(ref _GetIndexLevel, value);
                        }
                }
                private IRegionManager _regionManager;

                public string Title
                {
                        get { return _title; }
                        set { SetProperty(ref _title, value); }
                }
                public string NameInsertion
                {
                        get { return _NameInsertion; }
                        set { SetProperty(ref _NameInsertion, value); }
                }
                
                public DelegateCommand ButtonPress { get; private set; }
                public MainPageViewModel(IRegionManager regionManager)
                {
                        ButtonPress = new DelegateCommand(Execute);
                        _regionManager = regionManager;
                }
                public void Execute()
                {
                        if (_NameInsertion.Length == 0 || _GetIndexLevel == -1)
                        {
                                MessageBox.Show("Introdu numele si selecteaza dificultatea testului!");
                        }
                        else
                        {
                                _regionManager.Regions["ContentRegion"].Add(new ViewA());
                                //ViewAViewModel obj = new ViewAViewModel(_NameInsertion);
                        }
                        

                }
        }
}

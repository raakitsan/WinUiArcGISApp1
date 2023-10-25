using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace WinUiArcGISApp1
{
   /// <summary>
   /// A map window that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class MainWindow : Window
   {
      public MainWindow()
      {
         this.InitializeComponent();
      }

      /// <summary>
      /// Gets the view-model that provides mapping capabilities to the view
      /// </summary>
      public MapViewModel ViewModel { get; } = new MapViewModel();

      // Map initialization logic is contained in MapViewModel.cs
   }
}

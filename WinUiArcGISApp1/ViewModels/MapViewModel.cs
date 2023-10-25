using CommunityToolkit.Mvvm.ComponentModel;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinUiArcGISApp1
{
   /// <summary>
   /// Provides map data to an application
   /// </summary>
   [ObservableObject]
   public partial class MapViewModel
   {
      [ObservableProperty]
      private Map _map;

      [ObservableProperty]
      private GraphicsOverlayCollection? _graphicsOverlays;

      public MapViewModel()
      {
         _map = new Map(SpatialReferences.WebMercator)
         {
            InitialViewpoint = new Viewpoint(new Envelope(-180, -85, 180, 85, SpatialReferences.Wgs84)),
            Basemap = new Basemap(BasemapStyle.ArcGISStreets)
         };
         CreateGraphics();
      }

      private void CreateGraphics()
      {
         // Create a new graphics overlay to contain a variety of graphics.
         var wiscGraphicsOverlay = new GraphicsOverlay();

         // Add the overlay to a graphics overlay collection.
         GraphicsOverlayCollection overlays = new GraphicsOverlayCollection
            {
                wiscGraphicsOverlay
            };

         // Set the view model's "GraphicsOverlays" property (will be consumed by the map view).
         this.GraphicsOverlays = overlays;

         // Create a point geometry.
         var ctyLineTavernPoint = new MapPoint(-92.155434, 45.525302, SpatialReferences.Wgs84);

         // Create a symbol to define how the point is displayed.
         var pointSymbol = new SimpleMarkerSymbol
         {
            Style = SimpleMarkerSymbolStyle.Circle,
            Color = System.Drawing.Color.Orange,
            Size = 10.0
         };

         // Add an outline to the symbol.
         pointSymbol.Outline = new SimpleLineSymbol
         {
            Style = SimpleLineSymbolStyle.Solid,
            Color = System.Drawing.Color.Blue,
            Width = 2.0
         };

         // Create a point graphic with the geometry and symbol.
         var pointGraphic = new Graphic(ctyLineTavernPoint, pointSymbol);

         // Add the point graphic to graphics overlay.
         wiscGraphicsOverlay.Graphics.Add(pointGraphic);

         // Create text symbols.
         TextSymbol CLTextSymbol = new TextSymbol("County Line Tavern", Color.Blue, 10,
             HorizontalAlignment.Right, VerticalAlignment.Bottom);

         var labelGraphic = new Graphic(ctyLineTavernPoint, CLTextSymbol);
         wiscGraphicsOverlay.Graphics.Add(labelGraphic);
      }
   }
}

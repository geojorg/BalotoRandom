using BalotoRandom.Models;
using BalotoRandom.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace BalotoRandom.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private string _direction;
        private string _name;
        private bool _isEnable;

        public LocationViewModel()
        {
            SearchResultModel = new SearchResultModel();
            BalotoMap = new Map();
            BalotoMap.HasScrollEnabled = true;
            BalotoMap.HasZoomEnabled = true;
            BalotoMap.IsShowingUser = true;
            GetLocalPosition();
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsEnable = false;
            }
            else
            {
                IsEnable = true;
            }
        }

        public SearchResultModel SearchResultModel { get; }
        public Map BalotoMap { get; private set; }
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }
        public string Direction
        {
            get { return _direction; }
            set { SetProperty(ref _direction, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public async void GetLocalPosition()
        {
            try
            {
                var location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    CurrentLatitude = location.Latitude;
                    CurrentLongitude = location.Longitude;
                    Position currentposition = new Position(CurrentLatitude, CurrentLongitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(currentposition, Distance.FromKilometers(1));
                    BalotoMap.MoveToRegion(mapSpan);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
        }
        public ICommand SearchCommand => new Command(Search, () => IsEnable);

        private async void Search()
        {
            IsEnable = false;
            var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
            analyticsService.LogEvent("buscarubicacion");
            GetLocalPosition();
            var model = new SearchModel
            {
                Name = "Baloto",
                InputType = "textquery",
                Fields = "name,geometry,formatted_address",
                LocationBias = $"circle:4000@{CurrentLatitude},{CurrentLongitude}",
            };
            IMapsService mapsService = new MapsService();
            SearchResultModel resultModel = await mapsService.GetTextSearch(model);
            if (resultModel.Status != "OK")
            {
                Direction = "No Disponible";
                Name = "No Disponible";
                Lat = CurrentLatitude;
                Lng = CurrentLongitude;
            }
            else
            {
                Direction = resultModel.Candidates.FirstOrDefault().FormattedAddress;
                Name = resultModel.Candidates.FirstOrDefault().Name;
                Lat = resultModel.Candidates.FirstOrDefault().Geometry.Location.Lat;
                Lng = resultModel.Candidates.FirstOrDefault().Geometry.Location.Lng;
            }

            Pin pin = new Pin
            {
                Label = Name,
                Address = Direction,
                Type = PinType.SearchResult,
                Position = new Position(Lat, Lng)
            };
            BalotoMap.Pins.Add(pin);
            IsEnable = true;
        }
    }
}

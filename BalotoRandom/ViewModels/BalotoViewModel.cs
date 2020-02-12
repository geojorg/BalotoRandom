using BalotoRandom.Helpers;
using BalotoRandom.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BalotoRandom.ViewModels
{
    public class BalotoViewModel : BaseViewModel
    {
        private string _acumulado;
        private string _fecha;
        private string _sorteo;
        private string _res1;
        private string _res2;
        private string _res3;
        private string _res4;
        private string _res5;
        private string _res6;
        private string _antfecha1;
        private string _antfecha2;
        private string _antfecha3;
        private string _antfecha4;
        private string _resfecha1;
        private string _resfecha2;
        private string _resfecha3;
        private string _resfecha4;

        public string Acumulado { get { return _acumulado; } set { SetProperty(ref _acumulado, value); } }
        public string Fecha { get { return _fecha; } set { SetProperty(ref _fecha, value); } }
        public string Sorteo { get { return _sorteo; } set { SetProperty(ref _sorteo, value); } }
        public string Res1 { get { return _res1; } set { SetProperty(ref _res1, value); } }
        public string Res2 { get { return _res2; } set { SetProperty(ref _res2, value); } }
        public string Res3 { get { return _res3; } set { SetProperty(ref _res3, value); } }
        public string Res4 { get { return _res4; } set { SetProperty(ref _res4, value); } }
        public string Res5 { get { return _res5; } set { SetProperty(ref _res5, value); } }
        public string Res6 { get { return _res6; } set { SetProperty(ref _res6, value); } }
        public string AntFecha1 { get { return _antfecha1; } set { SetProperty(ref _antfecha1, value); } }
        public string ResFecha1 { get { return _resfecha1; } set { SetProperty(ref _resfecha1, value); } }
        public string AntFecha2 { get { return _antfecha2; } set { SetProperty(ref _antfecha2, value); } }
        public string ResFecha2 { get { return _resfecha2; } set { SetProperty(ref _resfecha2, value); } }
        public string AntFecha3 { get { return _antfecha3; } set { SetProperty(ref _antfecha3, value); } }
        public string ResFecha3 { get { return _resfecha3; } set { SetProperty(ref _resfecha3, value); } }
        public string AntFecha4 { get { return _antfecha4; } set { SetProperty(ref _antfecha4, value); } }
        public string ResFecha4 { get { return _resfecha4; } set { SetProperty(ref _resfecha4, value); } }

        public BalotoViewModel()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

            }
            else
            {
                var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
                analyticsService.LogEvent("paginabaloto");
                LoadResults();
            }
        }

        public void LoadResults()
        {
            Fecha = APIService.Fecha;
            Sorteo = $"Baloto {Languages.Draw} {APIService.Sorteo}";
            Acumulado = APIService.Acumulado;
            Res1 = APIService.B1;
            Res2 = APIService.B2;
            Res3 = APIService.B3;
            Res4 = APIService.B4;
            Res5 = APIService.B5;
            Res6 = APIService.B6;
            AntFecha1 = APIService.FechaA1;
            AntFecha2 = APIService.FechaA2;
            AntFecha3 = APIService.FechaA3;
            AntFecha4 = APIService.FechaA4;
            ResFecha1 = APIService.BalotoRA1;
            ResFecha2 = APIService.BalotoRA2;
            ResFecha3 = APIService.BalotoRA3;
            ResFecha4 = APIService.BalotoRA4;
        }
    }
}
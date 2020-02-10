using BalotoRandom.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BalotoRandom.ViewModels
{
    public class RevanchaViewModel : BaseViewModel
    {
        private string _acumulado;
        private string _fecha;
        private string _sorteo;
        private string _rev1;
        private string _rev2;
        private string _rev3;
        private string _rev4;
        private string _rev5;
        private string _rev6;
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
        public string Rev1 { get { return _rev1; } set { SetProperty(ref _rev1, value); } }
        public string Rev2 { get { return _rev2; } set { SetProperty(ref _rev2, value); } }
        public string Rev3 { get { return _rev3; } set { SetProperty(ref _rev3, value); } }
        public string Rev4 { get { return _rev4; } set { SetProperty(ref _rev4, value); } }
        public string Rev5 { get { return _rev5; } set { SetProperty(ref _rev5, value); } }
        public string Rev6 { get { return _rev6; } set { SetProperty(ref _rev6, value); } }
        public string AntFecha1 { get { return _antfecha1; } set { SetProperty(ref _antfecha1, value); } }
        public string ResFecha1 { get { return _resfecha1; } set { SetProperty(ref _resfecha1, value); } }
        public string AntFecha2 { get { return _antfecha2; } set { SetProperty(ref _antfecha2, value); } }
        public string ResFecha2 { get { return _resfecha2; } set { SetProperty(ref _resfecha2, value); } }
        public string AntFecha3 { get { return _antfecha3; } set { SetProperty(ref _antfecha3, value); } }
        public string ResFecha3 { get { return _resfecha3; } set { SetProperty(ref _resfecha3, value); } }
        public string AntFecha4 { get { return _antfecha4; } set { SetProperty(ref _antfecha4, value); } }
        public string ResFecha4 { get { return _resfecha4; } set { SetProperty(ref _resfecha4, value); } }

        public RevanchaViewModel()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

            }
            else
            {
                var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
                analyticsService.LogEvent("paginarevancha");
                LoadResults();
            }
        }

        private void LoadResults()
        {
            Fecha = APIService.Fecha;
            Sorteo = $"Revancha Sorteo {APIService.Sorteo}";
            Acumulado = APIService.AcumuladoR;
            Rev1 = APIService.R1;
            Rev2 = APIService.R2;
            Rev3 = APIService.R3;
            Rev4 = APIService.R4;
            Rev5 = APIService.R5;
            Rev6 = APIService.R6;
            AntFecha1 = APIService.FechaA1;
            AntFecha2 = APIService.FechaA2;
            AntFecha3 = APIService.FechaA3;
            AntFecha4 = APIService.FechaA4;
            ResFecha1 = APIService.RevanchaRA1;
            ResFecha2 = APIService.RevanchaRA2;
            ResFecha3 = APIService.RevanchaRA3;
            ResFecha4 = APIService.RevanchaRA4;
        }
    }
}
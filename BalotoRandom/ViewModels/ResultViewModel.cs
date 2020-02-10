using BalotoRandom.Services;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BalotoRandom.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        private string _balot0;
        private string _colorBalot0;
        private string _balot1;
        private string _colorBalot1;
        private string _balot2;
        private string _colorBalot2;
        private string _balot3;
        private string _colorBalot3;
        private string _balot4;
        private string _colorBalot4;
        private string _balot5;
        private string _colorBalot5;
        private string _message;
        private string _isVisible;
        private string _win;
        private bool _isEnable;
        public static List<string> WinnersRevancha = new List<string>();
        public static List<string> WinnersBaloto = new List<string>();

        public ResultViewModel()
        {
            ColorBalot0 = "YellowBall";
            ColorBalot1 = "YellowBall";
            ColorBalot2 = "YellowBall";
            ColorBalot3 = "YellowBall";
            ColorBalot4 = "YellowBall";
            ColorBalot5 = "RedBall";

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsEnable = false;
            }
            else
            {
                IsEnable = true;
                Data();
            }
        }

        public async void Data()
        {
            IsEnable = false;
            string url = $"https://www.loterias.com/baloto/resultados/{APIService.FechaSync}";
            var client = new WebClient();
            string premiosdata = await client.DownloadStringTaskAsync(url);
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(premiosdata);
            string tag = "/html/body/div[2]/div/div[2]/table/tbody/tr";
            string tag2 = "/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr";
            var Premio5_1 = doc.DocumentNode.SelectNodes($"{tag}[1]/td[2]").Single();
            var Premio5_0 = doc.DocumentNode.SelectNodes($"{tag}[2]/td[2]").Single();
            var Premio4_1 = doc.DocumentNode.SelectNodes($"{tag}[3]/td[2]").Single();
            var Premio4_0 = doc.DocumentNode.SelectNodes($"{tag}[4]/td[2]").Single();
            var Premio3_1 = doc.DocumentNode.SelectNodes($"{tag}[5]/td[2]").Single();
            var Premio3_0 = doc.DocumentNode.SelectNodes($"{tag}[6]/td[2]").Single();
            var Premio2_1 = doc.DocumentNode.SelectNodes($"{tag}[7]/td[2]").Single();
            if (Premio5_1 == null || Premio5_0 == null || Premio4_1 == null || Premio4_0 == null || Premio3_1 == null || Premio3_0 == null || Premio2_1 == null)
            {
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
                WinnersBaloto.Add("Sin Datos");
            }
            else
            {
                WinnersBaloto.Add(Premio5_1.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio5_0.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio4_1.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio4_0.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio3_1.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio3_0.InnerText.Trim().TrimEnd('$'));
                WinnersBaloto.Add(Premio2_1.InnerText.Trim().TrimEnd('$'));
            }

            var RPremio5_1 = doc.DocumentNode.SelectNodes($"{tag2}[1]/td[2]").Single();
            var RPremio5_0 = doc.DocumentNode.SelectNodes($"{tag2}[2]/td[2]").Single();
            var RPremio4_1 = doc.DocumentNode.SelectNodes($"{tag2}[3]/td[2]").Single();
            var RPremio4_0 = doc.DocumentNode.SelectNodes($"{tag2}[4]/td[2]").Single();
            var RPremio3_1 = doc.DocumentNode.SelectNodes($"{tag2}[5]/td[2]").Single();
            var RPremio3_0 = doc.DocumentNode.SelectNodes($"{tag2}[6]/td[2]").Single();
            var RPremio2_1 = doc.DocumentNode.SelectNodes($"{tag2}[7]/td[2]").Single();

            if (RPremio5_1 == null || RPremio5_0 == null || RPremio4_1 == null || RPremio4_0 == null || RPremio3_1 == null || RPremio3_0 == null || RPremio2_1 == null)
            {
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
                WinnersRevancha.Add("Sin Datos");
            }
            else
            {
                WinnersRevancha.Add(RPremio5_1.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio5_0.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio4_1.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio4_0.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio3_1.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio3_0.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
                WinnersRevancha.Add(RPremio2_1.InnerText.Trim().TrimEnd('$').TrimEnd(' ').Trim('0').Trim('0').Trim(','));
            }
            IsEnable = true;
        }

        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }
        public string Balot0
        {
            get { return _balot0; }
            set { SetProperty(ref _balot0, value); }
        }
        public string ColorBalot0
        {
            get { return _colorBalot0; }
            set { SetProperty(ref _colorBalot0, value); }
        }
        public string Balot1
        {
            get { return _balot1; }
            set { SetProperty(ref _balot1, value); }
        }
        public string ColorBalot1
        {
            get { return _colorBalot1; }
            set { SetProperty(ref _colorBalot1, value); }
        }
        public string Balot2
        {
            get { return _balot2; }
            set { SetProperty(ref _balot2, value); }
        }
        public string ColorBalot2
        {
            get { return _colorBalot2; }
            set { SetProperty(ref _colorBalot2, value); }
        }
        public string Balot3
        {
            get { return _balot3; }
            set { SetProperty(ref _balot3, value); }
        }
        public string ColorBalot3
        {
            get { return _colorBalot3; }
            set { SetProperty(ref _colorBalot3, value); }
        }
        public string Balot4
        {
            get { return _balot4; }
            set { SetProperty(ref _balot4, value); }
        }
        public string ColorBalot4
        {
            get { return _colorBalot4; }
            set { SetProperty(ref _colorBalot4, value); }
        }
        public string Balot5
        {
            get { return _balot5; }
            set { SetProperty(ref _balot5, value); }
        }
        public string ColorBalot5
        {
            get { return _colorBalot5; }
            set { SetProperty(ref _colorBalot5, value); }
        }
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public string IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public string Win
        {
            get { return _win; }
            set { SetProperty(ref _win, value); }
        }
        public int Acierto { get; set; }
        public int SuperAcierto { get; set; }

        public ICommand BalotoCommand => new Command(Baloto, () => IsEnable);
        private void Baloto()
        {
            var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
            analyticsService.LogEvent("balotobutton");
            var Balotolist = APIService.ResultadosBaloto;
            var SuperBalot = APIService.B6;
            var WinnerBaloto = WinnersBaloto;

            var Bal0 = Convert.ToInt32(Balot0);
            var Bal1 = Convert.ToInt32(Balot1);
            var Bal2 = Convert.ToInt32(Balot2);
            var Bal3 = Convert.ToInt32(Balot3);
            var Bal4 = Convert.ToInt32(Balot4);
            var Bal5 = Convert.ToInt32(Balot5);

            string[] array = { Balot0, Balot1, Balot2, Balot3, Balot4 };
            var duplicados = CheckforDuplicates(array);
            Acierto = 0;
            SuperAcierto = 0;

            if (duplicados == true || Bal0 > 43 || Bal1 > 43 || Bal2 > 43 || Bal3 > 43 || Bal4 > 43 || Bal5 > 17)
            {
                Message = "Revisa los numeros ingresados";
                IsVisible = "Red";
            }
            else
            {
                IsVisible = "Transparent";
            }

            if (Balotolist.Contains(Balot0) == true)
            {
                Acierto++;
                ColorBalot0 = "GreenBall";
            }
            else
            {
                ColorBalot0 = "YellowBall";
            }
            if (Balotolist.Contains(Balot1) == true)
            {
                Acierto++;
                ColorBalot1 = "GreenBall";
            }
            else
            {
                ColorBalot1 = "YellowBall";
            }
            if (Balotolist.Contains(Balot2) == true)
            {
                Acierto++;
                ColorBalot2 = "GreenBall";
            }
            else
            {
                ColorBalot2 = "YellowBall";
            }
            if (Balotolist.Contains(Balot3) == true)
            {
                Acierto++;
                ColorBalot3 = "GreenBall";
            }
            else
            {
                ColorBalot3 = "YellowBall";
            }
            if (Balotolist.Contains(Balot4) == true)
            {
                Acierto++;
                ColorBalot4 = "GreenBall";
            }
            else
            {
                ColorBalot4 = "YellowBall";
            }
            if (Balot5 == SuperBalot)
            {
                SuperAcierto++;
                ColorBalot5 = "GreenBall";
            }
            else
            {
                ColorBalot5 = "RedBall";
            }
            if (Acierto == 5 && SuperAcierto == 1)
            {
                Win = $"${WinnerBaloto[0]}";
            }
            else if (Acierto == 5 && SuperAcierto == 0)
            {
                Win = $"${WinnerBaloto[1]}";
            }
            else if (Acierto == 4 && SuperAcierto == 1)
            {
                Win = $"${WinnerBaloto[2]}";
            }
            else if (Acierto == 4 && SuperAcierto == 0)
            {
                Win = $"${WinnerBaloto[3]}";
            }
            else if (Acierto == 3 && SuperAcierto == 1)
            {
                Win = $"${WinnerBaloto[4]}";
            }
            else if (Acierto == 3 && SuperAcierto == 0)
            {
                Win = $"${WinnerBaloto[5]}";
            }
            else if (Acierto == 2 && SuperAcierto == 1)
            {
                Win = $"${WinnerBaloto[6]}";
            }
            else if (SuperAcierto == 1)
            {
                Win = "$5.700";
            }
            else
            {
                Win = "$0";
            }
        }

        public ICommand RevanchaCommand => new Command(Revancha, () => IsEnable);
        private void Revancha()
        {
            var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
            analyticsService.LogEvent("revanchabutton");
            var Revanchalist = APIService.ResultadosRevancha;
            var SuperRevancha = APIService.R6;
            var Winner = WinnersRevancha;

            var Bal0 = Convert.ToInt32(Balot0);
            var Bal1 = Convert.ToInt32(Balot1);
            var Bal2 = Convert.ToInt32(Balot2);
            var Bal3 = Convert.ToInt32(Balot3);
            var Bal4 = Convert.ToInt32(Balot4);
            var Bal5 = Convert.ToInt32(Balot5);

            string[] array = { Balot0, Balot1, Balot2, Balot3, Balot4 };
            var duplicados = CheckforDuplicates(array);
            Acierto = 0;
            SuperAcierto = 0;

            if (duplicados == true || Bal0 > 43 || Bal1 > 43 || Bal2 > 43 || Bal3 > 43 || Bal4 > 43 || Bal5 > 17)
            {
                Message = "Revisa los numeros ingresados";
                IsVisible = "Red";
            }
            else
            {
                IsVisible = "Transparent";
            }

            if (Revanchalist.Contains(Balot0) == true)
            {
                Acierto++;
                ColorBalot0 = "GreenBall";
            }
            else
            {
                ColorBalot0 = "YellowBall";
            }
            if (Revanchalist.Contains(Balot1) == true)
            {
                Acierto++;
                ColorBalot1 = "GreenBall";
            }
            else
            {
                ColorBalot1 = "YellowBall";
            }
            if (Revanchalist.Contains(Balot2) == true)
            {
                Acierto++;
                ColorBalot2 = "GreenBall";
            }
            else
            {
                ColorBalot2 = "YellowBall";
            }
            if (Revanchalist.Contains(Balot3) == true)
            {
                Acierto++;
                ColorBalot3 = "GreenBall";
            }
            else
            {
                ColorBalot3 = "YellowBall";
            }
            if (Revanchalist.Contains(Balot4) == true)
            {
                Acierto++;
                ColorBalot4 = "GreenBall";
            }
            else
            {
                ColorBalot4 = "YellowBall";
            }
            if (Balot5 == SuperRevancha)
            {
                SuperAcierto++;
                ColorBalot5 = "GreenBall";
            }
            else
            {
                ColorBalot5 = "RedBall";
            }
            if (Acierto == 5 && SuperAcierto == 1)
            {
                Win = $"${Winner[0]}";
            }
            else if (Acierto == 5 && SuperAcierto == 0)
            {
                Win = $"${Winner[1]}";
            }
            else if (Acierto == 4 && SuperAcierto == 1)
            {
                Win = $"${Winner[2]}";
            }
            else if (Acierto == 4 && SuperAcierto == 0)
            {
                Win = $"${Winner[3]}";
            }
            else if (Acierto == 3 && SuperAcierto == 1)
            {
                Win = $"${Winner[4]}";
            }
            else if (Acierto == 3 && SuperAcierto == 0)
            {
                Win = $"${Winner[5]}";
            }
            else if (Acierto == 2 && SuperAcierto == 1)
            {
                Win = $"${Winner[6]}";
            }
            else if (SuperAcierto == 1)
            {
                Win = "$2.100";
            }
            else
            {
                Win = "$0";
            }
        }

        public bool CheckforDuplicates(string[] array)
        {
            var duplicates = array
             .GroupBy(p => p)
             .Where(g => g.Count() > 1)
             .Select(g => g.Key);
            return (duplicates.Count() > 0);
        }
    }
}

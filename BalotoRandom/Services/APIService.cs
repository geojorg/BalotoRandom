using BalotoRandom.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace BalotoRandom.Services
{
    public class APIService
    {
        public static string B1;
        public static string B2;
        public static string B3;
        public static string B4;
        public static string B5;
        public static string B6;
        public static string R1;
        public static string R2;
        public static string R3;
        public static string R4;
        public static string R5;
        public static string R6;
        public static string Fecha;
        public static string FechaSync;
        public static string Acumulado;
        public static string AcumuladoR;
        public static string Sorteo;
        public static string FechaA1;
        public static string FechaA2;
        public static string FechaA3;
        public static string FechaA4;
        public static string BalotoRA1;
        public static string BalotoRA2;
        public static string BalotoRA3;
        public static string BalotoRA4;
        public static string RevanchaRA1;
        public static string RevanchaRA2;
        public static string RevanchaRA3;
        public static string RevanchaRA4;
        public static List<string> ResultadosBaloto = new List<string>();
        public static List<string> ResultadosRevancha = new List<string>();

        public class RestService
        {
            public async Task<BalotoResults> GetBalotoResultsAsync()
            {
                HttpClient client = new HttpClient();
                BalotoResults balotoResults = null;
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.balotoclub.com/es/api-baloto-getSorteos");
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        balotoResults = BalotoResults.FromJson(content);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\tERROR {0}", ex.Message);
                }
                FechaSync = balotoResults.Sorteos[1].Fecha.ToString("dd-MM-yyyy");
                Fecha = balotoResults.Sorteos[1].Fecha.ToString("dd MMMMM yyyy", new CultureInfo("es-CO"));
                Acumulado = $"{(balotoResults.Sorteos[1].Bacumulado / 1000000):C0} Millones";
                AcumuladoR = $"{(balotoResults.Sorteos[1].Racumulado / 1000000):C0} Millones";
                Sorteo = balotoResults.Sorteos[1].SorteoSorteo.ToString();
                B1 = balotoResults.Sorteos[1].B1.ToString().PadLeft(2, '0');
                B2 = balotoResults.Sorteos[1].B2.ToString().PadLeft(2, '0');
                B3 = balotoResults.Sorteos[1].B3.ToString().PadLeft(2, '0');
                B4 = balotoResults.Sorteos[1].B4.ToString().PadLeft(2, '0');
                B5 = balotoResults.Sorteos[1].B5.ToString().PadLeft(2, '0');
                B6 = balotoResults.Sorteos[1].B6.ToString().PadLeft(2, '0');
                ResultadosBaloto.Add(B1);
                ResultadosBaloto.Add(B2);
                ResultadosBaloto.Add(B3);
                ResultadosBaloto.Add(B4);
                ResultadosBaloto.Add(B5);

                R1 = balotoResults.Sorteos[1].R1.ToString().PadLeft(2, '0');
                R2 = balotoResults.Sorteos[1].R2.ToString().PadLeft(2, '0');
                R3 = balotoResults.Sorteos[1].R3.ToString().PadLeft(2, '0');
                R4 = balotoResults.Sorteos[1].R4.ToString().PadLeft(2, '0');
                R5 = balotoResults.Sorteos[1].R5.ToString().PadLeft(2, '0');
                R6 = balotoResults.Sorteos[1].R6.ToString().PadLeft(2, '0');
                ResultadosRevancha.Add(R1);
                ResultadosRevancha.Add(R2);
                ResultadosRevancha.Add(R3);
                ResultadosRevancha.Add(R4);
                ResultadosRevancha.Add(R5);

                FechaA1 = balotoResults.Sorteos[2].Fecha.ToString("dd MMMM yyyy", new CultureInfo("es-CO"));
                FechaA2 = balotoResults.Sorteos[3].Fecha.ToString("dd MMMM yyyy", new CultureInfo("es-CO"));
                FechaA3 = balotoResults.Sorteos[4].Fecha.ToString("dd MMMM yyyy", new CultureInfo("es-CO"));
                FechaA4 = balotoResults.Sorteos[5].Fecha.ToString("dd MMMM yyyy", new CultureInfo("es-CO"));

                BalotoRA1 =
                    $"{balotoResults.Sorteos[2].B1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].B2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].B3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].B4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].B5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].B6.ToString().PadLeft(2, '0')}";

                BalotoRA2 =
                    $"{balotoResults.Sorteos[3].B1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].B2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].B3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].B4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].B5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].B6.ToString().PadLeft(2, '0')}";

                BalotoRA3 =
                    $"{balotoResults.Sorteos[4].B1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].B2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].B3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].B4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].B5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].B6.ToString().PadLeft(2, '0')}";

                BalotoRA4 =
                    $"{balotoResults.Sorteos[5].B1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].B2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].B3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].B4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].B5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].B6.ToString().PadLeft(2, '0')}";

                RevanchaRA1 =
                    $"{balotoResults.Sorteos[2].R1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].R2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].R3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].R4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].R5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[2].R6.ToString().PadLeft(2, '0')}";

                RevanchaRA2 =
                    $"{balotoResults.Sorteos[3].R1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].R2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].R3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].R4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].R5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[3].R6.ToString().PadLeft(2, '0')}";

                RevanchaRA3 =
                    $"{balotoResults.Sorteos[4].R1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].R2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].R3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].R4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].R5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[4].R6.ToString().PadLeft(2, '0')}";

                RevanchaRA4 =
                    $"{balotoResults.Sorteos[5].R1.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].R2.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].R3.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].R4.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].R5.ToString().PadLeft(2, '0')}-" +
                    $"{balotoResults.Sorteos[5].R6.ToString().PadLeft(2, '0')}";

                return balotoResults;
            }
        }
    }
}
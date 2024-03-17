using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_plecakowy
{
    public class ProblemPlecakowy
    {
        public int LiczbaPrzedmiotow { get; set; }
        public List<Przedmiot> Przedmioty { get; set; }

        public ProblemPlecakowy(int n, int seed)
        {
            LiczbaPrzedmiotow = n;
            Przedmioty = new List<Przedmiot>();
            Random random = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                int wartosc = random.Next(1, 11);
                int waga = random.Next(1, 11);
                Przedmioty.Add(new Przedmiot(wartosc, waga));
            }
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Przedmioty.Count; i++)
            {
                var przedmiot = Przedmioty[i];
                result += $"{i+1}. Wartość: {przedmiot.Wartosc}, Waga: {przedmiot.Waga}{Environment.NewLine}";
            }
            return result;
        }
        public Result Solve(int capacity)
        {
            var posortowanePrzedmioty = Przedmioty.OrderByDescending(p => (double)p.Wartosc / p.Waga).ToList();
            List<int> numeryPrzedmiotow = new List<int>();
            int sumarycznaWartosc = 0;
            int sumarycznaWaga = 0;

            foreach (var przedmiot in posortowanePrzedmioty)
            {
                if (sumarycznaWaga + przedmiot.Waga <= capacity)
                {
                    numeryPrzedmiotow.Add(Przedmioty.IndexOf(przedmiot) + 1);
                    sumarycznaWartosc += przedmiot.Wartosc;
                    sumarycznaWaga += przedmiot.Waga;
                }
            }

            return new Result(numeryPrzedmiotow, sumarycznaWartosc, sumarycznaWaga);
        }
    }

}
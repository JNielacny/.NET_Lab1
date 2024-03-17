using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_plecakowy
{
    public class Result
    {
        public List<int> NumeryPrzedmiotow { get; set; }
        public int SumarycznaWartosc { get; set; }
        public int SumarycznaWaga { get; set; }

        public Result(List<int> numeryPrzedmiotow, int sumarycznaWartosc, int sumarycznaWaga)
        {
            NumeryPrzedmiotow = numeryPrzedmiotow;
            SumarycznaWartosc = sumarycznaWartosc;
            SumarycznaWaga = sumarycznaWaga;
        }
        public override string ToString()
        {
            return $"Numery przedmiotów: {string.Join(", ", NumeryPrzedmiotow)}, Sumaryczna wartość: {SumarycznaWartosc}, Sumaryczna waga: {SumarycznaWaga}";
        }
    }
}

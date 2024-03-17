using problem_plecakowy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestyJednostkowe
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCzyZwroconoJedenPrzedmiot()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(5, 123); // 5 przedmiotów, seed = 123
            foreach (var przedmiot in problem.Przedmioty) // Dla ka¿dego
            {
                przedmiot.Waga = 1; // Ustawienie wagi ka¿dego przedmiotu na jeden
            }
            // Act
            var result = problem.Solve(1); // Pojemnoœæ plecaka na tyle ma³¹, ¿eby pomieœciæ tylko jeden przedmiot
            // Assert
            Assert.IsTrue(result.NumeryPrzedmiotow.Count > 0);
        }

        [Test]
        public void TestCzyZwroconoPusteRozwiazanie()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(5, 456); // 5 przedmiotów, seed = 456
            // Act
            var result = problem.Solve(0); // Pojemnoœæ plecaka na tyle ma³¹, ¿eby ¿aden przedmiot siê nie zmieœci³
            // Assert
            Assert.AreEqual(0, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku równy 0
        }

        [Test]
        public void TestCzyKolejnoscWplywaNaRozwiazanie()
        {
            // Arrange
            ProblemPlecakowy problem1 = new ProblemPlecakowy(5, 789); // 5 przedmiotów, seed = 789
            ProblemPlecakowy problem2 = new ProblemPlecakowy(5, 789); // 5 przedmiotów, seed = 789
            // Act
            var result1 = problem1.Solve(15); // Dostêpna pojemnoœæ plecaka wystarczaj¹ca
            var result2 = problem2.Solve(15); // Dostêpna pojemnoœæ plecaka wystarczaj¹ca
            // Assert
            CollectionAssert.AreEqual(result1.NumeryPrzedmiotow, result2.NumeryPrzedmiotow); // Oczekiwana ta sama kolejnoœæ przedmiotów w wyniku
            Assert.AreEqual(result1.NumeryPrzedmiotow.Count, result2.NumeryPrzedmiotow.Count); // // Oczekiwana ta sama liczba przedmiotów
            Assert.AreEqual(result1.SumarycznaWaga, result2.SumarycznaWaga); // Oczekiwana ta sama sumaryczna waga przedmiotów w wyniku
            Assert.AreEqual(result1.SumarycznaWartosc, result2.SumarycznaWartosc); // Oczekiwana ta sama sumaryczna wartoœæ przedmiotów w wyniku
        }

        [Test]
        public void TestPoprawnosciWynikuDlaKonkretnejInstancji()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(5, 999); // 5 przedmiotów, seed = 999
            foreach (var przedmiot in problem.Przedmioty) // Dla ka¿dego
            {
                przedmiot.Waga = 1; // Ustawienie wagi ka¿dego przedmiotu na jeden
                przedmiot.Wartosc = 1; // Ustawienie wartoœci ka¿dego przedmiotu na jeden
            }
            // Act
            var result = problem.Solve(50); // Dostêpna pojemnoœæ plecaka wystarczaj¹ca na 5 przedmiotów o maksymalnej wadze 10 ka¿dy
            // Assert
            Assert.AreEqual(5, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku równy 5
            Assert.AreEqual(5, result.SumarycznaWartosc); // Oczekiwana sumaryczna wartoœæ przedmiotów w wyniku równa 5
            Assert.AreEqual(5, result.SumarycznaWaga); // Oczekiwana sumaryczna waga przedmiotów w wyniku równa 5
        }

        [Test]
        public void TestPoprawnosciDzialaniaZakresowLosowania()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(5, 999); // 5 przedmiotów, seed = 999
            // Act
            var result = problem.Solve(50); // Dostêpna pojemnoœæ plecaka wystarczaj¹ca na 5 przedmiotów o maksymalnej wadze 10 ka¿dy
            // Assert
            Assert.AreEqual(5, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku równa 5
            Assert.LessOrEqual(result.SumarycznaWartosc, 50); // Oczekiwana sumaryczna wartoœæ przedmiotów w wyniku mniejsza od 50
            Assert.LessOrEqual(result.SumarycznaWaga, 50); // Oczekiwana sumaryczna waga przedmiotów w wyniku mniejsz od 50
        }

        [Test]
        public void TestCzyZwroconoPusteRozwiazaniePrzyBrakuPrzedmiotow()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(0, 456); // Brak przedmiotów, seed = 456
            // Act
            var result = problem.Solve(10); // Dostêpna pojemnoœæ plecaka (na wypadek gdyby)
            // Assert
            Assert.AreEqual(0, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku równa 0
        }

        [Test]
        public void TestCzyZwroconoWszystkiePrzedmiotyPrzyZerowejWadze()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(100, 789); // 5 przedmiotów, seed = 789
            foreach (var przedmiot in problem.Przedmioty) // Dla ka¿dego
            {
                przedmiot.Waga = 0; // Ustawienie wagi ka¿dego przedmiotu na zero
            }
            // Act
            var result = problem.Solve(15); // Dostêpna pojemnoœæ plecaka wystarczaj¹ca
            // Assert
            Assert.AreEqual(problem.LiczbaPrzedmiotow, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku równa 100
            Assert.AreEqual(0, result.SumarycznaWaga); // Oczekiwana sumaryczna waga przedmiotów w wyniku równa 0
        }

        [Test]
        public void TestCzyZwroconoWszystkiePrzedmiotyWGlebokosciPlecaka()
        {
            // Arrange
            ProblemPlecakowy problem = new ProblemPlecakowy(5, 123); // 5 przedmiotów, seed = 123
            foreach (var przedmiot in problem.Przedmioty) // Dla ka¿dego
            {
                przedmiot.Waga = 1; // Ustawienie tej samej wagi dla ka¿dego przedmiotu
            }
            // Act
            var result = problem.Solve(problem.LiczbaPrzedmiotow); // Dostêpna pojemnoœæ plecaka równa liczbie przedmiotów
            // Assert
            Assert.AreEqual(problem.LiczbaPrzedmiotow, result.NumeryPrzedmiotow.Count); // Oczekiwana liczba przedmiotów w wyniku
        }

    }
}
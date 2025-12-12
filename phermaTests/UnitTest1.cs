using NUnit.Framework;
using FermatDemo; // или твой namespace с FermatChecker

namespace Pherma.Tests
{
    [TestFixture]
    public class FermatCheckerTests
    {
        [Test]
        public void NoCounterexample_ForClassicCase()
        {
            // n = 3, max = 25 Ч в демонстрационном диапазоне не должно быть решений
            var result = FermatChecker.FindCounterexample(25, 3);

            Assert.IsNull(result, "ќжидали отсутствие контрпримеров дл€ n=3 в диапазоне до 25.");
        }

        [Test]
        public void ReturnsNull_ForTooSmallMax()
        {
            // max = 1 Ч просто граничный случай, там физически нечего провер€ть
            var result = FermatChecker.FindCounterexample(1, 3);

            Assert.IsNull(result, "ƒл€ max=1 метод должен возвращать null.");
        }

        [Test]
        public void ReturnsSameResult_ForSameInput()
        {
            // ќдин и тот же вход должен давать один и тот же результат
            var first = FermatChecker.FindCounterexample(25, 3);
            var second = FermatChecker.FindCounterexample(25, 3);

            Assert.AreEqual(first, second, "ћетод должен быть детерминированным дл€ одинаковых аргументов.");
        }

    }
}

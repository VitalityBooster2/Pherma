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
            // n = 3, max = 25 — в демонстрационном диапазоне не должно быть решений
            var result = FermatChecker.FindCounterexample(25, 3);

            Assert.IsNull(result, "Ожидали отсутствие контрпримеров для n=3 в диапазоне до 25.");
        }

        [Test]
        public void ReturnsNull_ForTooSmallMax()
        {
            // max = 1 — просто граничный случай, там физически нечего проверять
            var result = FermatChecker.FindCounterexample(1, 3);

            Assert.IsNull(result, "Для max=1 метод должен возвращать null.");
        }

        [Test]
        public void ThrowsOnInvalidPower()
        {
            // n <= 2 не имеет смысла для теоремы Ферма, можно ожидать ArgumentOutOfRangeException
            Assert.Throws<ArgumentOutOfRangeException>(
                () => FermatChecker.FindCounterexample(10, 2));
        }
    }
}

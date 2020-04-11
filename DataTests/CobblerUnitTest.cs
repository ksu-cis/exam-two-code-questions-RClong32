using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// implements Inotify Property Changed test
        /// </summary>
        [Fact]
        public void CobblerImplementsINotifyPropertyChanged()
        {
            var cc = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cc);
        }

        /// <summary>
        /// Changing FruitFilling implements INotifyproperty changed
        /// </summary>
        [Fact]
        public void ChangingFruitFillingPropertyShouldShouldInvokePropertyChangedForFruitFilling()
        {
            var cc = new Cobbler();

            Assert.PropertyChanged(cc, "FruitFilling", () => {
                cc.Fruit = FruitFilling.Blueberry;
            });

            Assert.PropertyChanged(cc, "FruitFilling", () => {
                cc.Fruit = FruitFilling.Cherry;
            });

            Assert.PropertyChanged(cc, "FruitFilling", () => {
                cc.Fruit = FruitFilling.Peach;
            });
        }

        /// <summary>
        /// changing WithIceCream invokes propertychanged WithIceCream
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamPropertyShouldInvokePropertyChangedWithIceCream()
        {
            var cc = new Cobbler();

            Assert.PropertyChanged(cc, "WithIceCream", () => {
                cc.WithIceCream = false;
            });
        }

        /// <summary>
        /// tests when WithIceCream prperty is changed the special instructions is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamPropertyShouldInvokePropertyChangedForSpecialInstructionsAndWithIceCream()
        {
            var cc = new Cobbler();

            Assert.PropertyChanged(cc, "SpecialInstructions", () =>
            {
                cc.WithIceCream = false;
            });

            Assert.PropertyChanged(cc, "WithIceCream", () => {
                cc.WithIceCream = false;
            });
        }


    }
}

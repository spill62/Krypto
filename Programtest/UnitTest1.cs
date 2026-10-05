using Krypto;
namespace Programtest
{
    public class UnitTest1
    {
        [Fact]
        public void negative_value_throw_exception()
        {
            //Arrange
            Program program = new Program();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => program.SetPricePerUnit("Monero", -1));
        }

        [Fact]
        public void set_valid_price()
        {
            //Arrange
            Program program = new Program();

            //Act
            program.SetPricePerUnit("Monero", 0);

            //Assert
            Assert.Equal(0, program.GetCryptoPrice("Monero"));
        }

        [Fact]
        public void update_already_set_price()
        {
            //Arrange
            Program program = new Program();
            program.SetPricePerUnit("Monero", 0);
            double updatedPrice = 1;

            //Act
            program.SetPricePerUnit("Monero", updatedPrice);

            //Assert
            Assert.Equal(updatedPrice, program.GetCryptoPrice("Monero"));
        }

        [Fact]
        public void convert_valid_currencies_same_value()
        {
            //Arrange
            Program program = new Program();
            program.SetPricePerUnit("Bitcoin", 5);
            program.SetPricePerUnit("Monero", 5);

            //Act
            double convertedAmount = program.Convert("Bitcoin", "Monero", 2);

            //Assert
            Assert.Equal(10, convertedAmount);
        }
        [Fact]
        public void convert_valid_currencies_different_value()
        {
            //Arrange
            Program program = new Program();
            program.SetPricePerUnit("Bitcoin", 10);
            program.SetPricePerUnit("Monero", 5);

            //Act
            double convertedAmount = program.Convert("Bitcoin", "Monero", 2);

            //Assert
            Assert.Equal(4, convertedAmount);
        }


        [Fact]
        public void convert_fromcurrency_exception()
        {
            //Arrange
            Program program = new Program();
            program.SetPricePerUnit("Monero", 5);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => program.Convert("Ethereum", "Monero", 2));
        }

        [Fact]
        public void convert_tocurrency_exception()
        {
            //Arrange
            Program program = new Program();
            program.SetPricePerUnit("Monero", 10);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => program.Convert("Monero", "Ethereum", 2));
        }
    }
}


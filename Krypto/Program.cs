
namespace Krypto
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public Dictionary<string,double> priceForCrypto = new Dictionary<string,double>();

        /// <summary>
        /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
        /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
        /// bliver den gamle værdi overskrevet af den nye værdi
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
        /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
        public void SetPricePerUnit(String currencyName, double price)
        {

            if (price <0)
            {
                throw new ArgumentException("Ugyldig pris");
            }
                
            priceForCrypto[currencyName] = price;
       

        }

        public double GetCryptoPrice(string CryptoName)
        {
            return priceForCrypto[CryptoName];}

        /// <summary>
        /// Konverterer fra en kryptovaluta til en anden. 
        /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
        /// 
        /// </summary>
        /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
        /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
        /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
        /// <returns>Værdien af beløbet i toCurrencyName</returns>
        public double Convert(String fromCurrencyName, String toCurrencyName, double amount)
        {
            double result = 0;
            if (!priceForCrypto.ContainsKey(fromCurrencyName))
            {
                throw new ArgumentException("'fra' krypto valutaen findes ikke");
            }
            if (!priceForCrypto.ContainsKey(toCurrencyName))
            {
                throw new ArgumentException("'til' krypto valutaen findes ikke");
            }

            if (GetCryptoPrice(fromCurrencyName) == GetCryptoPrice(toCurrencyName))
            {
                result = amount * GetCryptoPrice(fromCurrencyName);
            }
            else
            {

                result = amount * priceForCrypto[fromCurrencyName] / priceForCrypto[toCurrencyName];
            }

            return result;
        }


        //ækvivalensklasser
        // 0< ---
    }
}
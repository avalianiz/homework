namespace homework7;

    internal class Company(bool isForeign)
    {
        public double GetTaxRate()
        {
            return isForeign ? 0.05 : 0.18;
        }
    }
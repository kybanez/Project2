namespace Project2
{
    internal class PriceCutEventArgs
    {
        private string name;
        private double new_Price;

        public PriceCutEventArgs(string name, double new_Price)
        {
            this.name = name;
            this.new_Price = new_Price;
        }

        public string Id
        {
            get
            {
                return name;
            }
            set
            {
                Id = value;
            }
        }

        public double Price
        {
            get
            {
                return new_Price;
            }
            set
            {
                new_Price = value;
            }
        }
    }
}
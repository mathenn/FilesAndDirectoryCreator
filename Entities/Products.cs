namespace FilesAndDirectory.Entities
{
    class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Products()
        {

        }

        public Products(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double total()
        {
            return Price * Quantity;
        }
    }
}

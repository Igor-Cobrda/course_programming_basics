namespace Homework
{
    internal class Product
    {
        internal string Name { get; }
        internal float Price { get; }
        internal double Quantity { get; }

        internal Product(string name, float price, double quantity) 
        {
            try
            {
                kontrolaCeny(price);
                Name = name;
                Price = price;
                Quantity = quantity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cena nemôže byť menšia ako 0 !");
            }
        }

        internal static void kontrolaCeny(float price) 
        {
            if (price < 0)
            {
                throw new InvalidProductExecption();
            }
        }
    }
}

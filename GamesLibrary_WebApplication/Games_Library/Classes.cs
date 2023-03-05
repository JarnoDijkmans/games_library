namespace Games_Library
{
	public abstract class Product
	{
		public int ProductId { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public string Description { get; private set; }
		public int QuantityInStock { get; private set; }

		public abstract decimal CalculateTotalPrice(int quantity);
		public abstract string DisplayProductInformation();
	}

	public class Game : Product
	{
		public string Genre { get; private set; }
		public string Platform { get; private set; }

		public override decimal CalculateTotalPrice(int quantity)
		{
			return Price * quantity;
		}

		public override string DisplayProductInformation()
		{
			return $"ID: {ProductId}\nName: {Name}\nDiscription: {Description}\nPrice: {Price}\nQuantity in stock: {QuantityInStock}\nGenre: {Genre}\nPlatform: {Platform}";
		}
	}
	public class Customer
	{
		public int CustomerId { get; private set; }
		public string Name { get; private set; }
		public string Email { get; private set; }
		public string Address { get; private set; }
	}

	public class Order
	{
		public int OrderId { get; private set; }
		public Customer costumer;
		public List<Product> products { get; private set; }
		public decimal TotalPrice { get; private set; }
	}

	public class Inventory
	{
		private List<Product> products;
		public Inventory()
		{
			products = new List<Product>();
		}

		public void AddProduct (Product product)
		{
			products.Add(product);
		}

		public void RemoveProduct (Product product)
		{
			products.Remove(product);
		}

		public List<Product> SearchByName(string name)
		{
			return products.Where(p => p.Name.Contains(name)).ToList();	
		}

		public Product SearchById(int id)
		{
			return products.FirstOrDefault(p=> p.ProductId == id);
		}
	}
		

}


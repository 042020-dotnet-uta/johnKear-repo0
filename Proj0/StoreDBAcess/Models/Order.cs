using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLitePCL;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace StoreDBAcess.Models
{
	public class Order
	{
		#region Fields

		private int orderId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}
		
<<<<<<< HEAD
		private int customerId;
		[ForeignKey("CustomerId")]		
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}
=======
		public int? CustomerId { get; set; }
		[ForeignKey("CustomerId")]		
		public virtual Customer Customer { get; set; }
>>>>>>> 9149d922ba00a0f316ff96297e6d0d5bd217a6a7

		public int? LocationId { get; set; }
		[ForeignKey("LocationId")]
		public virtual Location Location { get; set; }

<<<<<<< HEAD
		private List<Product> products;
		public List<Product> Products
		{
			get { return products; }
			set { products = value; }
		}
=======
		public virtual List<Product> Products	{ get; set;	}

		public virtual List<Quantities> Quantities { get; set; }
>>>>>>> 9149d922ba00a0f316ff96297e6d0d5bd217a6a7

		private string timeStamp;
		public string TimeStamp
		{
			get { return timeStamp; }
			set { timeStamp = value; }
		}

		[Required]
		private double total;
		public double Total
		{
			get { return total; }
			set { total = value; }
		}

		#endregion

		#region Constructors
		public Order() 
		{
			//set timestamp and initialize total to zero
			this.timeStamp =  DateTime.Now.ToString();
			this.total = 0;
<<<<<<< HEAD
			this.products = new List<Product>();
=======
			//create new instance for products
			this.Products = new List<Product>();
			this.Quantities = new List<Quantities>();
>>>>>>> 9149d922ba00a0f316ff96297e6d0d5bd217a6a7
		}

		#endregion

		#region Methods

		/// <summary>
		/// Adds product item to order
		/// and updates total order cost
		/// </summary>
		/// <param name="product"></param>
		public void AddProduct(Product product, Quantities qty)
		{
			if (product is null)
			{
				throw new System.ArgumentNullException("Parameter cannot be null", "product");
			}
			else
			{
				this.Products.Add(product);
				this.total += (product.UnitCost * qty.Quantity);
				this.Quantities.Add(qty);
			}
		}
		
		/// <summary>
		/// Removes a product from the list
		/// Decrements total
		/// Removes qty element from list
		/// </summary>
		/// <param name="product"></param>
		public void RemoveProduct(Product product)
		{
			if (product is null)
			{
				throw new System.ArgumentNullException("Parameter cannot be null", "product");
			}
			else
			{
				for(int i = 0; i <= this.Products.Count(); i++)
				{
					var prod = this.Products[i];
					if(prod.ProductId == product.ProductId)
					{
						var qty = this.Quantities[i];
						this.total -= (product.UnitCost * qty.Quantity);
						this.Products.RemoveAt(i);
						this.Quantities.RemoveAt(i);
						break;
					}
				}
			}
		}

		/*public Product GetProduct(string name)
		{
			var product = new Product();
			foreach(Product n in this.products)
			{
				if (n.ProductName == name) product = n;
			}
			return product;
		}*/

		#endregion
	}
}

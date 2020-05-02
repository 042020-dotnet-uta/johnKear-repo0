using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLitePCL;
using System.Reflection.Metadata.Ecma335;

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
		
		private int customerId;
		[ForeignKey("Customer")]		
		public int CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}

		private int locationId;
		[ForeignKey("LocationId")]		
		public int LocationId
		{
			get { return locationId; }
			set { locationId = value; }
		}

		private ICollection<Product> products;
		public ICollection<Product> Products
		{
			get { return products; }
			set { products = value; }
		}

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
		}

		#endregion

		#region Methods

		/// <summary>
		/// Adds product item to order
		/// and updates total order cost
		/// </summary>
		/// <param name="product"></param>
		public void AddProduct(Product product)
		{
			this.products.Add(product);
			this.total = product.UnitCost;
		}

		#endregion
	}
}

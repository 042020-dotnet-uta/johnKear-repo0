using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class Product
	{
		#region Fields

		private int productId;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int ProductId
		{
			get { return productId; }
			set { productId = value; }
		}

		private int locationId;
		[ForeignKey("Location")]		
		public int LocationId
		{
			get { return locationId; }
			set { locationId = value; }
		}

		private string productName;
		[Required]
		[NotNull]		
		public string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}

		private double unitCost;
		[Required]		
		public double UnitCost
		{
			get { return unitCost; }
			set { unitCost = value; }
		}

		private int quantity;
		[Required]		
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		#endregion

		#region Constructors
		public Product() { }

		public Product(string name, double price, int qty) 
		{
			if(name == null)
			{
				throw new System.ArgumentException("Parameter cannot be null", "name");
			}else
			{
				this.productName = name;
				this.unitCost = price;
				this.quantity = qty;
			}
		}
		#endregion

		#region Methods

		#endregion
	}
}

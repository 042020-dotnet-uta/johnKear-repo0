using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	class Product
	{
		#region Properties
		[Key]
		private int productId;

		public int ProductId
		{
			get { return productId; }
			set { productId = value; }
		}
		#endregion

		#region Constructors
		public Product() { }
		#endregion

		#region Methods

		#endregion
	}
}

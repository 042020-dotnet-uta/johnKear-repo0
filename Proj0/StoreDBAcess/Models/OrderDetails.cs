using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	public class OrderDetails
	{
		#region Fields

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderDetailsId { get; set; }

		[ForeignKey("OrderId")]
		public int OrderId { get; set; }

		private int productId;
		[ForeignKey("ProductId")]
		public int ProductId
		{
			get { return productId; }
			set { productId = value; }
		}

		[Required]
		public int Qty { get; set; }

		#endregion

		#region Constructors
		public OrderDetails(){}
		#endregion

		#region Methods
		#endregion
	}
}

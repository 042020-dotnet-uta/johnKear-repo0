using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace StoreDBAcess.Models
{
	class Order
	{
		#region Properties
		[Key]
		private int orderId;

		public int OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}
		#endregion

		#region Constructors
		public Order() { }
		#endregion

		#region Methods

		#endregion
	}
}

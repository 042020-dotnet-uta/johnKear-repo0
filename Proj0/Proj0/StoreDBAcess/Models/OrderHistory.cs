using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreDBAcess.Models
{
	class OrderHistory : History
	{
		#region Properties
		[Key]
		private int orderHistoryId;
		public int OrderHistoryId
		{
			get { return orderHistoryId; }
			set { orderHistoryId = value; }
		}
		#endregion

		#region Constructors
		public OrderHistory() { }
		#endregion

		#region Methods
		void History.AddOrder(Order order)
		{
			throw new NotImplementedException();
		}
		#endregion

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace p0_jk.Models
{
	class OrderHistory : IHistory
	{
		private List<Order> orders;

		public void AddOrder(Order order)
		{
			this.orders.Add(order);
		}
	}
}

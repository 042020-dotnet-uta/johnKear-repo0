using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDBAcess.Models
{
	class OrderHistory : History
	{
		#region Properties

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

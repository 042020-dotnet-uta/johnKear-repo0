using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDBAcess.Models
{
	interface History
	{
		public void AddOrder(Order order);
	}
}

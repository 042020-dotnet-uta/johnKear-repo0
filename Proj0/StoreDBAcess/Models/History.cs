using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDBAcess.Models
{
	public interface History
	{
		public void AddOrder(Order order);
	}
}

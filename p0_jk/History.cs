using p0_jk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace p0_jk
{
	interface IHistory
	{
		public void AddOrder(Order order);
	}
}

using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StoreDBAcess.Models;

namespace Proj0
{
	class Program
	{
		static void Main(string[] args)
		{
			StoreApp app = new StoreApp();
			app.Run();
		}
	}
}

using System;
using Core.Entites;

namespace Core.Entities
{
	public class Order
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public int Count { get; set; }

		public Product Product { get; set; }
	}
}


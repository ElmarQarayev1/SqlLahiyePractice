﻿using System;
namespace Core.Entites
{
	public class Brand
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CreatorName { get; set; }

		public int BrandCount { get; set; }

		public List<Product> Products { get;set; }

        public override string ToString()
        {
			return $"{Id}-{Name}-{CreatorName}-{BrandCount}";
        }
    }	
}


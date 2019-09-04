using Model.Domain.DB.SubCategoryDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain.DB.CategoryDB
{
	public class Category 
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Lazy<List<SubCategory>> Subcategories { get; set; }
	}
}

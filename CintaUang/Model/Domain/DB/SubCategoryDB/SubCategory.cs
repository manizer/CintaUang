using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain.DB.SubCategoryDB
{
	public class SubCategory
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Name { get; set; }
	}
}

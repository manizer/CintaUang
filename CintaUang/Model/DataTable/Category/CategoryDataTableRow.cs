using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DataTable.Category
{
	public class CategoryDataTableRow
	{
		[Key]
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("currentRecord")]
		public int CurrentRecord { get; set; }
		[JsonProperty("totalPage")]
		public int TotalPage { get; set; }
		[JsonProperty("totalRecord")]
		public int TotalRecord { get; set; }
	}
}

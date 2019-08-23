using Model.DataTable.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DataTable.Category
{
	public class CategoryDataTableRow : AjaxDataTableRow
	{
		[Key]
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }
	}
}

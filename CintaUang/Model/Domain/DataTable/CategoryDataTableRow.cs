using Model.Domain.DataTable.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain.DataTable
{
	public class CategoryDataTableRow : AjaxDataTableRow
	{
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }
	}
}

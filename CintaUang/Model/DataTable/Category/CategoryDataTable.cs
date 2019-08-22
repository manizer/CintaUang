using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DataTable.Category
{
	public class CategoryDataTable
	{
		[JsonProperty("draw")]
		public int? Draw { get; set; }
		[JsonProperty("recordsTotal")]
		public int RecordsTotal { get; set; }
		[JsonProperty("recordsFiltered")]
		public int? RecordsFiltered { get; set; }
		[JsonProperty("data")]
		public List<CategoryDataTableRow> Data { get; set; }
	}
}

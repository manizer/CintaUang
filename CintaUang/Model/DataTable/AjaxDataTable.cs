using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DataTable
{
	public class AjaxDataTable<E> where E : class
	{
		[JsonProperty("draw")]
		public int? Draw { get; set; }
		[JsonProperty("recordsTotal")]
		public int RecordsTotal { get; set; }
		[JsonProperty("recordsFiltered")]
		public int? RecordsFiltered { get; set; }
		[JsonProperty("data")]
		public List<E> Data { get; set; }
	}
}

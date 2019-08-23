using Model.DTO.DB.DataTable.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTO.DB.DataTable
{
	public class CategoryDataTableRowDTO : AjaxDataTableRowDTO
	{
		[Key]
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }
	}
}

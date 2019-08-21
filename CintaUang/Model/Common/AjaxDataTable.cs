using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
	public class AjaxDataTable
	{
		public static _SortDirection SortDirection { get; private set; }

		public class _SortDirection
		{
			public static string ASC = "ASC";
			public static readonly string DESC = "DESC";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;

namespace CintaUang.Controllers
{
    public class BaseController : Controller
    {
        List<ViewNotification> viewNotifications = new List<ViewNotification>();

		public void AddNotification(ViewNotification viewNotification)
        {
			viewNotifications.Add(viewNotification);
			TempData["viewNotifications"] = viewNotifications;
		}
    }
}
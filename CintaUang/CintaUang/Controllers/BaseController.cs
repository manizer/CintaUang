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
		public enum ViewNotificationType
		{
			ERROR = 0,
			SUCCESS = 1
		}

        List<AlertMessage> listAlert = new List<AlertMessage>();

        public void AddNotification(ViewNotificationType notificationType, string message)
        {
			switch ((int)notificationType)
			{
				case (int)ViewNotificationType.ERROR:
					listAlert.Add(new AlertMessage("Error", message));
					break;
				case (int)ViewNotificationType.SUCCESS:
					listAlert.Add(new AlertMessage("Success", message));
					break;
			}
            
            TempData["listAlert"] = listAlert;
        }
    }
}
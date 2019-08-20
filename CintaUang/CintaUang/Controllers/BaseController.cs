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
        List<AlertMessage> listAlert = new List<AlertMessage>();
        public void AddAlert(string type, string message)
        {
            listAlert.Add(new AlertMessage(type, message));
            TempData["listAlert"] = listAlert;
        }
    }
}
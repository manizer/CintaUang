using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class AlertMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Form { get; set; }

        public AlertMessage(string type, string message)
        {
            this.Type = type;
            this.Message = message;
        }

        public AlertMessage(string type, string message, string form)
        {
            this.Type = type;
            this.Message = message;
            this.Form = form;
        }
    }
}

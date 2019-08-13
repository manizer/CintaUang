using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class ExecuteResult
    {
        [Key]
        public int InstanceId { get; set; }
    }
}

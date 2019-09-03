using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.DTO.DB
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

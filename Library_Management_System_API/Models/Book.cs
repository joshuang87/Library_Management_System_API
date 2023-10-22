﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library_Management_System_API.Models
{
	public class Book
	{
        [Key]
        public string Book_Id { get; set; }
        public string Book_Title { get; set; }
        public string Author { get; set; }
        public int Category_Id { get; set; }
        public DateTime Created_Time { get; set; }
        public DateTime Updated_Time { get; set; }
    }
}

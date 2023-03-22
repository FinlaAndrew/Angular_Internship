using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Web.Models
{
    public class Stud 
    {
         public int Id { get; set; }
        public string Name { get; set; }

     
      // public string Country { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
       
         // public DateTime DOB { get; set; }
       // public bool IsIndian{get;set;}


    }
   
}
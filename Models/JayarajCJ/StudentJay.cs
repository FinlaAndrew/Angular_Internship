 using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Web.Models.JayarajCJ
{
  
public class StudentJay
{
      public Guid Id{get;set;}
      public string Name{get;set;}
      public DateTime DateOfBirth{get;set;}
      public Guid CountryId{get;set;}
      public CountryJay Country{get;set;}
      public string Gender{get;set;}
      public bool IndianCitizen{get;set;}
      public string Mobile{get;set;}
    

}
}
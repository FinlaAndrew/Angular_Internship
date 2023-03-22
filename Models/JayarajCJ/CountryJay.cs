using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Web.Models.JayarajCJ
{
public class CountryJay
{
      public Guid Id {get;set;}
      public string Name{get;set;}
      public int SortOrder{get;set;}

}
}
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers;
public class HelloWorldController : Controller
{
  // 
  // GET: /HelloWorld/Welcome/ 
  public string Welcome()
  {
    return "This is the Welcome action method...";
  }
  public string Index()
  {
    return "This is my default action...";
  }

}
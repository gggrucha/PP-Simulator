using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public int Counter { get; private set; }
        public void OnGet() 
        {
            
            //Counter = HttpContext.Session.GetInt32("Counter") ?? 1; 
        }
        public void OnPost() //po nacisnieciu guzika count
        {
            //Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
            //Counter++;
            //HttpContext.Session.SetInt32("Counter", Counter);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mission09_ht242.Models;
using Mission09_ht242.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_ht242.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }


/*Finds page info and tells it how many to display on that page*/
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Books.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}

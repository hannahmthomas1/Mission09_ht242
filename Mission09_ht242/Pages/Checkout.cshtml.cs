using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_ht242.Infrastructure;
using Mission09_ht242.Models;

namespace Mission09_ht242.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public CheckoutModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        public Cart cart { get; set; }

/*Variable to hold the url the shopper was at before going to the cart*/
        public string ReturnUrl { get; set; }

/*Get method*/
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

/*Set method*/
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

/* Post method for remove button */
        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

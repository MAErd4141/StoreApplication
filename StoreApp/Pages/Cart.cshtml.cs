using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
                public Cart Cart  {get ; set;}

        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart=cartService;
        }

        
        public String ReturnUrl {get ; set;} = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl= returnUrl ?? "/";
            //Cart= HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int ProductId, string returnUrl)
        {
            Product? product =_manager.ProductService.GetOneProduct(ProductId,false);

            if(product is not null)
            {
                //Cart= HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
                //HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return RedirectToPage(new {returnUrl =returnUrl});
        }  
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart= HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            //HttpContext.Session.SetJson<Cart>("cart",Cart);

            return Page();
        }
    }
}
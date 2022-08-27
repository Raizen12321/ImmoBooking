using ImmoBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmoBooking.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }



        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemtoCart(Property property)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Property.Id == property.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Property = property,
                    AmountofDays = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.AmountofDays++;
            }
            _context.SaveChanges();
        }


        public void RemoveItemFromCart(Property property)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Property.Id == property.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.AmountofDays > 1)
                {
                    shoppingCartItem.AmountofDays--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }
            _context.SaveChanges();
        }



        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Property).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Property.Price * n.AmountofDays).Sum();




    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAppBookShop.Models.db;
using WebAppBookShop.Models.ViewModels;

namespace WebAppBookShop.Controllers
{
	public class BookController : Controller
	{
		private readonly DemoShopContext _context;

		public BookController(DemoShopContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			//var bs = from b in _context.Books select b;
			//var bs = _context.Books.Include(c => c.Category).Include(p => p.Publish); เรียกข้อมูลทั้งตารางทำให้ช้า
			var bs = from b in _context.Books
					 from c in _context.Categories
					 where (b.CategoryId == c.CategoryId)
					 select new BookCategoryViewModel
                     {
						 BookName = b.BookName,
						 BookPrice = b.BookPrice,
                         Isbn = b.Isbn,
						 CategoryName = c.CategoryName
					 };
            if (bs == null)
			{
				return NotFound();
			}
			return View(bs);
			//return View(await	_context.Book.ToListAsync());
		}
	}
}

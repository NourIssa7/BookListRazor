using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db=db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var dbBook = await _db.Book.FindAsync(Book.Id);
                dbBook.Name = Book.Name;
                dbBook.Author = Book.Author;
                dbBook.ISBN = Book.ISBN;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else return RedirectToPage();
        }
    }
}

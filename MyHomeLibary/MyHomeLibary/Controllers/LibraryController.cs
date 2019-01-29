using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHomeLibary.Models;

namespace MyHomeLibary.Controllers
{
    public class LibraryController : Controller
    {
        LibraryDataAccessLayer objLibrary = new LibraryDataAccessLayer();
        [HttpGet("[action]")]
        [Route("api/Library/Index")]
        public IEnumerable<Books> Index()
        {
            return objLibrary.GetAllBooks();
        }

        [HttpGet("[action]")]
        [Route("api/Library/GetAllTypes")]
        public IEnumerable<Types> GetAllTypes()
        {
            return objLibrary.GetAllTypes();
        }

        [HttpGet("[action]")]
        [Route("api/Library/GetAllLanguages")]
        public IEnumerable<Languages> GetAllLanguages()
        {
            return objLibrary.GetAllLanguages();
        }

        [HttpGet("[action]")]
        [Route("api/Library/GetAllClasss")]
        public IEnumerable<Classs> GetAllClasss()
        {
            return objLibrary.GetAllClasses();
        }

        [HttpGet("[action]")]
        [Route("api/Library/SearchByBookName/{_searchBookName}")]
        public IEnumerable<Books> GetAllBooksByBookName(string _searchBookName)
        {
            string serarchBookName = string.Empty;
            if (!string.IsNullOrEmpty(_searchBookName))
                serarchBookName = _searchBookName;
            return objLibrary.GetAllBooksByBookName(serarchBookName);
        }

        [HttpPost]
        [Route("api/Library/Create")]
        public int Create([FromBody] Books books)
        {
            return objLibrary.AddBooks(books);
        }

        [HttpGet]
        [Route("api/Library/Details/{id}")]
        public Books Details(int id)
        {
            return objLibrary.GetBookByID(id);
        }

        [HttpPut]
        [Route("api/Library/Edit")]
        public int Edit([FromBody]Books books)
        {
            return objLibrary.UpdateBooks(books);
        }

        [HttpDelete]
        [Route("api/Library/Delete/{id}")]
        public int Delete(int id)
        {
            return objLibrary.DeleteBooks(id);
        }
    }
}
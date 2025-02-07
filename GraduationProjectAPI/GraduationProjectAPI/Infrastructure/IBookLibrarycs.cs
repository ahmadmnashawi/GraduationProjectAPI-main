﻿using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IBookLibrarycs
    {
        public BookLibrary GetBookLibrary(int id);
        public IQueryable<BookLibrary> GetBookLibraries { get; }
        public bool Save(BookLibrary bookLibrary);
        public void Update(BookLibrary bookLibrary);
        public void Delete(int IdLibrary,int IdBook);
        public int GetIdLibraryBook(int IdBook, int IdLibrary);
    }
}

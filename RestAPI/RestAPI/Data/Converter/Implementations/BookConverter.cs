using System.Collections.Generic;
using System.Linq;
using RestApi.Data.Converter.Contract;
using RestApi.Data.VO;
using RestApi.Model;

namespace RestApi.Data.Converter.Implementations
{
    public class BookConverter : IParser<Book, BookVO> , IParser<BookVO, Book>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                LaunchDate = origin.LaunchDate
            };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
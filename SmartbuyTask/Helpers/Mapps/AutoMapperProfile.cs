using AutoMapper;
using BookStore.Dto.AuthorDto;
using BookStore.Dto.BookDto;
using BookStore.Dto.CategoryDto;
using BookStore.Models;

namespace BookStore.Helpers.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookListDto>();
            CreateMap<BookListDto, Book>(); 
            CreateMap<Book, CreateBookDto>();
            CreateMap<CreateBookDto, Book>();

            CreateMap<Author, AuthorListDto>();
            CreateMap<AuthorListDto, Author>(); 
            CreateMap<Author, CreateAuthorDto>();
            CreateMap<CreateAuthorDto, Author>();

            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryListDto, Category>();
             CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

        }


    }
}

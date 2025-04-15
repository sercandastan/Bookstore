using AutoMapper;
using Bookstore.Areas.AdminPanel.ViewModels.Author_VM;
using Bookstore.Areas.AdminPanel.ViewModels.Book_VM;
using Bookstore.Areas.AdminPanel.ViewModels.Category_VM;
using Bookstore.Areas.AdminPanel.ViewModels.Publisher_VM;
using Bookstore.Models;
using Bookstore.Models.DTOs.Author;
using Bookstore.Models.DTOs.Book;
using Bookstore.Models.DTOs.Category;
using Bookstore.Models.DTOs.Publisher;

namespace Bookstore.Mapper
{
    public class BookstoreMapper : Profile
    {
        public BookstoreMapper()
        {

            // 🔽 BOOK MAPPINGS


            // Entity <-> DTO
            CreateMap<CreateBook_DTO, Book>().ReverseMap();

            CreateMap<Book, Book_DTO>()
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.PublisherName : ""))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : ""))
                .ForMember(dest => dest.AuthorNames, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author.FullName).ToList()));

            CreateMap<Book_DTO, Book>();

            CreateMap<Book, BookDetail_DTO>()
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.PublisherName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author.Id).ToList()))
                .ForMember(dest => dest.AuthorNames, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author.FullName).ToList()))
                .ReverseMap();

            CreateMap<UpdateBook_DTO, Book>().ReverseMap();


            // VM <-> DTO
            CreateMap<CreateBook_VM, CreateBook_DTO>().ReverseMap();
            CreateMap<UpdateBook_VM, UpdateBook_DTO>()
                .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.AuthorIds));




            //  CATEGORY MAPPINGS


            // Entity <-> DTO
            CreateMap<Category, Category_DTO>().ReverseMap();
            CreateMap<CreateCategory_DTO, Category>().ReverseMap();
            CreateMap<UpdateCategory_DTO, Category>().ReverseMap();

            // VM <-> DTO
            CreateMap<CreateCategory_VM, CreateCategory_DTO>().ReverseMap();
            CreateMap<UpdateCategory_VM, UpdateCategory_DTO>().ReverseMap();
            CreateMap<Category_DTO, UpdateCategory_VM>().ReverseMap();




            //  PUBLISHER MAPPINGS

            // Entity <-> DTO
            CreateMap<Publisher, Publisher_DTO>().ReverseMap();
            CreateMap<CreatePublisher_DTO, Publisher>().ReverseMap();
            CreateMap<UpdatePublisher_DTO, Publisher>().ReverseMap();


            // VM <-> DTO
            CreateMap<CreatePublisher_VM, CreatePublisher_DTO>().ReverseMap();
            CreateMap<Publisher_DTO, UpdatePublisher_VM>().ReverseMap();
            CreateMap<UpdatePublisher_VM, UpdatePublisher_DTO>().ReverseMap();



            CreateMap<Publisher_DTO, UpdatePublisher_DTO>().ReverseMap();



            // AUTHOR MAPPINGS


            CreateMap<Author, Author_DTO>().ReverseMap();
            CreateMap<CreateAuthor_VM, CreateAuthor_DTO>().ReverseMap();

            CreateMap<CreateAuthor_DTO, Author>().ReverseMap();
            CreateMap<Author_DTO, UpdateAuthor_VM>().ReverseMap();
            CreateMap<UpdateAuthor_VM, UpdateAuthor_DTO>().ReverseMap();
            CreateMap<UpdateAuthor_DTO, Author>().ReverseMap();

        }
    }
}

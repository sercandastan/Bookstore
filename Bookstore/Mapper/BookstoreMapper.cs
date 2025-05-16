using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Author;
using Bookstore.Models.DTOs.Book;
using Bookstore.Models.DTOs.Cart;
using Bookstore.Models.DTOs.Category;
using Bookstore.Models.DTOs.Login;
using Bookstore.Models.DTOs.Publisher;
using Bookstore.Models.DTOs.Register;
using Bookstore.Models.ViewModels.Author_VM;
using Bookstore.Models.ViewModels.Book_VM;
using Bookstore.Models.ViewModels.Cart_VM;
using Bookstore.Models.ViewModels.Category_VM;
using Bookstore.Models.ViewModels.Login_VM;
using Bookstore.Models.ViewModels.Publisher_VM;
using Bookstore.Models.ViewModels.Register_VM;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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

            CreateMap<Book, DetailsBook_DTO>()
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

            CreateMap<DetailsBook_DTO, UpdateBook_VM>()
                 .ForMember(dest => dest.CoverImage, opt => opt.Ignore())
                 .ReverseMap();

            CreateMap<DetailsBook_DTO, DetailsBook_VM>().ReverseMap();
                





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



            CreateMap<Register_VM, Register_DTO>().ReverseMap();
            CreateMap<Register_DTO, AppUser>().ReverseMap();


            CreateMap<Login_VM, Login_DTO>().ReverseMap();



            CreateMap<Cart_DTO, Cart_VM>()
    .ForMember(vm => vm.Title, opt => opt.Ignore())
    .ForMember(vm => vm.Price, opt => opt.Ignore())
    .ForMember(vm => vm.CoverImage, opt => opt.Ignore())
    .ForMember(vm => vm.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
    .ForMember(vm => vm.BookId, opt => opt.MapFrom(dto => dto.BookId));
        }


    }
}

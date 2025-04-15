﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class BookAuthor_CFG : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(ba => new { ba.AuthorId, ba.BookId });

            builder.HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            builder.HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            builder.HasData(
               new BookAuthor { BookId = 1, AuthorId = 1,},
               new BookAuthor { BookId = 2, AuthorId = 2 },
               new BookAuthor { BookId = 3, AuthorId = 3 },
               new BookAuthor { BookId = 4, AuthorId = 4 },
               new BookAuthor { BookId = 5, AuthorId = 5 },
               new BookAuthor { BookId = 6, AuthorId = 6 },
               new BookAuthor { BookId = 7, AuthorId = 7 },
               new BookAuthor { BookId = 8, AuthorId = 8 },
               new BookAuthor { BookId = 9, AuthorId = 9 },
               new BookAuthor { BookId = 10, AuthorId = 10 }

            );


        }
    }
}

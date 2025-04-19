using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Book_VM
{
    public class UpdateBook_VM : Book_VM
    {
        public string? ExistingCoverImagePath { get; set; }
    }
}

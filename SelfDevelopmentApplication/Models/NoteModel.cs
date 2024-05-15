using System;
using SelfDevelopmentApplication.Helpers;

namespace SelfDevelopmentApplication.Models
{
    class NoteModel : ObservableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public virtual NoteCategoryModel Category { get; set; }
        public DateTime LastEditDateTime { get; set; }
    }
}

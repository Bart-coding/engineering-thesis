using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SelfDevelopmentApplication.Models
{
    class NoteCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<NoteModel> Notes { get; set; } = new ObservableCollection<NoteModel>();
    }
}

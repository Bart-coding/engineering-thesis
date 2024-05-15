using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SelfDevelopmentApplication.Models
{
    class TaskCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();
    }
}
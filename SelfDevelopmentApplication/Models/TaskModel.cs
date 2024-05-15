using SelfDevelopmentApplication.Database;
using System;
using SelfDevelopmentApplication.Helpers;

namespace SelfDevelopmentApplication.Models
{
    enum TaskStatus
    {
        ToDo,
        Done,
        Failed
    }
    enum TaskPriority
    {
        ImportantUrgent,
        ImportantNotUrgent,
        NotImportantUrgent,
        NotImportantNotUrgent
    }
    class TaskModel : ObservableObject
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private int categoryId;
        public int CategoryId 
        {
            get => categoryId;
            set
            {
                categoryId = value;
                OnPropertyChanged();
            }
        }
        private TaskCategoryModel category;
        public virtual TaskCategoryModel Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }

        private DateTime assignedDateTime;
        public DateTime AssignedDateTime
        {
            get => assignedDateTime;
            set
            {
                assignedDateTime = value;
                OnPropertyChanged();
            }
        }

        private TaskStatus status;
        public TaskStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        private TaskPriority priority;
        public TaskPriority Priority
        {
            get => priority;
            set
            {
                priority = value;
                OnPropertyChanged();
            }
        }

        public void CopyTask(TaskModel copyingTask)
        {
            copyingTask.Category = null;

            copyingTask.Name = Name;
            copyingTask.Description = Description;
            copyingTask.AssignedDateTime = AssignedDateTime;
            copyingTask.Status = Status;
            copyingTask.CategoryId = CategoryId;
            copyingTask.Priority = Priority;
        }

        public static TaskModel GetDefaultTask()
        {
            int defaultCategoryId = DatabaseManager.GetDefaultTasksCategoryId();
            return new TaskModel
            {
                Name = "",
                Description = "",
                AssignedDateTime = DateTime.Now,
                Status = TaskStatus.ToDo,
                CategoryId = defaultCategoryId,
                Priority = TaskPriority.NotImportantNotUrgent
            };
        }
    }
}

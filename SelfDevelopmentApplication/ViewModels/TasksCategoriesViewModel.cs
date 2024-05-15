using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class TasksCategoriesViewModel : ViewModelBase
    {
        private ObservableCollection<TaskCategoryModel> tasksCategories = new();
        public ObservableCollection<TaskCategoryModel> TasksCategories
        {
            get => tasksCategories;
            set
            {
                tasksCategories = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectCategoryCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand SubmitDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        private bool showDialog;
        public bool ShowDialog
        {
            get => showDialog;
            set
            {
                showDialog = value;
                OnPropertyChanged();
            }
        }

        private bool isCategoryNameTaken;
        public bool IsCategoryNameTaken
        {
            get => isCategoryNameTaken;
            set
            {
                isCategoryNameTaken = value;
                OnPropertyChanged();
            }
        }

        private string filteringText = "";

        public string FilteringText
        {
            get => filteringText;
            set
            {
                filteringText = value;
                InitializeTasksCategories();
                OnPropertyChanged();
            }
        }

        private TaskCategoryModel selectedCategory;

        public TaskCategoryModel SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private string categoryNameInput = "";

        public string CategoryNameInput
        {
            get => categoryNameInput;
            set
            {
                if (IsCategoryNameTaken)
                {
                    IsCategoryNameTaken = false;
                }
                categoryNameInput = value;
                OnPropertyChanged();
            }
        }

        public TasksCategoriesViewModel() : base()
        {
            InitializeTasksCategories();
            InitializeCommands();
        }

        public void InitializeTasksCategories()
        {
            TasksCategories = DatabaseManager.FilterTasksCategories(FilteringText);
        }

        private void InitializeCommands()
        {
            SelectCategoryCommand = new RelayCommand(taskCategory =>
            {
                SelectedCategory = (TaskCategoryModel)taskCategory;
                CategoryNameInput = SelectedCategory.Name;
                SelectedCategory.Name = CategoryNameInput;
                ShowDialog = true;
            });

            AddCategoryCommand = new RelayCommand(o =>
            {
                ShowDialog = true;
            });

            SubmitDialogCommand = new RelayCommand(o =>
            {
                if (!string.IsNullOrWhiteSpace(CategoryNameInput))
                {
                    if (SelectedCategory == null)
                    {
                        object newCategory = DatabaseManager.AddTasksCategory(CategoryNameInput);
                        if (newCategory == null)
                        {
                            IsCategoryNameTaken = true;
                        }
                        else if (newCategory is not false)
                        {
                            ShowMessageBox = true;
                        }
                    }
                    else
                    {
                        SelectedCategory.Name = CategoryNameInput;
                        bool? updatingResult = DatabaseManager.UpdateTasksCategory(SelectedCategory);
                        if (updatingResult == null)
                        {
                            IsCategoryNameTaken = true;
                        }
                        else if (updatingResult == true)
                        {
                            ShowMessageBox = true;
                            SelectedCategory = null;
                            CategoryNameInput = "";
                            ShowDialog = false;
                        }
                    }
                    InitializeTasksCategories();
                }
                else
                {
                    ShowDialog = false;
                }
            });

            CancelDialogCommand = new RelayCommand(o =>
            {
                ShowDialog = false;
                if (SelectedCategory != null)
                {
                    SelectedCategory = null;
                }
                CategoryNameInput = "";
            });

            DeleteCategoryCommand = new RelayCommand(taskCategory =>
            {
                ShowConfirmationDialog = true;
                ConfirmationDialogData = taskCategory;
            });

            ConfirmationDialogYesCommand = new RelayCommand(o =>
            {
                DatabaseManager.DeleteTasksCategory((TaskCategoryModel)ConfirmationDialogData);
                ConfirmationDialogData = null;
                InitializeTasksCategories();
                ShowConfirmationDialog = false;
            });

            ConfirmationDialogNoCommand = new RelayCommand(o =>
            {
                ConfirmationDialogData = null;
                ShowConfirmationDialog = false;
            });
        }
    }
}

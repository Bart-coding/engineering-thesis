using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaskStatus = SelfDevelopmentApplication.Models.TaskStatus;

namespace SelfDevelopmentApplication.ViewModels
{
    class TasksManagementPanelViewModel : ViewModelBase
    {
        public ICommand ShowTaskDialogCommand { get; set; }
        public ICommand SubmitTaskDialogCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand ModifySelectedTasksListCommand { get; set; }
        public ICommand DeleteSelectedTasksCommand { get; set; }
        public ICommand SelectAllTasksCommand { get; set; }
        public ICommand ChangeSelectedTasksStatusCommand { get; set; }
        public ICommand ChangeSelectedTasksPriorityCommand { get; set; }
        public ICommand UnselectTasksCommand { get; set; }
        public ICommand CancelTaskDialogCommand { get; set; }
        public ICommand AddNewCategoryCommand { get; set; }

        private TaskModel selectedTask;
        public TaskModel SelectedTask
        {
            get => selectedTask;
            set 
            { 
                selectedTask = value;
                OnPropertyChanged(); 
            }
        }

        private ObservableCollection<TaskModel> selectedTasksList = new();

        public ObservableCollection<TaskModel> SelectedTasksList
        {
            get => selectedTasksList;
            set
            {
                selectedTasksList = value;
                OnPropertyChanged();
            }
        }

        private TaskModel tempTask;
        public TaskModel TempTask
        {
            get => tempTask;
            set
            {
                tempTask = value;
                OnPropertyChanged();
            }
        }

        private string tempTaskHour;

        public string TempTaskHour
        {
            get => tempTaskHour;
            set
            {
                tempTaskHour = value;
                OnPropertyChanged();
            }
        }

        private string tempTaskMinute;

        public string TempTaskMinute
        {
            get => tempTaskMinute;
            set
            {
                tempTaskMinute = value;
                OnPropertyChanged();
            }
        }

        private bool displayMode;

        public bool DisplayMode
        {
            get => displayMode;
            set
            {
                if (value)
                {
                    UnselectTasksMethod();
                }

                displayMode = value;
                OnPropertyChanged();
            }
        }

        private bool selectAllTasks;

        public bool SelectAllTasks
        {
            get => selectAllTasks;
            set
            {
                selectAllTasks = value;
                OnPropertyChanged();
            }
        }

        private bool unselectTasks;

        public bool UnselectTasks
        {
            get => unselectTasks;
            set
            {
                unselectTasks = value;
                OnPropertyChanged();
            }
        }

        private bool showTaskDialog;

        public bool ShowTaskDialog
        {
            get => showTaskDialog;
            set
            {
                showTaskDialog = value;
                OnPropertyChanged();
            }
        }

        private bool addingNewCategory;
        public bool AddingNewCategory
        {
            get => addingNewCategory;
            set
            {
                addingNewCategory = value;
                OnPropertyChanged();
            }
        }

        private bool showCategoryMessage;
        public bool ShowCategoryMessage
        {
            get => showCategoryMessage;
            set
            {
                showCategoryMessage = value;
                OnPropertyChanged();
            }
        }

        private string tempCategoryName = "";
        public string TempCategoryName
        {
            get => tempCategoryName;
            set
            {
                if (ShowCategoryMessage)
                {
                    ShowCategoryMessage = false;
                }
                tempCategoryName = value;
                OnPropertyChanged();
            }
        }

        public List<TaskStatus> TaskStatusValues =>
            new(Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>());
        public List<TaskPriority> TaskPriorityValues =>
            new(Enum.GetValues(typeof(TaskPriority)).Cast<TaskPriority>());

        private ObservableCollection<TaskCategoryModel> tasksCategories;
        public ObservableCollection<TaskCategoryModel> TasksCategories
        {
            get => tasksCategories;
            set
            {
                tasksCategories = value;
                OnPropertyChanged();
            }
        }


        private readonly Action<object> _ShowTaskDialogAction;
        private readonly Action _SubmitTaskDialogAction;
        private readonly Action<TaskModel> _RemoveTaskAction;
        private readonly Action _InitializeTasksCategoriesLists;

        public TasksManagementPanelViewModel(Action<object> ShowTaskDialogAction,
                                            Action SubmitTaskDialogAction,
                                            Action<TaskModel> RemoveTaskAction,
                                            Action InitializeTasksCategoriesLists = null) : base()
        {
            _ShowTaskDialogAction = ShowTaskDialogAction;
            _SubmitTaskDialogAction = SubmitTaskDialogAction;
            _RemoveTaskAction = RemoveTaskAction;
            _InitializeTasksCategoriesLists = InitializeTasksCategoriesLists;

            DisplayMode = true;

            InitalizeCommands();
        }

        private void InitalizeCommands()
        {
            ShowTaskDialogCommand = new RelayCommand(o =>
            {
                TempTask = TaskModel.GetDefaultTask();
                AddingNewCategory = false;
                TasksCategories = new(DatabaseManager.GetAllTasksCategories().OrderBy(c => c.Name));
                OnPropertyChanged(nameof(TempTask)); //to re-select its category
                _ShowTaskDialogAction(o);
            });
            SubmitTaskDialogCommand = new RelayCommand(o =>
            {
                if (!string.IsNullOrWhiteSpace(TempTask.Name))
                {
                    _SubmitTaskDialogAction();
                }
                else
                {
                    ShowTaskDialog = false;
                }
            });
            CancelTaskDialogCommand = new RelayCommand(o =>
            {
                ShowTaskDialog = false;
                if (SelectedTask != null)
                {
                    SelectedTask = null;
                }
            });
            DeleteTaskCommand = new RelayCommand(task =>
            {
                ShowConfirmationDialog = true;
                ConfirmationDialogData = task;
            });
            ModifySelectedTasksListCommand = new RelayCommand(
            t =>
            {
                TaskModel task = (TaskModel)t;

                if (SelectedTasksList.Contains(task))
                {
                    SelectedTasksList.Remove(task);
                }
                else
                {
                    SelectedTasksList.Add(task);
                }


            });
            DeleteSelectedTasksCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = true;
                ConfirmationDialogData = SelectedTasksList;
            });
            SelectAllTasksCommand = new RelayCommand(o =>
            {
                if (!DisplayMode)
                {
                    SelectAllTasks = true;
                    SelectAllTasks = false;
                }
            });

            ChangeSelectedTasksStatusCommand = new RelayCommand(tStatus =>
            {
                if (SelectedTasksList.Count > 0)
                {
                    TaskStatus taskStatus;
                    if (Enum.TryParse((string)tStatus, out taskStatus))
                    {
                        foreach (TaskModel task in SelectedTasksList)
                        {
                            task.Status = taskStatus;
                        }
                    }
                }
            });
            ChangeSelectedTasksPriorityCommand = new RelayCommand(tPriority =>
            {
                if (SelectedTasksList.Count > 0)
                {
                    TaskPriority taskPriority;
                    if (Enum.TryParse((string)tPriority, out taskPriority))
                    {
                        foreach (TaskModel task in SelectedTasksList)
                        {
                            task.Priority = taskPriority;
                        }
                    }
                }
            });

            UnselectTasksCommand = new RelayCommand(o =>
            {
                UnselectTasksMethod();
            });

            AddNewCategoryCommand = new RelayCommand(o =>
            {
                AddingNewCategory = !AddingNewCategory;

                if (!AddingNewCategory)
                {
                    if (!string.IsNullOrWhiteSpace(TempCategoryName))
                    {
                        object newCategory = DatabaseManager.AddTasksCategory(TempCategoryName);
                        if (newCategory == null)
                        {
                            ShowCategoryMessage = true;
                            AddingNewCategory = true;
                        }
                        else if (newCategory is not false)
                        {
                            TasksCategories = new(DatabaseManager.GetAllTasksCategories().OrderBy(c => c.Name));
                            TempTask.CategoryId = ((TaskCategoryModel)newCategory).Id;
                            TempCategoryName = "";
                            _InitializeTasksCategoriesLists?.Invoke();
                        }
                    }
                    else
                    {
                        AddingNewCategory = true;
                    }
                }
            });

            ConfirmationDialogYesCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = false;

                if (ConfirmationDialogData is TaskModel)
                {
                    _RemoveTaskAction((TaskModel)ConfirmationDialogData);
                }
                else
                {
                    if (SelectedTasksList.Count > 0)
                    {
                        for (int i = SelectedTasksList.Count - 1; i >= 0; --i)
                        {
                            _RemoveTaskAction(SelectedTasksList[i]);
                            SelectedTasksList.Remove(SelectedTasksList[i]);
                        }
                    }
                }
                
                ConfirmationDialogData = null;
            });

            ConfirmationDialogNoCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = false;
                ConfirmationDialogData = null;
            });
        }

        private void UnselectTasksMethod()
        {
            if (SelectedTasksList.Count > 0)
            {
                UnselectTasks = true;
                UnselectTasks = false;
            }
        }

        public void ClearSelectedTasksList()
        {
            SelectedTasksList.Clear();
        }
    }
}

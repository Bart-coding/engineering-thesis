using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Helpers;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Reflection;

namespace SelfDevelopmentApplication.ViewModels
{
    class DayViewModel : ViewModelBase
    {
        private ObservableCollection<TaskModel> tasksList;
        public ObservableCollection<TaskModel> TasksList
        {
            get => tasksList;
            set
            {
                tasksList = value;

                if (tasksList.Count == 0)
                {
                    IsTasksListEmpty = true;
                }
                else
                {
                    IsTasksListEmpty = false;
                }

                OnPropertyChanged();
            }
        }

        public ICommand NavigateToNotesVMCommand { get; set; }
        public ICommand NavigateToYesterdayCommand { get; set; }
        public ICommand NavigateToTommorowCommand { get; set; }
        public ICommand NavigateToPlanVMCommand { get; set; }
        public ICommand FilterCheckCategory { get; set; }
        public ICommand ChangeCategoriesFilterPopupVisibilityCommand { get; set; }
        public ICommand SortTasksCommand { get; set; }



        private readonly Action<DateTime> _NavigateToPlanVM;
        private readonly Action<DateTime> _NavigateToNotesVM;


        private bool isCurrentDayNotFutureDay;

        public bool IsCurrentDayNotFutureDay
        {
            get => isCurrentDayNotFutureDay;
            set 
            {
                isCurrentDayNotFutureDay = value;
                OnPropertyChanged();
            }
        }

        private DateTime currentDate;
        public DateTime CurrentDate
        {
            get => currentDate;
            set
            { 
                currentDate = value;

                if (currentDate > DateTime.Now)
                {
                    IsCurrentDayNotFutureDay = false;
                }
                else
                {
                    IsCurrentDayNotFutureDay = true;
                }

                TasksPanelVM = new(ShowTaskDialog, SubmitTaskDialog, RemoveTask, InitializeTasksCategoriesLists);

                InitializeHelperLists();
                InitializeTasksList();

                if (MoodStatusPanelVM == null)
                {
                    MoodStatusPanelVM = new(currentDate);
                }
                else
                {
                    MoodStatusPanelVM.InitializeCurrentMoodStatusView(currentDate);
                }

                OnPropertyChanged();
            }
        }



        private string tasksNamesFilteringText = "";

        public string TasksNamesFilteringText
        {
            get => tasksNamesFilteringText;
            set
            {
                tasksNamesFilteringText = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private string tasksDescriptionsFilteringText = "";

        public string TasksDescriptionsFilteringText
        {
            get => tasksDescriptionsFilteringText;
            set
            {
                tasksDescriptionsFilteringText = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskCategoryModel> tasksCategoriesViewList;

        public ObservableCollection<TaskCategoryModel> TasksCategoriesViewList
        {
            get => tasksCategoriesViewList;
            set
            {
                tasksCategoriesViewList = value;
                OnPropertyChanged();
            }
        }

        private string tasksCategoriesFilteringText;

        public string TasksCategoriesFilteringText
        {
            get => tasksCategoriesFilteringText;
            set
            {
                tasksCategoriesFilteringText = value;

                TasksCategoriesViewList = new(TasksCategoriesList.Where(category => category
                                            .Name.Contains(tasksCategoriesFilteringText, StringComparison.OrdinalIgnoreCase)));
                OnPropertyChanged();
            }
        }

        private string filterFromHour = "00";

        public string FilterFromHour
        {
            get => filterFromHour;
            set
            {
                filterFromHour = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private string filterFromMinute = "00";

        public string FilterFromMinute
        {
            get => filterFromMinute;
            set
            {
                filterFromMinute = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private string filterToHour = "23";

        public string FilterToHour
        {
            get => filterToHour;
            set
            {
                filterToHour = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private string filterToMinute = "59";

        public string FilterToMinute
        {
            get => filterToMinute;
            set
            {
                filterToMinute = value;
                InitializeTasksList();
                OnPropertyChanged();
            }
        }

        private GenericCollection<bool> filterTasksStatusesList;

        public GenericCollection<bool> FilterTasksStatusesList
        {
            get => filterTasksStatusesList;
            set
            {
                filterTasksStatusesList = value;
                OnPropertyChanged();
            }
        }

        private GenericCollection<bool> filterTasksCategoriesList;

        public GenericCollection<bool> FilterTasksCategoriesList
        {
            get => filterTasksCategoriesList;
            set
            {
                filterTasksCategoriesList = value;
                OnPropertyChanged();
            }
        }

        private GenericCollection<bool> filterTasksPrioritiesList;

        public GenericCollection<bool> FilterTasksPrioritiesList
        {
            get => filterTasksPrioritiesList;
            set
            {
                filterTasksPrioritiesList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskCategoryModel> tasksCategoriesList;

        public ObservableCollection<TaskCategoryModel> TasksCategoriesList
        {
            get => tasksCategoriesList;
            set
            {
                tasksCategoriesList = value;
                OnPropertyChanged();
            }
        }

        private bool isCategoriesFilterPopupVisibile;

        public bool IsCategoriesFilterPopupVisibile
        {
            get => isCategoriesFilterPopupVisibile;
            set 
            {
                isCategoriesFilterPopupVisibile = value;
                OnPropertyChanged();
            }
        }

        private bool isTasksListEmpty;

        public bool IsTasksListEmpty
        {
            get => isTasksListEmpty;
            set
            {
                isTasksListEmpty = value;
                OnPropertyChanged();
            }
        }

        private PropertyInfo sortProperty = null;

        public PropertyInfo SortProperty
        {
            get => sortProperty;
            set 
            { 
                sortProperty = value;
                OnPropertyChanged();
            }
        }

        private string sortDirection = null;

        public string SortDirection
        {
            get => sortDirection;
            set 
            { 
                sortDirection = value;
                OnPropertyChanged();
            }
        }

        private TasksManagementPanelViewModel tasksPanelVM;
        public TasksManagementPanelViewModel TasksPanelVM
        {
            get => tasksPanelVM;
            set
            {
                tasksPanelVM = value;
                OnPropertyChanged();
            }
        }

        private MoodStatusPanelViewModel moodStatusPanelVM;
        public MoodStatusPanelViewModel MoodStatusPanelVM
        {
            get => moodStatusPanelVM;
            set
            {
                moodStatusPanelVM = value;
                OnPropertyChanged();
            }
        }

        public DayViewModel(Action<DateTime> NavigateToPlanVM, Action<DateTime> NavigateToNotesVM)
        {
            _NavigateToPlanVM = NavigateToPlanVM;
            _NavigateToNotesVM = NavigateToNotesVM;

            InitializeCommands();

            CurrentDate = DateTime.Today;
        }

        public void ChangeCurrentDate(DateTime day)
        {
            CurrentDate = day;
        }

        public void ResetToToday()
        {
            ChangeCurrentDate(DateTime.Today);
        }

        private void ShowTaskDialog(object o)
        {
            if (o == null)
            {
                tasksPanelVM.TempTask.AssignedDateTime = CurrentDate;
                tasksPanelVM.TempTaskHour = "12";
                tasksPanelVM.TempTaskMinute = "00";
            }
            else
            {
                tasksPanelVM.SelectedTask = (TaskModel)o;
                tasksPanelVM.SelectedTask.CopyTask(tasksPanelVM.TempTask);
                tasksPanelVM.TempTaskHour = tasksPanelVM.TempTask.AssignedDateTime.Hour.ToString();
                tasksPanelVM.TempTaskMinute = tasksPanelVM.TempTask.AssignedDateTime.Minute.ToString();
            }

            tasksPanelVM.ShowTaskDialog = true;
        }

        private void RemoveTaskFromTasksList(TaskModel task)
        {
            TasksList.Remove(task);
            TasksList = new(TasksList);
        }

        private void RemoveTask(TaskModel task)
        {
            RemoveTaskFromTasksList(task);
            DatabaseManager.DeleteTask(task);
        }

        private void SubmitTaskDialog()
        {
            if (tasksPanelVM.SelectedTask != null) //editing
            {
                tasksPanelVM.TempTask.CopyTask(tasksPanelVM.SelectedTask);
                DateTime newDate = tasksPanelVM.SelectedTask.AssignedDateTime;
                tasksPanelVM.SelectedTask.AssignedDateTime = new DateTime(newDate.Year, newDate.Month, newDate.Day,
                                                        int.Parse(tasksPanelVM.TempTaskHour), int.Parse(tasksPanelVM.TempTaskMinute), 00);
                
                if(DatabaseManager.UpdateTask(tasksPanelVM.SelectedTask) != false)
                {
                    tasksPanelVM.ShowMessageBox = true;
                    InitializeTasksList();
                    tasksPanelVM.ShowTaskDialog = false;
                    tasksPanelVM.SelectedTask = null;
                }
                
            }
            else //adding
            {
                TaskModel newTask = TaskModel.GetDefaultTask();
                tasksPanelVM.TempTask.CopyTask(newTask);
                DateTime assignedDate = newTask.AssignedDateTime.Date;
                newTask.AssignedDateTime = new DateTime(assignedDate.Year, assignedDate.Month, assignedDate.Day,
                                                            int.Parse(tasksPanelVM.TempTaskHour), int.Parse(tasksPanelVM.TempTaskMinute), 00);
               
                if(DatabaseManager.AddTask(newTask) != false)
                {
                    tasksPanelVM.ShowMessageBox = true;
                    if (assignedDate == CurrentDate)
                    {
                        InitializeTasksCategoriesLists();
                        InitializeTasksList();
                    }
                }
                
            }
        }

        private void InitializeHelperLists()
        {
            if (FilterTasksStatusesList == null)
            {
                FilterTasksStatusesList = new(new bool[3], () =>
                {
                    OnPropertyChanged(nameof(FilterTasksStatusesList));
                    InitializeTasksList();
                });
            }

            if (FilterTasksPrioritiesList == null)
            {
                FilterTasksPrioritiesList = new(new bool[4], () =>
                {
                    OnPropertyChanged(nameof(FilterTasksPrioritiesList));
                    InitializeTasksList();
                });
            }

            InitializeTasksCategoriesLists();

            FilterTasksStatusesList[0] = true;
            FilterTasksStatusesList[1] = true;
            FilterTasksStatusesList[2] = true;

            
            FilterTasksPrioritiesList[0] = true;
            FilterTasksPrioritiesList[1] = true;
            FilterTasksPrioritiesList[2] = true;
            FilterTasksPrioritiesList[3] = true;
        }

        private void InitializeTasksCategoriesLists()
        {
            TasksCategoriesList = new(DatabaseManager.GetAllTasksCategories().OrderBy(c => c.Name));
            bool[] tasksCategoriesBools = new bool[TasksCategoriesList.Count];
            for (int i = 0; i < tasksCategoriesBools.Length; ++i)
            {
                tasksCategoriesBools[i] = true;
            }
            FilterTasksCategoriesList = new GenericCollection<bool>(tasksCategoriesBools, InitializeTasksList);

            TasksCategoriesFilteringText = "";
        }

        private void InitializeTasksList()
        {
            if (TasksList != null)
            {
                TasksList.Clear();
            }
            
            DateTime filteringDateTimeFrom = CurrentDate
                                            .AddHours(Convert.ToDouble(FilterFromHour))
                                            .AddMinutes(Convert.ToDouble(FilterFromMinute));
            DateTime filteringDateTimeTo = CurrentDate
                                           .AddHours(Convert.ToDouble(FilterToHour))
                                           .AddMinutes(Convert.ToDouble(FilterToMinute));
            TasksList = DatabaseManager.FilterTasks(TasksNamesFilteringText, TasksDescriptionsFilteringText,
                                                    filteringDateTimeFrom, filteringDateTimeTo,
                                                    FilterTasksStatusesList, FilterTasksPrioritiesList,
                                                    TasksCategoriesList, FilterTasksCategoriesList);


            if (TasksPanelVM.SelectedTasksList.Count > 0)
            {
                TasksPanelVM.ClearSelectedTasksList();
            }

            SortTasks();
        }

        private void InitializeCommands()
        {
            NavigateToNotesVMCommand = new RelayCommand(o =>
            {
                _NavigateToNotesVM.Invoke(CurrentDate);
            });
            NavigateToYesterdayCommand = new RelayCommand(o =>
            {
                ChangeCurrentDate(CurrentDate.AddDays(-1));
            });
            NavigateToTommorowCommand = new RelayCommand(o =>
            {
                ChangeCurrentDate(CurrentDate.AddDays(1));
            });
            NavigateToPlanVMCommand = new RelayCommand(o =>
            {
                _NavigateToPlanVM.Invoke(CurrentDate);
            });
            FilterCheckCategory = new RelayCommand(category =>
            {
                int index = TasksCategoriesList.IndexOf((TaskCategoryModel)category);
                if(FilterTasksCategoriesList[index])
                {
                    FilterTasksCategoriesList[index] = false;
                }
                else
                {
                    FilterTasksCategoriesList[index] = true;
                }
            });
            ChangeCategoriesFilterPopupVisibilityCommand = new RelayCommand(parameter =>
            {
                if (IsCategoriesFilterPopupVisibile && (string)parameter == "Close")
                {
                    IsCategoriesFilterPopupVisibile = false;
                }
                else if (!IsCategoriesFilterPopupVisibile && (string)parameter == "Open")
                {
                    IsCategoriesFilterPopupVisibile = true;
                }
            });
            SortTasksCommand = new RelayCommand(columnName =>
            {
                string handledColumn = (string)columnName;
                foreach (PropertyInfo property in typeof(TaskModel).GetProperties())
                {
                    if (property.Name.Contains(handledColumn) || handledColumn.Contains(property.Name))
                    {
                        if (property != SortProperty)
                        {
                            SortProperty = property;
                            SortDirection = null;
                        }
                        break;
                    }
                }

                if (SortDirection == null)
                {
                    SortDirection = "Ascending";
                    InitializeTasksList();
                }
                else if (SortDirection == "Ascending")
                {
                    SortDirection = "Descending";
                    InitializeTasksList();
                }
                else if (SortDirection == "Descending")
                {
                    SortDirection = null;
                    InitializeTasksList();
                }
            });
        }

        private void SortTasks()
        {
            if (SortDirection == "Ascending")
            {
                if (SortProperty.Name != "Category")
                {
                    TasksList = new(TasksList.OrderBy(t => SortProperty.GetValue(t)));
                }
                else
                {
                    TasksList = new(TasksList.OrderBy(t => ((TaskCategoryModel)SortProperty.GetValue(t)).Name));
                }
                
            }
            else if (SortDirection == "Descending")
            {
                if (SortProperty.Name != "Category")
                {
                    TasksList = new(TasksList.OrderByDescending(t => SortProperty.GetValue(t)));
                }
                else
                {
                    TasksList = new(TasksList.OrderByDescending(t => ((TaskCategoryModel)SortProperty.GetValue(t)).Name));
                }
            }
        }
    }
}
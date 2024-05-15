using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class PlanViewModel : ViewModelBase
    {

        private ObservableCollection<DateTime> currentWeekDays = new();

        public ObservableCollection<DateTime> CurrentWeekDays
        {
            get => currentWeekDays;
            set
            {
                currentWeekDays = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> mondayTasksList = new();

        public ObservableCollection<TaskModel> MondayTasksList
        {
            get => mondayTasksList;
            set 
            { 
                mondayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> tuesdayTasksList = new();

        public ObservableCollection<TaskModel> TuesdayTasksList
        {
            get => tuesdayTasksList;
            set
            {
                tuesdayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> wednesdayTasksList = new();

        public ObservableCollection<TaskModel> WednesdayTasksList
        {
            get => wednesdayTasksList;
            set
            {
                wednesdayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> thursdayTasksList = new();

        public ObservableCollection<TaskModel> ThursdayTasksList
        {
            get => thursdayTasksList;
            set
            {
                thursdayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> fridayTasksList = new();

        public ObservableCollection<TaskModel> FridayTasksList
        {
            get => fridayTasksList;
            set
            {
                fridayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> saturdayTasksList = new();

        public ObservableCollection<TaskModel> SaturdayTasksList
        {
            get => saturdayTasksList;
            set
            {
                saturdayTasksList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TaskModel> sundayTasksList = new();

        public ObservableCollection<TaskModel> SundayTasksList
        {
            get => sundayTasksList;
            set
            {
                sundayTasksList = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToDayVMCommand { get; set; }
        public ICommand NavigateToLastWeekCommand { get; set; }
        public ICommand NavigateToNextWeekCommand { get; set; }


        private DateTime pickedDay;

        public DateTime PickedDay
        {
            get => pickedDay;
            set
            {
                pickedDay = value.Date;
                if (!CurrentWeekDays.Contains(pickedDay))
                {
                    InitializePlanTable();
                }
                OnPropertyChanged();
            }
        }


        private DateTime currentMonday;

        public DateTime CurrentMonday
        {
            get => currentMonday;
            set
            {
                currentMonday = value.Date;
                OnPropertyChanged();

            }
        }

        private readonly Action<DateTime> _NavigateToDayVM;


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

        public PlanViewModel(Action<DateTime> NavigateToDayVM)
        {
            _NavigateToDayVM = NavigateToDayVM;
            TasksPanelVM = new(ShowTaskDialog, SubmitTaskDialog, RemoveTask);

            PickedDay = DateTime.Today;
            InitalizeCommands();
        }

        public void ChangeCurrentWeek(DateTime day)
        {
            PickedDay = day.Date;
        }

        private void ShowTaskDialog(object o)
        {
            if (o == null) //adding
            {
                tasksPanelVM.TempTask.AssignedDateTime = CurrentMonday;;
                tasksPanelVM.TempTaskHour = "12";
                tasksPanelVM.TempTaskMinute = "00";
            }
            else
            {
                if (o.GetType() == typeof(string)) //adding with custom day
                {
                    if (int.TryParse((string)o, out int daysFromCurrentMonday))
                    {
                        tasksPanelVM.TempTask.AssignedDateTime = CurrentMonday.AddDays(daysFromCurrentMonday);
                        tasksPanelVM.TempTaskHour = "12";
                        tasksPanelVM.TempTaskMinute = "00";
                    }

                }
                else //editing
                {
                    tasksPanelVM.SelectedTask = (TaskModel)o;
                    tasksPanelVM.SelectedTask.CopyTask(tasksPanelVM.TempTask);
                    tasksPanelVM.TempTaskHour = tasksPanelVM.TempTask.AssignedDateTime.Hour.ToString();
                    tasksPanelVM.TempTaskMinute = tasksPanelVM.TempTask.AssignedDateTime.Minute.ToString();
                }
            }

            tasksPanelVM.ShowTaskDialog = true;
        }

        private void SubmitTaskDialog()
        {
            if (tasksPanelVM.SelectedTask != null) //editing
            {
                bool refreshPlanView = false;
                DateTime newDate = tasksPanelVM.TempTask.AssignedDateTime;
                tasksPanelVM.TempTask.AssignedDateTime = new DateTime(newDate.Year, newDate.Month, newDate.Day,
                                                        int.Parse(tasksPanelVM.TempTaskHour), int.Parse(tasksPanelVM.TempTaskMinute), 00);
                if (tasksPanelVM.TempTask.AssignedDateTime != tasksPanelVM.SelectedTask.AssignedDateTime)
                {
                    RemoveTaskFromWeekList(tasksPanelVM.SelectedTask);
                    if (CurrentWeekDays.Contains(tasksPanelVM.TempTask.AssignedDateTime.Date))
                    {
                        refreshPlanView = true;
                    }
                }

                tasksPanelVM.TempTask.CopyTask(tasksPanelVM.SelectedTask);

                if(DatabaseManager.UpdateTask(tasksPanelVM.SelectedTask))
                {
                    tasksPanelVM.ShowMessageBox = true;

                    if (refreshPlanView)
                    {
                        InsertTaskToWeekList(tasksPanelVM.SelectedTask);
                    }
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

                if(DatabaseManager.AddTask(newTask))
                {
                    tasksPanelVM.ShowMessageBox = true;

                    if (CurrentWeekDays.Contains(assignedDate))
                    {
                        InsertTaskToWeekList(newTask);
                    }
                }    
            }
        }

        private void RemoveTask(TaskModel task)
        {
            DatabaseManager.DeleteTask(task);
            RemoveTaskFromWeekList(task);
        }

        private void InitalizeCommands()
        {
            NavigateToDayVMCommand = new RelayCommand(date =>
            {
                _NavigateToDayVM.Invoke((DateTime) date);
            });
            NavigateToLastWeekCommand = new RelayCommand(o =>
            {
                InitializePlanTable(-1);
            });
            NavigateToNextWeekCommand = new RelayCommand(o =>
            {
                InitializePlanTable(1);
            });
        }

        private void InsertTaskToSortedList(TaskModel task, ObservableCollection<TaskModel> tasksList)
        {
            if (tasksList.Count == 0)
            {
                tasksList.Add(task);
                return;
            }

            for (int i = 0; i < tasksList.Count; ++i)
            {
                if (tasksList[i].AssignedDateTime.CompareTo(task.AssignedDateTime) == 1)
                {
                    tasksList.Insert(i, task);
                    return;
                }
            }
            tasksList.Add(task);
        }

        private void InsertTaskToWeekList(TaskModel task)
        {
            switch (task.AssignedDateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    InsertTaskToSortedList(task, MondayTasksList);
                    break;
                case DayOfWeek.Tuesday:
                    InsertTaskToSortedList(task, TuesdayTasksList);
                    break;
                case DayOfWeek.Wednesday:
                    InsertTaskToSortedList(task, WednesdayTasksList);
                    break;
                case DayOfWeek.Thursday:
                    InsertTaskToSortedList(task, ThursdayTasksList);
                    break;
                case DayOfWeek.Friday:
                    InsertTaskToSortedList(task, FridayTasksList);
                    break;
                case DayOfWeek.Saturday:
                    InsertTaskToSortedList(task, SaturdayTasksList);
                    break;
                case DayOfWeek.Sunday:
                    InsertTaskToSortedList(task, SundayTasksList);
                    break;
            }
        }

        private void RemoveTaskFromWeekList(TaskModel task)
        {
            switch (task.AssignedDateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    MondayTasksList.Remove(task);
                    break;
                case DayOfWeek.Tuesday:
                    TuesdayTasksList.Remove(task);
                    break;
                case DayOfWeek.Wednesday:
                    WednesdayTasksList.Remove(task);
                    break;
                case DayOfWeek.Thursday:
                    ThursdayTasksList.Remove(task);
                    break;
                case DayOfWeek.Friday:
                    FridayTasksList.Remove(task);
                    break;
                case DayOfWeek.Saturday:
                    SaturdayTasksList.Remove(task);
                    break;
                case DayOfWeek.Sunday:
                    SundayTasksList.Remove(task);
                    break;
            }
        }

        private void ClearTasksLists()
        {
            MondayTasksList.Clear();
            TuesdayTasksList.Clear();
            WednesdayTasksList.Clear();
            ThursdayTasksList.Clear();
            FridayTasksList.Clear();
            SaturdayTasksList.Clear();
            SundayTasksList.Clear();
        }

        private void PopulateWeekTasksList()
        {
            ObservableCollection<TaskModel> WeekTasksToAssign =
                new(DatabaseManager.GetAllTasks()
                .Where(task => task.AssignedDateTime.Month == CurrentMonday.Month || task.AssignedDateTime.Month == CurrentMonday.Month - 1)
                .Where(task => task.AssignedDateTime.Date >= CurrentWeekDays[0].Date && task.AssignedDateTime.Date < CurrentWeekDays[6].Date.AddDays(1))
                .OrderBy(task => task.AssignedDateTime));


            foreach (TaskModel task in WeekTasksToAssign)
            {
                switch (task.AssignedDateTime.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        MondayTasksList.Add(task);
                        break;
                    case DayOfWeek.Tuesday:
                        TuesdayTasksList.Add(task);
                        break;
                    case DayOfWeek.Wednesday:
                        WednesdayTasksList.Add(task);
                        break;
                    case DayOfWeek.Thursday:
                        ThursdayTasksList.Add(task);
                        break;
                    case DayOfWeek.Friday:
                        FridayTasksList.Add(task);
                        break;
                    case DayOfWeek.Saturday:
                        SaturdayTasksList.Add(task);
                        break;
                    case DayOfWeek.Sunday:
                        SundayTasksList.Add(task);
                        break;
                }
            }
        }

        private void CalculateCurrentMonday(DateTime relativeDay)
        {
            DayOfWeek relativeDayOfWeek = relativeDay.DayOfWeek;
            int daysSinceMonday = relativeDayOfWeek == (int)DayOfWeek.Sunday ? 6
                                                    : (int)relativeDayOfWeek - (int)DayOfWeek.Monday;
            CurrentMonday = relativeDay.AddDays(-daysSinceMonday);
        }

        private void PopulateWeekDaysList()
        {
            CurrentWeekDays.Clear();
            CurrentWeekDays.Add(CurrentMonday);
            for (int i = 1; i < 7; ++i)
            {
                CurrentWeekDays.Add(CurrentWeekDays[0].AddDays(i));
            }
        }

        private void InitializePlanTable(int weeksToAdd = 0)
        {
            ClearTasksLists();

            if (weeksToAdd == 0)
            {
                CalculateCurrentMonday(pickedDay);
                PopulateWeekDaysList();
            }

            else
            {
                CurrentMonday = CurrentMonday.AddDays(weeksToAdd * 7);

                ObservableCollection<DateTime> newWeekDays = new();
                foreach (DateTime dayOfWeek in CurrentWeekDays)
                {
                    newWeekDays.Add(dayOfWeek.AddDays(weeksToAdd * 7));
                }
                CurrentWeekDays = newWeekDays;
                PickedDay = currentMonday;
            }

            PopulateWeekTasksList();

            if (TasksPanelVM.SelectedTasksList.Count > 0)
            {
                TasksPanelVM.ClearSelectedTasksList();
            }
        }
    }
}
using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        private int selectedMenuButton;

        public int SelectedMenuButton
        {
            get => selectedMenuButton;
            set
            {
                selectedMenuButton = value;
                OnPropertyChanged();
            }
        }

        public DayViewModel DayVM { get; set; }
        public PlanViewModel PlanVM { get; set; }
        public NotesViewModel NotesVM { get; set; }
        public TasksCategoriesViewModel TasksCategoriesVM { get; set; }
        public AboutAppViewModel AboutAppVM { get; set; }

        public ICommand NavigateToDayVMCommand { get; set; }
        public ICommand NavigateToPlanVMCommand { get; set; }
        public ICommand NavigateToNotesVMCommand { get; set; }
        public ICommand NavigateToTasksCategoriesVMCommand { get; set; }
        public ICommand NavigateToAboutAppVMCommand { get; set; }

        public ICommand NavigateToSelectedNoteViewCommand { get; set; }
        public ICommand ChangeFastNotesFilterVisibilityCommand { get; set; }


        private ObservableCollection<NoteModel> fastNotesList;
        public ObservableCollection<NoteModel> FastNotesList 
        { 
            get => fastNotesList;
            set
            {
                fastNotesList = value;
                OnPropertyChanged();
            }
        }

        private bool fastNotes;

        public bool FastNotes
        {
            get => fastNotes;
            set
            {
                fastNotes = value;
                OnPropertyChanged();
            }
        }

        private string filteringText;

        public string FilteringText
        {
            get => filteringText;
            set
            {
                filteringText = value;

                if (value == "")
                {
                    FastNotes = false;
                }
                else
                {
                    FastNotes = true;
                    InitializeFastNotesList(value);
                }

                OnPropertyChanged();

            }
        }

        public MainViewModel()
        {
            InitializeViewModels();
            InitializeCommands();
            FilteringText = "";
        }

        private void InitializeViewModels()
        {
            NotesVM = new NotesViewModel();

            DayVM = new DayViewModel(
            (date) =>
            {
                PlanVM.ChangeCurrentWeek(date);
                SelectedViewModel = PlanVM; ;
                ChangeSelectedMenuButton(1);
            },
            (day) =>
            {
                NotesVM.PickDay(day);
                SelectedViewModel = NotesVM;
                ChangeSelectedMenuButton(2);
            });

            PlanVM = new PlanViewModel((date) =>
            {
                DayVM.ChangeCurrentDate(date);
                SelectedViewModel = DayVM;
                ChangeSelectedMenuButton(0);
            });

            TasksCategoriesVM = new TasksCategoriesViewModel();

            AboutAppVM = new AboutAppViewModel();

            SelectedViewModel = DayVM;
        }

        private void InitializeCommands()
        {
            NavigateToDayVMCommand = new RelayCommand(o =>
            {
                DayVM.ResetToToday();
                SelectedViewModel = DayVM;
                ChangeSelectedMenuButton(0);
            });
            NavigateToPlanVMCommand = new RelayCommand(o =>
            {
                PlanVM = new PlanViewModel((date) => 
                {
                    DayVM.ChangeCurrentDate(date);
                    SelectedViewModel = DayVM;
                    ChangeSelectedMenuButton(0);
                });

                SelectedViewModel = PlanVM;
                ChangeSelectedMenuButton(1);
            });
            NavigateToNotesVMCommand = new RelayCommand(o => 
            { 
                NotesVM.PickDay(null);
                SelectedViewModel = NotesVM;
                ChangeSelectedMenuButton(2); 
            });
            NavigateToTasksCategoriesVMCommand = new RelayCommand(o =>
            {
                TasksCategoriesVM.InitializeTasksCategories();
                SelectedViewModel = TasksCategoriesVM;
                ChangeSelectedMenuButton(3); 
            });
            NavigateToAboutAppVMCommand = new RelayCommand(o =>
            {
                SelectedViewModel = AboutAppVM;
                ChangeSelectedMenuButton(4);
            });


            NavigateToSelectedNoteViewCommand = new RelayCommand(note =>
            {
                NotesVM = new NotesViewModel(((NoteModel)note).Category, (NoteModel)note);
                SelectedViewModel = NotesVM;
                ChangeSelectedMenuButton(2);
            });
            ChangeFastNotesFilterVisibilityCommand = new RelayCommand(param =>
            {
                if ((string) param == "Collapsed")
                {
                    if (FastNotes)
                    {
                        FastNotes = false;
                    }
                }
                    
                else if ((string)param == "Visible")
                {
                    if (!FastNotes)
                    {
                        if (filteringText != "")
                        {
                            InitializeFastNotesList(filteringText);
                            FastNotes = true;
                        }
                    }
                }
            });
        }

        private void ChangeSelectedMenuButton(int index)
        {
            SelectedMenuButton = index;
        }

        private void InitializeFastNotesList(string containingText)
        {
            FastNotesList = DatabaseManager.FilterNotesByAllProperties(containingText);
            if (FastNotesList.Count == 0)
            {
                FastNotes = false;
            }
        }
    }
}
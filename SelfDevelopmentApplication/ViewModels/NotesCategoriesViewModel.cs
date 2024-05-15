using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class NotesCategoriesViewModel : ViewModelBase
    {
        private ObservableCollection<NoteCategoryModel> notesCategories = new();
        public ObservableCollection<NoteCategoryModel> NotesCategories 
        {
            get => notesCategories; 
            set
            {
                notesCategories = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectCategoryCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; } 
        public ICommand SubmitDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand ResetPickedDay { get; set; }

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

        private bool navigationMode = true;

        public bool NavigationMode
        {
            get => navigationMode;
            set 
            { 
                navigationMode = value;
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
                InitializeNotesCategories();
                OnPropertyChanged();
            }
        }

        private NoteCategoryModel selectedCategory;

        public NoteCategoryModel SelectedCategory
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

        private DateTime? pickedDay = null;

        public DateTime? PickedDay
        {
            get => pickedDay;
            set 
            { 
                pickedDay = value;
                InitializeNotesCategories();
                OnPropertyChanged();
            }
        }


        public Action<NoteCategoryModel,NoteModel,DateTime?> _NavigateToNotesList { get; set; }

        public NotesCategoriesViewModel(Action<NoteCategoryModel,NoteModel,DateTime?> NavigateToNotesList, DateTime? day) : base()
        {
            _NavigateToNotesList = NavigateToNotesList;
            PickedDay = day;
            InitializeNotesCategories();
            InitializeCommands();
        }

        public void PickDay(DateTime? day)
        {
            PickedDay = day;
        }

        private void InitializeNotesCategories()
        {
            NotesCategories = DatabaseManager.FilterNotesCategories(FilteringText, PickedDay);
        }

        private void InitializeCommands()
        {
            SelectCategoryCommand = new RelayCommand(noteCategory =>
            {
                if (NavigationMode)
                {
                    _NavigateToNotesList.Invoke((NoteCategoryModel)noteCategory, null, PickedDay);
                }
                else
                {
                    SelectedCategory = (NoteCategoryModel)noteCategory;
                    CategoryNameInput = SelectedCategory.Name;
                    ShowDialog = true;
                }
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
                        bool? addingResult = DatabaseManager.AddNotesCategory(CategoryNameInput);
                        if (addingResult == null)
                        {
                            IsCategoryNameTaken = true;
                        }
                        else if (addingResult == true)
                        {
                            ShowMessageBox = true;
                        }
                    }
                    else
                    {
                        SelectedCategory.Name = CategoryNameInput;
                        bool? updatingResult = DatabaseManager.UpdateNotesCategory(SelectedCategory);
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
                    PickedDay = null;
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

            DeleteCategoryCommand = new RelayCommand(noteCategory =>
            {
                ShowConfirmationDialog = true;
                ConfirmationDialogData = noteCategory;
            });

            ConfirmationDialogYesCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = false;
                DatabaseManager.DeleteNotesCategory((NoteCategoryModel)ConfirmationDialogData);
                ConfirmationDialogData = null;
                InitializeNotesCategories();
            });

            ConfirmationDialogNoCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = false;
                ConfirmationDialogData = null;
            });

            ResetPickedDay = new RelayCommand(o =>
            {
                PickedDay = null;
            });
        }
    }
}
using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class NotesListViewModel : ViewModelBase
    {
        private NoteCategoryModel _notesCategory;

        public NoteCategoryModel NotesCategory
        {
            get => _notesCategory;
            set
            {
                _notesCategory = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<NoteModel> notesList;
        public ObservableCollection<NoteModel> NotesList 
        {
            get => notesList;
            set
            {
                notesList = value;
                OnPropertyChanged();
            }
        }
        public ICommand ShowNoteDialogCommand { get; set; }
        public ICommand SubmitDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand DeleteNoteCommand { get; set; }
        public ICommand NavigateToNotesCategoriesCommand { get; set; }
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

        private NoteModel selectedNote;

        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                OnPropertyChanged();
            }
        }

        private string noteTitleInput = "";

        public string NoteTitleInput
        {
            get => noteTitleInput;
            set 
            { 
                noteTitleInput = value;
                OnPropertyChanged();
            }
        }

        private string noteContentInput = "";

        public string NoteContentInput
        {
            get => noteContentInput;
            set
            {
                noteContentInput = value;
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
                InitializeNotesList();
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
                InitializeNotesList();
                OnPropertyChanged();
            }
        }

        private Action<DateTime?> _NavigateToNotesCategories { get; set; }

        public NotesListViewModel(NoteCategoryModel notesCategory, Action<DateTime?> NavigateToNotesCategories,
                                  NoteModel note = null, DateTime? day = null) : base()
        {
            NotesCategory = notesCategory;
            _NavigateToNotesCategories = NavigateToNotesCategories;
            PickedDay = day;

            if (note != null)
            {
                SelectedNote = note;
                ShowNoteDialog();
            }

            InitializeNotesList();
            InitalizeCommands();
            
        }

        private void InitializeNotesList()
        {
            NotesList = DatabaseManager.FilterNotes(FilteringText, NotesCategory, PickedDay);
        }

        private void InitalizeCommands()
        {
            ShowNoteDialogCommand = new RelayCommand(note =>
            {
                if (note != null)
                {
                    SelectedNote = (NoteModel)note;
                }
                ShowNoteDialog();
            });
            NavigateToNotesCategoriesCommand = new RelayCommand(o =>
            {
                _NavigateToNotesCategories.Invoke(PickedDay);
            });
            SubmitDialogCommand = new RelayCommand(o =>
            {
                if (!string.IsNullOrWhiteSpace(NoteTitleInput))
                {
                    if (SelectedNote != null) //editing
                    {
                        SelectedNote.Title = NoteTitleInput;
                        SelectedNote.Content = NoteContentInput;
                        SelectedNote.LastEditDateTime = DateTime.Now;

                        if (DatabaseManager.UpdateNote(SelectedNote))
                        {
                            ShowMessageBox = true;
                            PickedDay = null;
                            ShowDialog = false;
                            SelectedNote = null;
                            NoteTitleInput = "";
                            NoteContentInput = "";
                        }
                    }

                    else //adding
                    {
                        if (DatabaseManager.AddNote(NoteTitleInput, NoteContentInput, _notesCategory.Id, DateTime.Now))
                        {
                            ShowMessageBox = true;
                            PickedDay = null;
                        }
                    }
                }
                else
                {
                    ShowDialog = false;
                }
            });
            CancelDialogCommand = new RelayCommand(o =>
            {
                NoteTitleInput = "";
                NoteContentInput = "";
                if (SelectedNote != null)
                {
                    SelectedNote = null;
                }
                ShowDialog = false;
            });

            DeleteNoteCommand = new RelayCommand(note =>
            {
                ShowConfirmationDialog = true;
                ConfirmationDialogData = note;
            });

            ConfirmationDialogYesCommand = new RelayCommand(o =>
            {
                ShowConfirmationDialog = false;
                DatabaseManager.DeleteNote((NoteModel)ConfirmationDialogData);
                ConfirmationDialogData = null;
                InitializeNotesList();
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

        private void ShowNoteDialog()
        {
            if (SelectedNote != null)
            {
                NoteTitleInput = SelectedNote.Title;
                NoteContentInput = SelectedNote.Content;
            }
            
            ShowDialog = true;
        }
    }
}

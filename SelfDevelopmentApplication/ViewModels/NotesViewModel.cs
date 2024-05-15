using SelfDevelopmentApplication.Models;
using System;

namespace SelfDevelopmentApplication.ViewModels
{
    class NotesViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NotesCategoriesViewModel NotesCategoriesViewModel { get; set; }
        public NotesListViewModel NotesListViewModel { get; set; }

        public NotesViewModel(NoteCategoryModel noteCategory = null, NoteModel note = null)
        {
            InitializeViewModels();
            if (noteCategory != null && note != null)
            {
                NavigateToNotesList(noteCategory, note, null);
            }
        }

        public void PickDay(DateTime? day)
        {
            InitializeViewModels(day);
        }

        private void InitializeViewModels(DateTime? day = null)
        {
            NotesCategoriesViewModel = new NotesCategoriesViewModel(NavigateToNotesList, day);

            CurrentViewModel = NotesCategoriesViewModel;
        }

        private void NavigateToNotesCategories(DateTime? day)
        {
            NotesCategoriesViewModel.PickDay(day);
            CurrentViewModel = NotesCategoriesViewModel;
        }

        private void NavigateToNotesList(NoteCategoryModel noteCategory, NoteModel note, DateTime? day)
        {
            NotesListViewModel = new NotesListViewModel(noteCategory, NavigateToNotesCategories, note, day);
            CurrentViewModel = NotesListViewModel;
        }

    }
}

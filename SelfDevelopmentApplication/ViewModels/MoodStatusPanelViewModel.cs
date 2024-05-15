using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Database;
using SelfDevelopmentApplication.Helpers;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class MoodStatusPanelViewModel : ViewModelBase
    {
        public ICommand ChangeCurrentMoodProperty { get; set; }
        public ICommand ChangeMoodStarsCommand { get; set; }
        public ICommand ChangeMoodStatusCommand { get; set; }

        private Dictionary<string, GenericCollection<bool>> moodStatusStarsListDictionary = new();
        public Dictionary<string, GenericCollection<bool>> MoodStatusStarsListDictionary
        {
            get => moodStatusStarsListDictionary;
            set
            {
                moodStatusStarsListDictionary = value;
                OnPropertyChanged();
            }
        }

        private MoodStatusModel currentMoodStatus;
        public MoodStatusModel CurrentMoodStatus
        {
            get => currentMoodStatus;
            set
            {
                currentMoodStatus = value;
                OnPropertyChanged();
            }
        }

        private PropertyInfo currentMoodProperty;

        public PropertyInfo CurrentMoodProperty
        {
            get => currentMoodProperty;
            set
            {
                currentMoodProperty = value;
                OnPropertyChanged();
            }
        }

        public MoodStatusPanelViewModel(DateTime currentDate)
        {
            InitializeCommands();
            InitializeCurrentMoodStatusView(currentDate);
        }

        private void NotifyMoodStatusStarsListDictionaryChanged()
        {
            OnPropertyChanged(nameof(MoodStatusStarsListDictionary));
        }

        public void InitializeCurrentMoodStatusView(DateTime currentDate)
        {
            if (MoodStatusStarsListDictionary.Count > 0)
            {
                MoodStatusStarsListDictionary.Clear();
            }
            
            MoodStatusModel moodStatus = DatabaseManager.GetMoodStatus(currentDate);
            if (moodStatus == default(MoodStatusModel)) //
            {
                CurrentMoodStatus = DatabaseManager.AddMoodStatus(currentDate);
            }
            else
            {
                CurrentMoodStatus = moodStatus;
            }

            MoodStatusStarsListDictionary.Add(nameof(MoodStatusModel.Gratitude),
                                              new(new bool[5], NotifyMoodStatusStarsListDictionaryChanged));
            MoodStatusStarsListDictionary.Add(nameof(MoodStatusModel.Joy),
                                              new(new bool[5], NotifyMoodStatusStarsListDictionaryChanged));
            MoodStatusStarsListDictionary.Add(nameof(MoodStatusModel.Stress),
                                              new(new bool[5], NotifyMoodStatusStarsListDictionaryChanged));
            MoodStatusStarsListDictionary.Add(nameof(MoodStatusModel.Anger),
                                              new(new bool[5], NotifyMoodStatusStarsListDictionaryChanged));
            for (int i = 0; i < 5; ++i)
            {
                if (i <= CurrentMoodStatus.Gratitude)
                {
                    MoodStatusStarsListDictionary[nameof(MoodStatusModel.Gratitude)][i] = true;
                }
                if (i <= CurrentMoodStatus.Joy)
                {
                    MoodStatusStarsListDictionary[nameof(MoodStatusModel.Joy)][i] = true;
                }
                if (i <= CurrentMoodStatus.Stress)
                {
                    MoodStatusStarsListDictionary[nameof(MoodStatusModel.Stress)][i] = true;
                }
                if (i <= CurrentMoodStatus.Anger)
                {
                    MoodStatusStarsListDictionary[nameof(MoodStatusModel.Anger)][i] = true;
                }
            }
        }

        private void InitializeCommands()
        {
            ChangeCurrentMoodProperty = new RelayCommand(property =>
            {
                if (CurrentMoodProperty == null || CurrentMoodProperty.Name != (string)property)
                {
                    foreach (PropertyInfo moodProperty in typeof(MoodStatusModel).GetProperties())
                    {
                        if (moodProperty.Name == (string)property)
                        {
                            Debug.WriteLine(moodProperty.Name);

                            CurrentMoodProperty = moodProperty;
                            break;
                        }
                    }
                }
            });
            ChangeMoodStarsCommand = new RelayCommand(parameter =>
            {
                short rating = (short)CurrentMoodProperty.GetValue(CurrentMoodStatus);

                if (parameter != null)
                {
                    rating = (short)parameter;

                    Debug.WriteLine("Nie null" + rating);
                }
                else
                {
                    Debug.WriteLine("Null" + rating);
                }

                for (short i = 0; i < 5; ++i)
                {
                    if (i <= rating)
                    {
                        MoodStatusStarsListDictionary[CurrentMoodProperty.Name][i] = true;
                    }
                    else
                    {
                        MoodStatusStarsListDictionary[CurrentMoodProperty.Name][i] = false;
                    }
                }
            });
            ChangeMoodStatusCommand = new RelayCommand(rating =>
            {
                CurrentMoodProperty.SetValue(CurrentMoodStatus, (short)rating);
                DatabaseManager.UpdateMoodStatus(CurrentMoodStatus);
            });
        }
    }
}

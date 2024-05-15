using SelfDevelopmentApplication.Helpers;
using SelfDevelopmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SelfDevelopmentApplication.Database
{
    static class DatabaseManager
    {
        public static List<TaskModel> GetAllTasks()
        {
            using (var appDbContext = new AppDbContext())
            {
                return appDbContext.Tasks.ToList();
            }
        }

        public static bool AddTask(TaskModel task)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Tasks.Add(task);
                appDbContext.SaveChanges();

                return appDbContext.Tasks.Contains(task);
            }
        }

        public static bool UpdateTask(TaskModel task)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Tasks.Update(task);
                bool updated = appDbContext.ChangeTracker.HasChanges();
                appDbContext.SaveChanges();

                return updated;
            }
        }

        public static void DeleteTask(TaskModel task)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Tasks.Remove(task);
                appDbContext.SaveChanges();
            }
        }

        public static List<TaskCategoryModel> GetAllTasksCategories()
        {
            using (var appDbContext = new AppDbContext())
            {
                return appDbContext.TasksCategories.ToList();
            }
        }

        public static object AddTasksCategory(string categoryName)
        {
            using (var appDbContext = new AppDbContext())
            {
                if (appDbContext.TasksCategories.FirstOrDefault(category => category.Name == categoryName) != null)
                {
                    return null;
                }

                TaskCategoryModel newCategory = new TaskCategoryModel { Name = categoryName };
                appDbContext.TasksCategories.Add(newCategory);
                appDbContext.SaveChanges();

                if(appDbContext.TasksCategories.Contains(newCategory))
                {
                    return newCategory;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool? UpdateTasksCategory(TaskCategoryModel tasksCategory)
        {
            using (var appDbContext = new AppDbContext())
            {
                if (appDbContext.TasksCategories.FirstOrDefault(category => category.Name == tasksCategory.Name) != null)
                {
                    return null;
                }

                appDbContext.TasksCategories.Update(tasksCategory);
                bool updated = appDbContext.ChangeTracker.HasChanges();
                appDbContext.SaveChanges();
                
                return updated;
            }
        }

        public static void DeleteTasksCategory(TaskCategoryModel tasksCategory)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.TasksCategories.Remove(tasksCategory);
                appDbContext.SaveChanges();
            }
        }

        public static bool AddNote(string title, string content, int categoryId, DateTime lastEditDateTime)
        {
            using (var appDbContext = new AppDbContext())
            {
                NoteModel note = new NoteModel
                {
                    Title = title,
                    Content = content,
                    CategoryId = categoryId,
                    LastEditDateTime = lastEditDateTime
                };
                appDbContext.Notes.Add(note);
                appDbContext.SaveChanges();
                       
                return appDbContext.Notes.Contains(note);
            }
        }

        public static bool UpdateNote(NoteModel note)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Notes.Update(note);
                bool updated = appDbContext.ChangeTracker.HasChanges();
                appDbContext.SaveChanges();

                return updated;
            }
        }

        public static void DeleteNote(NoteModel note)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Notes.Remove(note);
                appDbContext.SaveChanges();
            }
        }

        public static bool? AddNotesCategory(string categoryName)
        {
            using (var appDbContext = new AppDbContext())
            {
                if (appDbContext.NotesCategories.FirstOrDefault(category => category.Name == categoryName) != null)
                {
                    return null;
                }

                NoteCategoryModel newCategory = new NoteCategoryModel { Name = categoryName };
                appDbContext.NotesCategories.Add(newCategory);
                appDbContext.SaveChanges();

                return appDbContext.NotesCategories.Contains(newCategory);//
            }
        }

        public static bool? UpdateNotesCategory(NoteCategoryModel noteCategory)
        {
            using (var appDbContext = new AppDbContext())
            {
                if (appDbContext.NotesCategories.FirstOrDefault(category => category.Name == noteCategory.Name) != null)
                {
                    return null;
                }

                appDbContext.NotesCategories.Update(noteCategory);
                bool updated = appDbContext.ChangeTracker.HasChanges();
                appDbContext.SaveChanges();

                return updated;
            }
        }

        public static void DeleteNotesCategory(NoteCategoryModel noteCategory)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.NotesCategories.Remove(noteCategory);
                appDbContext.SaveChanges();
            }
        }

        public static MoodStatusModel GetMoodStatus(DateTime day)
        {
            using (var appDbContext = new AppDbContext())
            {
                return appDbContext.MoodStatuses.FirstOrDefault(m => m.Day == day);
            }
        }

        public static MoodStatusModel AddMoodStatus(DateTime day)
        {
            using (var appDbContext = new AppDbContext())
            {
                MoodStatusModel moodStatus = new()
                {
                    Gratitude = 2,
                    Joy = 2,
                    Stress = 2,
                    Anger = 2,
                    Day = day
                };

                appDbContext.MoodStatuses.Add(moodStatus);
                appDbContext.SaveChanges();

                return moodStatus;//
            }
        }

        public static void UpdateMoodStatus(MoodStatusModel moodStatus)
        {
            using (var appDbContext = new AppDbContext())
            {
                appDbContext.MoodStatuses.Update(moodStatus);
                appDbContext.SaveChanges();
            }
        }

        public static ObservableCollection<NoteModel> FilterNotes (string filteringText, 
                                                                   NoteCategoryModel notesCategory,
                                                                   DateTime? day)
        { 
            using (var appDbContext = new AppDbContext())
            {
                ObservableCollection<NoteModel> notesList = new(appDbContext.Notes.ToList()
                            .Where(note => note.Category.Id == notesCategory.Id)
                            .Where(note => note.Title.Contains(filteringText, StringComparison.OrdinalIgnoreCase) ||
                                       note.Content.Contains(filteringText, StringComparison.OrdinalIgnoreCase))
                            .OrderByDescending(note => note.LastEditDateTime));

                if (day != null)
                {
                    return new(notesList.Where(note => note.LastEditDateTime.Date == day));
                }

                return notesList;
            }
        }

        public static ObservableCollection<NoteModel> FilterNotesByAllProperties(string filteringText)
        {
            using (var appDbContext = new AppDbContext())
            {
                filteringText = filteringText.ToLower();
                Dictionary<int, int> compatibleLettersPerNote = new();
                ObservableCollection<NoteModel> notesList = new(appDbContext.Notes.ToList());
                for (int i = 0; i < notesList.Count; ++i)
                {
                    compatibleLettersPerNote.Add(i, 0);
                    foreach (char c in filteringText)
                    {
                        foreach (char cc in notesList[i].Title)
                        {
                            if (c == char.ToLower(cc))
                            {
                                ++compatibleLettersPerNote[i];
                            }
                        }
                        foreach (char cc in notesList[i].Content)
                        {
                            if (c == char.ToLower(cc))
                            {
                                ++compatibleLettersPerNote[i];
                            }
                        }
                        foreach (char cc in notesList[i].Category.Name)
                        {
                            if (c == char.ToLower(cc))
                            {
                                ++compatibleLettersPerNote[i];
                            }
                        }
                        StringBuilder dateTimeString = new StringBuilder().Append(notesList[i].LastEditDateTime.Day)
                                                                          .Append(notesList[i].LastEditDateTime.Month)
                                                                          .Append(notesList[i].LastEditDateTime.Year)
                                                                          .Append(notesList[i].LastEditDateTime.Hour)
                                                                          .Append(notesList[i].LastEditDateTime.Minute);
                        foreach (char cc in dateTimeString.ToString())
                        {
                            if (c == char.ToLower(cc))
                            {
                                ++compatibleLettersPerNote[i];
                            }
                        }
                    }
                }

                compatibleLettersPerNote = new(compatibleLettersPerNote.OrderByDescending(c => c.Value));
                ObservableCollection<NoteModel> listToReturn = new();
                foreach (KeyValuePair<int, int> kv in compatibleLettersPerNote)
                {
                    if (kv.Value != 0)
                    {
                        listToReturn.Add(notesList[kv.Key]);
                    }
                }

                return listToReturn;
            }
        }

        public static ObservableCollection<NoteCategoryModel> FilterNotesCategories(string filteringText, DateTime? day)
        { 
            using (var appDbContext = new AppDbContext())
            {
                ObservableCollection<NoteCategoryModel> categories = new ObservableCollection<NoteCategoryModel>(appDbContext.NotesCategories.ToList()
                                                        .Where(category => category.Name.Contains(filteringText, StringComparison.OrdinalIgnoreCase))
                                                        .OrderBy(category => category.Name));

                if (day != null)
                {
                    return new(categories.Where(category => category.Notes.ToList().Any(note => note.LastEditDateTime.Date == day.Value)));
                }

                return categories;
            }
        }

        public static ObservableCollection<TaskModel> FilterTasks(string tasksNamesFilteringText, string tasksDescriptionsFilteringText,
                                                                  DateTime dateTimeFrom, DateTime dateTimeTo,
                                                                  GenericCollection<bool> filterStatusesList, GenericCollection<bool> filterPrioritiesList,
                                                                  ObservableCollection<TaskCategoryModel> tasksCategoriesList, GenericCollection<bool> filterCategoriesList)
        {
            using (var appDbContext = new AppDbContext())
            {
                ObservableCollection<TaskModel> list = new ObservableCollection<TaskModel>(appDbContext.Tasks.ToList()
                        .Where(task => task.Name.Contains(tasksNamesFilteringText, StringComparison.OrdinalIgnoreCase))
                        .Where(task => task.Description.Contains(tasksDescriptionsFilteringText, StringComparison.OrdinalIgnoreCase))
                        .Where(task => task.AssignedDateTime >= dateTimeFrom && task.AssignedDateTime <= dateTimeTo));

                if (list.Count != 0)
                {
                    bool taskToDelete = true;
                    for (int i = list.Count - 1; i >= 0; --i)
                    {
                        for (int j = 0; j < 3; ++j)
                        {
                            if (filterStatusesList[j] && ((int)list[i].Status) == j)
                            {
                                for (int k = 0; k < 4; ++k)
                                {
                                    if (filterPrioritiesList[k] && ((int)list[i].Priority) == k)
                                    {
                                        for (int l = 0; l < tasksCategoriesList.Count; ++l)
                                        {
                                            if (filterCategoriesList[l] && list[i].CategoryId == tasksCategoriesList[l].Id)
                                            {
                                                list[i].Category = appDbContext.TasksCategories.Find(list[i].CategoryId);
                                                taskToDelete = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (taskToDelete)
                        {
                            list.RemoveAt(i);
                        }
                        else
                        {
                            taskToDelete = true;
                        }
                    }
                }

                return list;
            }
        }

        public static ObservableCollection<TaskCategoryModel> FilterTasksCategories(string filteringText)
        {
            using (var appDbContext = new AppDbContext())
            {
                return new ObservableCollection<TaskCategoryModel>(appDbContext.TasksCategories.ToList()
                        .Where(category => category.Name.Contains(filteringText, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(category => category.Name));
            }
        }

        public static int GetDefaultTasksCategoryId()
        {
            using (var appDbContext = new AppDbContext())
            {
                if (appDbContext.TasksCategories.FirstOrDefault(c => c.Name == "General") == null)
                {
                    appDbContext.TasksCategories.Add(new TaskCategoryModel { Name = "General" });
                    appDbContext.SaveChanges();
                }
                return appDbContext.TasksCategories.FirstOrDefault(c => c.Name == "General").Id;
            }
        }
    }
}
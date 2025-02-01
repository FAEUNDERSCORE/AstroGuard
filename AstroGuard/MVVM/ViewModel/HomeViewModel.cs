using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AstroGuard.Core;
using AstroGuard.MVVM.Model;
using AstroGuard.Services;
using Newtonsoft.Json;

namespace AstroGuard.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private readonly IPatchNoteService _patchNoteService;
        private ObservableCollection<PatchNote> _patchNotes;
        public ObservableCollection<PatchNote> PatchNotes
        {
            get => _patchNotes;
            set
            {
                if (_patchNotes != value)
                {
                    _patchNotes = value;
                    OnPropertyChanged(nameof(PatchNotes));
                }
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        private bool patchNotesLoaded = false;
        public bool PatchNotesLoaded
        {
            get => patchNotesLoaded;
            set
            {
                if (patchNotesLoaded != value)
                {
                    patchNotesLoaded = value;
                    OnPropertyChanged(nameof(PatchNotesLoaded));
                }
            }
        }

        public ICommand LoadPatchNotesCommand { get; }

        public HomeViewModel(IPatchNoteService patchNoteService)
        {
            _patchNoteService = patchNoteService;
            PatchNotes = new ObservableCollection<PatchNote>();
            LoadPatchNotesCommand = new AsyncRelayCommand(async _ => await LoadPatchNotes(), _ => !PatchNotesLoaded);
            LoadPatchNotesCommand.Execute(null);
        }

        private async Task LoadPatchNotes()
        {
            IsLoading = true;
            try
            {
                var updates = await _patchNoteService.GetPatchNotesAsync();
                PatchNotes.Clear();
                foreach (var patch in updates)
                {
                    PatchNotes.Add(patch);
                }
                PatchNotesLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load patch notes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if (Application.Current != null)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

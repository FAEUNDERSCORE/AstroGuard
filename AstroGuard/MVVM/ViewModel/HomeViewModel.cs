using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using AstroGuard.MVVM.Model;
using Newtonsoft.Json;

namespace AstroGuard.MVVM.ViewModel
{
    public class HomeViewModel
    {
        public ObservableCollection<PatchNote> PatchNotes { get; set; }

        public HomeViewModel() 
        { 
            PatchNotes = new ObservableCollection<PatchNote>();
            LoadPatchNotes();
        }

        private async void LoadPatchNotes()
        {
            //string url = "https://ton-repo.github.io/ton-projet/patch-notes.json";
            //using (HttpClient client = new HttpClient())
            //{
            //    string json = await client.GetStringAsync(url);
            //    var updates = JsonConvert.DeserializeObject<List<PatchNote>>(json);

            //    foreach (var patch in updates)
            //    {
            //        PatchNotes.Add(patch);
            //    }
            //}
        }
    }
}

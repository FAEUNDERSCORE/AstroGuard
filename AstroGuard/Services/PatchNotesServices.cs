using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AstroGuard.MVVM.Model;
using Newtonsoft.Json;

namespace AstroGuard.Services
{
    public interface IPatchNoteService
    {
        Task<List<PatchNote>> GetPatchNotesAsync();
    }

    public class PatchNoteService : IPatchNoteService
    {
        private readonly HttpClient _httpClient;

        public PatchNoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PatchNote>> GetPatchNotesAsync()
        {
            string url = "https://faeunderscore.github.io/AstroGuard/patch-notes.json";
            string json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<PatchNote>>(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TDT.Core.DTO;

namespace TDT_Music.Models
{
    public class SongModel
    {
        private readonly string _apiBaseUrl;
        private readonly HttpClient _httpClient;

        public SongModel(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<SongDTO>> GetAllSongsFromExternalAPI()
        {
            var response = await _httpClient.GetAsync("api/v1/songs/load");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var songs = JsonConvert.DeserializeObject<List<SongDTO>>(content);
                return songs;
            }
            return new List<SongDTO>();
        }

        public async Task<SongDTO> GetSongFromExternalAPI(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/songs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var song = JsonConvert.DeserializeObject<SongDTO>(content);
                return song;
            }
            return null;
        }

        public async Task<bool> UpdateSongInExternalAPI(int id, SongDTO updatedSong)
        {
            var songJson = JsonConvert.SerializeObject(updatedSong);
            var content = new StringContent(songJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/v1/songs/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSongInExternalAPI(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/songs/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateSongInExternalAPI(SongDTO song)
        {
            var songJson = JsonConvert.SerializeObject(song);
            var content = new StringContent(songJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/v1/songs", content);
            return response.IsSuccessStatusCode;
        }
    }
}

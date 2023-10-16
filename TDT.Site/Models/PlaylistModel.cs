using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TDT.Core.DTO;
using TDT.Core.ModelClone;

namespace TDT_Music.Models
{
    public class PlaylistModel
    {
        private readonly string _apiBaseUrl;
        private readonly HttpClient _httpClient;
        public List<Playlist> Playlists { get; set; }
        public PlaylistModel(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<PlaylistDTO>> GetAllPlaylistsFromExternalAPI()
        {
            var response = await _httpClient.GetAsync("api/v1/Playlists/load");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var playlists = JsonConvert.DeserializeObject<List<PlaylistDTO>>(content);
                return playlists;
            }
            return new List<PlaylistDTO>();
        }

        public async Task<PlaylistDTO> GetPlaylistFromExternalAPI(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/Playlists/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var playlist = JsonConvert.DeserializeObject<PlaylistDTO>(content);
                return playlist;
            }
            return null;
        }

        public async Task<bool> UpdatePlaylistInExternalAPI(int id, PlaylistDTO updatedPlaylist)
        {
            var playlistJson = JsonConvert.SerializeObject(updatedPlaylist);
            var content = new StringContent(playlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/v1/Playlists/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePlaylistInExternalAPI(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Playlists/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreatePlaylistInExternalAPI(PlaylistDTO playlist)
        {
            var playlistJson = JsonConvert.SerializeObject(playlist);
            var content = new StringContent(playlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/v1/Playlists", content);
            return response.IsSuccessStatusCode;
        }
    }
}

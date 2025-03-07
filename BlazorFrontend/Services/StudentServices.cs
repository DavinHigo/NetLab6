using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using SchoolLibrary;

namespace BlazorFrontend.Services
{
    public class StudentServices
    {
        private readonly HttpClient _httpClient;

        public StudentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get students by school
        public async Task<List<Student>> GetStudentsBySchoolAsync(string school)
        {
            var response = await _httpClient.GetAsync($"{Constants.BaseUrl}api/students/school/{school}");
            response.EnsureSuccessStatusCode(); // Ensure the request was successful

            var students = await response.Content.ReadFromJsonAsync<List<Student>>();
            return students ?? new List<Student>();
        }

        // Method to get student count by school
        public async Task<List<SchoolReport>> GetStudentCountBySchoolAsync()
        {
            var response = await _httpClient.GetAsync($"{Constants.BaseUrl}api/students/count-by-school");
            response.EnsureSuccessStatusCode(); // Ensure the request was successful

            var report = await response.Content.ReadFromJsonAsync<List<SchoolReport>>();
            return report ?? new List<SchoolReport>();
        }
    }
}
using System.Net.Http;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class CompleteClass
{
    public DateTime Datetimestart { get; set; }

    public DateTime Datetimeend { get; set; }

    public string Classroom { get; set; }

    public string Coursename { get; set; }

    public string Description { get; set; }

    public string Nameteacher { get; set; }
}
public class DataGetter
{
    public const string API_STRING = "http://192.168.56.1:8082/campusorientation";
    public CompleteClass GetCompleteByClassroom(string classroom)
    {
        var httpClient = new HttpClient();

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, API_STRING + "/api/completeclass");

            var response = httpClient.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            using var stream = response.Content.ReadAsStringAsync();

            CompleteClass selectedClass = null;
            stream.Result.ToString().Split('{').ToList().ForEach(c =>
            {
                if (c.Contains(classroom))
                {
                    selectedClass = JsonUtility.FromJson<CompleteClass>("{" + c.Remove(c.Length - 1));
                    return;
                }
            });

            if (selectedClass == null) return new CompleteClass
            {
                Datetimestart = DateTime.Now,
                Datetimeend = DateTime.Now,
                Classroom = classroom,
                Coursename = "Nenhuma aula cadastrada",
                Description = "",
                Nameteacher = ""
            };

            return selectedClass;

        }
        catch (Exception ex)
        {
            return new CompleteClass
            {
                Datetimestart = DateTime.Now,
                Datetimeend = DateTime.Now,
                Classroom = classroom,
                Coursename = "Erro ao carregar aula",
                Description = "",
                Nameteacher = ""
            };
        }
    }
}
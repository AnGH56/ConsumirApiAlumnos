using System;
using System.Collections.Generic;
using ConsumirApiAlumnos.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsumirApiAlumnos.Controllers
{
    internal class AlumnoController
    {
        static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5170/")
        };

        public async Task ObtenerAlumnosAsync() 
        {
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("AlumnosApi/Alumnos");

            if (response.IsSuccessStatusCode)
            {
                var al = JsonConvert.DeserializeObject<List<Alumno>>(await response.Content.ReadAsStringAsync());
                foreach (var alumnos in al)
                {
                    Console.WriteLine($"ID: {alumnos.Id} \n Nombre: {alumnos.Nombre} \n Edad:{alumnos.Edad} \n " +
                        $"Fecha de Nacimiento: {alumnos.FechaNacimiento}");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
                }
            }
        }

        public async Task EliminarAlumnosAsync(int Id) 
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine($"ID:{Id}");
            HttpResponseMessage response = await client.DeleteAsync("AlumnosApi/Alumnos/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Alumno con ID {Id} eliminado correctamente.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Alumno con ID {Id} no encontrado.");
            }
            else
            {
                Console.WriteLine($"Error al eliminar el alumno con ID {Id}: {response.ReasonPhrase}");
            }

        }
    }
}

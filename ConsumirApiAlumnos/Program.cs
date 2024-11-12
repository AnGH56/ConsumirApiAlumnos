using System;
using ConsumirApiAlumnos.Controllers;
using ConsumirApiAlumnos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApiAlumnos
{
    internal class Program
    {
        public enum Menu{VerAlumnos=1, AgregarAlumno, ActualizarAlumno,EliminarAlumno,Salir }
        static void Main(string[] args)
        {
            AlumnoController alctrl = new AlumnoController();
            Alumno ali = new Alumno();

            while (true)
            {
                Console.WriteLine("- - B I E N V E N I D O - -");
                Console.WriteLine("¿Qué deseas hacer?");

                switch (Seleccion())
                {
                    case Menu.VerAlumnos:
                        Console.WriteLine("1) Ver Alumnos");
                        alctrl.ObtenerAlumnosAsync().Wait();
                        break;
                    case Menu.AgregarAlumno:
                        Console.WriteLine("2) Insertar Alumnos");

                        Console.Write("Ingrese el nombre del alumno: ");
                        ali.Nombre = Console.ReadLine();
                        Console.Write("Edad del alumno: ");
                        ali.Edad= Convert.ToInt32(Console.ReadLine());
                        Console.Write("Fecha de nacimiento del alumno (yyyy-mm-dd): ");
                        ali.FechaNacimiento=Convert.ToDateTime(Console.ReadLine());

                        alctrl.InsertarAlumnoAsync(ali).Wait();
                        break;
                    case Menu.ActualizarAlumno:
                        Console.WriteLine("3) Actualizar Alumno");
                        Console.Write("Ingrese el ID del alumno a Actualizar: ");
                        int Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ingrese el nombre del alumno: ");
                        ali.Nombre = Console.ReadLine();
                        Console.Write("Edad del alumno: ");
                        ali.Edad = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Fecha de nacimiento del alumno (yyyy-mm-dd): ");
                        ali.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());

                        alctrl.ActualizarAlumnoAsync(Id,ali).Wait();

                        break;
                    case Menu.EliminarAlumno:
                        Console.WriteLine("4) Eliminar Alumno");
                        Console.WriteLine("Inserta el ID del alumno que deseas eliminar:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        alctrl.EliminarAlumnosAsync(id).Wait();
                        break;
                    case Menu.Salir:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }

        static Menu Seleccion() 
        {
            Console.WriteLine("1) Ver Alumnos");
            Console.WriteLine("2) Insertar Alumno");
            Console.WriteLine("3) Actualizar Alumno");
            Console.WriteLine("4) Eliminar Alumno");
            Console.WriteLine("5) Salir");

            Menu opc = (Menu)Convert.ToInt32(Console.ReadLine());

            return opc;
        }
    }
}

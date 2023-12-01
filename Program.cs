using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantalla07
{
    internal class Program
    {
        
            static List<Almacen> almacenes = new List<Almacen>();

            static void Main()
            {
                int opcion;

                do
                {
                    MostrarMenuGestionAlmacenes();
                    opcion = ObtenerOpcion();

                    switch (opcion)
                    {
                        case 1:
                            AgregarAlmacen();
                            break;
                        case 2:
                            EliminarAlmacen();
                            break;
                        case 3:
                            MostrarAlmacenes();
                            break;
                        case 4:
                            Console.WriteLine("Volviendo al Menú Principal");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                            break;
                    }

                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();

                } while (opcion != 4);
            }

            static void MostrarMenuGestionAlmacenes()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("||       Gestionar Almacenes - Mi Tiendita      ||");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("|| 1. Agregar Almacén                           ||");
                Console.WriteLine("|| 2. Eliminar Almacén                          ||");
                Console.WriteLine("|| 3. Mostrar Almacenes                         ||");
                Console.WriteLine("|| 4. Volver al Menú Principal                  ||");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Seleccione una opción:");
            }

            static int ObtenerOpcion()
            {
                int opcion;
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
                return opcion;
            }

            static void AgregarAlmacen()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Agregar Almacén =====");
                Console.WriteLine("--------------------------------------------------");

                Console.Write("Ingrese el nombre del almacén: ");
                string nombre = Console.ReadLine();

                almacenes.Add(new Almacen(nombre));

                Console.WriteLine("\nConfirmación: Almacén agregado exitosamente.");
            }

            static void EliminarAlmacen()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Eliminar Almacén =====");
                Console.WriteLine("--------------------------------------------------");

                if (almacenes.Count == 0)
                {
                    Console.WriteLine("No hay almacenes para eliminar.");
                    return;
                }

                Console.WriteLine("Almacenes disponibles:");

                for (int i = 0; i < almacenes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {almacenes[i].Nombre}");
                }

                Console.Write("\nIngrese el número del almacén a eliminar: ");
                int indiceEliminar;

                while (!int.TryParse(Console.ReadLine(), out indiceEliminar) || indiceEliminar < 1 || indiceEliminar > almacenes.Count)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                string nombreEliminar = almacenes[indiceEliminar - 1].Nombre;
                almacenes.RemoveAt(indiceEliminar - 1);

                Console.WriteLine($"\nConfirmación: Almacén '{nombreEliminar}' eliminado exitosamente.");
            }

            static void MostrarAlmacenes()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Mostrar Almacenes =====");
                Console.WriteLine("--------------------------------------------------");

                if (almacenes.Count == 0)
                {
                    Console.WriteLine("No hay almacenes para mostrar.");
                }
                else
                {
                    Console.WriteLine("Almacenes Actuales:");

                    foreach (var almacen in almacenes)
                    {
                        Console.WriteLine($"- {almacen.Nombre}");
                    }
                }
            }

    // Definición de la clase Almacen
    class Almacen
        {
            public string Nombre { get; set; }

            public Almacen(string nombre)
            {
                Nombre = nombre;
            }
        }
    }

}
    


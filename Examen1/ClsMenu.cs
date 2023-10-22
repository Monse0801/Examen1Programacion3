using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsMenu
    {
        private static int opcion = 0;


        public static void Desplegar()
        {

             do
             {
                Console.Clear();
                Console.WriteLine("1- Inicializar Arreglos");
                Console.WriteLine("2- Agregar Empleados");
                Console.WriteLine("3- Modificar Empleados");
                Console.WriteLine("4- Consultar Empleados");
                Console.WriteLine("5- Borrar Empleados");
                Console.WriteLine("6- Reportes");
                Console.WriteLine("7- Salir");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese una opcion ");

                int.TryParse(Console.ReadLine(), out opcion); // Lee la opcion a elegir

                switch (opcion)
                {
                    case 1: ClsEmpleado.InicializarArreglos(); break;
                    case 2: ClsEmpleado.Agregar(); break;
                    case 3: ClsEmpleado.Modificar(); break;
                    case 4: ClsEmpleado.Consultar(); break;
                    case 5: ClsEmpleado.Borrar(); break;
                    case 6: ClsEmpleado.Reportes(); break;



                    case 7: 
                        Console.Clear();
                        Console.WriteLine("Cerrando sistema");
                        Console.ReadLine();
                        break;


                    default:
                        break;
                }


            }
                  while (opcion != 7);

        }




    }
}

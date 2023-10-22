using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class ClsEmpleado
    {
        static private int cantidad = 10;
        static public string[] cedula = new string[cantidad];
        static public string[] nombre = new string[cantidad];
        static public string[] direccion = new string[cantidad];
        static public int[] telefono = new int[cantidad];
        static public float[] salario = new float[cantidad];
        static byte indice = 0;
        static int pos = 1;

        public static void Agregar()
        {

            char resp;
             
            do
            {
                Console.Clear();
                Console.WriteLine($"Ingrese una Cedula ({pos}):  ");
                cedula[indice] = Console.ReadLine();

                Console.WriteLine($"Ingrese un Nombre ({pos}):  ");
                nombre[indice] = Console.ReadLine();

                Console.WriteLine("Ingrese una Direccion: ");
                direccion[indice] = Console.ReadLine();

                Console.WriteLine($"Telefono: ");
                int.TryParse(Console.ReadLine(), out telefono[indice]);

                Console.WriteLine($"salario: ");
                float.TryParse(Console.ReadLine(), out salario[indice]);

                indice++;
                pos++;

                Console.WriteLine("Empleado Agregado");
                Console.WriteLine(" ");
                Console.WriteLine("Desea ingresar otro empleado? (s/n)");
                resp = Convert.ToChar(Console.ReadLine().ToLower());

                switch (resp)
                {
                    case 's':
                    case 'n': break;

                    default:
                        Console.WriteLine(" Opcion Incorrecta ");
                        resp = 'n';
                        break;
                }



            } while (resp.Equals('s'));



        }


        public static void Consultar()
        {
            Console.Clear();
            char resp;

            do
            {
                Console.Clear();
                string ced = "";
                Console.WriteLine("Digite cedula a consultar: ");
                ced = Console.ReadLine();

                for (int i = 0; i < cantidad; i++)
                {
                    if (ced.Equals(cedula[i]))
                    {
                        Console.Write($"Nombre: {nombre[i]}");
                        Console.WriteLine(" ");
                        Console.Write($"Cedula: {cedula[i]}");
                        Console.WriteLine(" ");
                        Console.Write($"Direccion: {direccion[i]}");
                        Console.WriteLine(" ");
                        Console.Write($"Telefono: {telefono[i]}");
                        Console.WriteLine(" ");
                        Console.Write($"Salario: {salario[i]}");
                        Console.WriteLine(" ");
                        break;
                    }
                }

                Console.WriteLine("Empleado encontrado");
                Console.WriteLine(" ");
                Console.WriteLine("Desea consultar otro empleado? (s/n)");
                resp = Convert.ToChar(Console.ReadLine().ToLower());

                switch (resp)
                {
                    case 's':
                    case 'n': break;

                    default:
                        Console.WriteLine(" Opcion Incorrecta ");
                        resp = 'n';
                        break;
                }



            } while (resp.Equals('s'));
           


        }



        public static void Modificar()
        {
            Console.Clear();
            string ced = "";
            Console.WriteLine("Digite la cedula: ");
            ced = Console.ReadLine();

            for (int i = 0; i < cantidad; i++)
            {
                if (ced.Equals(cedula[i]))
                {
                    Console.Write("Digite un nuevo nombre: ");
                    nombre[i] = Console.ReadLine();
                    Console.Write("Digite una nueva direccion: ");
                    direccion[i] = Console.ReadLine();
                    Console.Write("Digite un nuevo telefono: ");
                    int.TryParse(Console.ReadLine(), out telefono[i]);
                    break;
                }
            }


        }
        public static void Borrar()
        {
            Console.Clear();
            string ced = "";
            Console.Write("Ingrese la cedula a borrar: ");
            ced = Console.ReadLine();

            for (int i = 0; i < cantidad ; i++)
            {
                if (ced.Equals(cedula[i]))
                {
                    
                    for (int j = i; j < cantidad -1; j++)
                    {
                        nombre[j] = nombre[j + 1];
                        cedula[j] = cedula[j + 1];
                        direccion[j] = direccion[j + 1];
                        telefono[j] = telefono[j + 1];
                        salario[j] = salario[j + 1];
                    }
                    cantidad--;

                    nombre[cantidad] = null;
                    cedula[cantidad] = null;
                    direccion[cantidad] = null;
                    telefono[cantidad] = 0;
                    salario[cantidad] = 0;

                    Console.WriteLine("Registro eliminado con éxito.");
                    pos = 1;

                    break;
                }
                
            }





        }


        public static void InicializarArreglos()
        {
            cedula = Enumerable.Repeat("", cantidad).ToArray();
            nombre = Enumerable.Repeat("", cantidad).ToArray();
            direccion = Enumerable.Repeat("", cantidad).ToArray();
            telefono = Enumerable.Repeat(0, cantidad).ToArray();
            salario = Enumerable.Repeat(0f, cantidad).ToArray();

            Console.Clear();

            Console.WriteLine("Sistema Inicializado ");
            Console.ReadLine();



        }



        public static void Reportes()
        {
            int opcion = 0;
            do
            {
                
                Console.WriteLine("Menu de Reportes");
                Console.WriteLine(" ");
                Console.WriteLine("1- Consultar Empleados");
                Console.WriteLine("2- Listar todos los empleados");
                Console.WriteLine("3- Calcular y mostrar el promedio de los salarios");
                Console.WriteLine("4- Calcular y mostrar el salario más alto y el más bajo de todos los empleados");
                Console.WriteLine("5- Ir al menu principal");
                Console.WriteLine(" ");
                Console.Write("Ingrese una opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);


                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Consultar();
                        break;
                    
                    case 2:
                        Console.Clear();
                        Listar();
                        break;

                    case 3:
                        Console.Clear();
                        promediosalarios();
                        break;

                    case 4:
                        Console.Clear();
                        MontosSalariosAltosBajos();
                        break;

                    case 5:
                        Console.Clear();
                        ClsMenu.Desplegar();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(" ");
                        Console.WriteLine($"Opcion no valida");
                        Console.WriteLine(" ");
                        Console.ReadKey();
                        break;

                }


            } while (opcion != 5);



        }


       
        public static void Listar()
        {
            char resp;
            do
            {
                string[] nombresOrdenados = (string[])nombre.Clone();
                Array.Sort(nombresOrdenados);

                // Recorrer la lista ordenada de nombres e imprimir los datos correspondientes
                for (int i = 0; i < nombresOrdenados.Length; i++)
                {
                    // Encontrar el índice del nombre en el array original
                    int indiceOriginal = Array.IndexOf(nombre, nombresOrdenados[i]);

                    if (indiceOriginal >= 0 && !string.IsNullOrWhiteSpace(cedula[indiceOriginal]))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"Cedula: {cedula[indiceOriginal]}");
                        Console.WriteLine($"Nombre: {nombresOrdenados[i]}");
                        Console.WriteLine($"Direccion: {direccion[indiceOriginal]}");
                        Console.WriteLine($"Telefono: {telefono[indiceOriginal]}");
                        Console.WriteLine($"Salario: {salario[indiceOriginal]}");
                        Console.WriteLine(" ");
                    }
                }

                Console.WriteLine(" ");
                Console.WriteLine("Desea volver a listar? (s/n)");
                resp = Convert.ToChar(Console.ReadLine().ToLower());

                switch (resp)
                {
                    case 's':
                    case 'n': break;

                    default:
                        Console.WriteLine(" Opcion Incorrecta ");
                        resp = 'n';
                        break;
                }



            } while (resp.Equals('s'));





           
            
        }

        public static void promediosalarios()
        {

            char resp;
            do
            {

                float suma = 0f;

                for (int i = 0; i < cantidad; i++)
                {
                    suma += salario[i];
                }

                float promedio = suma / cantidad;

                Console.WriteLine($"El promedio de los salarios corresponde a : {promedio}");
                Console.WriteLine(" ");

                Console.WriteLine(" ");
                Console.WriteLine("Desea volver a ejecutar? (s/n)");
                resp = Convert.ToChar(Console.ReadLine().ToLower());

                switch (resp)
                {
                    case 's':
                    case 'n': break;

                    default:
                        Console.WriteLine(" Opcion Incorrecta ");
                        resp = 'n';
                        break;
                }



            } while (resp.Equals('s'));




        }


        public static void MontosSalariosAltosBajos()
        {
            char resp;
            do
            {

                float max = salario[0];
                float min = salario[0];

                for (int i = 0; i < cantidad; i++)
                {
                    if (salario[i] > max)
                    {
                        max = salario[i];
                    }

                    if (salario[i] < min && salario[i] != 0)
                    {
                        min = salario[i];
                    }
                }

                Console.WriteLine($"El salario máximo encontrado es: {max}");
                Console.WriteLine($"El salario mínimo encontrado es: {min}");
                Console.WriteLine(" ");

                Console.WriteLine(" ");
                Console.WriteLine("Desea volver a ejecutar? (s/n)");
                resp = Convert.ToChar(Console.ReadLine().ToLower());

                switch (resp)
                {
                    case 's':
                    case 'n': break;

                    default:
                        Console.WriteLine(" Opcion Incorrecta ");
                        resp = 'n';
                        break;
                }



            } while (resp.Equals('s'));



        }


    }
}

using System;

namespace MiProyecto
{
    public static class Utils
    {
        // Función simplificada para Console.ReadLine
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        // Función para leer y convertir a entero
        public static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        // Función para leer y convertir a double
        public static double ReadDouble()
        {
            return Convert.ToDouble(Console.ReadLine());
        }

        // Función simplificada para Console.WriteLine
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void Salir()
        {
            WriteLine("\n\n");
            WriteLine("[Y] - Regresar al menú principal");
            WriteLine("[N] - Salir del programa");
            char opcion = ReadLine().ToUpper()[0];
            if (opcion == 'Y')
                Menu.MostrarMenu();
            else
                Environment.Exit(0);
        }
        public static List<double> LeerDatos()
        {
            var lista = new List<double>();
            WriteLine("Ingresa datos numéricos. Ingresa 'F' para finalizar:");
            int contador = 1;
            while (true)
            {
                WriteLine($"Dato {contador++}: ");
                string s = ReadLine();
                if (string.Equals(s, "F", StringComparison.OrdinalIgnoreCase))
                    break;
                if (double.TryParse(s, out double v))
                    lista.Add(v);
                else
                {
                    WriteLine("Entrada inválida. Intenta de nuevo.");
                    contador--;
                }
            }
            return lista;
        }
    }
}
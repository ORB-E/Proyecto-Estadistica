using static MiProyecto.Utils;
using static MiProyecto.Menu;

namespace MiProyecto
{
    class TecnicaConteo
    {
        public static void Combinaciones()
        {
            Clear();
            WriteLine("\t\tCombinaciones");
            WriteLine("Ingresa la cantidad de formas (n)");
            int n = ReadInt();
            WriteLine("Objetos del conjunto (r)");
            int r = ReadInt();
            long resultado = 1, resultado2 = 1, resultado3 = 1;
            for (int i = 1; i <= n; i++) resultado *= i;
            for (int i = 1; i <= r; i++) resultado2 *= i;
            for (int i = 1; i <= (n - r); i++) resultado3 *= i;
            resultado /= (resultado2 * resultado3);

            WriteLine($"El resultado de  combinasciones {n}C{r} es: {resultado}");
            Salir();
        }
        public static void Combinaciones1Dato()
        {
            Clear();
            WriteLine("\t\tCombinaciones");
            WriteLine("Ingresa la cantidad de formas (n)");
            string s = ReadLine();
            long resultado = 1;
            for (int i = 1; i <= s.Length; i++) resultado *= i;
            WriteLine($"El resultado de combinasciones es: {resultado}");
            Salir();
        }
        public static void Permutaciones()
        {
            Clear();
            WriteLine("\t\tPermutaciones");
            WriteLine("Ingresa la cantidad de formas (n)");
            int n = ReadInt();
            WriteLine("Objetos del conjunto (r)");
            int r = ReadInt();
            WriteLine("Ingresa la cantidad de elementos");
            long resultado = 1, resultado2 = 1;
            for (int i = 1; i <= n; i++) resultado *= i;
            for (int i = 1; i <= (n - r); i++) resultado2 *= i;
            resultado /= resultado2;

            WriteLine($"El resultado de  permutaciones {n}P{r} es: {resultado}");

            Salir();
        }
        public static void PrincipioAditivo()
        {
            Clear();
            WriteLine("\t\tPrincipio Aditivo");
            WriteLine("Escribe valores del conjunto 'A', 'f' para finalizar");

            var listaA = LeerDatos();
            Clear();
            WriteLine("\t\tPrincipio Aditivo");

            WriteLine("Escribe valores del conjunto 'B', 'f' para finalizar");
            var listaB = LeerDatos();

            if (listaA.Count == 0 && listaB.Count == 0)
            {
                WriteLine("No se puede realizar la operación, uno de los conjuntos está vacío.");
                Salir();
            }

            int sumaA = 1, sumaB = 1;
            foreach (int i in listaB)
            {
                sumaB *= i;
            }
            foreach (int i in listaA)
            {
                sumaA *= i;
            }
            Clear();
            WriteLine("\t\tPrincipio Aditivo");
            WriteLine($"El resultado es: {sumaA + sumaB}");

            Salir();
        }
        public static void PrincipioMultiplicativo()
        {
            Clear();
            WriteLine("\t\tPrincipio Multiplicativo");
            var lista = LeerDatos();

            int producto = 1;
            foreach (int i in lista)
            {
                producto *= i;
            }
            Clear();
            WriteLine("\t\tPrincipio Multiplicativo");
            WriteLine($"El resultado es: {producto}");

            Salir();
        }
    }
}
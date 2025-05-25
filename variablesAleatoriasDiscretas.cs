using static MiProyecto.Utils;

namespace MiProyecto
{
    class VariablesAleatoriasDiscretas
    {
        public static void EsperanzaMatematica()
        {
            var datos = LeerDatos();
            double resultado = 0;
            for (int i = 1; i <= datos.Count; i++)
            {
                resultado += (datos[i - 1] * i);
            }
            resultado /= datos.Count;
            WriteLine($"La esperanza matemática es: {resultado}");
            Salir();
        }

        public static void Varianza()
        {
            Clear();
            WriteLine("\t\tVarianza");
            var datos = LeerDatos();
            int n = datos.Count;
            if (n == 0)
            {
                WriteLine("No hay datos para calcular varianza.");
                return;
            }

            double media = datos.Average();

            double sumaCuadrados = datos
                .Select(x => Math.Pow(x - media, 2))
                .Sum();

            double varianza = sumaCuadrados / (n - 1);

            double desviacion = Math.Sqrt(varianza);

            Clear();
            WriteLine("\t\tVarianza");
            WriteLine($"Media: {media:F2}");
            WriteLine($"Varianza (muestral): {varianza:F2}");
            WriteLine($"Desviación estándar: {desviacion:F2}");
            Salir();
        }
    }
}
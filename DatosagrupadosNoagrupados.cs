<<<<<<< HEAD
using static MiProyecto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiProyecto
{
    class DatosAgrupadosNoAgrupados
    {
        public static void DatosNoAgrupados()
        {
            var datos = LeerDatos();

            if (datos.Count == 0)
            {
                WriteLine("No hay datos para analizar.");
                Salir();
            }

            datos.Sort();

            if (datos.Count <= 30)
            {
                Clear();
                WriteLine("\t\tDatos no agrupados:");
                CalcularEstadisticasNoAgrupadas(datos);
            }
            else
            {
                Clear();
                WriteLine("\t\tDatos agrupados:");
                CalcularFrecuenciasAgrupadas(datos);
            }

            Salir();
        }

        private static void CalcularEstadisticasNoAgrupadas(List<double> datos)
        {
            int n = datos.Count;
            double media = datos.Average();
            double mediana = (n % 2 == 0)
                ? (datos[n / 2 - 1] + datos[n / 2]) / 2.0
                : datos[n / 2];

            var freq = datos.GroupBy(x => x)
                            .Select(g => new { Valor = g.Key, fi = g.Count() })
                            .OrderBy(g => g.Valor)
                            .ToList();

            WriteLine("Valor\tfi\tfr\tFa\tFra");
            int Fa = 0;
            foreach (var f in freq)
            {
                Fa += f.fi;
                double fr = (double)f.fi / n;
                double Fra = (double)Fa / n;
                WriteLine($"{f.Valor}\t{f.fi}\t{fr:P2}\t{Fa}\t{Fra:P2}");
            }

            WriteLine($"\nTotal de datos: {n}");
            WriteLine($"Media: {media:F2}");
            WriteLine($"Mediana: {mediana:F2}");
            int maxF = freq.Max(f => f.fi);
            var modas = freq.Where(f => f.fi == maxF).Select(f => f.Valor).ToList();
            WriteLine(modas.Count == 1
                ? $"Moda: {modas[0]} (f={maxF})"
                : $"Modas: {string.Join(", ", modas)} (f={maxF})");
            double varianza = datos.Select(x => Math.Pow(x - media, 2)).Sum() / (n - 1);
            double desviacion = Math.Sqrt(varianza);
            WriteLine($"Varianza muestral: {varianza:F2}");
            WriteLine($"Desviación estándar: {desviacion:F2}");
        }

        private static void CalcularFrecuenciasAgrupadas(List<double> datos)
        {
            datos.Sort();
            int n = datos.Count;
            double min = datos.First();
            double max = datos.Last();
            int k = (int)Math.Ceiling(1 + 3.32 * Math.Log10(n));
            double h = (max - min) / k;

            var clases = new List<(double Li, double Ls, int fi)>();
            for (int i = 0; i < k; i++)
            {
                double Li = min + i * h;
                double Ls = (i == k - 1) ? max : Li + h;
                clases.Add((Li, Ls, 0));
            }

            foreach (double dato in datos)
            {
                int idx = clases.FindIndex(c => dato >= c.Li && dato <= c.Ls);
                var c = clases[idx];
                clases[idx] = (c.Li, c.Ls, c.fi + 1);
            }

            WriteLine("Clase\t\txi\tfi\tfr\tFa\tFra");
            int Fa = 0;
            foreach (var c in clases)
            {
                Fa += c.fi;
                double xi = (c.Li + c.Ls) / 2;
                double fr = (double)c.fi / n;
                double Fra = (double)Fa / n;
                WriteLine($"{c.Li:0.##}-{c.Ls:0.##}\t{xi:0.##}\t{c.fi}\t{fr:P2}\t{Fa}\t{Fra:P2}");
            }
            WriteLine($"\nIntervalo: {h:F2}");
            WriteLine($"Media agrupada: {clases.Sum(c => ((c.Li + c.Ls)/2) * c.fi) / n:0.##}");
            var cm = clases.OrderByDescending(c => c.fi).First();
            int im = clases.IndexOf(cm);
            double modaAgr = cm.Li + ((cm.fi - (im>0?clases[im-1].fi:0)) /
                ((cm.fi - (im>0?clases[im-1].fi:0)) + (cm.fi - (im<clases.Count-1?clases[im+1].fi:0)))) * h;
            WriteLine($"Moda agrupada: {modaAgr:0.##}");
            int mitad = (n + 1) / 2;
            int facAcum = 0; double Lmed = 0, fmed = 0;
            foreach (var c in clases)
            {
                if (facAcum + c.fi >= mitad) { Lmed = c.Li; fmed = c.fi; break; }
                facAcum += c.fi;
            }
            double medianaAgr = Lmed + ((mitad - facAcum) / fmed) * h;
            WriteLine($"Mediana agrupada: {medianaAgr:0.##}");
        }
    }
=======
using static MiProyecto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiProyecto
{
    class DatosAgrupadosNoAgrupados
    {
        public static void DatosNoAgrupados()
        {
            var datos = LeerDatos();

            if (datos.Count == 0)
            {
                WriteLine("No hay datos para analizar.");
                Salir();
            }

            datos.Sort();

            if (datos.Count <= 30)
            {
                Clear();
                WriteLine("\t\tDatos no agrupados:");
                CalcularEstadisticasNoAgrupadas(datos);
            }
            else
            {
                Clear();
                WriteLine("\t\tDatos agrupados:");
                CalcularFrecuenciasAgrupadas(datos);
            }

            Salir();
        }

        private static void CalcularEstadisticasNoAgrupadas(List<double> datos)
        {
            int n = datos.Count;
            double media = datos.Average();
            double mediana = (n % 2 == 0)
                ? (datos[n / 2 - 1] + datos[n / 2]) / 2.0
                : datos[n / 2];

            var freq = datos.GroupBy(x => x)
                            .Select(g => new { Valor = g.Key, fi = g.Count() })
                            .OrderBy(g => g.Valor)
                            .ToList();

            WriteLine("Valor\tfi\tfr\tFa\tFra");
            int Fa = 0;
            foreach (var f in freq)
            {
                Fa += f.fi;
                double fr = (double)f.fi / n;
                double Fra = (double)Fa / n;
                WriteLine($"{f.Valor}\t{f.fi}\t{fr:P2}\t{Fa}\t{Fra:P2}");
            }

            WriteLine($"\nTotal de datos: {n}");
            WriteLine($"Media: {media:F2}");
            WriteLine($"Mediana: {mediana:F2}");
            int maxF = freq.Max(f => f.fi);
            var modas = freq.Where(f => f.fi == maxF).Select(f => f.Valor).ToList();
            WriteLine(modas.Count == 1
                ? $"Moda: {modas[0]} (f={maxF})"
                : $"Modas: {string.Join(", ", modas)} (f={maxF})");
            double varianza = datos.Select(x => Math.Pow(x - media, 2)).Sum() / (n - 1);
            double desviacion = Math.Sqrt(varianza);
            WriteLine($"Varianza muestral: {varianza:F2}");
            WriteLine($"Desviación estándar: {desviacion:F2}");
        }

        private static void CalcularFrecuenciasAgrupadas(List<double> datos)
        {
            datos.Sort();
            int n = datos.Count;
            double min = datos.First();
            double max = datos.Last();
            int k = (int)Math.Ceiling(1 + 3.32 * Math.Log10(n));
            double h = (max - min) / k;

            var clases = new List<(double Li, double Ls, int fi)>();
            for (int i = 0; i < k; i++)
            {
                double Li = min + i * h;
                double Ls = (i == k - 1) ? max : Li + h;
                clases.Add((Li, Ls, 0));
            }

            foreach (double dato in datos)
            {
                int idx = clases.FindIndex(c => dato >= c.Li && dato <= c.Ls);
                var c = clases[idx];
                clases[idx] = (c.Li, c.Ls, c.fi + 1);
            }

            WriteLine("Clase\t\txi\tfi\tfr\tFa\tFra");
            int Fa = 0;
            foreach (var c in clases)
            {
                Fa += c.fi;
                double xi = (c.Li + c.Ls) / 2;
                double fr = (double)c.fi / n;
                double Fra = (double)Fa / n;
                WriteLine($"{c.Li:0.##}-{c.Ls:0.##}\t{xi:0.##}\t{c.fi}\t{fr:P2}\t{Fa}\t{Fra:P2}");
            }
            WriteLine($"\nIntervalo: {h:F2}");
            WriteLine($"Media agrupada: {clases.Sum(c => ((c.Li + c.Ls)/2) * c.fi) / n:0.##}");
            var cm = clases.OrderByDescending(c => c.fi).First();
            int im = clases.IndexOf(cm);
            double modaAgr = cm.Li + ((cm.fi - (im>0?clases[im-1].fi:0)) /
                ((cm.fi - (im>0?clases[im-1].fi:0)) + (cm.fi - (im<clases.Count-1?clases[im+1].fi:0)))) * h;
            WriteLine($"Moda agrupada: {modaAgr:0.##}");
            int mitad = (n + 1) / 2;
            int facAcum = 0; double Lmed = 0, fmed = 0;
            foreach (var c in clases)
            {
                if (facAcum + c.fi >= mitad) { Lmed = c.Li; fmed = c.fi; break; }
                facAcum += c.fi;
            }
            double medianaAgr = Lmed + ((mitad - facAcum) / fmed) * h;
            WriteLine($"Mediana agrupada: {medianaAgr:0.##}");
        }
    }
>>>>>>> 349c920d51cdf481696c247c9555ebe80362ce85
}
using static MiProyecto.Utils;
using static MiProyecto.DatosAgrupadosNoAgrupados;
using static MiProyecto.TecnicaConteo;
using static MiProyecto.VariablesAleatoriasDiscretas;
using System;

namespace MiProyecto {
    class Menu {
        public static void MostrarMenu() {
            Clear();
            WriteLine("Bienvenido al programa de análisis de datos.");
            WriteLine("1. Datos no agrupados");
            WriteLine("2. Combinaciones");
            WriteLine("3. Combinaciones (Para 1 dato)");
            WriteLine("4. Permutaciones");
            WriteLine("5. Principio Aditivo");
            WriteLine("6. Principio Multiplicativo");
            WriteLine("7. Esperanza Matemática");
            WriteLine("8. Varianza");
            WriteLine("9. Salir");
            WriteLine("Seleccione una opción: ");
            int opcion = ReadInt();

            switch (opcion) {
                case 1:
                    Clear();
                    WriteLine("Limite 30 (Mayor a 30 datos agrupados)");
                    DatosAgrupadosNoAgrupados.DatosNoAgrupados();
                    break;
                case 2:
                    Clear();
                    WriteLine("Combinaciones (nCr)");
                    TecnicaConteo.Combinaciones();
                    break;
                case 3:
                    Clear();
                    WriteLine("Combinaciones (1 dato)");
                    TecnicaConteo.Combinaciones1Dato();
                    break;
                case 4:
                    Clear();
                    WriteLine("Permutaciones");
                    TecnicaConteo.Permutaciones();
                    break;
                case 5:
                    Clear();
                    WriteLine("Principio Aditivo");
                    TecnicaConteo.PrincipioAditivo();
                    break;
                case 6:
                    Clear();
                    WriteLine("Principio Multiplicativo");
                    TecnicaConteo.PrincipioMultiplicativo();
                    break;
                case 7:
                    Clear();
                    WriteLine("Esperanza Matemática");
                    VariablesAleatoriasDiscretas.EsperanzaMatematica();
                    break;
                case 8:
                    Clear();
                    WriteLine("Esperanza Matemática");
                    VariablesAleatoriasDiscretas.Varianza();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Opción no válida, intente de nuevo.");
                    MostrarMenu();
                    break;
            }
        }
    }
}
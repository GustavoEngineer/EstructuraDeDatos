using System;

namespace PracticaU2_Estructuras.Services
{
    // Clase para manejar todos los ejercicios de Pilas (4 en total)
    public class PilasService
    {
        public void EjecutarMenu()
        {
            Console.WriteLine("--- Menú Ejercicios de Pilas ---");
            // Llamar al menú específico de Pilas
            MostrarMenuPilas();
        }

        private void MostrarMenuPilas()
        {
            bool volverAPrincipal = false;
            while (!volverAPrincipal)
            {
                Console.Clear();
                Console.WriteLine("--- Menú Ejercicios de Pilas ---");
                Console.WriteLine("1. Invertir palabra");
                Console.WriteLine("2. Palíndromo");
                Console.WriteLine("3. Suma números grandes");
                Console.WriteLine("4. Reemplazar valor");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1: EjecutarInvertirPalabra(); break;
                        case 2: EjecutarPalindromo(); break;
                        case 3: EjecutarSumaNumerosGrandes(); break;
                        case 4: EjecutarReemplazarValor(); break;
                        case 0: volverAPrincipal = true; break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }

                if (!volverAPrincipal)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // 🎯 Ejercicio 1: Invertir palabra
        private void EjecutarInvertirPalabra()
        {
            Console.WriteLine("\n--- 1. Invertir Palabra ---");
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine() ?? string.Empty;

            // Usamos la clase Stack<char> de C#
            var pila = new Stack<char>();

            // Apilar caracteres
            foreach (char c in palabra)
            {
                pila.Push(c);
            }

            string palabraInvertida = "";
            // Desapilar caracteres para invertir el orden
            while (pila.Count > 0)
            {
                palabraInvertida += pila.Pop();
            }

            Console.WriteLine($"Original: {palabra}");
            Console.WriteLine($"Invertida: {palabraInvertida}");
        }

        // 🎯 Ejercicio 2: Palíndromo
        private void EjecutarPalindromo()
        {
            Console.WriteLine("\n--- 2. Palíndromo ---");
            Console.Write("Introduce una palabra (ej. 'reconocer'): ");
            string palabraOriginal = (Console.ReadLine() ?? string.Empty).ToLower().Replace(" ", ""); // Normalizar

            if (string.IsNullOrEmpty(palabraOriginal))
            {
                Console.WriteLine("No se introdujo ninguna palabra.");
                return;
            }

            var pila = new Stack<char>();

            // Apilar caracteres
            foreach (char c in palabraOriginal)
            {
                pila.Push(c);
            }

            string palabraInversa = "";
            // Desapilar para obtener la inversa
            while (pila.Count > 0)
            {
                palabraInversa += pila.Pop();
            }

            if (palabraOriginal.Equals(palabraInversa))
            {
                Console.WriteLine($"'{palabraOriginal}' es un PALÍNDROMO.");
            }
            else
            {
                Console.WriteLine($"'{palabraOriginal}' NO es un palíndromo (Inversa: '{palabraInversa}').");
            }
        }

        // 🎯 Ejercicio 3: Suma números grandes (Lógica Simplificada, enfocada en POO y Pila)
        private void EjecutarSumaNumerosGrandes()
        {
            Console.WriteLine("\n--- 3. Suma Números Grandes (solo dígitos positivos) ---");
            Console.Write("Introduce el primer número grande: ");
            string num1Str = Console.ReadLine() ?? "0";
            Console.Write("Introduce el segundo número grande: ");
            string num2Str = Console.ReadLine() ?? "0";

            // Validar que solo contengan dígitos y revertirlos para procesar de LSB a MSB
            if (!int.TryParse(num1Str, out _) || !int.TryParse(num2Str, out _))
            {
                // Solo una validación rápida, la completa es más compleja para "números muy grandes"
                Console.WriteLine("🚨 Validación: Por favor, asegúrate de introducir solo dígitos.");
                return;
            }

            // Invertir para apilar desde el dígito menos significativo (unidad)
            string reversedNum1 = new string(num1Str.Reverse().ToArray());
            string reversedNum2 = new string(num2Str.Reverse().ToArray());

            // Elegir el más largo para el loop
            int maxLength = Math.Max(reversedNum1.Length, reversedNum2.Length);

            var resultadoPila = new Stack<int>();
            int carry = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int digito1 = i < reversedNum1.Length ? int.Parse(reversedNum1[i].ToString()) : 0;
                int digito2 = i < reversedNum2.Length ? int.Parse(reversedNum2[i].ToString()) : 0;

                int suma = digito1 + digito2 + carry;
                int nuevoDigito = suma % 10;
                carry = suma / 10;

                resultadoPila.Push(nuevoDigito);
            }

            if (carry > 0)
            {
                resultadoPila.Push(carry);
            }

            string resultadoFinal = "";
            while (resultadoPila.Count > 0)
            {
                resultadoFinal += resultadoPila.Pop().ToString();
            }

            Console.WriteLine($"\nPrimer Número:  {num1Str}");
            Console.WriteLine($"Segundo Número: {num2Str}");
            Console.WriteLine($"Suma Total:     {resultadoFinal.TrimStart('0')}");
        }

        // 🎯 Ejercicio 4: Reemplazar valor
        private void EjecutarReemplazarValor()
        {
            Console.WriteLine("\n--- 4. Reemplazar Valor ---");
            var pilaInicial = new Stack<int>();
            pilaInicial.Push(10);
            pilaInicial.Push(20);
            pilaInicial.Push(10);
            pilaInicial.Push(30);
            pilaInicial.Push(10);
            
            // Mostrar pila inicial
            Console.Write("Pila Inicial (cima a base): ");
            Console.WriteLine(string.Join(", ", pilaInicial.Reverse())); // Reverse para mostrar de cima a base

            int valorViejo, valorNuevo;
            // Lectura de valores y validación
            Console.Write("Introduce el valor a reemplazar (viejo): ");
            if (!int.TryParse(Console.ReadLine(), out valorViejo))
            {
                Console.WriteLine("🚨 Error: Valor viejo debe ser un número."); return;
            }
            
            Console.Write("Introduce el nuevo valor: ");
            if (!int.TryParse(Console.ReadLine(), out valorNuevo))
            {
                Console.WriteLine("🚨 Error: Valor nuevo debe ser un número."); return;
            }

            // Llamada al método estático (mejor práctica para funciones que no usan estado de la clase)
            Reemplazar(pilaInicial, valorNuevo, valorViejo);
            
            // Mostrar pila final
            Console.Write("Pila Final (cima a base):   ");
            Console.WriteLine(string.Join(", ", pilaInicial.Reverse()));
        }

        /// <summary>
        /// Reemplaza todas las ocurrencias de un valor en la pila.
        /// </summary>
        /// <param name="pila">La pila de enteros a modificar.</param>
        /// <param name="nuevo">El nuevo valor a introducir.</param>
        /// <param name="viejo">El valor existente a reemplazar.</param>
        public static void Reemplazar(Stack<int> pila, int nuevo, int viejo)
        {
            var pilaAuxiliar = new Stack<int>();

            // 1. Transferir elementos y reemplazar
            while (pila.Count > 0)
            {
                int elemento = pila.Pop();
                if (elemento == viejo)
                {
                    pilaAuxiliar.Push(nuevo); // Reemplaza
                }
                else
                {
                    pilaAuxiliar.Push(elemento); // Conserva
                }
            }

            // 2. Devolver elementos a la pila original (restaurando el orden)
            while (pilaAuxiliar.Count > 0)
            {
                pila.Push(pilaAuxiliar.Pop());
            }
            Console.WriteLine($"\n✅ '{viejo}' reemplazado por '{nuevo}' en la pila.");
        }
    }
}
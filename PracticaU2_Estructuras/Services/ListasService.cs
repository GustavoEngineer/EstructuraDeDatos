using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaU2_Estructuras.Services
{
    // Clase para manejar todos los ejercicios de Listas (5 en total)
    public class ListasService
    {
        public void EjecutarMenu()
        {
            MostrarMenuListas();
        }

        private void MostrarMenuListas()
        {
            bool volverAPrincipal = false;
            while (!volverAPrincipal)
            {
                Console.Clear();
            Console.WriteLine("--- Menú Ejercicios de Listas ---");
                Console.WriteLine("1. Gestión de Productos (Supermercado)");
                Console.WriteLine("2. Números Pares e Impares");
                Console.WriteLine("3. Gestión de Productos con Clave");
                Console.WriteLine("4. Clasificación de Palabras por Letra");
                Console.WriteLine("5. Calificaciones de Alumnos");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1: EjecutarGestionProductos(); break;
                        case 2: EjecutarNumerosParesImpares(); break;
                        case 3: EjecutarGestionProductosClave(); break;
                        case 4: EjecutarPalabrasPorLetra(); break;
                        case 5: EjecutarCalificaciones(); break;
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

        // 🎯 Ejercicio 1: Gestión de Productos (Supermercado)
        private void EjecutarGestionProductos()
        {
            Console.WriteLine("\n--- 1. Gestión de Productos (Supermercado) ---");
            var servicio = new ProductoSupermercado();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Opciones ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Retirar Producto");
                Console.WriteLine("3. Mostrar Productos Disponibles");
                Console.WriteLine("4. Mostrar Productos Retirados");
                Console.WriteLine("0. Volver");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            servicio.AgregarProducto();
                            break;
                        case 2:
                            Console.Write("Introduce el nombre del producto a retirar: ");
                            string nombre = Console.ReadLine() ?? string.Empty;
                            servicio.RetirarProducto(nombre);
                            break;
                        case 3:
                            servicio.MostrarDisponibles();
                            break;
                        case 4:
                            servicio.MostrarRetirados();
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }
            }
        }

        // 🎯 Ejercicio 2: Números Pares e Impares
        private void EjecutarNumerosParesImpares()
        {
            Console.WriteLine("\n--- 2. Números Pares e Impares ---");
            var servicio = new NumerosParesImpares();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Opciones ---");
                Console.WriteLine("1. Generar Números");
                Console.WriteLine("2. Mostrar Listas");
                Console.WriteLine("0. Volver");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            servicio.GenerarNumeros();
                            break;
                        case 2:
                            servicio.MostrarListas();
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }
            }
        }

        // 🎯 Ejercicio 3: Gestión de Productos con Clave
        private void EjecutarGestionProductosClave()
        {
            Console.WriteLine("\n--- 3. Gestión de Productos con Clave ---");
            var servicio = new ProductosConClave();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Opciones ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Eliminar Producto por Clave");
                Console.WriteLine("3. Mostrar Productos (Ordenados y Costo Total)");
                Console.WriteLine("0. Volver");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Introduce la clave: ");
                            string clave = Console.ReadLine() ?? string.Empty;
                            Console.Write("Introduce el nombre: ");
                            string nombre = Console.ReadLine() ?? string.Empty;
                            Console.Write("Introduce el precio: ");
                            if (double.TryParse(Console.ReadLine(), out double precio))
                            {
                                servicio.AgregarProducto(clave, nombre, precio);
                            }
                            else
                            {
                                Console.WriteLine("🚨 Error: Precio inválido.");
                            }
                            break;
                        case 2:
                            Console.Write("Introduce la clave del producto a eliminar: ");
                            string claveEliminar = Console.ReadLine() ?? string.Empty;
                            servicio.EliminarProductoPorClave(claveEliminar);
                            break;
                        case 3:
                            servicio.MostrarProductos();
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }
            }
        }

        // 🎯 Ejercicio 4: Clasificación de Palabras por Letra
        private void EjecutarPalabrasPorLetra()
        {
            Console.WriteLine("\n--- 4. Clasificación de Palabras por Letra ---");
            var servicio = new PalabrasPorLetra();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Opciones ---");
                Console.WriteLine("1. Agregar Palabra");
                Console.WriteLine("2. Mostrar Listas por Letra");
                Console.WriteLine("0. Volver");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Introduce una palabra: ");
                            string palabra = Console.ReadLine() ?? string.Empty;
                            servicio.AgregarPalabra(palabra);
                            break;
                        case 2:
                            servicio.MostrarListas();
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }
            }
        }

        // 🎯 Ejercicio 5: Calificaciones de Alumnos
        private void EjecutarCalificaciones()
        {
            Console.WriteLine("\n--- 5. Calificaciones de Alumnos ---");
            var servicio = new CalificacionesAlumnos();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Opciones ---");
                Console.WriteLine("1. Agregar Alumno");
                Console.WriteLine("2. Mostrar Resultados (Aprobados y Reprobados)");
                Console.WriteLine("0. Volver");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Introduce el nombre del alumno: ");
                            string nombre = Console.ReadLine() ?? string.Empty;
                            Console.Write("Introduce la calificación (0-10): ");
                            if (double.TryParse(Console.ReadLine(), out double calificacion))
                            {
                                servicio.AgregarAlumno(nombre, calificacion);
                            }
                            else
                            {
                                Console.WriteLine("🚨 Error: Calificación inválida.");
                            }
                            break;
                        case 2:
                            servicio.MostrarResultados();
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }
            }
        }

        // ==================== CLASES INTERNAS ====================

        // Clase Producto para representar un producto del supermercado
        private class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }

            public Producto(string nombre, int cantidad, decimal precio)
            {
                Nombre = nombre;
                Cantidad = cantidad;
                Precio = precio;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: ${Precio:F2}";
            }
        }

        // Servicio para gestionar productos del supermercado
        private class ProductoSupermercado
        {
            private List<Producto> productosDisponibles;
            private List<Producto> productosRetirados;

            public ProductoSupermercado()
            {
                productosDisponibles = new List<Producto>();
                productosRetirados = new List<Producto>();
            }

            public void AgregarProducto()
            {
                Console.Write("Introduce el nombre del producto: ");
                string nombre = Console.ReadLine() ?? string.Empty;

                Console.Write("Introduce la cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad))
                {
                    Console.WriteLine("🚨 Error: Cantidad inválida.");
                    return;
                }

                Console.Write("Introduce el precio: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    Console.WriteLine("🚨 Error: Precio inválido.");
                    return;
                }

                Producto nuevoProducto = new Producto(nombre, cantidad, precio);
                productosDisponibles.Add(nuevoProducto);
                
                Console.WriteLine($"✅ Producto agregado: {nuevoProducto}");
            }

            public void RetirarProducto(string nombre)
            {
                Producto producto = productosDisponibles.FirstOrDefault(p => 
                    p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

                if (producto != null)
                {
                    productosDisponibles.Remove(producto);
                    productosRetirados.Add(producto);
                    Console.WriteLine($"✅ Producto '{nombre}' retirado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"🚨 Error: No se encontró el producto '{nombre}' en la lista de disponibles.");
                }
            }

            public void MostrarDisponibles()
            {
                if (productosDisponibles.Count == 0)
                {
                    Console.WriteLine("📦 No hay productos disponibles en el inventario.");
                    return;
                }

                Console.WriteLine($"\n📦 PRODUCTOS DISPONIBLES (Total: {productosDisponibles.Count}):");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                foreach (var producto in productosDisponibles)
                {
                    Console.WriteLine($"  • {producto}");
                }
                Console.WriteLine("═══════════════════════════════════════════════════════");
            }

            public void MostrarRetirados()
            {
                if (productosRetirados.Count == 0)
                {
                    Console.WriteLine("🗑️ No hay productos retirados.");
                    return;
                }

                Console.WriteLine($"\n🗑️ PRODUCTOS RETIRADOS (Total: {productosRetirados.Count}):");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                foreach (var producto in productosRetirados)
                {
                    Console.WriteLine($"  • {producto}");
                }
                Console.WriteLine("═══════════════════════════════════════════════════════");
            }
        }

        // Servicio para gestionar números aleatorios y separarlos en pares e impares
        private class NumerosParesImpares
        {
            private List<int> numerosOriginales;
            private List<int> numerosPares;
            private List<int> numerosImpares;
            private Random random;

            public NumerosParesImpares()
            {
                numerosOriginales = new List<int>();
                numerosPares = new List<int>();
                numerosImpares = new List<int>();
                random = new Random();
            }

            public void GenerarNumeros()
            {
                numerosOriginales.Clear();
                numerosPares.Clear();
                numerosImpares.Clear();

                for (int i = 0; i < 20; i++)
                {
                    int numero = random.Next(1, 101);
                    numerosOriginales.Add(numero);

                    if (numero % 2 == 0)
                    {
                        numerosPares.Add(numero);
                    }
                    else
                    {
                        numerosImpares.Add(numero);
                    }
                }

                Console.WriteLine("✅ Se generaron 20 números aleatorios entre 1 y 100.");
            }

            public List<int> ObtenerPares()
            {
                return numerosPares;
            }

            public List<int> ObtenerImpares()
            {
                return numerosImpares;
            }

            public void MostrarListas()
            {
                Console.WriteLine("\n═══════════════════════════════════════════════════════");
                
                Console.WriteLine($"📋 LISTA ORIGINAL ({numerosOriginales.Count} números):");
                Console.WriteLine(string.Join(", ", numerosOriginales));
                
                Console.WriteLine("\n───────────────────────────────────────────────────────");
                
                var pares = ObtenerPares();
                Console.WriteLine($"🔢 NÚMEROS PARES ({pares.Count} números):");
                if (pares.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", pares));
                }
                else
                {
                    Console.WriteLine("(No hay números pares)");
                }
                
                Console.WriteLine("\n───────────────────────────────────────────────────────");
                
                var impares = ObtenerImpares();
                Console.WriteLine($"🔣 NÚMEROS IMPARES ({impares.Count} números):");
                if (impares.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", impares));
                }
                else
                {
                    Console.WriteLine("(No hay números impares)");
                }
                
                Console.WriteLine("═══════════════════════════════════════════════════════\n");
            }
        }

        // Clase Producto para la gestión de productos con clave
        private class ProductoGestion
        {
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }

            public ProductoGestion(string clave, string nombre, double precio)
            {
                Clave = clave;
                Nombre = nombre;
                Precio = precio;
            }

            public override string ToString()
            {
                return $"Clave: {Clave}, Nombre: {Nombre}, Precio: ${Precio:F2}";
            }
        }

        // Servicio para gestionar productos con clave, nombre y precio
        private class ProductosConClave
        {
            private List<ProductoGestion> productos;

            public ProductosConClave()
            {
                productos = new List<ProductoGestion>();
            }

            public void AgregarProducto(string clave, string nombre, double precio)
            {
                if (productos.Any(p => p.Clave.Equals(clave, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"🚨 Error: Ya existe un producto con la clave '{clave}'.");
                    return;
                }

                ProductoGestion nuevoProducto = new ProductoGestion(clave, nombre, precio);
                productos.Add(nuevoProducto);
                Console.WriteLine($"✅ Producto agregado: {nuevoProducto}");
            }

            public void EliminarProductoPorClave(string clave)
            {
                ProductoGestion producto = productos.FirstOrDefault(p => 
                    p.Clave.Equals(clave, StringComparison.OrdinalIgnoreCase));

                if (producto != null)
                {
                    productos.Remove(producto);
                    Console.WriteLine($"✅ Producto con clave '{clave}' eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"🚨 Error: No se encontró un producto con la clave '{clave}'.");
                }
            }

            public void MostrarProductos()
            {
                if (productos.Count == 0)
                {
                    Console.WriteLine("📦 No hay productos registrados.");
                    return;
                }

                var productosOrdenados = productos.OrderBy(p => p.Nombre).ToList();
                double costoTotal = productos.Sum(p => p.Precio);

                Console.WriteLine("\n═══════════════════════════════════════════════════════");
                Console.WriteLine($"📦 PRODUCTOS ORDENADOS POR NOMBRE (Total: {productos.Count}):");
                Console.WriteLine("───────────────────────────────────────────────────────");
                
                foreach (var producto in productosOrdenados)
                {
                    Console.WriteLine($"  • {producto}");
                }
                
                Console.WriteLine("───────────────────────────────────────────────────────");
                Console.WriteLine($"💰 COSTO TOTAL: ${costoTotal:F2}");
                Console.WriteLine("═══════════════════════════════════════════════════════\n");
            }
        }

        // Servicio para gestionar palabras clasificadas por su letra inicial
        private class PalabrasPorLetra
        {
            private Dictionary<char, List<string>> palabrasPorLetra;

            public PalabrasPorLetra()
            {
                palabrasPorLetra = new Dictionary<char, List<string>>();
            }

            public void AgregarPalabra(string palabra)
            {
                if (string.IsNullOrWhiteSpace(palabra))
                {
                    Console.WriteLine("🚨 Error: La palabra no puede estar vacía.");
                    return;
                }

                char letraInicial = char.ToUpper(palabra.Trim()[0]);

                if (!palabrasPorLetra.ContainsKey(letraInicial))
                {
                    palabrasPorLetra[letraInicial] = new List<string>();
                }

                palabrasPorLetra[letraInicial].Add(palabra.Trim());
                
                Console.WriteLine($"✅ Palabra '{palabra.Trim()}' agregada a la lista de la letra '{letraInicial}'.");
            }

            public void MostrarListas()
            {
                if (palabrasPorLetra.Count == 0)
                {
                    Console.WriteLine("📝 No hay palabras registradas.");
                    return;
                }

                Console.WriteLine("\n═══════════════════════════════════════════════════════");
                Console.WriteLine("📝 PALABRAS AGRUPADAS POR LETRA INICIAL:");
                Console.WriteLine("───────────────────────────────────────────────────────");

                var letrasOrdenadas = palabrasPorLetra.Keys.OrderBy(l => l);

                foreach (char letra in letrasOrdenadas)
                {
                    var palabras = palabrasPorLetra[letra];
                    string palabrasString = string.Join(", ", palabras);
                    Console.WriteLine($"{letra}: {palabrasString}");
                }

                Console.WriteLine("═══════════════════════════════════════════════════════\n");
            }
        }

        // Clase Alumno para representar un alumno con su calificación
        private class Alumno
        {
            public string Nombre { get; set; }
            public double Calificacion { get; set; }

            public Alumno(string nombre, double calificacion)
            {
                Nombre = nombre;
                Calificacion = calificacion;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Calificación: {Calificacion:F2}";
            }
        }

        // Servicio para gestionar calificaciones de alumnos
        private class CalificacionesAlumnos
        {
            private List<Alumno> alumnos;

            public CalificacionesAlumnos()
            {
                alumnos = new List<Alumno>();
            }

            public void AgregarAlumno(string nombre, double calificacion)
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("🚨 Error: El nombre no puede estar vacío.");
                    return;
                }

                Alumno nuevoAlumno = new Alumno(nombre, calificacion);
                alumnos.Add(nuevoAlumno);
                Console.WriteLine($"✅ Alumno agregado: {nuevoAlumno}");
            }

            public List<Alumno> ObtenerAprobados()
            {
                return alumnos.Where(a => a.Calificacion >= 7.0).ToList();
            }

            public List<Alumno> ObtenerReprobados()
            {
                return alumnos.Where(a => a.Calificacion < 7.0).ToList();
            }

            public void MostrarResultados()
            {
                var aprobados = ObtenerAprobados();
                var reprobados = ObtenerReprobados();

                Console.WriteLine("\n═══════════════════════════════════════════════════════");
                Console.WriteLine($"📊 RESULTADOS DE CALIFICACIONES (Total: {alumnos.Count} alumnos)");
                Console.WriteLine("───────────────────────────────────────────────────────");

                Console.WriteLine($"✅ APROBADOS ({aprobados.Count} alumnos, Calificación >= 7.0):");
                if (aprobados.Count > 0)
                {
                    foreach (var alumno in aprobados)
                    {
                        Console.WriteLine($"  • {alumno}");
                    }
                }
                else
                {
                    Console.WriteLine("  (No hay alumnos aprobados)");
                }

                Console.WriteLine("\n❌ REPROBADOS ({0} alumnos, Calificación < 7.0):", reprobados.Count);
                if (reprobados.Count > 0)
                {
                    foreach (var alumno in reprobados)
                    {
                        Console.WriteLine($"  • {alumno}");
                    }
                }
                else
                {
                    Console.WriteLine("  (No hay alumnos reprobados)");
                }

                Console.WriteLine("═══════════════════════════════════════════════════════\n");
            }
        }
    }
}

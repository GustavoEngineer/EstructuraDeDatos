using System;
using System.Collections.Generic;
using System.Data;

namespace Services
{
    /// <summary>
    /// Servicio estático de colas para el ejercicio "Ventanilla del banco".
    /// NO requiere modificar Program ni otras capas: expone métodos simples para la UI.
    /// </summary>
    public static class ColasService
    {
        // Instancia única interna
        private static BankQueueService? _svc;

        /// <summary>
        /// Inicializa el servicio con una capacidad fija. Idempotente.
        /// Debe llamarse una sola vez al iniciar la app.
        /// </summary>
        /// <param name="capacidad">Capacidad máxima de la cola (elementos).</param>
        /// <param name="turnoInicial">Turno inicial (por defecto 1).</param>
        public static void Inicializar(int capacidad, int turnoInicial = 1)
        {
            _svc ??= new BankQueueService(capacidad, turnoInicial);
        }

        private static BankQueueService Svc =>
            _svc ?? throw new InvalidOperationException("ColasService no inicializado. Llama Inicializar(capacidad).");

        /// <summary>Indica si la cola está vacía.</summary>
        public static bool ColaVacia() => Svc.ColaVacia();

        /// <summary>Indica si la cola está llena.</summary>
        public static bool ColaLlena() => Svc.ColaLlena();

        /// <summary>Capacidad configurada de la cola.</summary>
        public static int Capacidad => Svc.Capacidad;

        /// <summary>Cantidad actual de elementos en cola.</summary>
        public static int Conteo => Svc.Conteo;

        /// <summary>
        /// Inserta un cliente en la cola con hora de llegada provista (normalmente DateTime.Now).
        /// Lanza InvalidOperationException si la cola está llena.
        /// </summary>
        public static void InsertaCola(string nombre, string tipoMovimiento, DateTime horaLlegada)
            => Svc.InsertaCola(nombre, tipoMovimiento, horaLlegada);

        /// <summary>
        /// Atiende al siguiente cliente (FIFO) y devuelve su resultado de atención,
        /// incluyendo el tiempo de espera calculado.
        /// Lanza InvalidOperationException si la cola está vacía.
        /// </summary>
        public static ResultadoAtencion AtenderVentanilla()
            => Svc.EliminaColaYCalculaEspera();

        /// <summary>Retorna un DataTable en orden FIFO para data binding en UI.</summary>
        public static DataTable ObtenerSnapshot() => Svc.ObtenerSnapshot();

        /// <summary>Obtiene el primer elemento (sin eliminar). Retorna null si la cola está vacía.</summary>
        public static Cliente? ObtenerFrente() => Svc.ObtenerFrenteSeguro();

        /// <summary>Obtiene el último elemento insertado (sin eliminar). Retorna null si la cola está vacía.</summary>
        public static Cliente? ObtenerFinal() => Svc.ObtenerFinalSeguro();

        // =========================
        // Implementación interna
        // =========================

        /// <summary>
        /// Lógica de negocio de ventanilla (encapsulada en este mismo archivo).
        /// </summary>
        private sealed class BankQueueService
        {
            private readonly ColaAcotada<Cliente> _cola;
            private int _siguienteTurno;

            public BankQueueService(int capacidad, int turnoInicial = 1)
            {
                _cola = new ColaAcotada<Cliente>(capacidad);
                _siguienteTurno = turnoInicial > 0 ? turnoInicial : 1;
            }

            public bool ColaVacia() => _cola.ColaVacia();

            public bool ColaLlena() => _cola.ColaLlena();

            public int Capacidad => _cola.Capacidad;

            public int Conteo => _cola.Conteo;

            public Cliente? ObtenerFrenteSeguro() => _cola.ColaVacia() ? null : _cola.Frente();

            public Cliente? ObtenerFinalSeguro()  => _cola.ColaVacia() ? null : _cola.Final();

            public Cliente InsertaCola(string nombre, string tipoMovimiento, DateTime horaLlegada)
            {
                if (ColaLlena())
                    throw new InvalidOperationException("Estructura llena: no se puede insertar.");

                var cliente = new Cliente(_siguienteTurno++, nombre, tipoMovimiento, horaLlegada);
                _cola.Enqueue(cliente);
                return cliente;
            }

            public ResultadoAtencion EliminaColaYCalculaEspera()
            {
                if (ColaVacia())
                    throw new InvalidOperationException("Estructura vacía: no se puede eliminar.");

                var horaAtencion = DateTime.Now;
                var cliente = _cola.Dequeue();

                var espera = CalcularTiempoEspera(cliente.HoraLlegada, horaAtencion);
                return new ResultadoAtencion(cliente, horaAtencion, espera);
            }

            /// <summary>
            /// Calcula el tiempo de espera como (atención - llegada).
            /// Si por error llegada es posterior a atención, retorna TimeSpan.Zero.
            /// </summary>
            public static TimeSpan CalcularTiempoEspera(DateTime llegada, DateTime atencion)
            {
                var diff = atencion - llegada;
                return diff < TimeSpan.Zero ? TimeSpan.Zero : diff;
            }

            public DataTable ObtenerSnapshot()
            {
                var dt = new DataTable("ColaBanco");
                dt.Columns.Add("Turno", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Movimiento", typeof(string));
                dt.Columns.Add("HoraLlegada", typeof(DateTime));

                foreach (var c in _cola.ToList())
                    dt.Rows.Add(c.NumeroTurno, c.Nombre, c.TipoMovimiento, c.HoraLlegada);

                return dt;
            }
        }

        /// <summary>Elemento de la cola (inmutable).</summary>
        public sealed class Cliente
        {
            public int NumeroTurno { get; }

            public string Nombre { get; }

            public string TipoMovimiento { get; }

            public DateTime HoraLlegada { get; }

            public Cliente(int numeroTurno, string nombre, string tipoMovimiento, DateTime horaLlegada)
            {
                if (numeroTurno <= 0) throw new ArgumentOutOfRangeException(nameof(numeroTurno));
                if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre requerido.", nameof(nombre));

                NumeroTurno = numeroTurno;
                Nombre = nombre.Trim();
                TipoMovimiento = string.IsNullOrWhiteSpace(tipoMovimiento) ? "General" : tipoMovimiento.Trim();
                HoraLlegada = horaLlegada;
            }
        }

        /// <summary>Resultado de atención al atender en ventanilla.</summary>
        public sealed class ResultadoAtencion
        {
            public Cliente Cliente { get; }

            public DateTime HoraAtencion { get; }

            public TimeSpan TiempoEspera { get; }

            public ResultadoAtencion(Cliente cliente, DateTime horaAtencion, TimeSpan tiempoEspera)
            {
                Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
                HoraAtencion = horaAtencion;
                TiempoEspera = tiempoEspera;
            }
        }

        /// <summary>
        /// Cola acotada (circular) de capacidad fija con operaciones O(1).
        /// Expone ColaLlena y ColaVacia para uso directo en UI si se requiere.
        /// </summary>
        private sealed class ColaAcotada<T>
        {
            private readonly T?[] _buffer;
            private int _head; // índice del primer elemento
            private int _tail; // índice donde se insertará el siguiente
            private int _count;

            public int Capacidad { get; }

            public int Conteo => _count;

            public ColaAcotada(int capacidad)
            {
                if (capacidad <= 0) throw new ArgumentOutOfRangeException(nameof(capacidad));

                Capacidad = capacidad;
                _buffer = new T[capacidad];
                _head = 0;
                _tail = 0;
                _count = 0;
            }

            /// <summary>Devuelve true si la cola no contiene elementos.</summary>
            public bool ColaVacia() => _count == 0;

            /// <summary>Devuelve true si la cola alcanzó la capacidad máxima.</summary>
            public bool ColaLlena() => _count == Capacidad;

            /// <summary>Inserta un elemento al final; lanza InvalidOperationException si la cola está llena.</summary>
            public void Enqueue(T item)
            {
                if (ColaLlena())
                    throw new InvalidOperationException("No se puede insertar: la cola está llena.");

                _buffer[_tail] = item;
                _tail = (_tail + 1) % Capacidad;
                _count++;
            }

            /// <summary>Elimina y retorna el primer elemento; lanza InvalidOperationException si la cola está vacía.</summary>
            public T Dequeue()
            {
                if (ColaVacia())
                    throw new InvalidOperationException("No se puede eliminar: la cola está vacía.");

                var item = _buffer[_head];
                _buffer[_head] = default;
                _head = (_head + 1) % Capacidad;
                _count--;
                return item!;
            }

            /// <summary>Obtiene el primer elemento sin eliminar; lanza InvalidOperationException si está vacía.</summary>
            public T Frente()
            {
                if (ColaVacia())
                    throw new InvalidOperationException("La cola está vacía.");
                return _buffer[_head]!;
            }

            /// <summary>Obtiene el último elemento insertado sin eliminar; lanza InvalidOperationException si está vacía.</summary>
            public T Final()
            {
                if (ColaVacia())
                    throw new InvalidOperationException("La cola está vacía.");
                var idx = (_tail - 1 + Capacidad) % Capacidad;
                return _buffer[idx]!;
            }

            /// <summary>Devuelve una lista materializada en orden FIFO.</summary>
            public IReadOnlyList<T> ToList()
            {
                var list = new List<T>(_count);
                for (int i = 0, idx = _head; i < _count; i++, idx = (idx + 1) % Capacidad)
                    list.Add(_buffer[idx]!);
                return list;
            }
        }

        // =========================
        // Verificación manual opcional
        // =========================
        internal static class SelfCheck
        {
            public static void Run()
            {
                var tmp = new BankQueueService(capacidad: 2);
                if (!tmp.ColaVacia()) throw new Exception("Cola debería iniciar vacía.");

                tmp.InsertaCola("Ana", "Depósito", DateTime.Now.AddMinutes(-5));
                if (tmp.ColaVacia()) throw new Exception("Cola no debería estar vacía.");
                if (tmp.ColaLlena()) throw new Exception("Cola no debería estar llena con 1/2.");

                tmp.InsertaCola("Luis", "Retiro", DateTime.Now.AddMinutes(-3));
                if (!tmp.ColaLlena()) throw new Exception("Cola debería estar llena con 2/2.");

                try
                {
                    tmp.InsertaCola("Extra", "Pago", DateTime.Now);
                    throw new Exception("Debió lanzar por cola llena.");
                }
                catch (InvalidOperationException) { }

                var r1 = tmp.EliminaColaYCalculaEspera();
                if (r1.TiempoEspera < TimeSpan.Zero) throw new Exception("Tiempo de espera inválido.");

                var r2 = tmp.EliminaColaYCalculaEspera();
                if (!tmp.ColaVacia()) throw new Exception("Cola debería quedar vacía.");

                try
                {
                    tmp.EliminaColaYCalculaEspera();
                    throw new Exception("Debió lanzar por cola vacía.");
                }
                catch (InvalidOperationException) { }
            }
        }
    }
}

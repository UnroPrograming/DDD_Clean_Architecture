namespace CleanArchitecture.Domain.Vehiculos
{
    /// <summary>
    /// Implementación manual del patrón Smart Enum (enumeration class).
    /// NOTA: En un proyecto real sería mejor usar la librería Ardalis.SmartEnum
    /// (SmartEnum&lt;TipoMoneda, string&gt;), que ya resuelve:
    ///   - Listado de valores (List) sin mantener a mano la colección All.
    ///   - Conversión segura (FromValue / FromName / TryFromValue).
    ///   - Igualdad, comparación y serialización (JSON, EF Core) out of the box.
    /// Además, esta versión manual tiene un fallo: el setter 'init' permite
    /// crear instancias inválidas con 'with' (p. ej. Usd with { Codigo = "XXX" }),
    /// saltándose la validación de FromCodigo. Debería ser 'public string Codigo { get; }'.
    /// </summary>
    public record TipoMoneda
    {
        public static TipoMoneda None { get; } = new TipoMoneda("");
        public static TipoMoneda Usd { get; } = new TipoMoneda("USD");
        public static TipoMoneda Eur { get; } = new TipoMoneda("EUR");

        private TipoMoneda(string codigo) => Codigo = codigo;

        public string? Codigo { get; init; }

        public static readonly IReadOnlyCollection<TipoMoneda> All = new List<TipoMoneda>
        {
            Usd,
            Eur
        };

        public static TipoMoneda FromCodigo(string codigo)
        {
            return All.FirstOrDefault(m => m.Codigo == codigo)
                ?? throw new ApplicationException("El tipo de moneda es inválido");
        }
    }
}
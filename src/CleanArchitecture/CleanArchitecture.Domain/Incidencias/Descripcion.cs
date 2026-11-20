using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias
{
    public sealed record Descripcion
    {
        private Descripcion(string descripcion)
        {
            DescripcionValue = descripcion;
        }

        public string DescripcionValue { get; init; }

        public static Result<Descripcion> Create(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                return Result.Failure<Descripcion>(IncidenciaErrors.DescipcionEmpty);
            }
            if (descripcion.Length > 500)
            {
                return Result.Failure<Descripcion>(IncidenciaErrors.DescipcionTooLong);
            }

            return new Descripcion(descripcion);
        }
    }
}

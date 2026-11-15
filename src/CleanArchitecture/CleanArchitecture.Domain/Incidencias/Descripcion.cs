namespace CleanArchitecture.Domain.Incidencias
{
    public sealed record Descripcion
    {
        private Descripcion(string descripcion)
        {
            DescripcionValue = descripcion;
        }

        public string DescripcionValue { get; init; }

        public static Descripcion Create(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }
            if (descripcion.Length > 500)
            {
                throw new ArgumentException("La descripción no puede tener más de 500 caracteres.");
            }

            return new Descripcion(descripcion);
        }
    }
}

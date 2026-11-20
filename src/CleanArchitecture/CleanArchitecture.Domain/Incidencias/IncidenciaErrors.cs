using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias
{

    // Por qué no usar un enum directamente?
    public record IncidenciaErrors
    {
        public static Error IncidenciaAlreadyResolved => new("Incidencia.AlreadyResolved", "La incidencia ya ha sido resuelta y no se puede cambiar su estado.");
        public static Error TransaccionNoPermitida => new("Incidencia.NoPuedesSaltarteStatus", "La transacción no está permitida.");
        public static Error DescipcionEmpty => new("Incidencia.DescipcionEmpty", "La descripción no puede estar vacía.");
        public static Error DescipcionTooLong => new("Incidencia.DescipcionTooLong", "La descripción no puede tener más de 500 caracteres.");
    }
}

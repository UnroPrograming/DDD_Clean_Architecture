using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres
{
    public static class AlquilerErrors
    {
        public static Error NotFound => new("Alquiler.NotFound", "Alquiler no encontrado.");

        public static Error Overlap => new("Alquiler.Overlap", "El rango de fechas del alquiler se superpone con otro alquiler existente.");

        public static Error NotReserved => new("Alquiler.NotReserved", "Solo se puede confirmar un alquiler que esté en estado 'Reservado'.");

        public static Error NotConfirmed => new("Alquiler.NotConfirmed", "Solo se puede completar un alquiler que esté en estado 'Confirmado'.");

        public static Error AlreadyStarted => new("Alquiler.AlreadyStarted", "No se puede cancelar un alquiler que ya ha comenzado.");
    }
}

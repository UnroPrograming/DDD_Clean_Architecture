using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias
{
    public enum Status
    {
        Abierta = 1,
        EnReparacion = 2,
        Resuelta = 3
    }


    public sealed record IncidenciaStatus
    {
        private IncidenciaStatus(Status activeStatus) => ActiveStatus = activeStatus;

        public Status ActiveStatus { get; }

        public static IncidenciaStatus Create() => new(Status.Abierta);

        public Result<IncidenciaStatus> CambiarA(Status destino)
        {
            if (ActiveStatus == Status.Resuelta)
            {
                return Result.Failure<IncidenciaStatus>(IncidenciaErrors.IncidenciaAlreadyResolved);
            }

            if (!EsTransicionPermitida(ActiveStatus, destino))
            {
                return Result.Failure<IncidenciaStatus>(IncidenciaErrors.TransaccionNoPermitida);
            }

            return new IncidenciaStatus(destino);   // el operador implícito lo convierte en Result
        }

        private static bool EsTransicionPermitida(Status actual, Status destino) => (actual, destino) switch
        {
            (Status.Abierta, Status.EnReparacion) => true,
            (Status.EnReparacion, Status.Resuelta) => true,
            _ => false
        };
    }
}
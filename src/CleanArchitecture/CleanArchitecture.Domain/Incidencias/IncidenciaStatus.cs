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
        public Status ActiveStatus { get; private set; }

        public static IncidenciaStatus Create()
        {
            return new IncidenciaStatus { ActiveStatus = Status.Abierta };
        }

        public void ChangeStatus()
        {
            if (ActiveStatus == Status.Resuelta)
            {
                throw new InvalidOperationException("No se puede cambiar el estado de una incidencia resuelta.");
            }

            ActiveStatus++;
        }
    }
}
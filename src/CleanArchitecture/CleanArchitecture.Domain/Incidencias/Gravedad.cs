using Ardalis.SmartEnum;

namespace CleanArchitecture.Domain.Incidencias
{
    public abstract class Gravedad : SmartEnum<Gravedad>
    {
        private Gravedad(string name, int value, decimal cantidad) : base(name, value)
        {
            Cantidad = cantidad;
        }

        public static readonly Gravedad Baja = new BajaGravedad();
        public static readonly Gravedad Media = new MediaGravedad();
        public static readonly Gravedad Alta = new AltaGravedad();

        public decimal Cantidad { get; }

        private sealed class BajaGravedad : Gravedad
        {
            public BajaGravedad() : base("Baja", 1, 50m) { }
        }
        private sealed class MediaGravedad : Gravedad
        {
            public MediaGravedad() : base("Media", 2, 200m) { }
        }
        private sealed class AltaGravedad : Gravedad
        {
            public AltaGravedad() : base("Alta", 3, 800m) { }
        }
    }
}

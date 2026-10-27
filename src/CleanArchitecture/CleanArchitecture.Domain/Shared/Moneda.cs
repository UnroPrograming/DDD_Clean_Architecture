namespace CleanArchitecture.Domain.Shared
{
    public record Moneda(decimal Cantidad, TipoMoneda Tipo)
    {
        public static Moneda operator + (Moneda m1, Moneda m2)
        {
            // El cero es elemento neutro, sea de la moneda que sea
            if (m1.IsZero()) return m2;
            if (m2.IsZero()) return m1;

            if (m1.Tipo != m2.Tipo)
            {
                throw new InvalidOperationException("No se pueden sumar monedas de diferentes tipos.");
            }

            return new Moneda(m1.Cantidad + m2.Cantidad, m1.Tipo);
        }

        public static Moneda operator - (Moneda m1, Moneda m2)
        {
            // El cero es elemento neutro, sea de la moneda que sea
            if (m2.IsZero()) return m1;
            if (m1.IsZero()) return new Moneda(-m2.Cantidad, m2.Tipo); // 0 - x = -x

            if (m1.Tipo != m2.Tipo)
            {
                throw new InvalidOperationException("No se pueden restar monedas de diferentes tipos.");
            }
            return new Moneda(m1.Cantidad - m2.Cantidad, m1.Tipo);
        }

        public static Moneda Zero() => new (0, TipoMoneda.None);
        public static Moneda Zero(TipoMoneda tipo) => new(0, tipo);

        public bool IsZero() => Cantidad == 0;
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Vehiculos
{
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

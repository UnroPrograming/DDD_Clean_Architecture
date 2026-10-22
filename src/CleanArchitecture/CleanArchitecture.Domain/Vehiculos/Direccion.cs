namespace CleanArchitecture.Domain.Vehiculos
{
    public record Direccion
    (
        string Pais,
        string Provincia,
        string Ciudad,
        string Calle,
        string Piso
    );


    /// <summary>
    /// Versión explícita (didáctica) del record posicional:
    ///     public record Direccion(string Pais, string Provincia, string Ciudad, string Calle, string Piso);
    ///
    /// Esa línea es sintaxis abreviada (C# 9 / .NET 5+) y el compilador genera:
    ///   - Por ser POSICIONAL: propiedades, constructor y Deconstruct (escritos abajo como código real).
    ///   - Por ser RECORD: igualdad por valor, GetHashCode, ToString y 'with' (resumidos al final).
    /// </summary>
    public record DireccionExpandida
    {
        // =====================================================================
        // A) LO QUE GENERA POR SER POSICIONAL
        // =====================================================================

        // ---------------------------------------------------------------------
        // A.1) PROPIEDADES
        // Cada parámetro entre paréntesis se convierte en una propiedad pública
        // con el MISMO nombre (por eso van en PascalCase en la declaración).
        //
        //   get;  -> se puede leer desde fuera.
        //   init; -> solo se puede asignar durante la construcción del objeto
        //            (constructor, inicializador de objeto { } o expresión 'with').
        //            Después queda inmutable: direccion.Pais = "X"; NO compila.
        // ---------------------------------------------------------------------
        public string Pais { get; init; }
        public string Provincia { get; init; }
        public string Ciudad { get; init; }
        public string Calle { get; init; }
        public string Piso { get; init; }

        // ---------------------------------------------------------------------
        // A.2) CONSTRUCTOR PRINCIPAL
        // Recibe los parámetros en el MISMO ORDEN en que se declararon y los
        // asigna a las propiedades. No valida nada: acepta nulls o strings vacíos.
        // (Si quieres validar, tienes que escribir el record de forma explícita,
        // como este, y añadir las comprobaciones aquí dentro.)
        //
        // Uso: var d = new DireccionExpandida("España", "Madrid", "Aranjuez", "Calle Mayor 5", "2A");
        // ---------------------------------------------------------------------
        public DireccionExpandida(string pais, string provincia, string ciudad, string calle, string piso)
        {
            Pais = pais;
            Provincia = provincia;
            Ciudad = ciudad;
            Calle = calle;
            Piso = piso;
        }

        // ---------------------------------------------------------------------
        // A.3) DECONSTRUCT
        // Lo contrario del constructor: "desempaqueta" el objeto en variables.
        // Permite escribir:
        //
        //   var (pais, provincia, ciudad, calle, piso) = direccion;
        //   var (pais, _, ciudad, _, _) = direccion;          // ignorando campos
        //   if (direccion is ("España", _, var ciudad, _, _)) // pattern matching
        //
        // El compilador traduce esas líneas a una llamada a este método.
        // ---------------------------------------------------------------------
        public void Deconstruct(out string pais, out string provincia, out string ciudad,
                                out string calle, out string piso)
        {
            pais = Pais;
            provincia = Provincia;
            ciudad = Ciudad;
            calle = Calle;
            piso = Piso;
        }

        // Además, por ser record, el compilador genera automáticamente:
        //  - Equals / == / != : comparan por valor todas las propiedades (clave para Value Objects).
        //  - GetHashCode      : coherente con Equals (Dictionary, HashSet...).
        //  - ToString         : "DireccionExpandida { Pais = España, Provincia = Madrid, ... }".
        //  - 'with'           : copia cambiando campos -> direccion with { Piso = "3B" }.
        //                       Ojo: no pasa por el constructor, se salta cualquier validación.
    }
}

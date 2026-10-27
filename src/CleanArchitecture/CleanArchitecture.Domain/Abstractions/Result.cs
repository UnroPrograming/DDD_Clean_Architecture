using System.Diagnostics.CodeAnalysis;

// TODO: Revisar todo este código cuando tenga más contexto para enterarme bien de lo que hace
namespace CleanArchitecture.Domain.Abstractions
{
    /// <summary>
    /// Resultado de una operación que puede fallar, sin valor de retorno.
    /// Alternativa a lanzar excepciones para errores de negocio.
    /// </summary>
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException("Un resultado exitoso no puede tener un error.");
            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException("Un resultado fallido debe tener un error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        /// <summary>Éxito con valor. Uso: <c>Result.Success(alquiler)</c> (T se deduce).</summary>
        public static Result<T> Success<T>(T value) => new(value, true, Error.None);

        /// <summary>Fallo en un método que devuelve Result&lt;T&gt;. Uso: <c>Result.Failure&lt;Alquiler&gt;(error)</c>.</summary>
        public static Result<T> Failure<T>(Error error) => new(default, false, error);

        /// <summary>Éxito si el valor no es null; si no, fallo con <see cref="Error.NullValue"/>.</summary>
        public static Result<T> Create<T>(T? value) =>
            value is not null ? Success(value) : Failure<T>(Error.NullValue);
    }

    /// <summary>
    /// Resultado de una operación que puede fallar y que, si sale bien, devuelve un valor.
    /// </summary>
    public class Result<T> : Result
    {
        private readonly T? _value;

        protected internal Result(T? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        /// <summary>
        /// El valor del resultado. Lanza excepción si es un fallo: comprobar antes <see cref="Result.IsSuccess"/>.
        /// </summary>
        [NotNull]
        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("No se puede acceder al valor de un resultado fallido.");

        /// <summary>
        /// Permite <c>return alquiler;</c> en vez de <c>return Result.Success(alquiler);</c>.
        /// Llama al constructor al Create implicito de Result para convertir la propiedad en función de si tiene o no valor en exitosa o no.
        /// </summary>
        public static implicit operator Result<T>(T value) => Create(value);
    }
}
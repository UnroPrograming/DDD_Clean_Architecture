using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews
{
    public sealed record Rating
    {
        private Rating(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public static Result<Rating> Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(ReviewErrors.InvalidRating);
            }

            return new Rating(value);
        }
    }
}

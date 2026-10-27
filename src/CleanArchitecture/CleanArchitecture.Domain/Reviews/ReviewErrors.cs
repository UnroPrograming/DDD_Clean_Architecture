using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews
{
    public record ReviewErrors
    {
        public static Error NotEligible => new("Review.NotEligible", "El alquiler no es elegible para una reseña.");
        public static Error InvalidRating => new("Review.InvalidRating", "El rating debe estar entre 1 y 5.");
    }
}

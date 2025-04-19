using FluentValidation;
using OBILET.API.Application.Resources;

namespace OBILET.API.Application.Queries.Journeys
{
    public class GetJourneysQueryValidator : AbstractValidator<GetJourneysQuery>
    {
        public GetJourneysQueryValidator()
        {
            RuleFor(x => x.OriginId)
            .GreaterThan(0)
                .WithMessage(ValidationMessages.OriginRequired);

            RuleFor(x => x.DestinationId)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.DestinationRequired)
                .NotEqual(x => x.OriginId)
                .WithMessage(ValidationMessages.SameOriginAndDestination);

            RuleFor(x => x.DepartureDate)
                .NotEmpty()
                .Must(BeTodayOrFutureDate)
                .WithMessage(ValidationMessages.DepartureDatePast);
        }

        private bool BeTodayOrFutureDate(string date)
        {
            if (DateTime.TryParse(date, out var parsed))
            {
                return parsed.Date >= DateTime.Today;
            }
            return false;
        }
    }
}

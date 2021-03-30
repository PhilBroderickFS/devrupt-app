namespace DevRupt.Core.Contracts
{
    public interface IRepositoryWrapper
    {
        IFolioRepository Folio { get; }

        IRatePlanRepository RatePlan { get; }

        IReservationRepository Reservation { get; }

        IIngredientRepository Ingredient { get; }

        void Save();
    }
}

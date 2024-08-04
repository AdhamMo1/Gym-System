namespace GymCore.Interfaces.IUnitOfWorkConfig
{
    public interface IUnitOfWork
    {
        ITraineeRepo Trainees { get; }
        IAttendenceRepo Attendences { get; }
        ISubCategoryRepo SubCategories { get; }
        ValueTask Save();

    }
}

namespace Business.Interface
{
    public interface IUserService
    {
        TOutputModel Create<TOutputModel>(object inputModel);

        TOutputModel GetById<TOutputModel>(int Id);

        TOutputModel Update<TOutputModel>(object entity);
    }
}

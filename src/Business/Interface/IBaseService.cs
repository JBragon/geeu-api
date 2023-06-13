namespace Business.Interface
{
    public interface IBaseService<in TPrimarykey>
    {
        TOutputModel Create<TOutputModel>(object inputModel, string userName);

        TOutputModel GetById<TOutputModel>(TPrimarykey Id);

        TOutputModel Update<TOutputModel>(object entity, string userName);

        void Delete(TPrimarykey id);

        bool Exist(TPrimarykey Id);
    }
}

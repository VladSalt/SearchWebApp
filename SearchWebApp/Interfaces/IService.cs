namespace SearchWebApp.Interface
{
    public interface IService<T>
    {
        T RequestAnswer(string question);
    }
}

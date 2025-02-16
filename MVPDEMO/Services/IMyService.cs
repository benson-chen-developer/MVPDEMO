namespace MVC.Services
{
    public interface ISingletonService
    {
        string GetInstanceInfo();
    }

    public interface IScopedService
    {
        string GetInstanceInfo();
    }

    public interface ITransientService
    {
        string GetInstanceInfo();
    }
}

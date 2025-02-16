namespace MVC.Services
{
    // Singleton
    public class SingletonService : ISingletonService
    {
        private readonly string _instanceGuid;

        public SingletonService()
        {
            _instanceGuid = Guid.NewGuid().ToString();
        }

        public string GetInstanceInfo()
        {
            return $"Singleton GUID: {_instanceGuid}";
        }
    }

    // Scoped
    public class ScopedService : IScopedService
    {
        private readonly string _instanceGuid;

        public ScopedService()
        {
            _instanceGuid = Guid.NewGuid().ToString();
        }

        public string GetInstanceInfo()
        {
            return $"Scoped GUID: {_instanceGuid}";
        }
    }

    // Transient
    public class TransientService : ITransientService
    {
        private readonly string _instanceGuid;

        public TransientService()
        {
            _instanceGuid = Guid.NewGuid().ToString();
        }

        public string GetInstanceInfo()
        {
            return $"Transient GUID: {_instanceGuid}";
        }
    }


}

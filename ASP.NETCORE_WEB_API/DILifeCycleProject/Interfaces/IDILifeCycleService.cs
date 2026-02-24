

namespace DILifeCycleProject.Interfaces
{
    public interface  IDILifeCycleService
    {
        public Guid GetGuid();
    }

    public interface ISingleTonDILifeCycleService : IDILifeCycleService { }
    public interface IScopedDILifeCycleService : IDILifeCycleService { }
    public interface ITransientDILifeCycleService : IDILifeCycleService { }

}



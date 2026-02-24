using DILifeCycleProject.Interfaces;
namespace DILifeCycleProject.Service
{
    public class DILifeCycleService : ISingleTonDILifeCycleService,IScopedDILifeCycleService,ITransientDILifeCycleService
    {
        private Guid _id;

        public DILifeCycleService()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetGuid() => _id;
    }
}

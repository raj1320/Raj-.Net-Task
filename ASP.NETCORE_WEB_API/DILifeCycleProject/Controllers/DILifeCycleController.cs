using DILifeCycleProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DILifeCycleProject.Controllers
{
    [ApiController]
    [Route("api/lifetime")]
    public class DILifeCycleController : ControllerBase
    {
        private ISingleTonDILifeCycleService _SIservice1;
        private ISingleTonDILifeCycleService _SIservice2;

        private IScopedDILifeCycleService _SCservice1;
        private IScopedDILifeCycleService _SCservice2;

        private ITransientDILifeCycleService _STservice1;
        private ITransientDILifeCycleService _STservice2;


        public DILifeCycleController(
            ISingleTonDILifeCycleService SIservice1,
            ISingleTonDILifeCycleService SIservice2,
            IScopedDILifeCycleService SCservice1,
            IScopedDILifeCycleService SCservice2,
            ITransientDILifeCycleService STservice1,
            ITransientDILifeCycleService STservice2            ) 
        {
           this._SIservice1 = SIservice1;
            this._SIservice2 = SIservice2;
            this._SCservice1 = SCservice1;
            this._SCservice2 = SCservice2;
            this._STservice1 = STservice1;
            this._STservice2 = STservice2;
        }

        [HttpGet]
        public IActionResult GetGuIdBySignleTone() 
        {
            var result = new
            {
                

                singlTone_obj1_Id = _SIservice1.GetGuid(),
                singlTone_obj2_Id = _SIservice2.GetGuid(),

                scoped_obj1_Id = _SCservice1.GetGuid(),
                scoped_obj2_Id = _SCservice2.GetGuid(),

                Transient_obj1_Id = _STservice1.GetGuid(),
                Transient_obj2_Id = _STservice2.GetGuid(),
             };

            

            return Ok( result);
        }
    }
}

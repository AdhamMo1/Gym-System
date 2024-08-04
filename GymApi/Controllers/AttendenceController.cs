using AutoMapper;
using GymApi.Exceptions;
using GymCore.Entities;
using GymCore.Interfaces.IUnitOfWorkConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GymApi.Controllers
{
    public class AttendenceController : BaseController
    {
        public AttendenceController(IUnitOfWork data, IMapper mapper) : base(data, mapper) {  }

        [HttpPost]
        public async ValueTask<IActionResult> AddAttendence(Guid traineeId)
        {
            Log.Information($"Start Add Attendence");
            Attendence attend;
            try
            {
                attend = await Data.Attendences.CreateAsync(new Attendence() { TraineeId = traineeId });
                await Data.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException(ex.Message);
            }
            return Ok(attend);
        }
        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            Log.Information($"Start Get all Attendence");
            IEnumerable<Attendence> entityResult;
            try
            {
                entityResult = await Data.Attendences.ReadAllAsync();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException(ex.Message);
            }
            return Ok(entityResult);
        }
    }
}

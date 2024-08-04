using AutoMapper;
using GymApi.Exceptions;
using GymCore.Dto.Incoming.Trainee;
using GymCore.Dto.Outcoming.Trainee;
using GymCore.Entities;
using GymCore.Interfaces.IUnitOfWorkConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GymApi.Controllers
{
    [Authorize]
    public class TraineesController : BaseController
    {
        public TraineesController(IUnitOfWork data, IMapper mapper) : base(data, mapper) { }

        [HttpPost]
        public async ValueTask<IActionResult> AddTrainee([FromBody]TraineeInDto entityInDto)
        {
            Log.Information($"Start Add Trainee.");
            Trainee entityResult;
            try
            {
                entityResult = await Data.Trainees.CreateAsync(mapper.Map<Trainee>(entityInDto));
                await Data.Save();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException("Failed in save data!");
            }
            return Ok(entityResult);
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(string id)
        {
            Log.Information($"Start Get one Trainee with id : {id}");
            var entityResult = mapper.Map<TraineeDetailsOutDto>(await Data.Trainees.ReadAsync(id));
            if (entityResult == null)
            {
                Log.Warning($"Not Valid - Id  : {id}");
                throw new NotFoundException($"Id : {id} , not found!");
            }
            return Ok(entityResult);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            Log.Information("Start Geting all Trainees.");
            IEnumerable<TraineeOutDto> entityResult;
            try
            {
                entityResult = mapper.Map<IEnumerable<TraineeOutDto>>(await Data.Trainees.ReadAllAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex,ex.Message);
                throw new Exception(ex.Message);
            }
            return Ok(entityResult);
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody] UpdateTraineeDto entityDto)
        {
            Log.Information($"Start Update Trainee with id : {entityDto.Id}");
            try
            {
                Data.Trainees.Update(mapper.Map<Trainee>(entityDto));
                await Data.Save();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException("Failed in update data!");
            }
            return Ok("Done Successfully.");
        }
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete(string id)
        {
            Log.Information($"Start Delete Trainee with id : {id}");
            var entityResult =await Data.Trainees.ReadAsync(id);
            if(entityResult == null)
            {
                Log.Warning($"Not Valid - Id  : {id}");
                throw new NotFoundException($"Id : {id} , not found!");
            }
            try
            {
                await Data.Trainees.DeleteAsync(id);
                await Data.Save();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException("Failed in delete data!");
            }
            return Ok("Done Successfully.");
        }
    }
}

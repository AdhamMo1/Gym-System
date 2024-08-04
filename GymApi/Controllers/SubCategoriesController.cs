using AutoMapper;
using GymApi.Exceptions;
using GymCore.Dto.Incoming.SubcriptionCategory;
using GymCore.Entities;
using GymCore.Interfaces.IUnitOfWorkConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GymApi.Controllers
{
    [Authorize]
    public class SubCategoriesController : BaseController
    {
        public SubCategoriesController(IUnitOfWork data, IMapper _mapper) : base(data, _mapper)
        {
        }
        [HttpPost]
        public async ValueTask<IActionResult> AddSubCategory([FromBody] AddSubCategoryDto entityDto)
        {
            Log.Information($"Start AddSubCategory");
            SubscriptionCategory entityResult;
            try
            {
                entityResult = await Data.SubCategories.CreateAsync(mapper.Map<SubscriptionCategory>(entityDto));
                await Data.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException(ex.Message);
            }
            return Ok(entityResult);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            Log.Information($"Start get all SubCategories");
            IEnumerable<SubscriptionCategory> entityResult;
            try
            {
                entityResult = await Data.SubCategories.ReadAllAsync();
            }catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException(ex.Message);
            }
            return Ok(entityResult);
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(string id)
        {
            Log.Information($"Start Get one with id : {id}");
            var entityResult = await Data.SubCategories.ReadAsync(id);
            if(entityResult == null)
            {
                Log.Warning($"Not Valid - Id  : {id}");
                throw new NotFoundException("Not Found : Id not valid");
            }
            return Ok(entityResult);
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update([FromBody]SubscriptionCategory entity)
        {
            Log.Information($"Start Update SubCategory : {entity.Id}");
            try
            {
                Data.SubCategories.Update(entity);
                await Data.Save();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException("Failed in Update Data!");
            }
            return Ok("Done Successfully!");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> Delete(string id)
        {
            Log.Information($"Start Delete SubCategory with id : {id}");
            try
            {
                await Data.SubCategories.DeleteAsync(id);
                await Data.Save();
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new BadRequestException("Bad Request : Failed in delete data!");
            }
            return Ok("Done Successfully!");
        }
    }
}

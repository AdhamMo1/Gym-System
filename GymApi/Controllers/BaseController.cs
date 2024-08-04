using AutoMapper;
using GymCore.Interfaces.IUnitOfWorkConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IUnitOfWork Data;
        public IMapper mapper;
        public BaseController(IUnitOfWork data , IMapper _mapper) { 
            Data = data;
            mapper = _mapper;
        }

        
    }
}

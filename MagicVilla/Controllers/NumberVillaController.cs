using AutoMapper;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using MagicVilla.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberVillaController : ControllerBase
    {

        private readonly IVillaNumberRepository _villaNumberRepository;
        protected APIResponse _apiResponse;
        private readonly IMapper _mapper;


        public NumberVillaController(IVillaNumberRepository villaNumberRepository, IMapper mapper)
        {
              _villaNumberRepository= villaNumberRepository;
            _mapper = mapper;
            _apiResponse=new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillaNumber()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumbersList= await _villaNumberRepository.GetAll();

                _apiResponse.Result = _mapper.Map<IEnumerable<VillaNumberDto>>(villaNumbersList);
                _apiResponse.statusCode = HttpStatusCode.OK;

                return _apiResponse;

            }
            catch (Exception e)
            {

                _apiResponse.IsOk= false;
                _apiResponse.ErrorMessages=new List<string> { (e.Message) };

                return _apiResponse;

            }

        }

        [HttpGet ("id:int")]
        public ActionResult<APIResponse> GetVillaNumberbyId(int id) {

            var Villa= _villaNumberRepository.Get(x => x.VillaNmber == id);

            _apiResponse.Result = _mapper.Map<VillaNumberDto>(Villa);
            _apiResponse.statusCode = HttpStatusCode.OK;
            return _apiResponse;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber(VillaNumberCreateDto model)
        {

            try
            {

                var Villa = _mapper.Map<VillaNumber>(model);

                Villa.CreationDate = DateTime.Now;
                Villa.UpdateDate = DateTime.Now;
                await _villaNumberRepository.Create(Villa);
                _apiResponse.Result= Villa;
                _apiResponse.statusCode= HttpStatusCode.Created;

                return _apiResponse;
            }
            catch (Exception e)
            {
                _apiResponse.statusCode=HttpStatusCode.BadRequest;
                _apiResponse.IsOk = false;
                _apiResponse.ErrorMessages= new List<string> { (e.Message) };

                return _apiResponse;

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVillaNumber(int id, VillaNumberUpdateDto villaNumberUpdateDto)
        {
            try
            {
                var model = _mapper.Map<VillaNumber>(villaNumberUpdateDto);

                await _villaNumberRepository.Update(model);
                return Ok(model);

            }
            catch (Exception e)
            {
                _apiResponse.IsOk=false;
                _apiResponse.ErrorMessages = new List<String> { e.Message };
                return BadRequest(e.Message);

            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteVillaNumber(int id) {
            try
            {
                var villaNumber = await _villaNumberRepository.Get(x => x.VillaNmber == id);

                await _villaNumberRepository.Remove(villaNumber);
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return Ok(villaNumber);
            }
            catch (Exception e)
            {
                _apiResponse.IsOk=false;
                _apiResponse.ErrorMessages=new List<String> { e.Message };
                return BadRequest(_apiResponse);
              
            }
            

            
        
        }
















    }
}

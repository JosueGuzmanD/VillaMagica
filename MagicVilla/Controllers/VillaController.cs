using AutoMapper;
using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using MagicVilla.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly IVillaRepository _villaRepository;
        private readonly IMapper _mapper;
        protected APIResponse _apiResponse;

        public VillaController( IVillaRepository villaRepository, IMapper mapper)
        {
                _mapper = mapper;
            _villaRepository = villaRepository;
            _apiResponse = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult <APIResponse>> GetVillas() 
        {
            try
            {
                IEnumerable<Villa> villaList = await _villaRepository.GetAll();


                _apiResponse.Result = _mapper.Map<IEnumerable<VillaDto>>(villaList);
                _apiResponse.statusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsOk=false;
                _apiResponse.ErrorMessages= new List<string> { ex.ToString() };
                throw;
            }
            return _apiResponse;
           
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDto CreatevillaDTO)
        {
            try
            {
                Villa model = _mapper.Map<Villa>(CreatevillaDTO);



                model.CreationDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                await _villaRepository.Create(model);
                await _villaRepository.SaveChanges();


                _apiResponse.Result = model;
                _apiResponse.statusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = model.Id }, _apiResponse);

            }
            catch (Exception e)
            {
                _apiResponse.IsOk = false;
                _apiResponse.ErrorMessages = new List<string> { e.ToString() };

                throw;
            }

            
        }

        [HttpGet]
        [Route("VillaId:Int",Name ="GetVilla")]
        public async Task<ActionResult<APIResponse>> GetVilla(int id) {


            try
            {
                if (id == 0) { _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _apiResponse.IsOk = false;
                    return _apiResponse;
                }

                var villa = await _villaRepository.Get(x => x.Id == id);

                if (villa == null) { _apiResponse.statusCode = HttpStatusCode.NotFound;
                _apiResponse.IsOk=false;
                }

                _apiResponse.Result = _mapper.Map<VillaDto>(villa);
                _apiResponse.statusCode=HttpStatusCode.OK;


                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsOk = false;
                _apiResponse.ErrorMessages=new List<string>() {ex.ToString()};
                return _apiResponse;

            }

        }


        [HttpDelete("{id:int}")]
        public async Task<APIResponse> DeleteVilla(int id)
        {

            try
            {
                var villa = await _villaRepository.Get(villa => villa.Id == id);

                if (villa == null)
                {
                    _apiResponse.statusCode = HttpStatusCode.NotFound; _apiResponse.IsOk = false;
                    return _apiResponse;
                }
                await _villaRepository.Remove(villa);

                _apiResponse.Result = villa;
                _apiResponse.statusCode = HttpStatusCode.NoContent;

                return _apiResponse;

               
            }
            catch (Exception e)
            {
                _apiResponse.ErrorMessages= new List<String> { e.ToString()};
                return _apiResponse;
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto villadto) 
        { 

            if(villadto== null || id!= villadto.Id) { 
                _apiResponse.IsOk=false;
                _apiResponse.statusCode = HttpStatusCode.BadRequest;
                
                return BadRequest(_apiResponse); }

            var villa= await _villaRepository.Get(villadto=>villadto.Id==id);
            if (villa==null) {  return NotFound(); }

            var model = _mapper.Map<Villa>(villadto);

           await _villaRepository.Update(model);

            _apiResponse.statusCode=HttpStatusCode.NoContent;

            return Ok(_apiResponse);
        }




    }
}

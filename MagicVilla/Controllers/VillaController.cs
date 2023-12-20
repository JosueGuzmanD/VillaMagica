using AutoMapper;
using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public VillaController( ApplicationDbContext dbContext, IMapper mapper)
        {
                _dbcontext = dbContext;
                _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<VillaDto>>> GetVillas() 
        {

            IEnumerable<Villa> villaList = await _dbcontext.Villas.ToListAsync();


            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList));
        }

        [HttpPost]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody]VillaCreateDto CreatevillaDTO)
        {


            Villa model= _mapper.Map<Villa>(CreatevillaDTO);

          await _dbcontext.Villas.AddAsync(model);
            await _dbcontext.SaveChangesAsync();

            return CreatedAtRoute("GetVilla",new { id= model.Id}, CreatevillaDTO);
        }

        [HttpGet]
        [Route("/VillaId:Int",Name ="GetVilla")]
        public async Task<ActionResult<VillaDto>> GetVilla(int id) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0) {  return BadRequest(); }

            var villa = await _dbcontext.Villas.FirstOrDefaultAsync(x => x.Id == id);

            if (villa == null) { return NotFound(); }
            
            return Ok(_mapper.Map<VillaDto>(villa));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa= await _dbcontext.Villas.FirstOrDefaultAsync(villa => villa.Id == id);

            if (villa==null)
            {
                return NotFound();
            }

            _dbcontext.Villas.Remove(villa);
          await  _dbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto villadto) 
        { 

            if(villadto== null || id!= villadto.Id) { return BadRequest(ModelState); }

            var villa= await _dbcontext.Villas.FirstOrDefaultAsync(villadto=>villadto.Id==id);
            if (villa==null) {  return NotFound(); }

            var model = _mapper.Map<Villa>(villadto);

            _dbcontext.Villas.Update(model);
          await  _dbcontext.SaveChangesAsync();

            return Ok(villa);
        }




    }
}

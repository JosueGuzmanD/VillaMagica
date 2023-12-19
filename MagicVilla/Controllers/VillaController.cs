using MagicVilla.Datos;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public VillaController( ApplicationDbContext dbContext)
        {
                _dbcontext = dbContext;
        }

        [HttpGet]
        public ActionResult <IEnumerable<VillaDto>> GetVillas() 
        {

            return Ok(_dbcontext.Villas.ToList());
        }

        [HttpPost]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaCreateDto villa)
        {


            var model = new Villa()
            {
                VillaName = villa.VillaName,
                Details=villa.Details,
                Ocuppants=villa.Ocuppants,
                SquareMeters=villa.SquareMeters,
                Amenidad=villa.Amenidad,
                Price=villa.Price,
                ImagenUrl=villa.ImagenUrl
            };

             _dbcontext.Villas.Add(model);
            _dbcontext.SaveChanges();

            return CreatedAtRoute("GetVilla",new { id= model.Id}, villa);
        }

        [HttpGet]
        [Route("/VillaId:Int",Name ="GetVilla")]
        public ActionResult<VillaDto> GetVilla(int id) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id == 0) {  return BadRequest(); }

            var villa = _dbcontext.Villas.FirstOrDefault(x => x.Id == id);

            if (villa == null) { return NotFound(); }

            return Ok(villa);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            var villa=_dbcontext.Villas.FirstOrDefault(villa => villa.Id == id);

            if (villa==null)
            {
                return NotFound();
            }

            _dbcontext.Villas.Remove(villa);
            _dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateVilla(int id, [FromBody] VillaUpdateDto villadto) 
        { 

            if(villadto== null || id!= villadto.Id) { return BadRequest(ModelState); }

            var villa= _dbcontext.Villas.FirstOrDefault(villadto=>villadto.Id==id);
            if (villa==null) {  return NotFound(); }

            var model = new Villa()
            {
                VillaName = villa.VillaName,
                Details = villa.Details,
                Ocuppants = villa.Ocuppants,
                SquareMeters = villa.SquareMeters,
                Amenidad = villa.Amenidad,
                Price = villa.Price,
                ImagenUrl = villa.ImagenUrl
            };


            _dbcontext.Villas.Update(model);
            _dbcontext.SaveChanges();

            return Ok(villa);
        }




    }
}

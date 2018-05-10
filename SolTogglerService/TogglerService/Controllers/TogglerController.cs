using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TogglerService.DTO;
using TogglerService.Model;

namespace TogglerService.Controllers
{
    [Produces("application/json")]
    [Route("api/Toggler")]
    [Authorize]    
    public class TogglerController : Controller
    {
        private readonly TogglerContext _context;


        public TogglerController(TogglerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("isButtonBlue")]
        [AllowAnonymous]
        public IActionResult isButtonBlue(bool value)
        {
            if (!value)
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonBlue");

                toggler.IsOn = false;
            }else
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonBlue");

                toggler.IsOn = true;                
            }

            _context.SaveChanges();

            return Ok(value);
            
        }


        [HttpGet]
        [Route("isButtonGreen")]
        [AllowAnonymous]
        public IActionResult isButtonGreen(bool value)
        {
            if (!value)
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonGreen");

                toggler.IsOn = false;
            }
            else
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonGreen");

                toggler.IsOn = true;
            }

            _context.SaveChanges();

            return Ok(value);
            
        }


        [HttpGet]
        [Route("isButtonRed")]
        [AllowAnonymous]
        public IActionResult isButtonRed(bool value)
        {
            if (!value)
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonRed");

                toggler.IsOn = false;
            }
            else
            {
                var toggler = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonRed");

                toggler.IsOn = true;
            }

            _context.SaveChanges();

            return Ok(value);
            
        }


        // GET: api/Toggler
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Toggler> GetToggler()
        {            
            return _context.Toggler;
        }

        // GET: api/Toggler/5
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetToggler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toggler = await _context.Toggler.SingleOrDefaultAsync(m => m.Id == id);

            if (toggler == null)
            {
                return NotFound();
            }

            return Ok(toggler);
        }

        // PUT: api/Toggler/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToggler([FromRoute] int id, [FromBody] Toggler toggler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toggler.Id)
            {
                return BadRequest();
            }

            _context.Entry(toggler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TogglerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: first load in the database
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostToggler([FromBody] List<Toggler> togglerList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Toggler.AddRange(togglerList);            

            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetToggler", new { id = togglerList.FirstOrDefault().Id }, togglerList);
        }

        // DELETE: api/Toggler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToggler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toggler = await _context.Toggler.SingleOrDefaultAsync(m => m.Id == id);
            if (toggler == null)
            {
                return NotFound();
            }

            _context.Toggler.Remove(toggler);
            await _context.SaveChangesAsync();

            return Ok(toggler);
        }

        private bool TogglerExists(int id)
        {
            return _context.Toggler.Any(e => e.Id == id);
        }
    }
}
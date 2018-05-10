﻿using System;
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
        [Authorize]
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
        public async Task<IActionResult> PostToggler([FromBody] Toggler toggler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var togglerList = new List<Toggler>()
            {
                new Toggler() { Id = 1, NameButton = "isButtonBlue", Allowed = "", Restricted = "Service ABC", IsOn  = true },
                new Toggler() { Id = 2, NameButton = "isButtonGreen", Allowed = "Service ABC", Restricted = "",IsOn = true },
                new Toggler() { Id = 3, NameButton = "isButtonRed", Allowed = "", Restricted = "Service ABC", IsOn = true }
            };

            _context.Toggler.AddRange(togglerList);            

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToggler", new { id = toggler.Id }, toggler);
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
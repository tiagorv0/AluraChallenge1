using AluraChallenge1.DTO;
using AluraChallenge1.Models;
using AluraChallenge1.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaService videoService, IMapper mapper)
        {
            _categoriaService = videoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categorias = await _categoriaService.GetAllAsync();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoriaDTO dto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(dto);
                var categoriaCreate = await _categoriaService.CreateAsync(categoria);
                return Created("Get", categoriaCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCategoriaDTO dto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(dto);
                var categoriaUpdated = await _categoriaService.UpdateAsync(categoria);
                return Ok(categoriaUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoriaDeleted = await _categoriaService.RemoveAsync(id);
                if (categoriaDeleted)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/video")]
        public async Task<IActionResult> VideosPorCategoria(int id)
        {
            try
            {
                var result = _categoriaService.VideosPorCategoria(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

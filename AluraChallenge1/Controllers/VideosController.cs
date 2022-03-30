using AluraChallenge1.DTO;
using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using AluraChallenge1.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public VideosController(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var videos = await _videoService.GetAllAsync();
                return Ok(videos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var video = await _videoService.GetAsync(id);
                if(video == null)
                {
                    return NotFound();
                }
                return Ok(video);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVideoDTO dto)
        {
            try
            {
                var video = _mapper.Map<Video>(dto);
                var videoCreated = await _videoService.CreateAsync(video);
                return Created("Get", videoCreated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateVideoDTO dto)
        {
            try
            {
                var video = _mapper.Map<Video>(dto);
                var videoUpdated = await _videoService.UpdateAsync(video);
                return Ok(videoUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _videoService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

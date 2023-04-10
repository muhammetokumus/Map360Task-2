﻿using Map360Task.Application.Repositories;
using Map360Task.Domain.Entities;
using Map360Task.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Map360Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyReadRepository _readRepository;
        private readonly ICompanyWriteRepository _writeRepository;

        public CompaniesController(ICompanyReadRepository readRepository, ICompanyWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_readRepository.GetAll() != null)
                return Ok(_readRepository.GetAll());
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id != null)
                return Ok(await _readRepository.GetByIdAsync(id));
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyModel model)
        {
            if (ModelState.IsValid && model != null)
            {

                var info = JsonConvert.SerializeObject(new
                {
                    Name = model.Name,
                    TaxNumber = model.TaxNumber,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                });
                var newCompainy = new Company
                {
                    Info = info
                };
                await _writeRepository.AddAsync(newCompainy);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CompanyModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var info = JsonConvert.SerializeObject(new
                {
                    Name = model.Name,
                    TaxNumber = model.TaxNumber,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                });
                var oldCompany = await _readRepository.GetByIdAsync(model.Id);
                oldCompany.Info = info;
                _writeRepository.Update(oldCompany);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var model = await _readRepository.GetByIdAsync(id);
                _writeRepository.Remove(model);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}

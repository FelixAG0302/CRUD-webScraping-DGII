using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiREDDE.DAL;
using WebApiREDDE.Data;
using WebApiREDDE.Models;
using WebApiREDDE.Services;

namespace WebApiREDDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly Company_DAL _dal;

        private readonly CompanyService _service;

        public CompanyController(Company_DAL dal, CompanyService service)
        {
            _dal = dal;

            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companies = _dal.GetAll();

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound("La compania no existe");
            }

            Company company = _dal.GetById(id);

            if (company == null)
            {
                return NotFound("La compania no existe");
            }

            return Ok(company);

        }

        [HttpGet("search/{rnc}")]
        public async Task<IActionResult> search (string rnc)
        {
            if (string.IsNullOrWhiteSpace(rnc))
            {
                return BadRequest("El RNC es obligatorio");
            }

            rnc = rnc.Replace("-", "");

            if (rnc.Length != 9 && rnc.Length != 11)
            {
                return BadRequest("Un rnc debe contener 9 digitos");
            }

            if (!long.TryParse(rnc, out long numero))
            {
                return BadRequest("El rnc solo puede contener numeros");
            }
            Company company = await _service.SearchRNC(rnc);

            if (company == null)
            {
                return NotFound("No se eencontro con alguna empresa con el rnc ingresado");
            }

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
            _dal.Create(company);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company company)
        {

            _dal.Update(id, company);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID no es válido.");
            }

            _dal.Delete(id);

            return NoContent();
        }
    }
}

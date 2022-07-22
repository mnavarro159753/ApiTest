using ApiTestSmartMed.DTOs;
using DataExchange;
using DataExchange.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTestSmartMed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationExchange medicationExchange;
        public MedicationController(IMedicationExchange medicationExchange)
        {
            this.medicationExchange = medicationExchange;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Medication>> GetAll()
        {
            var medications = medicationExchange.GetAllMedications();
            if (medications == null || medications.Count == 0)
                return NoContent();
            
            try
            {
                return Ok(medications);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Medication> Create([FromBody] MedicationDTO medicationDTO)
        {
            if (medicationDTO.cantidade <= 0)
            {
                return BadRequest();
            }
            try
            {
                var medication = new Medication
                {
                    nome = medicationDTO.nome,
                    cantidade = medicationDTO.cantidade,
                    dataCreacion = medicationDTO.dataCreacion

                };

                var medicationID = medicationExchange.Create(medication).Id;
                return CreatedAtRoute("GetMedicationByID", new { id = medicationID }, medication);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        

        [HttpDelete("{id}")]
        public ActionResult<Medication> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var medication = medicationExchange.GetMedicationByID(id);
                if (medication == null)
                    return NotFound();

                medicationExchange.Delete(id);
                medication.Id = id;
                return Ok(medication);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
    }
}

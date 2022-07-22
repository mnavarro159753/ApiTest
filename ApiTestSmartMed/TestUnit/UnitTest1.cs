using ApiTestSmartMed.Controllers;
using ApiTestSmartMed.DTOs;
using DataExchange;
using System;
using System.Collections.Generic;
using TestUnit.FakeContext;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TestUnit
{
    public class UnitTest1
    {
        private MedicationDTO medicationDTO = new MedicationDTO
        {
            nome = "ibuprofeno",
            cantidade = 3,
            dataCreacion = DateTime.Now

        };
        [Fact]
        public void create()
        {
            //Arrage
            var oController = new MedicationController(new FakeMedicationExchange());
            //act
            var resp = oController.Create(medicationDTO).Result;
            //Assert
            Assert.IsType<CreatedAtRouteResult>(resp);

        }
        [Fact]
        public void create_badrequest()
        {
            //Arrage
            medicationDTO.cantidade = 0;
            var oController = new MedicationController(new FakeMedicationExchange());
            //act
            var resp = oController.Create(medicationDTO).Result;
            //Assert
            Assert.IsType<BadRequestResult>(resp);

        }
        [Fact]
        public void readAll()
        {
            //Arrage
            var oController = new MedicationController(new FakeMedicationExchange());
            //act
            var createdMedication = (oController.Create(medicationDTO).Result as CreatedAtRouteResult).Value as Medication;

            var resp = oController.GetAll().Result;
            //Assert
            Assert.IsType<OkObjectResult>(resp);

        }
        [Fact]
        public void delete()
        {
            var oController = new MedicationController(new FakeMedicationExchange());
            var createdMedication = (oController.Create(medicationDTO).Result as CreatedAtRouteResult).Value as Medication;
            var result = oController.Delete(createdMedication.Id).Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
    }
}

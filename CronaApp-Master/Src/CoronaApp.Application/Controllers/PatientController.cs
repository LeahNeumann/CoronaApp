﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]

    public class PatientController : ControllerBase
    {

        IPatientRepository patientrepository;
        public PatientController(IPatientRepository patientrepository)
        {
            this.patientrepository = patientrepository;
        }
        // GET api/<PatientController>/5
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var patients = await patientrepository.GetAllPatients();
            if (patients == null)
                return StatusCode(404, "not found");
            if (!patients.Any())
                return StatusCode(204, "no content");
            return Ok(patients);
        }
        [HttpGet("{id}")]
        //public async Task<ActionResult> GetById(int id)
        //{
        //    var patient = await patientrepository.GetById(id);
        //    if (patient == null)
        //        return StatusCode(404, "not found");
        //    if (!patient.())
        //        return StatusCode(204, "no content");
        //    return Ok(patient);
        //}

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            
            await patientrepository.AddNewPatient(patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task Put( [FromBody] Patient patient)
        {
            
            await patientrepository.EditPatient(patient);
        }

     
    }
}

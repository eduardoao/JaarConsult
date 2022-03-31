using Application.VehicleUseCase.Commands;
using Application.VehicleUseCase.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> Create (CreateVehicleCommand vehicleCommand)
        {
            return Ok(await Mediator.Send(vehicleCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (Guid id,UpdateVehicleCommand vehicleCommand)
        {
            //if (id != vehicleCommand.Id) return BadRequest();
            vehicleCommand.Id = id;
            return Ok(await Mediator.Send(vehicleCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            return Ok(await Mediator.Send(new DeleteVehicleCommand { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllVehiclesQuery()));
        }      

        [HttpGet("{plate}")]
        public async Task<IActionResult> GetByPlate(string plate)
        {
            return Ok(await Mediator.Send(new GetVehicleQueryByPlate { Plate = plate }));
        }

        [HttpGet("{codefipe}/{year}")]
        public async Task<IActionResult> GetByCodeFipe(string codefipe, int year)
        {
            return Ok(await Mediator.Send(new GetVehicleQueryByCodeFipe { Code = codefipe, Year = year }));
        }
    }
}

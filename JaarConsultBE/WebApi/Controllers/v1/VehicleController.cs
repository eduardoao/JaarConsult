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
          var result  = (await Mediator.Send(vehicleCommand));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (Guid id,UpdateVehicleCommand vehicleCommand)
        {          
            vehicleCommand.Id = id;
            var result = (await Mediator.Send(vehicleCommand));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);       
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            var result = (await Mediator.Send(new DeleteVehicleCommand { Id = id }));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {           
            var result = (await Mediator.Send(new GetAllVehiclesQuery()));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);
        }      

        [HttpGet("{plate}")]
        public async Task<IActionResult> GetByPlate(string plate)
        {           
            var result = (await Mediator.Send(new GetVehicleQueryByPlate { Plate = plate }));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);
        }

        [HttpGet("{codefipe}/{year}")]
        public async Task<IActionResult> GetByCodeFipe(string codefipe, int year)
        {          
            var result = (await Mediator.Send(new GetVehicleQueryByCodeFipe { Code = codefipe, Year = year }));
            if (result.Succeeded) return (Ok(result));
            return BadRequest(result);
        }
    }
}

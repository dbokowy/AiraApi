using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Aira.Domain.Business.Creator.Command;
using MediatR;
using Aira.Domain.Business.Creator.Queries;
using Microsoft.AspNetCore.Cors;
using Aira.Domain.Business.Creator.Dto;

namespace Aira.Api.Controllers
{
    [ApiController]
    [Area("Creator")]
    [Route("api/v1/[area]/JobOffer/AdditionalInfo")]
    [SwaggerTag("Kreator CV")]
    public class JobOfferAdditionalInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobOfferAdditionalInfoController(IMediator mediator) 
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateJobOfferAdditionalInfoCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateJobOfferAdditionalInfoCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{jobOfferId:Guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JobOfferAdditionalInfoDto), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Get))]
        public async Task<IActionResult> Get(Guid jobOfferId)
        {
            var response = await _mediator.Send(new GetJobOfferAdditionalInfoQuery() { JobOfferId = jobOfferId });
            return Ok(response);
        }
    }
}
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Aira.Domain.Business.Creator.Command;
using MediatR;
using Aira.Domain.Business.Creator.Queries;

namespace Aira.Api.Controllers
{
    [ApiController]
    [Area("Reporting")]
    [Route("[area]/[controller]")]
    [SwaggerTag("Kreator CV")]
    public class JobOfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobOfferController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateJobOfferCommand request)
        {
            var reportPrintInModel = await _mediator.Send(request);
            return Ok(reportPrintInModel);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateJobOfferCommand request)
        {
            var reportPrintInModel = await _mediator.Send(request);
            return Ok(reportPrintInModel);
        }

        [HttpGet("{jobOfferId:Guid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = nameof(Get))]
        public async Task<IActionResult> Get(Guid jobOfferId)
        {
            var reportPrintInModel = await _mediator.Send(new GetJobOfferQuery() { JobOfferId = jobOfferId });
            return Ok(reportPrintInModel);
        }
    }
}
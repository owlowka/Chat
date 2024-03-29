﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Net;
using Chat.ApplicationServices.ErrorHandling;

namespace Chat.WebAPI.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult<TResponse>> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            TResponse? response = await _mediator.Send(request);
            if (response.Error != null)
            {
                return ErrorResponse<TResponse>(response.Error);
            }
            return Ok(response);
        }

        private ActionResult<TResponse> ErrorResponse<TResponse>(ErrorModel errorModel)
        {
            HttpStatusCode httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;

                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;

                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;

                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;

                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;

                //case ErrorType.UnsupportedMediaType

                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;

                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}

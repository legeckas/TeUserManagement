using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeUserManagement.Models.Responses;

namespace TeUserManagement.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region GenericResponses

        [NonAction]
        protected GenericResponse<TModel> Ok<TModel>(TModel content, string message = null!)
        {
            return new GenericResponse<TModel>
            {
                Content = content,
                StatusCode = StatusCodes.Status200OK,
                Message = string.IsNullOrEmpty(message) && content == null
                    ? "The request was successful, but no content has been retrieved."
                    : message
            };
        }

        [NonAction]
        protected GenericResponse<TModel?> OkNoContent<TModel>(string message = null!)
        {
            return new GenericResponse<TModel?>
            {
                Content = default,
                StatusCode = StatusCodes.Status204NoContent,
                Message = message
            };
        }

        #endregion
    }
}

using System;
using System.Net;

namespace Shared.DTO
{
	public class ApiResponse
	{
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public string ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}


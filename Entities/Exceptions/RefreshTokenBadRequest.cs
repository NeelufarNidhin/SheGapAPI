using System;
namespace Entities.Exceptions
{
	public sealed class RefreshTokenBadRequest : BadRequestException
	{
		public RefreshTokenBadRequest() :base("Invalid clinet Request.The token has some Inavlid values")
		{
		}
	}
}


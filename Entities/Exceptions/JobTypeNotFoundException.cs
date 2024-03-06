using System;
namespace Entities.Exceptions
{
	public class JobTypeNotFoundException :NotFoundException
	{
		public JobTypeNotFoundException(Guid Id):base($"The job with id{Id} not found")
		{
		}
	}
}


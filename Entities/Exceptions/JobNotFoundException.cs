using System;
namespace Entities.Exceptions
{
	public class JobNotFoundException : NotFoundException
	{
		public JobNotFoundException(Guid jobId) : base ($"The job with {jobId} not found")
		{
		}
	}
}


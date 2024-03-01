using System;
namespace Entities.Exceptions
{
	public sealed class JobSeekerNotFoundException : NotFoundException
	{
		public JobSeekerNotFoundException(Guid jobSeekerId) : base($"The jobSeeker with Id : {jobSeekerId} doesn't exist")

		{
		}
	}
}


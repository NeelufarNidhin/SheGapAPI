using System;
namespace Entities.Exceptions
{
	public class ExperienceNotFoundException : NotFoundException
	{
		public ExperienceNotFoundException(Guid experienceId) : base($"The experience with Id {experienceId} not found")
		{
		}
	}
}


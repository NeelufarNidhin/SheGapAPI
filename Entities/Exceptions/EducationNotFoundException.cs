using System;
using Entities.Models;

namespace Entities.Exceptions
{
	public class EducationNotFoundException : NotFoundException
    {
		public EducationNotFoundException(Guid educationId) : base($"The education with Id : {educationId} doesn't exist")
		{
		}
	}
}


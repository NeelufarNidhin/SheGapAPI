using System;
namespace Entities.Exceptions
{
	public class JobSkillNotFoundException : NotFoundException
	{
        public JobSkillNotFoundException(Guid Id) : base($"The job with id{Id} not found")
        {
        }
    }
}


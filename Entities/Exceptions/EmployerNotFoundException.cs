using System;
namespace Entities.Exceptions
{
	public class EmployerNotFoundException : NotFoundException
	{
		public EmployerNotFoundException(Guid employerId) : base($"The employer with Id : {employerId} doesn't exist")

        {
        }

    }
}


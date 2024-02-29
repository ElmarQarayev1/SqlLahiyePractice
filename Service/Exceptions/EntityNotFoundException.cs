using System;
namespace Service.Exceptions
{
	public class EntityNotFoundException:Exception
	{
		public EntityNotFoundException(string message):base(message)
		{

		}
		
	}
}


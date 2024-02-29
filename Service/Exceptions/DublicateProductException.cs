using System;
namespace Service.Exceptions
{
	public class DublicateProductException:Exception
	{
		public DublicateProductException(string message):base(message)
		{
		}
	}
}


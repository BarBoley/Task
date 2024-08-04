

namespace Task.Services.Factories
{
	internal interface IFactory<T>
	{
		public T GetNewObject();
	}
}

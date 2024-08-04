

namespace Task.Services.Factories
{
    internal class ClientFactory : IFactory<HttpClient>, IService
	{
		private string _baseAddress;
		
		public ClientFactory(string baseAdress)
		{
			_baseAddress = baseAdress;
		}
		public HttpClient GetNewObject()
		{
			HttpClient client = new()
			{
				BaseAddress = new Uri(_baseAddress),
			};
			client.DefaultRequestHeaders.Add("TRON-PRO-API-KEY", Constants.KeyAPI);
			return client;
		}
	}
}

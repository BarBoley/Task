using System.Text;
using System.Text.Json;
using Task.Security.Entities;
using Task.Services;
using Task.Services.Cache;

namespace Task.Security
{
    internal class SecurityService : IService
    {
        private HttpClient _httpClient;
		private ICacheService<object> _cacheService;
		public SecurityService(HttpClient httpClient, ICacheService<object> cacheService)
		{
			_httpClient = httpClient;
			_cacheService = cacheService;
		}

		private async Task<string> GetTransactionsSecurity(string request)
		{
			string response = await _httpClient.GetStringAsync(request);
			return response;
		}

		public async Task<Dictionary<string, TransactionSecurity>> CheckTransactionsSecurity(string[] hashes)
		{
			StringBuilder stringBuilder = new();
			stringBuilder.Append(string.Join(",", hashes));
			string request = "transaction/data?hashes=" + stringBuilder.ToString();

			if (_cacheService.TryGetCache(request, out Dictionary<string, TransactionSecurity> foundedTransactions))
			{
				return foundedTransactions;
			}

			string response = await GetTransactionsSecurity(request);

			Dictionary<string, TransactionSecurity> transactions
				= JsonSerializer.Deserialize<Dictionary<string, TransactionSecurity>>(response);
			
			_cacheService.TryAddCache(request, transactions);

			return transactions;
		}

    }
}

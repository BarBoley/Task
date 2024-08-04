using Task.Security;
using Task.Security.Entities;
using Task.Services.Container;
using Task.Services.View;

namespace Task.Services.Controllers
{
	internal class ProgramController
	{
		ConsoleDataViewer _dataViewer;
		public void Init()
		{
			_dataViewer = new();
			ServiceLocator.Initialize();
			SecurityServiceContainer serviceContainer = new ();
			serviceContainer.LoadContainer(ServiceLocator.Instance);
		}

		public void DoProgram()
		{
			if (ServiceLocator.Instance.TryGetService(out SecurityService securityService))
			{
				while (true)
				{
					Console.WriteLine("Please, enter the hashes to check.");
					try
					{
						string[] hashes = Console.ReadLine().Split(',', ' ', ';');
						var transactionsSecurity = securityService.CheckTransactionsSecurity(hashes).Result;
						foreach ( KeyValuePair<string, TransactionSecurity> transaction in transactionsSecurity)
						{
							Console.WriteLine("\nhash: "+transaction.Key);
							_dataViewer.Display(transaction.Value);
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						throw;
					}
				}
			}
		}
	}
}

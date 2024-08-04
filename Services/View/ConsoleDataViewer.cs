
using Task.Security.Entities;

namespace Task.Services.View
{
	internal class ConsoleDataViewer:IDataViewer<TransactionSecurity>
	{
		public void Display(TransactionSecurity transactionSecurity)
		{
			Console.WriteLine("Risk token: "	   + transactionSecurity.RiskToken);
			Console.WriteLine("Zero transfer: "	   + transactionSecurity.ZeroTransfer);
			Console.WriteLine("Risk address: "	   + transactionSecurity.RiskAddress);
			Console.WriteLine("Same tail attach: " + transactionSecurity.SameTailAttach);
			Console.WriteLine("Risk transaction: " + transactionSecurity.RiskTransaction);
		}
	}
}

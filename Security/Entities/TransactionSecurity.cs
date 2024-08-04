using System.Text.Json.Serialization;

namespace Task.Security.Entities
{
	internal class TransactionSecurity
	{
		[property: JsonPropertyName("riskToken")] public bool RiskToken { get; set; }
		[property: JsonPropertyName("zeroTransfer")] public bool ZeroTransfer { get; set; }
		[property: JsonPropertyName("riskAddress")] public bool RiskAddress { get; set; }
		[property: JsonPropertyName("sameTailAttach")] public bool SameTailAttach { get; set; }
		[property: JsonPropertyName("riskTransaction")] public bool RiskTransaction { get; set; }

	}
}

using System.ComponentModel.DataAnnotations;

namespace portafoglio.api.Models.Requests;

public class CreateWalletRequest
{
	[Required] public string Name { get; set; } = null!;
	[Required] public int Money { get; set; } = 0;
	[Required] public Guid IdUser { get; set; } = Guid.Empty;
	public string? Description { get; set; } = null;
}

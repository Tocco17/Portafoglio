using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using portafoglio.bl.Entities;

namespace portafoglio.api.Models.Filters;

public class EarningSuddivisionFilter : BaseLogicDeleteFilter<EarningSuddivision>
{
	public Guid? IdUser { get; set; } = null;
	public int? Percentage { get; set; } = null;
	public string? Name { get; set; } = null;
	public string? Description { get; set; } = null;

	public override IQueryable<EarningSuddivision> GetOptionsFilterQuery(IQueryable<EarningSuddivision> baseQuery)
	{
		var query = baseQuery.AsQueryable();

		if (IdUser != null) 
			query = query.Where(x => x.IdUser == IdUser);

		if (Percentage != null) 
			query = query.Where(x => x.Percentage == Percentage);

		if (Name != null) 
			query = query.Where(x => x.Name.Contains(Name));

		if (Description != null) 
			query = query.Where(x => x.Description != null && x.Description.Contains(Description));

		return base.GetOptionsFilterQuery(query);
	}
}

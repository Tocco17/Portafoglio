using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using portafoglio.api.Models.Entities;

namespace portafoglio.api.Models.Filters;

public class LabelFilter : BaseLogicDeleteFilter<Label>
{
	public Guid? IdEarningSuddivision { get; set; } = null;
	public Guid? IdUser { get; set; } = null;
	public string? Name { get; set; } = null;
	public string? Description { get; set; } = null;
	public Guid? IdFatherLabel { get; set; } = null;

	public override IQueryable<Label> GetOptionsFilterQuery(IQueryable<Label> baseQuery)
	{
		var query = baseQuery.AsQueryable();

		if (IdEarningSuddivision != null) 
			query = query.Where(x => x.IdEarningSuddivision == IdEarningSuddivision);

		if (IdUser != null) 
			query = query.Where(x => x.EarningSuddivision.IdUser == IdUser );

		if(Name != null) 
			query = query.Where(x => x.Name.Contains(Name) );

		if(Description != null) 
			query = query.Where(x => x.Description != null && x.Description.Contains(Description) );

		if(IdFatherLabel != null) 
			query = query.Where(x => x.IdFatherLabel == IdFatherLabel );



		return base.GetOptionsFilterQuery(query);
	}
}

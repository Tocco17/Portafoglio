﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), nameof(Name), IsUnique = true)]
[Index(nameof(IdPortafoglio), IsUnique = false)]
public class Subscription : BaseLogicDeleteEntity
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; } = null;

	public int IdPortafoglio { get; set; }
	[ForeignKey(nameof(IdPortafoglio))] public Portafoglio? Portafoglio { get; set; } = null;

	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;

	public int Value { get; set; }

	public PeriodicityPayment Periodicity { get; set; }
}

public enum PeriodicityPayment
{
	Daily,
	Weekly,
	Monthly,
	Quarterly,
	SemiAnnual,
	Annual,
	Biennal,
}

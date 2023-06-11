using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class FrequentPaymentController : LogicDeleteController<FrequentPayment, FrequentPaymentFilter>
{
    public FrequentPaymentController(ILogger<FrequentPayment> logger, IRepository<FrequentPayment, FrequentPaymentFilter> dbRepo) : base(logger, dbRepo)
    {
    }
}

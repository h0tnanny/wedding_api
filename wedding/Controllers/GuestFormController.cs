using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding.API.Models.Input;
using Wedding.API.Persistence;
using Wedding.API.Persistence.Models;

namespace Wedding.API.Controllers;

[Route("api/[controller]")]
public sealed class GuestFormController(ILogger<GuestFormController> logger, 
    ApplicationDbContext dbContext) : ControllerBase
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<GuestFormController> _logger = logger;
    
    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<GuestForm>), 200)]
    public async Task<IActionResult> GetGuestFormAllAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("Запрос всех форм гостей");
        
        var guestFormList = await _dbContext.GuestForms.AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ok(guestFormList);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(GuestForm), 200)]
    public async Task<IActionResult> CreateGuestFormAsync([FromBody] GuestFormCreateModel createModel,
        CancellationToken cancellationToken = default)
    {
        _logger.LogTrace($"Создание формы гостя");
        
        var guestForm = new GuestForm()
        {
            Id = Guid.NewGuid(),
            FullName = createModel.FullName,
            HelpSelectors = createModel.HelpSelector?.Select(x => (HelpSelector)x).ToArray(),
            Preferences = createModel.Preferences
        };

        await _dbContext.GuestForms.AddAsync(guestForm, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok(guestForm);
    }
}
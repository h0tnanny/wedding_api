using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding.API.Models.Input;
using Wedding.API.Persistence;
using Wedding.API.Persistence.Models;

namespace Wedding.API.Controllers;

[Route("api/[controller]")]
public sealed class WelcomeController(ILogger<WelcomeController> logger, 
    ApplicationDbContext dbContext) : ControllerBase
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<WelcomeController> _logger = logger;
    
    [HttpGet("get/{key}")]
    [ProducesResponseType(typeof(WelcomeEntity), 200)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> GetWelcomeByKey(string key, CancellationToken cancellationToken = default)
    {
        _logger.LogTrace($"Запрос приглашения для: {key}");

        var welcome = await GetByKey(key, cancellationToken);

        if (welcome is null) return NoContent();
        
        return Ok(welcome);
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<WelcomeEntity>), 200)]
    public async Task<IActionResult> GetWelcomeAll(CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("Получение всех приглашений");
        
        var welcomeList = await _dbContext.WelcomeEntities.AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ok(welcomeList);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(WelcomeEntity), 200)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> CreateWelcome([FromBody] WelcomeCreateModel createModel, CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("Создание приглашения");
        
        var welcome = await GetByKey(createModel.Key, cancellationToken);

        if (welcome is not null) return Conflict("Значение с таким ключом уже существует!");
        
        var newWelcome = new WelcomeEntity()
        {
            Id = Guid.NewGuid(),
            Key = createModel.Key,
            Title = createModel.Title,
            Text = createModel.Text
        };

        await _dbContext.WelcomeEntities.AddAsync(newWelcome, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
            
        return Ok(newWelcome);
    }

    private async Task<WelcomeEntity?> GetByKey(string key, CancellationToken cancellationToken = default)
    {
        var welcome = await _dbContext.WelcomeEntities.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Key == key, cancellationToken);

        return welcome;
    }
}
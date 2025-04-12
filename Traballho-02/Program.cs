using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ApplyMigrations(app);

MapEndpoints(app);

app.Run();

#region Configuração
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<NotasDbContext>(options =>
        options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
}
#endregion

#region Migrations
void ApplyMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<NotasDbContext>();
    dbContext.Database.Migrate();
}
#endregion

#region Rotas
void MapEndpoints(WebApplication app)
{
    app.MapPost("/notas", async (Nota nota, NotasDbContext db) =>
    {
        var erros = ValidarNota(nota);
        if (erros.Any()) return Results.BadRequest(erros);

        nota.Id = Guid.NewGuid();
        nota.DataLancamento = DateTime.UtcNow;

        db.Notas.Add(nota);
        await db.SaveChangesAsync();

        return Results.Created($"/notas/{nota.Id}", nota);
    });

    app.MapGet("/notas", async (NotasDbContext db) =>
        await db.Notas.ToListAsync());

    app.MapGet("/notas/{id}", async (Guid id, NotasDbContext db) =>
    {
        var nota = await db.Notas.FindAsync(id);
        return nota is not null ? Results.Ok(nota) : Results.NotFound("Nota não encontrada.");
    });

    app.MapPut("/notas/{id}", async (Guid id, Nota notaAtualizada, NotasDbContext db) =>
    {
        var nota = await db.Notas.FindAsync(id);
        if (nota is null) return Results.NotFound("Nota não encontrada.");

        var erros = ValidarNota(notaAtualizada);
        if (erros.Any()) return Results.BadRequest(erros);

        nota.Aluno = notaAtualizada.Aluno;
        nota.Disciplina = notaAtualizada.Disciplina;
        nota.Valor = notaAtualizada.Valor;

        await db.SaveChangesAsync();
        return Results.Ok(nota);
    });

    app.MapDelete("/notas/{id}", async (Guid id, NotasDbContext db) =>
    {
        var nota = await db.Notas.FindAsync(id);
        if (nota is null) return Results.NotFound("Nota não encontrada.");

        db.Notas.Remove(nota);
        await db.SaveChangesAsync();

        return Results.Ok(nota);
    });
}
#endregion

#region Validação
List<string> ValidarNota(Nota nota)
{
    var erros = new List<string>();

    if (string.IsNullOrWhiteSpace(nota.Aluno) || nota.Aluno.Length > 100)
        erros.Add("Aluno é obrigatório e deve ter no máximo 100 caracteres.");

    if (string.IsNullOrWhiteSpace(nota.Disciplina) || nota.Disciplina.Length > 100)
        erros.Add("Disciplina é obrigatória e deve ter no máximo 100 caracteres.");

    if (nota.Valor < 0 || nota.Valor > 10)
        erros.Add("Valor deve estar entre 0 e 10.");

    return erros;
}
#endregion

#region Models e DbContext
public class Nota
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string Aluno { get; set; }

    [Required, MaxLength(100)]
    public string Disciplina { get; set; }

    [Required, Range(0, 10)]
    public decimal Valor { get; set; }

    [Required]
    public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
}

public class NotasDbContext : DbContext
{
    public NotasDbContext(DbContextOptions<NotasDbContext> options) : base(options) { }

    public DbSet<Nota> Notas { get; set; }
}
#endregion

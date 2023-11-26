using NHibernate.Driver;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Npgsql;
using NHibernate.Mapping.ByCode;
using EstagioJaAPI.Models;
using EstagioJaAPI;
using EstagioJaAPI.Repositories;
using EstagioJaAPI.Services;
using NHibernate.Mapping.Attributes;

// ...

var configuration = new Configuration();
configuration.Configure("hibernate.cfg.xml");

var modelMapper = new ModelMapper();
modelMapper.AddMappings(typeof(Curso).Assembly.GetExportedTypes());
modelMapper.AddMappings(typeof(Competencia).Assembly.GetExportedTypes());
modelMapper.AddMappings(typeof(Vaga).Assembly.GetExportedTypes());
configuration.AddAssembly(typeof(Curso).Assembly);
configuration.AddAssembly(typeof(Competencia).Assembly);
configuration.AddAssembly(typeof(Vaga).Assembly);
configuration.AddAssembly(typeof(Endereco).Assembly);
configuration.AddAssembly(typeof(Estudante).Assembly);
configuration.AddAssembly(typeof(Empresa).Assembly);
configuration.AddAssembly(typeof(Auth).Assembly);
configuration.AddAssembly(typeof(FraseEmpresa).Assembly);
configuration.AddAssembly(typeof(FraseEstudante).Assembly);
configuration.AddAssembly(typeof(Notificacao).Assembly);
configuration.AddInputStream(HbmSerializer.Default.Serialize(
	System.Reflection.Assembly.GetExecutingAssembly()));

//var hbmMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
//configuration.AddMapping(hbmMapping);

configuration.DataBaseIntegration(db =>
{
    db.Dialect<PostgreSQL83Dialect>();
    db.Driver<NpgsqlDriver>();
    db.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
    db.ConnectionString = "Server=db;Port=5432;Database=estagioja;User Id=estagioja;Password=estagioja;";
});

var sessionFactory = configuration.BuildSessionFactory();

// ...

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<NHibernate.ISessionFactory>(sessionFactory);

//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICompetenciaRepository, CompetenciaRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IFraseRepository, FraseRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();

// Registro do serviço
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<ICompetenciaService, CompetenciaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEstudanteService, EstudanteService>();
builder.Services.AddScoped<IFraseService, FraseService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<NHibernate.ISession>(factory =>
   factory
        .GetServices<NHibernate.ISessionFactory>()
        .First()
        .OpenSession()
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

//startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.

/*app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstagioJa");
    c.RoutePrefix = string.Empty;
});*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();
        


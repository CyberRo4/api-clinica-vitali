using API_Gestión_de_Clínica_Médica_Vitali.Data;
using API_Gestión_de_Clínica_Médica_Vitali.Models;
using API_Gestión_de_Clínica_Médica_Vitali.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 🔐 CLAVE JWT
var key = "MI_API_CLINICA_VITALI_2026_SUPER_SEGURA";

// 🔐 SWAGGER CON JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "🏥 API Clínica Vitali",
        Version = "v1",
        Description = "Sistema de gestión médica: pacientes, médicos, citas e historial clínico"
    });

    // ORDEN DE CONTROLADORES
    c.OrderActionsBy(api =>
    {
        var path = api.RelativePath.ToLower();

        if (path.Contains("paciente")) return "1";
        if (path.Contains("medico")) return "2";
        if (path.Contains("cita")) return "3";
        if (path.Contains("historial")) return "4";

        return "5";
    });

    // JWT CONFIG
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    // 🔥 (OPCIONAL) EVITA ERRORES DE CONFLICTOS
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// 🗄️ BASE DE DATOS
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string vacía");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 🧠 SERVICIOS
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<HistorialService>();

// 🔐 AUTENTICACIÓN JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
        )
    };
});

// 🎮 CONTROLLERS
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// SWAGGER
builder.Services.AddEndpointsApiExplorer();

// 🌐 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

// Swagger limpio
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clínica Vitali API v1");

    c.InjectStylesheet("data:text/css," + Uri.EscapeDataString(@"
        /* 🌑 FONDO GENERAL */
        body {
            background: #0b1220 !important;
            font-family: 'Segoe UI', sans-serif;
        }

        /* 🔝 HEADER */
        .swagger-ui .topbar {
            background: #020617 !important;
            border-bottom: 2px solid #0ea5e9;
        }

        /* 🔤 LOGO / TEXTO */
        .swagger-ui .topbar-wrapper span {
            color: #0ea5e9 !important;
            font-size: 18px;
            font-weight: bold;
        }

        /* 📄 TÍTULO */
        .swagger-ui .info h2 {
            color: #e2e8f0 !important;
        }

        /* 📦 CONTENEDOR */
        .swagger-ui .scheme-container {
            background: #020617 !important;
            border-radius: 12px;
            padding: 10px;
        }

        /* 📦 TARJETAS */
        .swagger-ui .opblock {
            border-radius: 14px !important;
            margin-bottom: 15px;
            border: none !important;
            box-shadow: 0 6px 18px rgba(0,0,0,0.5);
            overflow: hidden;
        }

        /* 🔵 GET */
        .swagger-ui .opblock.opblock-get {
            background: linear-gradient(135deg, #1d4ed8, #2563eb);
        }

        /* 🟢 POST */
        .swagger-ui .opblock.opblock-post {
            background: linear-gradient(135deg, #065f46, #10b981);
        }

        /* 🟠 PUT */
        .swagger-ui .opblock.opblock-put {
            background: linear-gradient(135deg, #92400e, #f59e0b);
        }

        /* 🔴 DELETE */
        .swagger-ui .opblock.opblock-delete {
            background: linear-gradient(135deg, #7f1d1d, #ef4444);
        }

        /* 📌 TEXTO ENDPOINT */
        .swagger-ui .opblock-summary {
            color: white !important;
            font-weight: 600;
        }

        /* 📄 DESCRIPCIÓN */
        .swagger-ui .opblock-description-wrapper {
            color: #cbd5f5 !important;
        }

        /* 🔘 BOTONES */
        .swagger-ui .btn {
            border-radius: 10px !important;
            font-weight: bold;
            transition: all 0.2s ease;
        }

        .swagger-ui .btn:hover {
            transform: scale(1.05);
        }

        /* ▶ EXECUTE */
        .swagger-ui .btn.execute {
            background: #0ea5e9 !important;
            color: black !important;
        }

        /* 🔽 INPUTS */
        .swagger-ui input,
        .swagger-ui textarea {
            background: #020617 !important;
            color: #e2e8f0 !important;
            border: 1px solid #334155 !important;
            border-radius: 8px;
        }

        /* 📊 RESPUESTAS */
        .swagger-ui .responses-wrapper {
            background: #020617 !important;
            border-radius: 10px;
            padding: 10px;
        }

        /* 🧾 CÓDIGO */
        .swagger-ui pre {
            background: #020617 !important;
            color: #e2e8f0 !important;
        }

        /* 📋 SCROLL */
        ::-webkit-scrollbar {
            width: 8px;
        }

        ::-webkit-scrollbar-thumb {
            background: #334155;
            border-radius: 10px;
        }
        .swagger-ui .opblock-tag {
    transition: all 0.2s ease;
}

    .swagger-ui .opblock-tag:hover {
        color: #38bdf8 !important;
        transform: translateX(5px);
    }

        /* 🏷️ Títulos de secciones (Cita, Historial, etc) */
        .swagger-ui .opblock-tag {
        color: #ffffff !important;
        font-size: 22px;
        font-weight: bold;
        }

        /* 🔽 Línea debajo del título */
        .swagger-ui .opblock-tag-section {
        border-bottom: 1px solid #334155 !important;
        }



        /* 🔗 URL    del endpoint (/api/Cita) */
        .swagger-ui .opblock-summary-path {
         color: #ffffff !important;
        font-weight: bold;
        }

        /* 🔗 Método + ruta juntos */
        .swagger-ui .opblock-summary-path__deprecated {
        color: #ffffff !important;
        }

        .swagger-ui .opblock-summary-path {
        color: #e2e8f0 !important;
        letter-spacing: 0.5px;
        }

       .swagger-ui .topbar-wrapper span::after {
       content: ""  |  Sistema Clínico Vitali"";
       color: #38bdf8;
       font-weight: bold;
       }

       .swagger-ui .topbar-wrapper {
       background-image: url('https://cdn-icons-png.flaticon.com/512/2967/2967350.png');
       background-repeat: no-repeat;
       background-position: left center;
       padding-left: 50px;
       }

                /* Citas */
        .opblock-tag[data-tag=""Cita""] {
            border-left: 5px solid #3b82f6;
        }

        /* Historial */
        .opblock-tag[data-tag=""Historial""] {
            border-left: 5px solid #10b981;
        }

        /* Pacientes */
        .opblock-tag[data-tag=""Paciente""] {
            border-left: 5px solid #f59e0b;
        }

        /* Médicos */
        .opblock-tag[data-tag=""Medico""] {
            border-left: 5px solid #ef4444;
        }

        .swagger-ui .opblock {
            transition: all 0.3s ease;
        }

        .swagger-ui .opblock:hover {
            transform: scale(1.02);
        }

        .swagger-ui .btn.execute {
            background: linear-gradient(135deg, #38bdf8, #0ea5e9) !important;
            color: black !important;
            box-shadow: 0 0 10px #0ea5e9;
        }
    


.opblock-tag[data-tag=""Paciente""]::before {
    content: ""👤 "";
}

.opblock-tag[data-tag=""Medico""]::before {
    content: ""🩺 "";
}

.opblock-tag[data-tag=""Cita""]::before {
    content: ""📅 "";
}

.opblock-tag[data-tag=""Historial""]::before {
    content: ""📄 "";
}

"));

    c.InjectJavascript("data:text/javascript," + Uri.EscapeDataString(@"
        (function () {

            function injectToken() {

                const token = localStorage.getItem('token');

                if (!token) {
                    window.location.href = '/index.html';
                    return;
                }

                const originalFetch = window.fetch;

                window.fetch = function (url, options = {}) {
                    options.headers = options.headers || {};
                    options.headers['Authorization'] = 'Bearer ' + token;
                    return originalFetch(url, options);
                };

                console.log('✅ Token automático activo');

            }

            setTimeout(injectToken, 1000);

        })();

    "));
});

// 🌐 CORS
app.UseCors("PermitirTodo");

// 🔐 ORDEN CORRECTO
app.UseAuthentication();
app.UseAuthorization();

// 🚀 CONTROLADORES
app.MapControllers();

app.Run();
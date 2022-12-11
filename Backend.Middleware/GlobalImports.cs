﻿global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using System.Text.Json;
global using System.Runtime.Serialization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.ResponseCompression;
global using Microsoft.Extensions.DependencyInjection;
global using System.IO.Compression;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using System.Reflection;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc.Infrastructure;
global using Microsoft.AspNetCore.Mvc.Routing;
global using NetCore.AutoRegisterDi;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.OpenApi.Models;

global using Backend.Models.Common;
global using Backend.Models.Options;
global using Backend.Middleware.Middlewares;
global using Backend.Middleware.Exceptions;
global using Backend.Middleware.Attributes;
global using Backend.Middleware.Binders;
global using Backend.Database;
global using Backend.Models.Settings;
global using Backend.Infrastructure.Interfaces.Common;
global using Backend.Middleware.HealthStatuses;
global using Backend.Models.Settings;

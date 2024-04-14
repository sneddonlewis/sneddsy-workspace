using SneddsyWorkspace.Apps.KratoApi.KratoApi;

WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .ConfigurePipeline()
    .Run();

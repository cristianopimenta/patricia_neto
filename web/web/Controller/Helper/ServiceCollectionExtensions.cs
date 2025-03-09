using Microsoft.Extensions.DependencyInjection;


namespace web
{
    public static class eServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Adicione todos os serviços aqui
            services.AddScoped<IPlanoConta, PlanoContaService>();
            services.AddScoped<IPet, PetService>();
            services.AddScoped<IEmpresa, EmpresaService>();
            services.AddScoped<IImoveis, ImovelService>();
            services.AddScoped<ILocalidade, LocalidadeService>();
            services.AddScoped<IOcorrenciaInterna, OcorrenciaInternaService>();
            services.AddScoped<IPessoaVeiculo, PessoaVeiculoService>();
            services.AddScoped<IPessoaDocumento, PessoaDocumentoService>();
            services.AddScoped<ICondominio, CondominioService>();
            services.AddScoped<IPessoa, PessoaService>();
            services.AddScoped<IPessoaPermanente, PessoaPermanenteService>();
            services.AddScoped<IPessoaContato, PessoaContatoService>();
            services.AddScoped<IPessoaEnderecos, PessoaEnderecoService>();
            services.AddScoped<IPanicoMobile, PanicoMobileService>();
            
            //Financeiro//
            services.AddScoped<IContaPagar, ContaPagarService>();
            services.AddScoped<ContaReceberService>();
            services.AddScoped<DerService>();
            services.AddScoped<RelatorioService>();
            services.AddScoped<FornecedorService>();

            
           


            services.AddScoped<HelperConfiguracoes>();
            services.AddHttpClient<BuscarCEPService>();
          
            return services;
        }
    }
}


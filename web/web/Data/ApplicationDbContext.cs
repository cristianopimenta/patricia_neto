using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using web.Data.Autenticacao;
using web.Data.Financeiro;
using static web.Data.ApplicationDbContext;


namespace web.Data

{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Financeiro
        public DbSet<CobrancaInadimplenteModel> CobrancasInadimplentes { get; set; }
        public DbSet<ContaPagarModel> ContasPagar { get; set; }
        public DbSet<ContaReceberModel> ContasReceber { get; set; }
        public DbSet<PagarParcialModel> PagamentosPaciais { get; set; }
        public DbSet<ParcialReceberModel> RecebimentosPaciais { get; set; }
        public DbSet<PlanoContaModel> PlanoContas { get; set; }
        public DbSet<BancoModel> Bancos { get; set; }
        public DbSet<BancoConta> BancosConta { get; set; }
        public DbSet<ConciliacaoBancariaModel> ConciliacoesBancarias { get; set; }

        //Pessoas
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<PessoaDocumento> PessoaDocumentos { get; set; }

        public DbSet<EnderecoModel> Enderecos { get; set; }

        //Cadastro
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<FornecedorModel> Fonecedores { get; set; }
        public DbSet<PetModel> AnimaisEstimacao { get; set; }
        public DbSet<ImovelAgregadoModel> ImoveisAgradados { get; set; }
        public DbSet<ImovelModel> Imoveis { get; set; }

        public DbSet<PessoaPermanente> pessoasPermanentes { get; set; }
        public DbSet<PessoaContato> pessoasContatos { get; set; }

        public DbSet<PessoaVeiculo> pessoasVeiculos { get; set; }
        public DbSet<PessoaEndereco> pessoasEnderecos { get; set; }

        public DbSet<TipoPerfilModel> TipoPerfis { get; set; }

        // public DbSet<ImovelSituacaoModel> ImoveisSituacoes { get; set; }
        public DbSet<LocalidadeModel> Localidades { get; set; }
        public DbSet<OcorrenciaInternaModel> OcorrenciasInternas { get; set; }

        public DbSet<CondominioModel> Condominios { get; set; }
        public DbSet<PanicoMobile> panicos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<UserToken> userTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações personalizadas, como relacionamentos, restrições, etc.
            modelBuilder.Entity<PessoaModel>().HasKey(p => p.Id);
            modelBuilder.Entity<PessoaContato>().HasKey(p => p.Id);
            modelBuilder.Entity<UserToken>().HasNoKey();

            modelBuilder.Entity<CondominioModel>()
                .HasIndex(e => e.CNPJ)
                .IsUnique();

            modelBuilder.Entity<EmpresaModel>(entity =>
            {
                entity.HasKey(e => e.Id); // Defina a chave primária

                entity.Property(e => e.CNPJ)
                    .IsRequired() // CNPJ é obrigatório
                    .HasMaxLength(18); // Exemplo de limite de tamanho
            });
        }
    }
}
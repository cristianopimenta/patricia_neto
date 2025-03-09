using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace web
{
    [Table("Imoveis")]
    public class ImovelModel
    {
        public ImovelModel()
        {
            // Necessário para o EF Core
        }
        [Key] public int Id { get; set; }

        public int? IdEmpresa { get; set; }
        public EmpresaModel? Empresa { get; set; }
        public string? Quadra { get; set; }
        public string? Lote { get; set; }
        public string? Sala { get; set; }
        public string? Andar { get; set; }
        public string? Torre { get; set; }
        public StatusImovel StatusImovel { get; set; }
        public string? Lograouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public decimal? AreaImovel { get; set; }
        public decimal? AreaConstruida { get; set; }
        public decimal? AreaJardinada { get; set; }
        public decimal? BaseCalculo { get; set; }
        public bool ImovelFicticio { get; set; } = false;
        public decimal? AreaTotalOriginal { get; set; }
        public decimal? AreaConstruidaOriginal { get; set; }
        public decimal? AreaPermeavel { get; set; }
        public bool? PossuiPiscina { get; set; }
        public bool? PossuiEdicula { get; set; }
        public decimal? AreaEdicula { get; set; }
        public decimal? AreaAproveitamento { get; set; }
        public decimal? Frente { get; set; }
        public decimal? FrenteM { get; set; }
        public decimal? Fundo { get; set; }
        public decimal? FundoM { get; set; }
        public decimal? Direita { get; set; }
        public decimal? DireitaM { get; set; }
        public decimal? Esquerda { get; set; }
        public decimal? EsquerdaM { get; set; }
        public decimal? Chanfro { get; set; }
        public DateTime? HabitesePrefeitura { get; set; }
        public DateTime? Vistoria { get; set; }
        public DateTime? EntradaRememb { get; set; }
        public DateTime? AprovacaoCondominio { get; set; }
        public DateTime? AprovacaoPrefeitura { get; set; }
        public DateTime? EnvioCopiaAusa { get; set; }
        public DateTime? RetornoAusa { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        public decimal? IndiceOcupacao { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int? PesoVoto { get; set; }
        public bool? PossuiTitulo { get; set; } = false;
        public string? Tipo { get; set; }

        public string? usuarioId { get; set; }


    }
}

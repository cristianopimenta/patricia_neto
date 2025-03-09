-- Backup do Banco de Dados
-- Data: 03/02/2025 14:52:52


-- Estrutura da tabela `__efmigrationshistory`
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

INSERT INTO `__efmigrationshistory` VALUES ('20250131134949_Inicial', '8.0.12');

-- Estrutura da tabela `aberturaporbotoeiras`
DROP TABLE IF EXISTS `aberturaporbotoeiras`;
CREATE TABLE `aberturaporbotoeiras` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdDispositivo` int(11) NOT NULL,
  `TipoDispositivo` longtext NOT NULL,
  `DataAbertura` datetime(6) NOT NULL,
  `idUsuario` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `acessos`
DROP TABLE IF EXISTS `acessos`;
CREATE TABLE `acessos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) NOT NULL,
  `IdEquipamento` int(11) NOT NULL,
  `dataAcesso` datetime(6) NOT NULL,
  `tipoAcesso` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `areas`
DROP TABLE IF EXISTS `areas`;
CREATE TABLE `areas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DescricaoAreaComum` longtext NOT NULL,
  `DataReservaInicial` datetime(6) DEFAULT NULL,
  `DataReservaFinal` datetime(6) DEFAULT NULL,
  `ValorReserva` double DEFAULT NULL,
  `StatusReserva` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetroleclaims`
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetroles`
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetuserclaims`
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetuserlogins`
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetuserroles`
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `aspnetusers`
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

INSERT INTO `aspnetusers` VALUES ('2eb33144-6056-47e2-b69a-12cef2c2e934', 'Cristiano', 'CRISTIANOPIMENTA@HOTMAIL.COM', 'cristianopimenta@hotmail.com', 'CRISTIANOPIMENTA@HOTMAIL.COM', False, 'AQAAAAIAAYagAAAAEK2JneL6MuxHsOLmBPGHCLJ1J7WZafEpKl+oDRcxuKqfv/Uwh2UDxnx54YS8j/BaHA==', 'SLZXU5ASNJTJKY5DPP3X4QZ5PSBHAHVV', '2866ee88-6eeb-4e3c-8770-e35f8cf2bba4', NULL, False, False, NULL, True, 0);

-- Estrutura da tabela `aspnetusertokens`
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `bancocontas`
DROP TABLE IF EXISTS `bancocontas`;
CREATE TABLE `bancocontas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdBanco` int(11) NOT NULL,
  `NomeConta` longtext NOT NULL,
  `NumeroConta` longtext NOT NULL,
  `DigitoConta` longtext NOT NULL,
  `Agencia` longtext NOT NULL,
  `DigitoAgencia` longtext DEFAULT NULL,
  `GeraBoleto` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `bancos`
DROP TABLE IF EXISTS `bancos`;
CREATE TABLE `bancos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NomeBanco` longtext NOT NULL,
  `NumeroBanco` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `cessao_uso`
DROP TABLE IF EXISTS `cessao_uso`;
CREATE TABLE `cessao_uso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` longtext NOT NULL,
  `id_imovel` int(11) NOT NULL,
  `softdeleted` int(11) NOT NULL,
  `created` datetime(6) NOT NULL,
  `updated` datetime(6) NOT NULL,
  `titulo_cedido` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `cessao_uso_clube`
DROP TABLE IF EXISTS `cessao_uso_clube`;
CREATE TABLE `cessao_uso_clube` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_cessao_uso` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `tipo` longtext NOT NULL,
  `grau_parentesco` longtext NOT NULL,
  `perm_liberacao_convite` longtext NOT NULL,
  `pode_comprar_convite` longtext NOT NULL,
  `dependente_especial` longtext NOT NULL,
  `softdeleted` int(11) NOT NULL,
  `created` datetime(6) NOT NULL,
  `updated` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `cidades_mobile`
DROP TABLE IF EXISTS `cidades_mobile`;
CREATE TABLE `cidades_mobile` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `slug` longtext NOT NULL,
  `nome` longtext NOT NULL,
  `uf` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `clube`
DROP TABLE IF EXISTS `clube`;
CREATE TABLE `clube` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `softdeleted` int(11) NOT NULL,
  `created` datetime(6) NOT NULL,
  `updated` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `cobrancainadimplentes`
DROP TABLE IF EXISTS `cobrancainadimplentes`;
CREATE TABLE `cobrancainadimplentes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPlanoContas` int(11) NOT NULL,
  `IdPessoa` int(11) NOT NULL,
  `IdImovel` int(11) NOT NULL,
  `IdModulo` int(11) NOT NULL,
  `DataVencimento` datetime(6) DEFAULT NULL,
  `DataInclusão` datetime(6) DEFAULT NULL,
  `DiasAtraso` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `condominiomobiles`
DROP TABLE IF EXISTS `condominiomobiles`;
CREATE TABLE `condominiomobiles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` longtext DEFAULT NULL,
  `Url` longtext DEFAULT NULL,
  `Img` longtext DEFAULT NULL,
  `Estado` longtext DEFAULT NULL,
  `Cidade` longtext DEFAULT NULL,
  `Ativo` longtext DEFAULT NULL,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `Slug` longtext DEFAULT NULL,
  `TipoCondominio` longtext DEFAULT NULL,
  `TipoEdificio` longtext DEFAULT NULL,
  `IdFilial` int(11) DEFAULT NULL,
  `RazaoSocial` longtext DEFAULT NULL,
  `Cnpj` longtext DEFAULT NULL,
  `Telefone1` longtext DEFAULT NULL,
  `Telefone2` longtext DEFAULT NULL,
  `Email` longtext DEFAULT NULL,
  `Cep` longtext DEFAULT NULL,
  `Endereco` longtext DEFAULT NULL,
  `PeriodoContratado` int(11) DEFAULT NULL,
  `DataInicio` datetime(6) DEFAULT NULL,
  `DataFim` datetime(6) DEFAULT NULL,
  `ValorMensal` decimal(65,30) DEFAULT NULL,
  `ObservacaoContrato` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `condominios`
DROP TABLE IF EXISTS `condominios`;
CREATE TABLE `condominios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CNPJ` varchar(14) NOT NULL,
  `Ativo` tinyint(1) NOT NULL,
  `DataCadastro` datetime(6) DEFAULT NULL,
  `DataAbertura` datetime(6) DEFAULT NULL,
  `tipoImovel` int(11) NOT NULL,
  `ExibirCampoFilipeta` tinyint(1) DEFAULT NULL,
  `HabilitarListaFerramentasPrestador` tinyint(1) DEFAULT NULL,
  `UsarDigitosCPFFilipeta` tinyint(1) DEFAULT NULL,
  `UsarPlacaFilipeta` tinyint(1) DEFAULT NULL,
  `BotoeiraVirtual` tinyint(1) DEFAULT NULL,
  `PossuiControleFacial` tinyint(1) DEFAULT NULL,
  `PossuirControleQRCode` tinyint(1) DEFAULT NULL,
  `ImovelAlugadoPermiteEntradaAssociado` tinyint(1) DEFAULT NULL,
  `ImovelAlugadoPermiteAssociadoFalaLiberacao` tinyint(1) DEFAULT NULL,
  `GerarCodigoAutomaticoPermanente` tinyint(1) DEFAULT NULL,
  `CondominioPossuiAcademia` tinyint(1) DEFAULT NULL,
  `CondominioPossuiAcademiaIntegracaoFinanceiro` tinyint(1) DEFAULT NULL,
  `CondominioAcademiaExigiAtestadoMedico` tinyint(1) DEFAULT NULL,
  `CondominioAcademiaPermiteAcessoPermanentes` tinyint(1) DEFAULT NULL,
  `CondominioPossuiPilates` tinyint(1) DEFAULT NULL,
  `CondominioPossuiPilatesIntegracaoFinanceiro` tinyint(1) DEFAULT NULL,
  `CondominioPossuiGPS` tinyint(1) DEFAULT NULL,
  `VisitantesHorarioPermitidoLiberacaoDas` longtext DEFAULT NULL,
  `VisitantesHorarioPermitidoLiberacaoAs` longtext DEFAULT NULL,
  `VisitantesTempoMaximoLibTemporarias` longtext DEFAULT NULL,
  `PrestadoresHorarioPermitidoLiberacaoDas` longtext DEFAULT NULL,
  `PrestadoresHorarioPermitidoLiberacaoAs` longtext DEFAULT NULL,
  `PrestadoresTempoMaximoLibTemporarias` longtext DEFAULT NULL,
  `ClubeTempoMaximoLibTemporarias` longtext DEFAULT NULL,
  `ExigirCNHObrigatorio` tinyint(1) DEFAULT NULL,
  `PermitirCNHVencida` tinyint(1) DEFAULT NULL,
  `ExigirPlacaObrigatorio` tinyint(1) DEFAULT NULL,
  `HabilitarCameraDocumento` tinyint(1) DEFAULT NULL,
  `HabilitarEntradaSaidaTempTerminais` tinyint(1) DEFAULT NULL,
  `VisitanteExigirCampoTelefoneEntrada` tinyint(1) DEFAULT NULL,
  `VisitanteExigirCampoNascimentoEntrada` tinyint(1) DEFAULT NULL,
  `VisitanteExigirCampoMaeEntrada` tinyint(1) DEFAULT NULL,
  `VisitanteExigirCampoCNHEntrada` tinyint(1) DEFAULT NULL,
  `PrestadorExigirCampoTelefoneEntrada` tinyint(1) DEFAULT NULL,
  `PrestadorExigirCampoNascimentoEntrada` tinyint(1) DEFAULT NULL,
  `PrestadorExigirCampoMaeEntrada` tinyint(1) DEFAULT NULL,
  `PrestadorExigirCampoCNHEntrada` tinyint(1) DEFAULT NULL,
  `HabilitarRegistroAtividadesMoradores` tinyint(1) DEFAULT NULL,
  `Instrucao_um` longtext NOT NULL,
  `Instrucao_dois` longtext NOT NULL,
  `Instrucao_tres` longtext NOT NULL,
  `UsuarioIdMestre` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Condominios_CNPJ` (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `contaspagar`
DROP TABLE IF EXISTS `contaspagar`;
CREATE TABLE `contaspagar` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idEmpresa` int(11) NOT NULL,
  `idPlanoConta` int(11) NOT NULL,
  `NumeroDocumentoPagar` longtext NOT NULL,
  `NumeroPedidoCompra` longtext NOT NULL,
  `OrdemDocumento` int(11) DEFAULT NULL,
  `ValorPagar` decimal(18,4) NOT NULL,
  `ValorPagamentoParcial` decimal(18,4) NOT NULL,
  `ValorPagamentoParcialUss` decimal(18,4) NOT NULL,
  `CodigoBlocoCobranca` int(11) NOT NULL,
  `DataDocumentoPagar` datetime(6) DEFAULT NULL,
  `DataVencimento` datetime(6) DEFAULT NULL,
  `NumeroDocumentoPagamento` int(11) NOT NULL,
  `DataPagamento` datetime(6) DEFAULT NULL,
  `JurosMulta` double NOT NULL,
  `JurosMora` double NOT NULL,
  `Desconto` double NOT NULL,
  `Observacoes` longtext NOT NULL,
  `StatusConta` int(11) NOT NULL,
  `ValorPagarUss` double NOT NULL,
  `TipoFatura` longtext NOT NULL,
  `NumeroFatura` int(11) NOT NULL,
  `NumeroLancamento` int(11) NOT NULL,
  `DataSistema` datetime(6) DEFAULT NULL,
  `CodigoMoeda` int(11) NOT NULL,
  `usuarioId` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ContasPagar_idEmpresa` (`idEmpresa`),
  KEY `IX_ContasPagar_idPlanoConta` (`idPlanoConta`),
  CONSTRAINT `FK_ContasPagar_Empresas_idEmpresa` FOREIGN KEY (`idEmpresa`) REFERENCES `empresas` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ContasPagar_PlanoContas_idPlanoConta` FOREIGN KEY (`idPlanoConta`) REFERENCES `planocontas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `contasreceber`
DROP TABLE IF EXISTS `contasreceber`;
CREATE TABLE `contasreceber` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idEmpresa` int(11) NOT NULL,
  `idPlanoConta` int(11) NOT NULL,
  `NumeroDocumentoReceber` varchar(50) NOT NULL,
  `NumeroPedidoVenda` varchar(50) NOT NULL,
  `OrdemDocumento` int(11) DEFAULT NULL,
  `ValorReceber` decimal(18,4) NOT NULL,
  `ValorRecebimentoParcial` decimal(18,4) NOT NULL,
  `ValorRecebimentoParcialUss` decimal(18,4) NOT NULL,
  `CodigoBlocoCobranca` int(11) NOT NULL,
  `DataVencimento` datetime(6) NOT NULL,
  `DataDocumentoVencer` datetime(6) DEFAULT NULL,
  `NumeroDocumentoRecebimento` int(11) NOT NULL,
  `DataRecebimento` datetime(6) DEFAULT NULL,
  `JurosMulta` double NOT NULL,
  `JurosMora` double NOT NULL,
  `Desconto` double NOT NULL,
  `Observacoes` varchar(500) NOT NULL,
  `StatusConta` int(11) NOT NULL,
  `ValorPagarUss` double NOT NULL,
  `TipoFatura` varchar(50) NOT NULL,
  `NumeroFatura` int(11) NOT NULL,
  `NumeroLancamento` int(11) NOT NULL,
  `DataSistema` datetime(6) DEFAULT NULL,
  `CodigoMoeda` int(11) NOT NULL,
  `usuarioId` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ContasReceber_idEmpresa` (`idEmpresa`),
  KEY `IX_ContasReceber_idPlanoConta` (`idPlanoConta`),
  CONSTRAINT `FK_ContasReceber_Empresas_idEmpresa` FOREIGN KEY (`idEmpresa`) REFERENCES `empresas` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ContasReceber_PlanoContas_idPlanoConta` FOREIGN KEY (`idPlanoConta`) REFERENCES `planocontas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `empresas`
DROP TABLE IF EXISTS `empresas`;
CREATE TABLE `empresas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` longtext NOT NULL,
  `NomeResponsavel` longtext NOT NULL,
  `RazaoSocial` longtext NOT NULL,
  `NomeFantasia` longtext NOT NULL,
  `TelefonePrincipal` longtext DEFAULT NULL,
  `CNPJ` varchar(18) NOT NULL,
  `CEP` longtext NOT NULL,
  `Endereco` longtext NOT NULL,
  `Numero` longtext NOT NULL,
  `Complemento` longtext NOT NULL,
  `Bairro` longtext NOT NULL,
  `Cidade` longtext NOT NULL,
  `Estado` longtext NOT NULL,
  `Observacao` longtext DEFAULT NULL,
  `Ativo` tinyint(1) DEFAULT NULL,
  `DataCadastro` datetime(6) DEFAULT NULL,
  `DataAbertura` datetime(6) DEFAULT NULL,
  `HabiteseCondominio` datetime(6) DEFAULT NULL,
  `HabitesePrefeitura` datetime(6) DEFAULT NULL,
  `ValorMensal` decimal(18,4) NOT NULL,
  `ValorProjeto` decimal(18,4) NOT NULL,
  `UsuarioID` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `enderecos`
DROP TABLE IF EXISTS `enderecos`;
CREATE TABLE `enderecos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClienteId` int(11) DEFAULT NULL,
  `Logradouro` longtext DEFAULT NULL,
  `Numero` longtext DEFAULT NULL,
  `Complemento` longtext DEFAULT NULL,
  `Bairro` longtext DEFAULT NULL,
  `Cidade` longtext DEFAULT NULL,
  `Estado` char(2) DEFAULT NULL,
  `CEP` char(9) DEFAULT NULL,
  `Referencia` longtext DEFAULT NULL,
  `Selecionado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `equipamentos`
DROP TABLE IF EXISTS `equipamentos`;
CREATE TABLE `equipamentos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdFornecedor` int(11) NOT NULL,
  `idPortaria` int(11) NOT NULL,
  `LocalInstalacao` longtext NOT NULL,
  `NomeEquipamento` longtext NOT NULL,
  `DescricaoEquipamento` longtext NOT NULL,
  `DataAquisicao` datetime(6) DEFAULT NULL,
  `TempoGarantia` longtext NOT NULL,
  `TipoNegociacao` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `estados_mobile`
DROP TABLE IF EXISTS `estados_mobile`;
CREATE TABLE `estados_mobile` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `slug` longtext NOT NULL,
  `nome` longtext NOT NULL,
  `uf` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `fornecedores`
DROP TABLE IF EXISTS `fornecedores`;
CREATE TABLE `fornecedores` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `CNPJ` varchar(14) NOT NULL,
  `Endereco` varchar(100) NOT NULL,
  `Telefone` varchar(50) NOT NULL,
  `Email` longtext NOT NULL,
  `Observacoes` varchar(500) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `imoveis`
DROP TABLE IF EXISTS `imoveis`;
CREATE TABLE `imoveis` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdEmpresa` int(11) NOT NULL,
  `EmpresaId` int(11) NOT NULL,
  `Quadra` longtext DEFAULT NULL,
  `Lote` longtext DEFAULT NULL,
  `Sala` longtext DEFAULT NULL,
  `Andar` longtext DEFAULT NULL,
  `Torre` longtext DEFAULT NULL,
  `StatusImovel` int(11) NOT NULL,
  `Lograouro` longtext DEFAULT NULL,
  `Numero` longtext DEFAULT NULL,
  `Complemento` longtext DEFAULT NULL,
  `Cep` longtext DEFAULT NULL,
  `AreaImovel` decimal(65,30) DEFAULT NULL,
  `AreaConstruida` decimal(65,30) DEFAULT NULL,
  `AreaJardinada` decimal(65,30) DEFAULT NULL,
  `BaseCalculo` decimal(65,30) DEFAULT NULL,
  `ImovelFicticio` tinyint(1) NOT NULL,
  `AreaTotalOriginal` decimal(65,30) DEFAULT NULL,
  `AreaConstruidaOriginal` decimal(65,30) DEFAULT NULL,
  `AreaPermeavel` decimal(65,30) DEFAULT NULL,
  `PossuiPiscina` tinyint(1) DEFAULT NULL,
  `PossuiEdicula` tinyint(1) DEFAULT NULL,
  `AreaEdicula` decimal(65,30) DEFAULT NULL,
  `AreaAproveitamento` decimal(65,30) DEFAULT NULL,
  `Frente` decimal(65,30) DEFAULT NULL,
  `FrenteM` decimal(65,30) DEFAULT NULL,
  `Fundo` decimal(65,30) DEFAULT NULL,
  `FundoM` decimal(65,30) DEFAULT NULL,
  `Direita` decimal(65,30) DEFAULT NULL,
  `DireitaM` decimal(65,30) DEFAULT NULL,
  `Esquerda` decimal(65,30) DEFAULT NULL,
  `EsquerdaM` decimal(65,30) DEFAULT NULL,
  `Chanfro` decimal(65,30) DEFAULT NULL,
  `HabitesePrefeitura` datetime(6) DEFAULT NULL,
  `Vistoria` datetime(6) DEFAULT NULL,
  `EntradaRememb` datetime(6) DEFAULT NULL,
  `AprovacaoCondominio` datetime(6) DEFAULT NULL,
  `AprovacaoPrefeitura` datetime(6) DEFAULT NULL,
  `EnvioCopiaAusa` datetime(6) DEFAULT NULL,
  `RetornoAusa` datetime(6) DEFAULT NULL,
  `DataCadastro` datetime(6) DEFAULT NULL,
  `IndiceOcupacao` decimal(65,30) DEFAULT NULL,
  `Latitude` longtext DEFAULT NULL,
  `Longitude` longtext DEFAULT NULL,
  `PesoVoto` int(11) DEFAULT NULL,
  `PossuiTitulo` tinyint(1) DEFAULT NULL,
  `Tipo` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Imoveis_EmpresaId` (`EmpresaId`),
  CONSTRAINT `FK_Imoveis_Empresas_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `empresas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `imovelagregado`
DROP TABLE IF EXISTS `imovelagregado`;
CREATE TABLE `imovelagregado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `quadra` longtext DEFAULT NULL,
  `lote` longtext DEFAULT NULL,
  `logradouro` longtext DEFAULT NULL,
  `area` longtext DEFAULT NULL,
  `sala` longtext DEFAULT NULL,
  `andar` longtext DEFAULT NULL,
  `apartamento` longtext DEFAULT NULL,
  `observacao` longtext DEFAULT NULL,
  `ativo` tinyint(1) DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `localidade`
DROP TABLE IF EXISTS `localidade`;
CREATE TABLE `localidade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` longtext DEFAULT NULL,
  `latitude` longtext DEFAULT NULL,
  `longitude` longtext DEFAULT NULL,
  `urlMapaRastreio` longtext DEFAULT NULL,
  `cadastrado` tinyint(1) DEFAULT NULL,
  `dataCadastro` datetime(6) DEFAULT NULL,
  `dataModificacaoRegistro` datetime(6) DEFAULT NULL,
  `ativo` tinyint(1) DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `modulomobiles`
DROP TABLE IF EXISTS `modulomobiles`;
CREATE TABLE `modulomobiles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descricao` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `ocorrenciainterna`
DROP TABLE IF EXISTS `ocorrenciainterna`;
CREATE TABLE `ocorrenciainterna` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) DEFAULT NULL,
  `IdImovel` int(11) DEFAULT NULL,
  `descricao` longtext DEFAULT NULL,
  `atividade` longtext DEFAULT NULL,
  `concluirDia` datetime(6) DEFAULT NULL,
  `dataCadastro` datetime(6) DEFAULT NULL,
  `hora` longtext DEFAULT NULL,
  `status` longtext DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pagamentospaciais`
DROP TABLE IF EXISTS `pagamentospaciais`;
CREATE TABLE `pagamentospaciais` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idContaPagar` int(11) NOT NULL,
  `NumeroDocumentoPagar` longtext NOT NULL,
  `NumeroPedidoCompra` longtext NOT NULL,
  `OrdemDocumento` int(11) DEFAULT NULL,
  `ValorPagar` decimal(18,4) NOT NULL,
  `ValorPagamentoParcial` decimal(18,4) NOT NULL,
  `DataPagamentoParcial` datetime(6) DEFAULT NULL,
  `usuarioId` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_PagamentosPaciais_idContaPagar` (`idContaPagar`),
  CONSTRAINT `FK_PagamentosPaciais_ContasPagar_idContaPagar` FOREIGN KEY (`idContaPagar`) REFERENCES `contaspagar` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `panicomobile`
DROP TABLE IF EXISTS `panicomobile`;
CREATE TABLE `panicomobile` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idPessoa` longtext NOT NULL,
  `DescricaoAlerta` longtext NOT NULL,
  `DataAlerta` longtext DEFAULT NULL,
  `DataAtendimento` longtext DEFAULT NULL,
  `StatusAlerta` longtext DEFAULT NULL,
  `TipoEmergencia` longtext DEFAULT NULL,
  `IdUsuarioAtendimento` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `permanente`
DROP TABLE IF EXISTS `permanente`;
CREATE TABLE `permanente` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) DEFAULT NULL,
  `tipoAcessoPessoa` int(11) NOT NULL,
  `apelido` longtext DEFAULT NULL,
  `raca` longtext DEFAULT NULL,
  `porte` longtext DEFAULT NULL,
  `datanascimento` datetime(6) DEFAULT NULL,
  `profissao` longtext DEFAULT NULL,
  `ativo` tinyint(1) DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoa`
DROP TABLE IF EXISTS `pessoa`;
CREATE TABLE `pessoa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` longtext DEFAULT NULL,
  `EmailPrincipal` longtext DEFAULT NULL,
  `TelefonePrincipal` longtext DEFAULT NULL,
  `CpfPessoa` longtext DEFAULT NULL,
  `DataCadastro` datetime(6) DEFAULT NULL,
  `DataNascimento` longtext DEFAULT NULL,
  `Sexo` longtext DEFAULT NULL,
  `Apelido` longtext DEFAULT NULL,
  `Mae` longtext DEFAULT NULL,
  `Pai` longtext DEFAULT NULL,
  `ApresentaMensagemEntrada` longtext DEFAULT NULL,
  `Mensagem` longtext DEFAULT NULL,
  `ObsSeguranca` longtext DEFAULT NULL,
  `IdCNH` int(11) DEFAULT NULL,
  `IdUsuarioAtendente` int(11) DEFAULT NULL,
  `Tipo` longtext DEFAULT NULL,
  `TipoCadastro` longtext DEFAULT NULL,
  `TipoCategoria` longtext DEFAULT NULL,
  `Parentesco` longtext DEFAULT NULL,
  `QrCodeGerado` tinyint(1) DEFAULT NULL,
  `TipoImovel` longtext DEFAULT NULL,
  `TipoMorador` longtext DEFAULT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoacontato`
DROP TABLE IF EXISTS `pessoacontato`;
CREATE TABLE `pessoacontato` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CpfPessoa` longtext NOT NULL,
  `Email` longtext DEFAULT NULL,
  `TipoContato` longtext DEFAULT NULL,
  `TelefoneCelular` longtext DEFAULT NULL,
  `TelefoneFixo` longtext DEFAULT NULL,
  `Ramal` longtext DEFAULT NULL,
  `Obervacao` longtext DEFAULT NULL,
  `permiteAcessoToten` tinyint(1) DEFAULT NULL,
  `AcessarSomenteLocalidade` tinyint(1) DEFAULT NULL,
  `CodigoAcesso` longtext DEFAULT NULL,
  `ApresentarObservacoesTodosAcessos` tinyint(1) DEFAULT NULL,
  `ObservacaoSeguranca` longtext DEFAULT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoadocumentos`
DROP TABLE IF EXISTS `pessoadocumentos`;
CREATE TABLE `pessoadocumentos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CpfPessoa` longtext NOT NULL,
  `documento` longtext DEFAULT NULL,
  `tipoDocumento` int(11) NOT NULL,
  `dataRegistroDocumento` datetime(6) DEFAULT NULL,
  `dataVencimentoDocumento` datetime(6) DEFAULT NULL,
  `OrgaoResponsavel` longtext DEFAULT NULL,
  `ativo` tinyint(1) DEFAULT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoasacessosvalidades`
DROP TABLE IF EXISTS `pessoasacessosvalidades`;
CREATE TABLE `pessoasacessosvalidades` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) NOT NULL,
  `IdEndereco` int(11) NOT NULL,
  `IdDocumento` int(11) NOT NULL,
  `DataEntrada` datetime(6) NOT NULL,
  `DataSaida` datetime(6) NOT NULL,
  `QtdDiasPermitido` int(11) DEFAULT NULL,
  `HoraEntrada` longtext NOT NULL,
  `HoraSaida` longtext NOT NULL,
  `diaSemana` int(11) NOT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoasenderecos`
DROP TABLE IF EXISTS `pessoasenderecos`;
CREATE TABLE `pessoasenderecos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CpfPessoa` longtext NOT NULL,
  `ImovelId` int(11) NOT NULL,
  `DataEndereco` datetime(6) NOT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_PessoasEnderecos_ImovelId` (`ImovelId`),
  CONSTRAINT `FK_PessoasEnderecos_Imoveis_ImovelId` FOREIGN KEY (`ImovelId`) REFERENCES `imoveis` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoaspermanentes`
DROP TABLE IF EXISTS `pessoaspermanentes`;
CREATE TABLE `pessoaspermanentes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_pessoa` int(11) DEFAULT NULL,
  `codigo` longtext DEFAULT NULL,
  `pai` longtext DEFAULT NULL,
  `nacionalidade` longtext DEFAULT NULL,
  `naturalidade` longtext DEFAULT NULL,
  `profissao` longtext DEFAULT NULL,
  `email` longtext DEFAULT NULL,
  `ativo` longtext DEFAULT NULL,
  `id_imovel` int(11) DEFAULT NULL,
  `ultima_atualizacao` longtext DEFAULT NULL,
  `tipo` longtext DEFAULT NULL,
  `senha` longtext DEFAULT NULL,
  `grau_parentesco` longtext DEFAULT NULL,
  `permitir_liberacao` longtext DEFAULT NULL,
  `associado` longtext DEFAULT NULL,
  `chefe_imediato` longtext DEFAULT NULL,
  `id_empresa` int(11) DEFAULT NULL,
  `data_vencimento` datetime(6) DEFAULT NULL,
  `categoria` longtext DEFAULT NULL,
  `tipo_servico` longtext DEFAULT NULL,
  `permitir_cad_permanente` longtext DEFAULT NULL,
  `permitir_acesso_toten` longtext DEFAULT NULL,
  `acesso_somente_sua_localidade` longtext DEFAULT NULL,
  `id_pessoa_autorizante` int(11) DEFAULT NULL,
  `id_endereco` int(11) DEFAULT NULL,
  `end_secundario_correspondencia` longtext DEFAULT NULL,
  `email_alternativo` longtext DEFAULT NULL,
  `modificado_em` datetime(6) DEFAULT NULL,
  `morador_prestador` longtext DEFAULT NULL,
  `especialidade` longtext DEFAULT NULL,
  `permitir_acesso_historico` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pessoaveiculos`
DROP TABLE IF EXISTS `pessoaveiculos`;
CREATE TABLE `pessoaveiculos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CpfPessoa` longtext NOT NULL,
  `Placa` longtext DEFAULT NULL,
  `MarcaModelo` longtext DEFAULT NULL,
  `Cor` longtext DEFAULT NULL,
  `IdUsuario` longtext DEFAULT NULL,
  `DataCadastro` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `pets`
DROP TABLE IF EXISTS `pets`;
CREATE TABLE `pets` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) DEFAULT NULL,
  `nome` longtext DEFAULT NULL,
  `raca` longtext DEFAULT NULL,
  `porte` longtext DEFAULT NULL,
  `datanascimento` datetime(6) DEFAULT NULL,
  `cadastrado` tinyint(1) DEFAULT NULL,
  `ativo` tinyint(1) DEFAULT NULL,
  `idCartaoVacina` int(11) DEFAULT NULL,
  `tipo` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `planocontas`
DROP TABLE IF EXISTS `planocontas`;
CREATE TABLE `planocontas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoPlanoContas` longtext NOT NULL,
  `Descricao` longtext NOT NULL,
  `usuarioId` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `recebimentospaciais`
DROP TABLE IF EXISTS `recebimentospaciais`;
CREATE TABLE `recebimentospaciais` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idContaReceber` int(11) NOT NULL,
  `NumeroDocumentoReceber` longtext NOT NULL,
  `NumeroPedidoVenda` longtext NOT NULL,
  `OrdemDocumento` int(11) DEFAULT NULL,
  `ValorReceber` decimal(18,4) NOT NULL,
  `ValorRecebimentoParcial` decimal(18,4) NOT NULL,
  `DataRecebimentoParcial` datetime(6) DEFAULT NULL,
  `usuarioId` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RecebimentosPaciais_idContaReceber` (`idContaReceber`),
  CONSTRAINT `FK_RecebimentosPaciais_ContasReceber_idContaReceber` FOREIGN KEY (`idContaReceber`) REFERENCES `contasreceber` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `tipo_perfil`
DROP TABLE IF EXISTS `tipo_perfil`;
CREATE TABLE `tipo_perfil` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `userinfos`
DROP TABLE IF EXISTS `userinfos`;
CREATE TABLE `userinfos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` longtext NOT NULL,
  `Password` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `usertokens`
DROP TABLE IF EXISTS `usertokens`;
CREATE TABLE `usertokens` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Token` longtext NOT NULL,
  `Expiration` datetime(6) NOT NULL,
  `Message` longtext NOT NULL,
  KEY `Index 1` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


-- Estrutura da tabela `usuarios`
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `Senha` longtext NOT NULL,
  `ConfirmarSenha` longtext NOT NULL,
  `Perfil` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;


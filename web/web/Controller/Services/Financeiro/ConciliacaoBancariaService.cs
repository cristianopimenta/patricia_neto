using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using web;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using web.Data.Financeiro;
using web.Data;
using web.Controller.Interface;

namespace web.Controller.Services.Financeiro
{
    public class ConciliacaoBancariaService : IConciliacaoBancaria
    {
        private readonly ApplicationDbContext _context;

        public ConciliacaoBancariaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConciliacaoBancariaModel>> ImportarXls(IFormFile file)
        {
            var conciliacoes = new List<ConciliacaoBancariaModel>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Começa da linha 2 (ignorando cabeçalho)
                    {
                        var conciliacao = new ConciliacaoBancariaModel
                        {
                            Banco = worksheet.Cells[row, 1].Value?.ToString() ?? "",
                            NumeroDocumentoBanco = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                            DataLancamentoBanco = DateTime.Parse(worksheet.Cells[row, 3].Value?.ToString() ?? "01/01/2000"),
                            ValorBanco = decimal.Parse(worksheet.Cells[row, 4].Value?.ToString() ?? "0", CultureInfo.InvariantCulture),
                            Conciliado = false
                        };

                        conciliacoes.Add(conciliacao);
                    }
                }
            }

            await _context.ConciliacoesBancarias.AddRangeAsync(conciliacoes);
            await _context.SaveChangesAsync();

            return conciliacoes;
        }

        public async Task<byte[]> ExportarXls()
        {
            var conciliacoes = await _context.ConciliacoesBancarias.ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Conciliação Bancária");

                worksheet.Cells[1, 1].Value = "Banco";
                worksheet.Cells[1, 2].Value = "Número Documento";
                worksheet.Cells[1, 3].Value = "Data Lançamento";
                worksheet.Cells[1, 4].Value = "Valor";
                worksheet.Cells[1, 5].Value = "Conciliado";

                int row = 2;
                foreach (var item in conciliacoes)
                {
                    worksheet.Cells[row, 1].Value = item.Banco;
                    worksheet.Cells[row, 2].Value = item.NumeroDocumentoBanco;
                    worksheet.Cells[row, 3].Value = item.DataLancamentoBanco.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 4].Value = item.ValorBanco;
                    worksheet.Cells[row, 5].Value = item.Conciliado ? "Sim" : "Não";
                    row++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
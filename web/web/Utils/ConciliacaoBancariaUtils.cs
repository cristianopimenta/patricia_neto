using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using web;
using Excel = OfficeOpenXml;

public partial class ConciliacaoBancariaUtils : ComponentBase
{
    [Inject] private IJSRuntime JS { get; set; } = default!;

    private IBrowserFile? uploadedFile;
    private List<ContaPagarModel> contasPagar = new();
    private List<ContaReceberModel> contasReceber = new();

    private async Task HandleFileSelected(InputFileChangeEventArgs e)
    {
        uploadedFile = e.File;
        if (uploadedFile != null)
        {
            await ProcessarArquivo(uploadedFile);
        }
    }

    private async Task ProcessarArquivo(IBrowserFile file)
    {
        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);
        string content = await reader.ReadToEndAsync();

        if (file.Name.EndsWith(".ofx", StringComparison.OrdinalIgnoreCase))
        {
            ParseOFX(content);
        }
        else if (file.Name.EndsWith(".orc", StringComparison.OrdinalIgnoreCase))
        {
            ParseORC(content);
        }
    }

    private void ParseOFX(string content)
    {
        // Implementar parsing de OFX
    }

    private void ParseORC(string content)
    {
        // Implementar parsing de ORC baseado no layout do banco
    }

    private async Task ExportarParaExcel()
    {
        using var package = new Excel.ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("ConciliacaoBancaria");

        sheet.Cells[1, 1].Value = "ID";
        sheet.Cells[1, 2].Value = "Tipo";
        sheet.Cells[1, 3].Value = "Valor";
        sheet.Cells[1, 4].Value = "Data Vencimento";

        int row = 2;
        foreach (var item in contasPagar.Cast<object>().Concat(contasReceber.Cast<object>()))
        {
            if (item is ContaPagarModel contaPagar)
            {
                sheet.Cells[row, 1].Value = contaPagar.Id;
                sheet.Cells[row, 2].Value = "Pagar";
                sheet.Cells[row, 3].Value = contaPagar.ValorPagamento;
                sheet.Cells[row, 4].Value = contaPagar.DataVencimento?.ToString("dd/MM/yyyy");
            }
            else if (item is ContaReceberModel contaReceber)
            {
                sheet.Cells[row, 1].Value = contaReceber.Id;
                sheet.Cells[row, 2].Value = "Receber";
                sheet.Cells[row, 3].Value = contaReceber.ValorRecebimento;
                sheet.Cells[row, 4].Value = contaReceber.DataVencimento?.ToString("dd/MM/yyyy");
            }
            row++;
        }

        var bytes = await package.GetAsByteArrayAsync();
        var fileUtil = new FileUtil(JS); // Criar instância de FileUtil passando JSRuntime
        await fileUtil.DownloadFile("Conciliacao.xlsx", bytes);
    }
}

public class FileUtil
{
    private readonly IJSRuntime _jsRuntime;

    public FileUtil(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task DownloadFile(string fileName, byte[] fileData)
    {
        var base64 = Convert.ToBase64String(fileData);
        var script = $"var a = document.createElement('a'); a.href = 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,{base64}'; a.download = '{fileName}'; document.body.appendChild(a); a.click(); document.body.removeChild(a);";
        await _jsRuntime.InvokeVoidAsync("eval", script);
    }
}

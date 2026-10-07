using Microsoft.VisualBasic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Playwright;
using WebApiREDDE.Models;

namespace WebApiREDDE.Services
{
    public class CompanyService
    {

        public async Task<Company> SearchRNC(string rnc)
        {
            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{ Headless = false });

            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://dgii.gov.do/app/WebApps/ConsultasWeb2/ConsultasWeb/consultas/rnc.aspx");
            await page.FillAsync("#cphMain_txtRNCCedula", rnc);
            await page.ClickAsync("#cphMain_btnBuscarPorRNC");

            Company company = new Company();

            company.Name = await page.Locator("xpath=//td[text()='Nombre/Razón Social']/following-sibling::td").InnerTextAsync();
            company.RNC = rnc;
            company.CommercialName = await page.Locator("xpath=//td[text()='Nombre Comercial']/following-sibling::td").InnerTextAsync();
            company.Category = await page.Locator("xpath=//td[text()='Categoría']/following-sibling::td").InnerTextAsync();
            company.PaymentScheme = await page.Locator("xpath=//td[text()='Régimen de pagos']/following-sibling::td").InnerTextAsync();
            company.State = await page.Locator("xpath=//td[text()='Estado']/following-sibling::td").InnerTextAsync();
            company.EconomicActivity = await page.Locator("xpath=//td[text()='Actividad Economica']/following-sibling::td").InnerTextAsync();
            company.GubernamentalBranch = " ";

            return company;
        }
    }
}

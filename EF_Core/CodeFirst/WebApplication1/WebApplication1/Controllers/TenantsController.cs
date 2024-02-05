using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Security.Cryptography;
using CodeFirstApp.Cryptography;


namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        AppDbContext _appDbContext;

        public TenantsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IList<Tenant>> GetAll()
        {
            var tenants = await _appDbContext.Tenants.ToListAsync();
            return tenants;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }
            var dbTenant = await _appDbContext.Tenants.FirstOrDefaultAsync(x => x.TenancyName == tenant.TenancyName);
            if (dbTenant != null)
            {
                return BadRequest("tenant already exists!");
            }
            await _appDbContext.Tenants.AddAsync(tenant);
            string connString = tenant.ConnectionString;
            string key = "asnsjhvjskhlkafbdsb";
            string iv = $"{tenant.TenancyName}{key}";
            byte[] keyBytes = new byte[32];
            byte[] ivBytes = new byte[16];

            Array.Copy(new SHA256Managed().ComputeHash(System.Text.Encoding.ASCII.GetBytes(key)), keyBytes, keyBytes.Length);
            Array.Copy(new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.ASCII.GetBytes(iv)), ivBytes, ivBytes.Length);

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                tenant.ConnectionString = Convert.ToBase64String(CryptographyHelper.Encrypt(connString, encryptor));
                //string decrptstr= Convert.ToBase64String(CyrptographyHelper.Encrypt(tenant.ConnectionString, decryptor));
            }

            await _appDbContext.SaveChangesAsync();
            return Ok(tenant);
        }
    }
}

using Azure.Identity;
// Imports Azure.Identity namespace.
// It gives us DefaultAzureCredential,
// which helps our application authenticate with Azure.


// Imports classes used to work with Azure Key Vault secrets.
// For example: SecretClient and KeyVaultSecret.
using Azure.Security.KeyVault.Secrets;


using Microsoft.AspNetCore.Mvc;

namespace BuildAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KeyVaultTestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSecret()
        {
            
            // Creates a variable named keyVaultUrl.
            //
            // var = C# automatically determines the variable's type.
            //
            // The value is the URL/address of your Azure Key Vault.
            //
            // Your application uses this URL to know:
            // "Which Key Vault should I connect to?"


            var keyVaultUrl = "https://Manjeetwebapi.vault.azure.net/";


            // Creates a SecretClient object.
            //
            // SecretClient is an Azure SDK class used to communicate
            // with Azure Key Vault Secrets.
            //
            // new Uri(keyVaultUrl)
            // converts the string URL into a Uri object.
            //
            // new DefaultAzureCredential()
            // creates an Azure authentication credential.
            //
            // It tells Azure:
            // "Use an available Azure identity to authenticate this application."
            //
            // SecretClient + URL + Credential
            // = authenticated connection to your Key Vault.

            var client = new SecretClient(
                new Uri(keyVaultUrl),
                new DefaultAzureCredential()
            );


            // Calls Azure Key Vault and asks for a secret named "TestSecret".
            //
            // GetSecretAsync() is a predefined Azure SDK method.
            //
            // await means:
            // "Wait for Azure to return the secret, but don't block the thread."
            //
            // The returned secret is stored in the "secret" variable.
            //
            // KeyVaultSecret is a predefined Azure SDK class.
            //
            // It contains information such as:
            // secret.Name
            // secret.Value

            KeyVaultSecret secret = await client.GetSecretAsync("TestSecret");

            return Ok(new
            {
                SecretName = secret.Name,
                SecretValue = secret.Value
            });

            // Ok() is a predefined ASP.NET Core method.
            //
            // It creates an HTTP 200 OK response.
            //
            // new { ... } creates an anonymous object.
            //
            // SecretName = secret.Name
            // gets the name of the secret.
            //
            // SecretValue = secret.Value
            // gets the actual secret value.
            //
            // The API sends this information back as JSON.
        }
    }
}
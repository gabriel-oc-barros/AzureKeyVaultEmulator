using AzureKeyVaultEmulator.Configuration;
using AzureKeyVaultEmulator.Repositories.Secrets;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Options;
using Microsoft.Rest.Azure;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Services.Secrets
{
    public class SecretsService : ISecretsService
    {
        private readonly PortOptions _portOptions;
        private readonly ISecretsRepository _secretsRepository;

        public SecretsService(
            IOptions<PortOptions> options,
            ISecretsRepository secretsRepository)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (secretsRepository is null)
            {
                throw new ArgumentNullException(nameof(secretsRepository));
            }

            _portOptions = options.Value;
            _secretsRepository = secretsRepository;
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secretName)
        {
            var secrets = await _secretsRepository.GetSecretsAsync(secretName, int.MaxValue);

            // Convert to SecretBundle
            var secretBundles = secrets.Select(s => new SecretBundle
            {
                Attributes = new SecretAttributes(s.Enabled, s.NotBefore, s.Expires, s.Created, s.Updated, s.RecoveryLevel),
                ContentType = s.ContentType,
                Id = $"http://localhost:{_portOptions.Port}/secrets/{secretName}/{s.Id.ToString()}",
                Tags = s.Tags?.ToDictionary(t => t.Key, t => t.Value),
                Value = s.Value
            });

            // Convert to byte array
            var backedUpSecret = JsonSerializer.SerializeToUtf8Bytes(secretBundles);

            return new BackupSecretResult(backedUpSecret);
        }

        public async Task<IPage<SecretItem>> GetSecretVersionsAsync(string secretName, int maxResults)
        {
            var secrets = await _secretsRepository.GetSecretsAsync(secretName, maxResults);

            var page = new Page<SecretItem>()
            {

            };

            return page;
        }

        public async Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion)
        {
            return new SecretBundle
            {

            };
        }



        public async Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
        {
            var secret = await _secretsRepository.SetSecretAsync(secretName, secretSetParameters);

            return new SecretBundle()
            {
                Attributes = new SecretAttributes(secret.Enabled, secret.NotBefore, secret.Expires, secret.Created, secret.Updated, secret.RecoveryLevel),
                ContentType = secret.ContentType,
                Id = $"http://localhost:{_portOptions.Port}/secrets/{secretName}/{secret.Id.ToString()}",
                Tags = secret.Tags?.ToDictionary(t => t.Key, t => t.Value),
                Value = secret.Value
            };
        }

        public async Task<DeletedSecretBundle> DeleteSecretAsync(string secretName)
        {
            return new DeletedSecretBundle
            {

            };
        }

        public async Task<IPage<SecretItem>> GetSecretsAsync(int maxResults)
        {
            return new Page<SecretItem>();
        }

        public async Task<SecretBundle> RestoreSecretAsync(string value)
        {
            return new SecretBundle();
        }

        public async Task<SecretBundle> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters)
        {
            return new SecretBundle();
        }
    }
}
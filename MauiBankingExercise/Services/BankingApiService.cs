
using MauiBankingExercise.Configurations;
using MauiBankingExercise.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiBankingExercise.Services
{
    public class BankingApiService
    {
        private HttpClient _apiClient;
       
        private ApplicationSettings _applicationSettings =new();

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Handles case mismatches between API and model
            WriteIndented = true
        };
        public BankingApiService()
        {
            
#if DEBUG
            HttpClientHandler insecureHandler = GetInsecureHandler();
            
            _apiClient = new HttpClient(insecureHandler);
#else
            _apiClient = new HttpClient();
#endif
            _applicationSettings = _applicationSettings;
            

        }

        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/Customers");
            try
            {

                HttpResponseMessage response = await _apiClient.GetAsync($"{uri}/customers");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    List<Customer>? games = JsonSerializer.Deserialize<List<Customer>>(content, _jsonSerializerOptions);


                    return games ?? new List<Customer>();
                }

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new("Failed to fetch game data from API.");
            }

            return new List<Customer>();
        }


        public async Task<List<Transaction>> GetCustomerTransaction (int accountId, decimal amount, int typeId)
        {
            Uri uri = new Uri(_applicationSettings.ServiceUrl);

            try
            {
                HttpResponseMessage response = await _apiClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    List<Transaction>? games = JsonSerializer.Deserialize<List<Transaction>>(content, _jsonSerializerOptions);


                    return games ?? new List<Transaction>();
                }
            }



            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new("Failed to fetch game data from API.");
            }

             return new List<Transaction>();
        }
        

        public async Task<Account> GetAccountId(int accountId)
        {
            Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/Accounts/{accountId}");

            try
            {
                HttpResponseMessage response = await _apiClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Account? game = JsonSerializer.Deserialize<Account>(content, _jsonSerializerOptions);

                    return game ?? new Account();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new ($"Failed to fetch game data for ID {accountId} from API.");
            }

                throw new ($"Failed to fetch game data for ID {accountId} from API.");
        
        }

        public async Task<List<AccountType>> GetAccountType(object accountTypeId)
        {
          Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/AccountTypes");
            try
            {
                HttpResponseMessage response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<AccountType>? games = JsonSerializer.Deserialize<List<AccountType>>(content, _jsonSerializerOptions);
                    return games ?? new List<AccountType>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new ("Failed to fetch game data from API.");
            }
            return new List<AccountType>();
        }

       

        public async Task<Customer> GetCustomer(int customerId)

        {
            Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/Customers/{customerId}");
            try
            {
                HttpResponseMessage response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Customer? game = JsonSerializer.Deserialize<Customer>(content, _jsonSerializerOptions);
                    return game ?? new Customer();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new ($"Failed to fetch game data for ID {customerId} from API.");
            }
        }

            public Task<List<Account>> GetCustomerAccounts(int customerId)
        {
            Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/Accounts/customer/{customerId}");

            try
                {
                HttpResponseMessage response =  _apiClient.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content =  response.Content.ReadAsStringAsync().Result;
                    List<Account>? game = JsonSerializer.Deserialize<List<Account>>(content, _jsonSerializerOptions);
                    return Task.FromResult(game ?? new List<Account>());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new ($"Failed to fetch game data for ID {customerId} from API.");
            }
        }

        public async Task<List<Transaction>> GetAccountTransactions(int accountId)
        {
            Uri uri = new Uri($"{_applicationSettings.ServiceUrl}/Transactions/account/{accountId}");

            try
                {
                HttpResponseMessage response = await _apiClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Transaction>? game = JsonSerializer.Deserialize<List<Transaction>>(content, _jsonSerializerOptions);
                    return game ?? new List<Transaction>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw new ($"Failed to fetch game data for ID {accountId} from API.");
            }
        }
    }
}

using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBankingExercise.ViewModels
{
    [QueryProperty(nameof(AccountId), "accountId")]
    public class TransactionViewModel : BaseViewModel
    {
        private readonly BankingApiService _service;
        private Account _selectedAccount;
        private string _selectedTransactionType;
        private string _transactionAmount;
        private int _accountId;

        public ObservableCollection<string> TransactionTypes { get; } = new() { "Deposit", "Withdrawal" };

        public ICommand SubmitTransactionCommand { get; }

        public Account SelectedAccount
        {
            get => _selectedAccount;
            set { _selectedAccount = value; OnPropertyChanged(); }
        }

        public string SelectedTransactionType
        {
            get => _selectedTransactionType;
            set { _selectedTransactionType = value; OnPropertyChanged(); ((Command)SubmitTransactionCommand).ChangeCanExecute(); }
        }

        public string TransactionAmount
        {
            get => _transactionAmount;
            set { _transactionAmount = value; OnPropertyChanged(); ((Command)SubmitTransactionCommand).ChangeCanExecute(); }
        }

        public int AccountId
        {
            get => _accountId;
            set
            {
                _accountId = value;
                LoadAccount(value);
            }
        }

        public TransactionViewModel()
        {
            _service = new BankingApiService();
            SubmitTransactionCommand = new Command(async () => await SubmitTransaction(), CanSubmitTransaction);
        }

        private void LoadAccount(int accountId)
        {
            SelectedAccount = _service.GetAccount(accountId);
        }

        private async Task SubmitTransaction()
        {
            if (!CanSubmitTransaction()) return;

            if (!decimal.TryParse(TransactionAmount, out var amount) || amount <= 0)
            {
                await Shell.Current.DisplayAlert("Error", "Enter a valid amount greater than 0", "OK");
                return;
            }

            string typeLabel = SelectedTransactionType;
            int typeId = typeLabel == "Deposit" ? 1 : 2;

            try
            {
                _service.AddTransaction(SelectedAccount.AccountId, amount, typeId);
                TransactionAmount = "";
                SelectedTransactionType = null;
                await Shell.Current.DisplayAlert("Success", $"{typeLabel} of {amount:C} completed!", "OK");
                
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private bool CanSubmitTransaction() =>
            SelectedAccount != null &&
            !string.IsNullOrWhiteSpace(SelectedTransactionType) &&
            !string.IsNullOrWhiteSpace(TransactionAmount);
    }
}

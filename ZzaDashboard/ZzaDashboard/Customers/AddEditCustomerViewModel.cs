﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    class AddEditCustomerViewModel : BindableBase
    {
        private Customer _editingCustomer = null;
        private ICustomersRepository _repo;

        public event Action Done = delegate { };

        #region Properties

        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private SimpleEditableCustomer _customer;

        public SimpleEditableCustomer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        #endregion

        public AddEditCustomerViewModel(ICustomersRepository repo)
        {
            _repo = repo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        #region Methods

        public void SetCustomer(Customer customer)
        {
            _editingCustomer = customer;
            if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(customer, Customer);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }

        private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }

        private bool CanSave()
        {
            return !Customer.HasErrors;
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);
            if (EditMode)
            {
                await _repo.UpdateCustomerAsync(_editingCustomer);
            }
            else
            {
                await _repo.AddCustomerAsync(_editingCustomer);
            }
            Done();
        }

        private void OnCancel()
        {
            Done();
        }

        #endregion
    }
}

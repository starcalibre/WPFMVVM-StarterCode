using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.Customers
{
    class AddEditCustomerViewModel : BindableBase
    {
        private Customer _editingCustomer = null;

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

        public AddEditCustomerViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        #region Methods

        public void SetCustomer(Customer customer)
        {
            _editingCustomer = customer;
            Customer = new SimpleEditableCustomer();
            CopyCustomer(customer, Customer);
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

        private bool CanSave()
        {
            return true;
        }

        private async void OnSave()
        {
            Done();
        }

        private void OnCancel()
        {
            Done();
        }

        #endregion
    }
}

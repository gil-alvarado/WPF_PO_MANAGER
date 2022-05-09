using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO_MANAGER.Commands
{
    public class AttachmentManagementCommand : CommandBase
    {
        private readonly object? createPurchaseOrderViewModel;
        private bool isAddingEmail;
        public AttachmentManagementCommand(object _createPurchaseOrderViewModel, bool isAddingEmail)
        {
            if(_createPurchaseOrderViewModel is CreatePurchaseOrderViewModel)
                this.createPurchaseOrderViewModel = (CreatePurchaseOrderViewModel)_createPurchaseOrderViewModel;
            else if(_createPurchaseOrderViewModel is EditPurchaseOrderViewModel)
                this.createPurchaseOrderViewModel = (EditPurchaseOrderViewModel)_createPurchaseOrderViewModel;
            else 
                this.createPurchaseOrderViewModel=null;

            this.isAddingEmail = isAddingEmail;
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);  
        }
        public override void Execute(object? parameter)
        {
            if (isAddingEmail && createPurchaseOrderViewModel is CreatePurchaseOrderViewModel)
                MessageBox.Show("ADD Open File Explorer, drag emails in file explorer");
            if(!isAddingEmail && createPurchaseOrderViewModel is CreatePurchaseOrderViewModel)
                MessageBox.Show("ADD Removed attachments");

            if (isAddingEmail && createPurchaseOrderViewModel is EditPurchaseOrderViewModel)
                MessageBox.Show("EDIT Open File Explorer, drag emails in file explorer");
            if (!isAddingEmail && createPurchaseOrderViewModel is EditPurchaseOrderViewModel)
                MessageBox.Show("EDIT Removed attachments");
        }
    }
}

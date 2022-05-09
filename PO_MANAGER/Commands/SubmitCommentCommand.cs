using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO_MANAGER.Commands
{
    public class SubmitCommentCommand : CommandBase
    {
        private readonly NotesViewModel _noteViewModel;
        public SubmitCommentCommand(NotesViewModel noteViewmodel)
        {
            _noteViewModel = noteViewmodel;
            _noteViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_noteViewModel.CommentEntry)
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Comment Submitted");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ( e.PropertyName == nameof(NotesViewModel.CommentEntry) )
            {
                OnCanExecuteChanged();
            }
        }

    }
}

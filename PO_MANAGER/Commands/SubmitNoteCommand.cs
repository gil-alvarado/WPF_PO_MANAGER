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
    public class SubmitNoteCommand : CommandBase
    {
        private readonly NotesViewModel _notesViewModel;
        public SubmitNoteCommand(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
            _notesViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_notesViewModel.NoteEntry)
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Note Submitted");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(NotesViewModel.NoteEntry))
            {
                OnCanExecuteChanged();//Invoke via CommandBase
            }
        }


    }
}

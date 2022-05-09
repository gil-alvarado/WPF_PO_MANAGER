using PO_MANAGER.Commands;
using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PO_MANAGER.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        private string? _purchaseOrder;// = "HX-00012"
        public string? PurchaseOrder
        {
            get => _purchaseOrder;
            set
            {
                _purchaseOrder = value;
                OnPropertyChanged(nameof(PurchaseOrder));
            }
        }

        private DateTime _followUpDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime FollowUpDate
        {
            get => _followUpDate;
            set
            {
                _followUpDate = value;
                OnPropertyChanged(nameof(FollowUpDate));
            }
        }
        /*
        private string? _realWorldComment;
        public string? RealWorldComment
        {
            get => _realWorldComment;
            set
            {
                _realWorldComment = value;
                OnPropertyChanged(nameof(RealWorldComment));
            }
        }
        */

        private string? _commentEntry;
        public string? CommentEntry
        {
            get => _commentEntry;
            set
            {
                _commentEntry = value;
                OnPropertyChanged(nameof(CommentEntry));
            }
        }

        /*
        private string? _followUpNote;
        public string? FollowUpNote
        {
            get => _followUpNote;
            set
            {
                _followUpNote = value;
                OnPropertyChanged(nameof(FollowUpNote));
            }
        }
        */
        private string? _noteEntry;
        public string? NoteEntry
        {
            get => _noteEntry;
            set
            {
                _noteEntry = value;
                OnPropertyChanged(nameof(NoteEntry));
            }
        }
        public ICommand SubmitCommentCommand { get; }
        public ICommand SubmitNoteCommand { get; }  
        public ICommand CloseCommand { get; }

        public NotesViewModel(ShopStore _shopStore,
            NavigationService<PurchaseOrderListingViewModel> listingViewNavigationService)
        {
            _purchaseOrder ="HX-00012";
            SubmitCommentCommand = new SubmitCommentCommand(this);
            SubmitNoteCommand = new SubmitNoteCommand(this);
            CloseCommand = new NavigateCommand(listingViewNavigationService);
        }
    }
}

using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInterview.ViewModels
{
    class TimelinePageViewModel : ViewModel
    {
        public TimelinePageViewModel(INavigationService navService)
        {
            _navService = navService;

            TimelineItems = new ObservableCollection<TimelineItem>();

            AddItemToTimelineCommand = new DelegateCommand(AddItemToTimeline);
        }

        public void AddItemToTimeline()
        {
            TimelineItems.Add(new TimelineItem() { Datestamp = DateTime.Now, Description = "New Item" });
        }

        public ObservableCollection<TimelineItem> TimelineItems { get; private set; }

        public TimelineItem SelectedItem {
            get { return _inlSelectedItem; } 
            set { SetProperty(ref _inlSelectedItem, value); } } TimelineItem _inlSelectedItem;

        public DelegateCommand AddItemToTimelineCommand { get; private set; }

        private readonly INavigationService _navService;
    }

    public class TimelineItem : BindableBase
    {
        public DateTimeOffset Datestamp { get { return _inlDatestamp; } set{ SetProperty(ref _inlDatestamp, value); } } DateTimeOffset _inlDatestamp;
        public String Description { get { return _inlDescription; } set { SetProperty(ref _inlDescription, value); } } String _inlDescription;
        public ObservableCollection<TimelineRating> Ratings { get; set; }
    }

    public class TimelineRating : BindableBase
    {
        public string Name {get; set;}
        public double Value { get { return _inlValue; } set { SetProperty(ref _inlValue, value); } } double _inlValue;
    }
}

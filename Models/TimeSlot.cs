using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace iTimeSlot.Models
{
    public class TimeSlot: ObservableObject
    {
        public bool IsSystemPreserved {get; set; }
        
        private TimeSpan _ts;
        
        public TimeSlot(TimeSpan srcTs, bool isSystemPreserved=false)
        {
            this._ts = srcTs;
            IsSystemPreserved = isSystemPreserved;
        }

        public TimeSlot(int minute, bool isSystemPreserved=false) : this(TimeSpan.FromMinutes(minute),isSystemPreserved)
        {
            
        }

        public override string ToString()
        {
            return  $"{(int) _ts.TotalMinutes} min";
        }

        public TimeSpan ToTimeSpan()
        {
            return _ts;
        }
        
    }
}
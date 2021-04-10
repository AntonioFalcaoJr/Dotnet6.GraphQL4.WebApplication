using System;

namespace Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Options
{
    public class SqlServerRetryingOptions
    {
        private const int DefaultRetryCount = 5;
        private const int DefaultRetryDelay = 5;

        private int _maxRetryCount;
        private int _maxSecondsRetryDelay;

        public int MaxRetryCount
        {
            get => _maxRetryCount <= 0 ? DefaultRetryCount : _maxRetryCount;
            set => _maxRetryCount = value;
        }

        public int MaxSecondsRetryDelay
        {
            get => _maxSecondsRetryDelay <= 0 ? DefaultRetryDelay : _maxSecondsRetryDelay;
            set => _maxSecondsRetryDelay = value;
        }

        public int[] ErrorNumbersToAdd { get; set; }
        
        internal TimeSpan MaxRetryDelay 
            => TimeSpan.FromSeconds(MaxSecondsRetryDelay);
    }
}
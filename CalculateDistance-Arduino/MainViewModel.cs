using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDistance_Arduino
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Data = new ObservableCollection<DataPoint>
            {
                new DataPoint(1, 10),
                new DataPoint(2, 20),
                new DataPoint(3, 30),
                new DataPoint(4, 40),
                new DataPoint(5, 50)
            };

            LineData = new ObservableCollection<DataPoint>
            {
                new DataPoint(0, 30),
                new DataPoint(5, 30)
            };
        }

        public ObservableCollection<DataPoint> Data { get; }
        public ObservableCollection<DataPoint> LineData { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDistance_Arduino
{
    public class ViewModelChart
    {
        public ViewModelChart()
        {
            //Data = new ObservableCollection<DataPoint>
            //{
            //    new DataPoint(1, 10),
            //    new DataPoint(2, 20),
            //    new DataPoint(3, 30),
            //    new DataPoint(4, 40),
            //    new DataPoint(5, 50)
            //};
            Data = new ObservableCollection<DataPoint>();
        }

        public void AddDataToViewModel(int distance, int time)
        {
            Data.Add(new DataPoint(distance, time));
        }

        public ObservableCollection<DataPoint> Data { get; }
    }
}

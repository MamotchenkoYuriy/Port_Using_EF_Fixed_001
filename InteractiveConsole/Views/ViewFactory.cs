using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InteractiveConsole.Views
{
    public class ViewFactory
    {
        private static ViewFactory _viewFactory = null;
        private IDictionary<string, BaseView> dictionary = null;
        

        private ViewFactory()
        {
            dictionary = new Dictionary<string, BaseView>();
            dictionary.Add(typeof(City).Name, new CityView());
            dictionary.Add(typeof(Port).Name, new PortView());
            dictionary.Add(typeof(Captain).Name, new CaptainView());
            dictionary.Add(typeof(Cargo).Name, new CargoView());
            dictionary.Add(typeof(CargoType).Name, new CargoTypeView());
            dictionary.Add(typeof (Ship).Name, new ShipView());
            dictionary.Add(typeof(Trip).Name, new TripView());
        }

        public static ViewFactory GetInstance()
        {
            if (_viewFactory != null)
            {
                return _viewFactory;
            }
            else
            {
                _viewFactory = new ViewFactory();
                return _viewFactory;
            }
        }

        public BaseView GetView<T>()
        {
            return dictionary[typeof(T).Name];
        }
    }
}

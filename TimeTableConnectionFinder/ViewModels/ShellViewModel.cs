using SwissTransport;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace TimeTableConnectionFinder {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public ShellViewModel()
        {
            TravelDate = DateTime.Now;
            TravelTime = DateTime.Now.ToString("HH:mm");
            DateTime travelTime = DateTime.ParseExact(TravelTime,"HH:mm", CultureInfo.InvariantCulture);
            Transport TransportApi = new Transport();
            var connection = TransportApi.GetConnections("Kriens, Alpenstrasse", "Luzern, Unterlöchli", TravelDate, travelTime);
            Connections = new ObservableCollection<Connection>(connection.ConnectionList);
        }

        private Coordinate _browserOriginCoordinate;

        public Coordinate BrowserCoordinate
        {
            get { return _browserOriginCoordinate; }
            set { _browserOriginCoordinate = value; }
        }

        private Coordinate _browserDestinationCoordinate;

        public Coordinate BrowserDestinationCoordinate
        {
            get { return _browserDestinationCoordinate; }
            set { _browserDestinationCoordinate = value; }
        }


        private DateTime _travelDate;

        public DateTime TravelDate
        {
            get { return _travelDate; }
            set
            {
                _travelDate = value;
                NotifyOfPropertyChange(() => TravelDate);
            }
        }

        private string _travelTime;

        public string TravelTime
        {
            get { return _travelTime;}
            set
            {
                _travelTime = value;
                NotifyOfPropertyChange(() => TravelTime);
            }
        }

        private string _origin;

        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                NotifyOfPropertyChange(() => Origin);
            }
        }


        private string _destination;

        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                NotifyOfPropertyChange(() => Destination);
            }
        }



        private ObservableCollection<Connection> _connections =  new ObservableCollection<Connection>();

        public ObservableCollection<Connection> Connections
        {
            get { return _connections; }
            set
            {
                _connections = value;
                NotifyOfPropertyChange(() => Connections);
            }
        }

        public void GetConnections()
        {
            Transport TransportApi = new Transport();
            DateTime travelTime;
            if (!DateTime.TryParse(TravelTime, out travelTime))
            {
                MessageBox.Show("Invalid timeformat expect HH:mm for example 16:15");
            }
            var connection = TransportApi.GetConnections(Origin, Destination, TravelDate, travelTime);
            Connections = new ObservableCollection<Connection>(connection.ConnectionList);
        }







    }
}
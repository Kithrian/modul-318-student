using SwissTransport;
using System;
using System.Collections.ObjectModel;

namespace TimeTableConnectionFinder {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public ShellViewModel()
        {
            Transport TransportApi = new Transport();
            var connection = TransportApi.GetConnections("Kriens, Alpenstrasse", "Luzern, Unterlöchli");
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
            set { _travelDate = value; }
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







    }
}
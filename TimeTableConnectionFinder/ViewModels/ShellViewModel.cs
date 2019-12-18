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
            //Code for testing purposes
            TravelDate = DateTime.Now;
            TravelTime = DateTime.Now.ToString("HH:mm");
            DateTime travelTime = DateTime.ParseExact(TravelTime,"HH:mm", CultureInfo.InvariantCulture);
            /*var connection = TransportApi.GetConnections("Kriens, Alpenstrasse", "Luzern, Unterlöchli", TravelDate, travelTime);
            Connections = new ObservableCollection<Connection>(connection.ConnectionList);
            Origin = "Test";
            Destination = "Test2";*/
        }

        Transport TransportApi = new Transport();

        
        public void Exchange()
        {
            String Temp = Origin;
            Origin = Destination;
            Destination = Temp;
        }

        public void GetStationBoard()
        {
            var Response = TransportApi.GetStationBoard(SelectedStation);
            StationBoard = new ObservableCollection<StationBoard>(Response.Entries);
            StationBoard2 = Response.Station;

        }

        public void GetStations()
        {
            var Response = TransportApi.GetStations("Kriens, Alpenstrass");
            Stations = new ObservableCollection<Station>(Response.StationList);
            //StationBoard2 = Response.Station;
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

        private Station _stationBoard2;

        public Station StationBoard2
        {
            get { return _stationBoard2; }
            set
            {
                _stationBoard2 = value;
                NotifyOfPropertyChange(() => StationBoard2);
            }
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



        private ObservableCollection<Station> _stations =  new ObservableCollection<Station>();

        public ObservableCollection<Station> Stations
        {
            get { return _stations; }
            set
            {
                _stations = value;
                NotifyOfPropertyChange(() => Stations);
            }
        }

        private ObservableCollection<Connection> _connections = new ObservableCollection<Connection>();

        public ObservableCollection<Connection> Connections
        {
            get { return _connections; }
            set
            {
                _connections = value;
                NotifyOfPropertyChange(() => Connections);
            }
        }


        private ObservableCollection<StationBoard> _stationBoard = new ObservableCollection<StationBoard>();

        public ObservableCollection<StationBoard> StationBoard
        {
            get { return _stationBoard; }
            set
            {
                _stationBoard = value;
                NotifyOfPropertyChange(() => StationBoard);
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

        private string _selectedStation;

        public string SelectedStation
        {
            get { return _selectedStation; }
            set
            {
                _selectedStation = value;
                NotifyOfPropertyChange(() => SelectedStation);
            }
        }

    }
}
namespace _2._5
{
    public class TemperatureSensor
    {
        
        public event Action<double> TemperatureChanged;

        private double _currentTemperature;

        public double CurrentTemperature
        {
            get => _currentTemperature;
            set
            {
                if (_currentTemperature != value)
                {
                    _currentTemperature = value;
                    
                    TemperatureChanged?.Invoke(value);
                }
            }
        }
    }

    
    public class Thermostat
    {
        private bool _heatingOn;
        private readonly double _targetTemperature;

        public Thermostat(double targetTemperature)
        {
            _targetTemperature = targetTemperature;
        }

    
        public void SubscribeToSensor(TemperatureSensor sensor)
        {
            sensor.TemperatureChanged += OnTemperatureChanged;
        }

    
        private void OnTemperatureChanged(double newTemperature)
        {
            if (newTemperature < _targetTemperature && !_heatingOn)
            {
                _heatingOn = true;
                Console.WriteLine($"Температура {newTemperature}°C - ВКЛЮЧАЕМ отопление");
            }
            else if (newTemperature >= _targetTemperature && _heatingOn)
            {
                _heatingOn = false;
                Console.WriteLine($"Температура {newTemperature}°C - ВЫКЛЮЧАЕМ отопление");
            }
        }
    }

    
    class Program
    {

        static void Main()
        {
            while (true)
            {
                Random rnd = new Random();

                var sensor = new TemperatureSensor();


                var thermostat = new Thermostat(22);


                thermostat.SubscribeToSensor(sensor);


                sensor.CurrentTemperature = rnd.Next(16,32);
                sensor.CurrentTemperature = rnd.Next(16, 32);
                sensor.CurrentTemperature = rnd.Next(16, 32);
                sensor.CurrentTemperature = rnd.Next(16, 32);
                Console.ReadKey();
                Console.Clear();   
            }
        }
    }
    }

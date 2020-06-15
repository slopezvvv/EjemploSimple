using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SensorHumedadTemperatura
{
    // CAJA NEGRA
    // NO MODIFICAR, SOLAMENTE USAR
    enum TipoSensor
    {
        HUMEDAD, TEMPERATURA
    }
    class Sensor
    {
        private static Dictionary<TipoSensor, ICollection<float>> _data = 
            new Dictionary<TipoSensor, ICollection<float>>();
        private Thread _conn;
        private Random _random;

        public Sensor()
        {
            _data[TipoSensor.HUMEDAD] = new Collection<float>();
            _data[TipoSensor.TEMPERATURA] = new Collection<float>();
            _random = new Random();
            _conn = new Thread(() => {
                while (true)
                {
                    if (Humedad.Count > 25 || Temperatura.Count > 25 || Humedad.Count != Temperatura.Count)
                    {
                        Humedad.Clear();
                        Temperatura.Clear();
                    }
                    Humedad.Add(_random.Next(0, 100));
                    Temperatura.Add(_random.Next(-200, 200));
                    Thread.Sleep(300);
                }
            });
            _conn.Start();
        }

        public ICollection<float> Humedad
        {
            get => _data[TipoSensor.HUMEDAD];
            set => _data[TipoSensor.HUMEDAD] = value;
        }

        public ICollection<float> Temperatura
        {
            get => _data[TipoSensor.TEMPERATURA];
            set => _data[TipoSensor.TEMPERATURA] = value;
        }
    }
}

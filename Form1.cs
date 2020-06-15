using SensorHumedadTemperatura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploSimple
{
    public partial class Form1 : Form
    {
        private DataTable dt = new DataTable();
        private Sensor sensor = new Sensor();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Humedad");
            dt.Columns.Add("Temperatura");
            gvDatos.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dt.Clear();
            // Desplegar la humedad entre el 25% y 50% utilizando LINQ
            var filtroHumedad = from humedad in sensor.Humedad where humedad >= 25 && humedad <= 50 select humedad;
            var filtroTemperatura = from temperatura in sensor.Temperatura where temperatura >= 0 && temperatura <= 23 select temperatura;
            

            // 25 25
            // recorrer 25 veces
            // 25 veces la temperatura por cada humedad

            foreach (float humedad in filtroHumedad)
            {
                foreach (float temperatura in filtroTemperatura) {
                    Object[] obj = new object[] {humedad, temperatura};
                    dt.Rows.Add(obj);
                }
            }
            // Agregar los datos de la temperatura a la tabla.
            // Filtren los datos de la temperatura entre 0 y 23 grados.
        }
    }
}

using MathServiceLibrary;
using System.ServiceModel;
using System.ServiceProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;

namespace MathWindowsServiceHost
{
    public partial class MathService : ServiceBase
    {
        private ServiceHost myHost;
        
        public MathService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myHost?.Close();
            // Создать хост и указать URL для привязки HTTP.
            myHost = new ServiceHost(typeof(MathService), new Uri("http://localhost:8080/MathServiceLibrary"));
            // Выбрать стандартные конечные точки.
            myHost.AddDefaultEndpoints();
            // Открыть хост.
            myHost.Open();
        }

        protected override void OnStop()
        {
            // Остановить хост.
            myHost?.Close();
        }
    }
}

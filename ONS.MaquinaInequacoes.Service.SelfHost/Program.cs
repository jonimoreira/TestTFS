using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ONS.MaquinaInequacoes.Service.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/MaquinaInequacoes");

            using (ServiceHost host = new ServiceHost(typeof(MaquinaInequacoesService), baseAddress))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                //smb.MetadataExporter.PolicyVersion = PlicyVersion
                host.Description.Behaviors.Add(smb);

                ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                if (sdb == null)
                {
                    sdb = new ServiceDebugBehavior();
                    sdb.IncludeExceptionDetailInFaults = true;
                    host.Description.Behaviors.Add(sdb);
                }
                else
                {
                    sdb.IncludeExceptionDetailInFaults = true;
                    //sdb.HttpHelpPageEnabled = true;
                    //host.Description.Behaviors.Add(sdb);

                }

                host.Open();

                Console.WriteLine("Serviço ativo em: " + baseAddress);
                Console.WriteLine("[Enter] para parar");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}

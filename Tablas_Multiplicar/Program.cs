using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Threading.Tasks;

namespace TABLAS_DE_MULTIPLICAR
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri orgUrl = new Uri("https://dev.azure.com/occeal");     // Account URL                
            String personalAccessToken = "tdmiy6nksvbrjikxubuzf6ufwcwtro5arsjkwkms3g55u3iq6weq";  // Personaltoken               
          
            int workItemId = 2; //   Actividad     



            // Create a connection to the account
            VssConnection connection = new VssConnection(orgUrl, new VssBasicCredential(string.Empty, personalAccessToken));

            // Show details a work item
            ShowWorkItemDetails(connection, workItemId).Wait();
        }

        static private async Task ShowWorkItemDetails(VssConnection connection, int workItemId)
            {
                WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
                try
                {
                    WorkItem workitem = await witClient.GetWorkItemAsync(workItemId);
                    foreach (var field in workitem.Fields)
                    {
                        Console.WriteLine("{0}:{1}", field.Key, field.Value);
                    }
                }
                catch (AggregateException aex)
                {
                    VssServiceException vssex = aex.InnerException as VssServiceException;
                    if (vssex != null)
                    {
                        Console.WriteLine(vssex.Message);
                    }
                }
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("\nTabla de multiplicar del {0}", i);
                Console.WriteLine("------------------------------");
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, (i * j));
                }
            }
            Console.ReadKey();
        }
    }
  
}
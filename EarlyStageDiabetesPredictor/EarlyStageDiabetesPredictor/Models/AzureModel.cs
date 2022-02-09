using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EarlyStageDiabetesPredictor.Models
{

    public class AzureModel
    {
        public static Person CheckForDiabetes(Person person)
        {
            var task = InvokeRequestResponseService(person);
            task.Wait();
           return task.Result;
        }

        static async Task<Person> InvokeRequestResponseService(Person person)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Age", person.age.ToString()
                                            },
                                            {
                                                "Gender", person.gender
                                            },
                                            {
                                                "Polyuria", person.Polyuria
                                            },
                                            {
                                                "Polydipsia", person.Polydipsia
                                            },
                                            {
                                                "sudden weight loss", person.suddenWeightLoss
                                            },
                                            {
                                                "weakness", person.weakness
                                            },
                                            {
                                                "Polyphagia", person.Polyphagia
                                            },
                                            {
                                                "Genital thrush", person.genitalThrush
                                            },
                                            {
                                                "visual blurring", person.visualBlurring
                                            },
                                            {
                                                "Itching", person.itching
                                            },
                                            {
                                                "Irritability", person.irritability
                                            },
                                            {
                                                "delayed healing", person.delayedHealing
                                            },
                                            {
                                                "partial paresis", person.partialParesis
                                            },
                                            {
                                                "muscle stiffness", person.muscleStiffness
                                            },
                                            {
                                                "Alopecia", person.alopecia
                                            },
                                            {
                                                "Obesity", person.obesity
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "pLzlQAP0ktP9rXyfvdHYBg4y4W1agd+Wfp66wMAmlbAhjBhrbgBM245GUivHm80O4S/JMfUKd7P6TFPZhjkSgg=="; // Replace this with the API key for the web service
                ///////////////////////pLzlQAP0ktP9rXyfvdHYBg4y4W1agd+Wfp66wMAmlbAhjBhrbgBM245GUivHm80O4S/JMfUKd7P6TFPZhjkSgg==
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/c112d590e4534ee0a949df28b93502c6/services/f5edff3edf49406890947da67c6c224e/execute?api-version=2.0&format=swagger");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {

                    var result = JsonConvert.DeserializeObject <Dictionary<string,Dictionary<string, List<Dictionary<string,string>>> >> (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                    person.outcome = result["Results"]["output1"][0]["Scored Labels"].ToString();
                    person.percentage = result["Results"]["output1"][0]["Scored Probabilities"].ToString();



                    // Console.WriteLine("Result: {0}", result);
                    return person;
                }
                else
                {
                   // Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    return person;
                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    //Console.WriteLine(response.Headers.ToString());

                    //string responseContent = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseContent);
                }
                
            }
        }
    }
}
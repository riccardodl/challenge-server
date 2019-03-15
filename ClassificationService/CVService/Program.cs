using Microsoft.Azure.CognitiveServices.Vision.CustomVision;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CVService
{
    public class Program
    {
        private const string SouthCentralUsEndpoint = "https://southcentralus.api.cognitive.microsoft.com";
        private const string trainingKey = "6b6d1dcaad52473783c2444e387b8a40";
        private const string predictionKey = "628cce4c7d0148c59fcb400c939380b2";

        public static Project project;

        static void Main(string[] args)
        {
            if (!Train())
            {
                throw new InvalidOperationException("Your model cannot be train. Check your project again.");
            }

            // Make a prediction
            Console.WriteLine("Making a prediction:");
            string relativePath = "test_image.jpg";
            string baseDirectory = "C:\\Users\\maros\\Desktop\\ropes\\test\\";
            string imageFile = Path.GetFullPath(baseDirectory + relativePath);
            FileStream fileStream = new FileStream(imageFile, FileMode.Open, FileAccess.Read);
            var str = ResultsToString(Predict(fileStream, project));
            foreach (var s in str)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// A wrapper for the VisionAI call
        /// </summary>
        /// <param name="rawImg"></param>
        /// <returns></returns>
        public static IList<string> PredictRawImage(byte[] rawImg)
        {
            Train();
            Stream stream = new MemoryStream(rawImg);
            return ResultsToString(Predict(stream, project));
        }

        private static IList<PredictionModel> Predict(Stream imageStream, Project project)
        {
            CustomVisionPredictionClient endpoint = new CustomVisionPredictionClient()
            {
                ApiKey = predictionKey,
                Endpoint = SouthCentralUsEndpoint
            };

            var resultML = endpoint.PredictImage(project.Id, imageStream);
            return resultML.Predictions;
        }

        private static bool Train()
        {
            CustomVisionTrainingClient trainingApi = new CustomVisionTrainingClient()
            {
                ApiKey = trainingKey,
                Endpoint = SouthCentralUsEndpoint
            };

            // Find the object detection domain
            var domains = trainingApi.GetDomains();
            var objDetectionDomain = domains.FirstOrDefault(d => d.Type == "ObjectDetection");

            // Get my classifier project
            project = trainingApi.GetProjects().Where(p => p.Name == "Rope-classifier").FirstOrDefault();
            // Get the current iteration of the trained model
            Iteration iteration = trainingApi.GetIterations(project.Id).Where(i => i.IsDefault).FirstOrDefault();
            if (iteration == null)
            {
                iteration = trainingApi.GetIterations(project.Id).OrderByDescending(t => t.TrainedAt).First();
                if (iteration == null)
                {
                    return false;
                }
            }

            TimeSpan timeDifference = DateTime.Now.Subtract(iteration.LastModified);
            if (timeDifference.TotalDays > 7)
            {
                Console.WriteLine("\tTraining");
                iteration = trainingApi.TrainProject(project.Id);

                while (iteration.Status == "Training")
                {
                    Thread.Sleep(1000);
                    iteration = trainingApi.GetIteration(project.Id, iteration.Id);
                }

                // The iteration is now trained. Make it the default project endpoint
                iteration.IsDefault = true;
                trainingApi.UpdateIteration(project.Id, iteration.Id, iteration);
                Console.WriteLine("Done!\n");
            }
            // Now there is a trained endpoint, it can be used to make a prediction
            return true;
        }

        public static IList<string> ResultsToString(IList<PredictionModel> resultML)
        {
            List<string> result = new List<string>();
            // Loop over each prediction and write out the results
            foreach (var c in resultML)
            {
                string bbInfo = "";
                if (c.BoundingBox != null)
                {
                    bbInfo = $"[ { c.BoundingBox.Left }, { +c.BoundingBox.Top }, {c.BoundingBox.Width}, {c.BoundingBox.Height } ]";
                }
                result.Add($"\t{c.TagName}: {c.Probability:P1}" + bbInfo);
                Console.WriteLine(result.Last());
            }
            return result;
        }

        public static byte[] ToByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }
}
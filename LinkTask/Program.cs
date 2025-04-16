using System.Diagnostics;

namespace LinkTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> links = new List<string>
               {
                 "https://www.youtube.com/watch?v=Wi7pzEYf4jE",
                 "https://www.youtube.com/watch?v=Wi7pzEYf4jE",
                 "https://www.youtube.com/watch?v=Wi7pzEYf4jE",
                 "https://www.youtube.com/watch?v=Wi7pzEYf4jE",
                 "https://www.youtube.com/watch?v=Wi7pzEYf4jE"
               };

            GetData(links).Wait();

        }
        static async Task GetData(List<string> links)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                foreach (var link in links)
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(link);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Youtube video linki: " + link);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Gonderilen linkde problem var:  {link} { ex.Message}");
                    }
                }

                stopwatch.Stop();

                Console.WriteLine(stopwatch.Elapsed.TotalSeconds + " saniye");
            }
        }
    }

}

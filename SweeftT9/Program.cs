
using System;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //Console.WriteLine("Press Enter to start:");
            //Console.ReadLine();

            Console.WriteLine("Press any key to exit the program...");

            // SemaphoreSlim 
            SemaphoreSlim semaphore = new SemaphoreSlim(1);
            //await Task.Delay(500);
            // Start infinite loop
            while (!Console.KeyAvailable)
            {
                await Task.Delay(500);
                // Task to output 1 0
                Task task = Task.Run(async () =>
                {
                    DateTime startTime = DateTime.Now;

                    while ((DateTime.Now - startTime).TotalSeconds < 5)
                    {
                        // Check if 5 seconds have passed
                       // if ((DateTime.Now - startTime).TotalSeconds >= 5)
                            //break;//so we display 1 ad 0 for 5 seconds and then break
                        await semaphore.WaitAsync();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("1");
                        await Task.Delay(100);

                        Console.Write("0");
                        Console.ResetColor();
                        semaphore.Release();
                        await Task.Delay(100); 
                                          

                    }
                    
                });

                // Wait for 5 seconds
                await Task.Delay(5000);


 
                Task messageTask = Task.Run(async () =>
                {
                    // after stopping displaying 1 and 0, line below will be displayed
                    await semaphore.WaitAsync();
             
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Neo, you are the chosen one ");
                    Console.ResetColor();
                    semaphore.Release();

                });
                
                // Wait for another 5 seconds, nothing will be displayed during it
                await Task.Delay(5000);

                
            }
        }
    }
}


// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

//url from which we get data
string url = "https://restcountries.com/v3.1/all";

await GenerateCountryDataFiles();

async Task GenerateCountryDataFiles()
{
    using HttpClient client = new HttpClient();

    try
    {
        //send get request and wait for response
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //get values from url
            //response.content contains needed data and we read it as string
            string responseBody = await response.Content.ReadAsStringAsync();
            //now deserialize json string into array of counntry objects
            Country[]? countries = JsonSerializer.Deserialize<Country[]>(responseBody);

            //now we can iterate over data
            if (countries != null)
            {
                foreach (Country country in countries)
                {

                    string file = $"{country.name?.common}.txt";
                    //start writing data into the file
                    using StreamWriter sw = File.CreateText(file);

                    await sw.WriteLineAsync($"Country: {country.name?.common}");
                    await sw.WriteLineAsync($"Region: {country.region}");
                    await sw.WriteLineAsync($"Subregion: {country.subregion}");
                    await sw.WriteLineAsync($"Latlng: {(country.latlng != null ? string.Join(", ", country.latlng) : "N/A")}");
                    await sw.WriteLineAsync($"Area: {country.area}");
                    await sw.WriteLineAsync($"Population: {country.population}");

                }
                Console.WriteLine("created files successfully");
            }
            else Console.WriteLine("could not deserialize data");
        }
        else
        {
            Console.WriteLine($"could not  get data. Status code: {response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"error occurred: {ex.Message}");
    }
}


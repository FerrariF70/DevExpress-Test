
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using Test.ViewModels;

namespace DXApplication1.Export
{
    public class ExportData : IExport
    {
        public async Task<string> ExportFile(string fileName, IList list)
        {
            try
            {
                using (FileStream fs = File.Create(Path.Combine(Environment.CurrentDirectory, fileName)))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine($"Id,NameModel,DateOfIssue,Price,");

                        foreach (CarModel car in list)
                        {
                            await sw.WriteLineAsync($"{car.Id},{car.NameModel},{car.DateOfIssue},{car.Price}$");
                        }
                        return "Complete!";
                    }
                }
            }
            catch(Exception)
            {
                return "Something went wrong";
            }
        }
    }
}

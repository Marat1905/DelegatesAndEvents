using DelegatesAndEvents.Extensions;

namespace DelegatesAndEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var persons = PersonGenerator.GeneratePersonCollection(20).ToList();

            var resultMax = persons.GetMax(x=>x.Age);

            Console.WriteLine(resultMax);

            var fileFinder = new FileFinder();

            Task task = new Task(() =>
            {
                //Можно получить данные из мметода
                //foreach (var file in fileFinder.FindFiles(@"..\..\..\Test", false, cts.Token))
                //    Console.WriteLine(file);

                //Подписываемся на событие
                fileFinder.FileFound += FileFinder_FileFound;
                fileFinder.FindFiles(@"..\..\..\Test", true, cts.Token).ToList();
               
            });
            

            task.Start();

            //Отмена операции
            //Thread.Sleep(2000);
            // после задержки по времени отменяем выполнение задачи
            //cts.Cancel();

            Console.ReadKey();
        }

        private static void FileFinder_FileFound(object? sender, Events.FileEventArgs e)
        {
            Console.WriteLine(e.Name);
        }
    }
}

using DelegatesAndEvents.Events;

namespace DelegatesAndEvents;

public class FileFinder
{
    public event EventHandler<FileEventArgs> FileFound;

    public IEnumerable<string> FindFiles(string directoryPath, bool includeSubdirectories =true, CancellationToken cancellation= default)
    {
        Console.WriteLine($"Start to search for new files in folder: {directoryPath}");

        DirectoryInfo directory = new(directoryPath);

        FileInfo[] filesDirectory = directory.GetFiles();

        //В цикле пробегаемся по всем файлам директории di и складываем их размеры
        foreach (FileInfo file in filesDirectory)
        {
             Task.Delay(1000).Wait();
            if (cancellation.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                break;     //  выходим из метода и тем самым завершаем задачу
            FileFound?.Invoke(this, new FileEventArgs(file.Name));
            yield return file.Name;
           
        }
       
        if (includeSubdirectories)
            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
                foreach (var str in FindFiles(subdirectory.FullName, true, cancellation))
                        yield return str;
    }
}


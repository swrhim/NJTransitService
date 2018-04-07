namespace NJTransit.LightRail

module Infrastructure = 
    open System.IO
    open CsvHelper

    let getCsvIgnoreHeader file = 
        let reader = File.OpenText(file)
        let csv = new CsvReader(reader)
        csv.ReadAsync() |> Async.AwaitTask |> Async.RunSynchronously |> ignore
        csv.ReadHeader() |> ignore
        csv
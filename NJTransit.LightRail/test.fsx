#r "/Users/daniel/.nuget/packages/csvhelper/6.1.1/lib/netstandard2.0/CsvHelper.dll"
#load "Types/RailData.fs"
#load "Persistence/RailDataPersistence.fs"

sprintf "%A" (NJTransit.LightRail.RailDataPersistence.load "NJTransit.LightRail/bin/Debug/netstandard2.0/rail_data/agency.csv")


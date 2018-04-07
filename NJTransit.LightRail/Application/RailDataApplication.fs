namespace NJTransit.LightRail

open NJTranit.LightRail.RailDataTypes
module RailDataApplication = 
    open System
    open NJTransit.LightRail.RailDataPersistence
    open NJTranit.LightRail.RailDataTypes

    let [<Literal>] agencyCsv = "../rail_data/agency.csv" 
    let [<Literal>] calendarDatesCsv = "../rail_data/calendar_dates.csv"
    let [<Literal>] routesCsv = "../rail_data/routes.csv"
    let [<Literal>] shapesCsv = "../rail_data/shapes.csv"
    let [<Literal>] stopTimesCsv = "../rail_data/stop_times.csv"
    let [<Literal>] stopsCsv = "../rail_data/stops.csv"
    let [<Literal>] tripsCsv = "../rail_data/trips.csv"

    let mutable agency = []
    let mutable calendarDates = []
    let mutable (routes : RouteTransferObject list) = []
    let mutable shapes = []
    let mutable stopTimes = []
    let mutable stops = []
    let mutable trips = []

    let init () = 
        agency <- loadFromCsv agencyCsv convertToAgency
        calendarDates <- loadFromCsv calendarDatesCsv convertToCalendarDate
        routes <- loadFromCsv routesCsv convertToRoute
        shapes <- loadFromCsv shapesCsv convertToShape
        stopTimes <- loadFromCsv stopTimesCsv convertToStopTime
        stops <- loadFromCsv stopsCsv convertToStop
        trips <- loadFromCsv tripsCsv convertToTrip
        ()

    let defaultScheduleFromHobokenToPortImperial (currentTime : DateTime) =
        //in routes we care about routeid 4
        //stopid 9878
        let getRouteFromId = 
            routes 
            |> List.map(RailDomain.convertRouteTransferToRouteDomain >> Choice.mapl(fun r -> r.id))
            |> List.filter(fun r -> 
                match r with
                | Success id -> id = 4
                | Failure _ -> false 
            )
        ()

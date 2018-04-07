namespace NJTransit.LightRail
open System.Web
open NJTranit.LightRail.RailDataTypes

module RailDomain = 
    let convertToDomainTypes field row = 
        row
        |> Seq.tryFind((fun (f,_) -> f = field))
        |> Option.map(fun (_,d) -> d)
        |> Option.getValueOrDefault

    
    let handleBadInput domainType input= 
        match input with
        | -1 -> Failure "Could not load"
        | _ -> Success domainType

        


    let convertRouteTransferToRouteDomain (routeTransferObject : RouteTransferObject) =
        let routeDomain = 
            {
                Route.id = routeTransferObject.id |> Int.tryParse |> Option.getValueOr -1
                agencyid = routeTransferObject.agencyId
                shortName = routeTransferObject.shortName
                longName = routeTransferObject.longName
                routeType = routeTransferObject.routeType
                url = routeTransferObject.url
                color = routeTransferObject.color
            } 

        handleBadIds routeDomain routeDomain.id
    let convertStopTransferToStopDomain (stopTransferObject : StopTransferObject) = 
        let stopDomain = 
            {
                Stop.id = stopTransferObject.id |> Int.tryParse |> Option.getValueOr -1
                code = stopTransferObject.code |> Int.tryParse |> Option.getValueOr -1
                name = stopTransferObject.name
                stopDesc = stopTransferObject.stopDesc
                stopLat = stopTransferObject.stopLat
                stopLong = stopTransferObject.stopLat
                zoneId = stopTransferObject.zoneId
            }
        handleBadIds stopDomain stopDomain.id
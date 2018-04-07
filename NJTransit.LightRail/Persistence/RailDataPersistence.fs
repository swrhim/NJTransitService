namespace NJTransit.LightRail

open NJTranit.LightRail
open System.Collections.Generic

module RailDataPersistence =
    open System
    open System.IO
    open System.Text
    open CsvHelper
    open RailDomain
    open RailDataTypes

    let convertToAgency records = {
        AgencyTransferObject.id = convertToDomainTypes "agency_id" records
        name = convertToDomainTypes "agency_name" records
        url = convertToDomainTypes "agency_url" records
        timezone = convertToDomainTypes "agency_timezone" records
        lang = convertToDomainTypes "agency_lang" records
        phone = convertToDomainTypes "agency_hone" records
    }

    let convertToCalendarDate records = {
        CalendarDateTransferObject.serviceId = convertToDomainTypes "service_id" records
        date = convertToDomainTypes "date" records
        exceptionType = convertToDomainTypes "exception_types" records
    }

    let convertToRoute records = {
        RouteTransferObject.id = convertToDomainTypes "route_id" records
        agencyId = convertToDomainTypes "agency_id" records
        shortName = convertToDomainTypes "route_short_name" records
        longName = convertToDomainTypes "route_long_name" records
        routeType = convertToDomainTypes "route_type" records
        url = convertToDomainTypes "route_url" records
        color = convertToDomainTypes "route_color" records
    }

    let convertToShape records = {
        ShapeTransferObject.id = convertToDomainTypes "shape_id" records
        lat = convertToDomainTypes "shape_pt_lat" records
        lon = convertToDomainTypes "shape_pt_lon" records
        sequence = convertToDomainTypes "shape_pt_sequence" records
        distTraveled = convertToDomainTypes "shape_dist_traveled" records
    }

    let convertToStopTime records = {
        StopTimeTransferObject.tripId = convertToDomainTypes "trip_id" records
        arrivalTime = convertToDomainTypes "arrival_time" records
        departureTime = convertToDomainTypes "departure_time" records
        stopId = convertToDomainTypes "stop_id" records
        stopSeq = convertToDomainTypes "stop_sequence" records
        pickupType = convertToDomainTypes "pickup_type" records
        dropoffType = convertToDomainTypes "drop_off_type" records
        distTraveled = convertToDomainTypes "shape_dist_traveled" records
    }

    let convertToStop records = {
        StopTransferObject.id = convertToDomainTypes "stop_id" records
        code = convertToDomainTypes "stop_code" records
        name = convertToDomainTypes "stop_name" records
        stopDesc = convertToDomainTypes "stop_desc" records
        stopLat = convertToDomainTypes "stop_lat" records
        stopLong = convertToDomainTypes "stop_long" records
        zoneId = convertToDomainTypes "zone_id" records
    }

    let convertToTrip records = {
        TripTransferObject.routeId = convertToDomainTypes "route_id" records
        serviceId = convertToDomainTypes "service_id" records
        tripId = convertToDomainTypes "trip_id" records
        tripHeadSign = convertToDomainTypes "trip_headsign" records
        directionId = convertToDomainTypes "direction_id" records
        blockId = convertToDomainTypes "block_id" records
        shapeId = convertToDomainTypes "shape_id" records
    }

    let rec readRecords (csv : CsvReader) domainTypes (f : seq<string * string> -> 'a) =
        if csv.Read() then domainTypes 
        else
            let records = csv.GetRecord()
            let domainType = f records
            let newDomainTypes = domainTypes |> List.append [ domainType ]
            newDomainTypes

    let loadFromCsv file (f : seq<string*string> -> 'a) : 'a list=
        let csv = Infrastructure.getCsvIgnoreHeader file
        readRecords csv [] f
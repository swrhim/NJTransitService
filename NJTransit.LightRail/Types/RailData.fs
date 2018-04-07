namespace NJTranit.LightRail

module RailDataTypes =
    open System

    type id = int 
    type stringId = string

    type Agency = {
        id : stringId 
        name : string
        url : string
        timezone : string
        lang : string
        phone : string
    }

    type CalendarDate = {
        serviceId : id
        date : DateTime
        exceptionType : int
    }

    type Route = {
        id : id
        agencyid : stringId
        shortName : string
        longName : string
        routeType : string
        url : string
        color : string
    }

    type Shape = {
        id : id
        lat : float
        long : float 
        sequence : int
        distTraveled : float
    }

    type StopTime = {
        id : id
        arrivalTime : DateTime
        departureTime : DateTime
        stopId : id
        stopSeq : float
        pickupType : int
        dropOffType : int
        distTraveled : float
    }

    type Stop = {
        id : id
        code : int
        name : string
        stopDesc : string
        stopLat : float
        stopLong : float
        zoneId : id
    }

    type Trip = {
        routeId : id
        serviceId :id
        tripId : id
        tripHeadSign : string
        directionId : id
        blockId : string
        shapeId : float
    }

    type AgencyTransferObject = {
        id : string
        name : string
        url : string
        timezone : string
        lang : string
        phone : string
    }

    type CalendarDateTransferObject = {
        serviceId : string
        date : string
        exceptionType : string
    }

    type RouteTransferObject = {
        id : string
        agencyId : string
        shortName : string
        longName : string
        routeType : string
        url : string
        color : string
    }

    type ShapeTransferObject = {
        id : string
        lat : string
        lon : string 
        sequence : string
        distTraveled : string
    }

    type StopTimeTransferObject = {
        tripId : string
        arrivalTime : string
        departureTime : string
        stopId : string
        stopSeq : string
        pickupType : string
        dropoffType : string
        distTraveled : string
    }

    type StopTransferObject = {
        id : string
        code : string
        name : string
        stopDesc : string
        stopLat : string
        stopLong : string
        zoneId : string
    }

    type TripTransferObject = {
        routeId : string
        serviceId : string
        tripId : string
        tripHeadSign : string
        directionId : string
        blockId : string
        shapeId : string
    }


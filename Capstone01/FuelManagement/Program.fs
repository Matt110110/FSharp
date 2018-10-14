// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open Car

let getDestinationString =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let getProperDestination destination =
    if destination = "Petrol" then Destinations.Petrol
    elif destination = "Stadium" then Destinations.Stadium
    elif destination = "Office" then Destinations.Office
    elif destination = "Home" then Destinations.Home
    else failwith "Unknown destination!"

let mutable petrol = 100

[<EntryPoint>]
let main argv = 
    while true do
        try
            let dest = getDestinationString
            let destination = getProperDestination dest
            printfn "Trying to drive to %s" dest
            petrol <- driveTo(petrol, destination)
            printfn "Made it to %s! You have %d petrol left" dest petrol
        with ex -> printfn "ERROR: %s" ex.Message
    0 // return an integer exit code

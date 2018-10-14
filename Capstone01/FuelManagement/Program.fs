// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type Destinations =
    | Home = 0
    | Petrol = 1
    | Stadium = 2
    | Office = 3
    | Unknown = 4

// Function to return the distance to travel
let getDistance destination =
    if destination = Destinations.Petrol then 10
    elif destination = Destinations.Home then 25
    elif destination = Destinations.Office then 50
    elif destination = Destinations.Stadium then 25
    else failwith "Unknown destination"

[<EntryPoint>]
let main argv = 
    while true do
        try
            let destination = getDestination()
            printfn "Trying to drive to %s" destination
            petrol <- driveTo(petrol, destination)
            printfn "Made it to %s! You have %f petrol left" destination petrol
        with ex -> printfn "ERROR: %s" ex.Message
    0 // return an integer exit code

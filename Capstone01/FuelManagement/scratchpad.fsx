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

// Test cases for getDistance function
getDistance Destinations.Home = 25

getDistance Destinations.Stadium = 25

// Calculate the remaining petrol
let calculateRemainingPetrol (currentPetrol:int, distance:int) = 
    if currentPetrol >= distance then currentPetrol - distance
    else failwith "Oops! You have run out of petrol!"

let x = calculateRemainingPetrol(25, getDistance(Destinations.Petrol))
let y = calculateRemainingPetrol(5, getDistance(Destinations.Petrol))

let driveTo (petrol:int, destination:Destinations) = calculateRemainingPetrol(petrol, getDistance(destination))
let petrolRun destination = if destination = Destinations.Petrol then petrol + 50
module Car

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

let calculateRemainingPetrol (currentPetrol:int, distance:int) = 
    let remainingPetrol = currentPetrol - distance
    if remainingPetrol >= 0 then currentPetrol - distance
    else failwith "Oops! You have run out of petrol!"

let driveTo (petrol, destination) =
    let distanceToNextDestination = getDistance destination
    let petrolAfterDriving = calculateRemainingPetrol(petrol, distanceToNextDestination)
    if destination = Destinations.Petrol then petrolAfterDriving + 50
    else petrolAfterDriving
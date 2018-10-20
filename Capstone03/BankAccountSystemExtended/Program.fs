open System
open BankAccountSystemAPI
open Audit

// Take input from the console and store it in file
let private getAccountDetails() = 
    printfn "Enter the account number: "
    let accNo = Console.ReadLine()
    printfn "Enter the account owner details: "
    printfn "Enter the First name: "
    let fname = Console.ReadLine()
    printfn "Enter the last name: "
    let lname = Console.ReadLine()
    printfn "Enter the age: "
    let age = Console.ReadLine() |> int
    let owner = { Firstname = fname; Lastname = lname; Age = age }
    printfn "\nEnter the ammount in the account: "
    let amt = Console.ReadLine() |> decimal
    { UniqueID = accNo; Owner = owner; CurrentBalance = amt }

// Gets the ammount to be used for the operation and return a tuple of the command
let getAmmount cmd =
    printfn "Enter the ammount"
    let amt = Console.ReadLine() |> decimal
    (cmd, amt)

// Shows the options and asks the users to enter the list of space separated operations
let getCommand() =
    printfn "\n\nPlease select your preferred operation:"
    printfn "1. Deposit cash"
    printfn "2. Withdraw cash"
    printfn "3. Exit"
    printfn "Enter a space separated sequence of operations you want to perform:"
    let choice = Console.ReadLine()
    let choices = 
        choice.Split(' ')
        |> Seq.map (fun u -> u |> int)
    choices

let processCommand account (command, ammount) =
    if command = 1 then depositWithConsoleAudit ammount account
    elif command = 2 && ammount <= account.CurrentBalance then withdrawWithConsoleAudit ammount account
    elif command = 2 && ammount > account.CurrentBalance then printfn "Account balance insufficient"; account
    else account


let acc() =
    let account = getAccountDetails()
    let commands = getCommand()
    commands
    |> Seq.filter(fun i -> i = 1 || i = 2 || i = 3)
    |> Seq.takeWhile (not << fun i -> i = 3)
    |> Seq.map getAmmount
    |> Seq.fold processCommand account


[<EntryPoint>]
let main argv =
    Console.WriteLine("Welcome to the bank\n")
    try
        let x = acc()
        x |> ignore
    with
        ex -> printfn "%s" ex.Message
    0 // return an integer exit code

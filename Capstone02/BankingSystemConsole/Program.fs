open System
open BankAccountSystemAPI

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

let amt() =
    printfn "Enter the ammount"
    Console.ReadLine() |> decimal

[<EntryPoint>]
let main argv =
    Console.WriteLine("Welcome to the bank\n")
    let mutable account = getAccountDetails()
    let mutable choice = true
    let mutable amt = amt()
    while choice do
        printfn "\n\nPlease select your preferred operation:"
        printfn "1. Deposit cash"
        printfn "2. Withdraw cash"
        printfn "3. Exit"
        let mutable ch = Console.ReadLine() |> int
        match ch with
            | 1 -> account <- Audit.depositWithConsoleAudit amt account
            | 2 -> account <- Audit.withdrawWithConsoleAudit amt account
            | 3 -> choice <- false
            | _ -> printfn "Please enter a valid choice"
    0 // return an integer exit code

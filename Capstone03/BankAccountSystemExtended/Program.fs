open System
open BankAccountSystemAPI
open Audit

// If the user is already present in the folder it takes it from the disk or else it creates a new user from scratch.
let loadAccountFromDisk = FileRepository.findTransactionsOnDisk >> Operations.loadAccount

let private GetUser =
    let fname =
        Console.Write "Please enter your first name: "
        Console.ReadLine()
    let lname =
        Console.Write "Please enter your last name: "
        Console.ReadLine()
    let age =
        Console.Write "Please enter your age: "
        Console.ReadLine() |> int
    { Firstname = fname; Lastname = lname; Age = age }

// Gets the ammount to be used for the operation and return a tuple of the command
let getAmmount cmd =
    printfn "\nEnter the ammount"
    let amt = Console.ReadLine() |> decimal
    (cmd, amt)

// Shows the options and asks the users to enter the commands. Takes one key at a time and only accepts valid keys.
let getCommand = seq {
    while true do
        printfn "\n\nSelect (d)eposit, (w)ithdraw or e(x)it: "
        yield Console.ReadKey().KeyChar }

// Take the command:char and then give the ammount from the console input
let processCommand account (command, ammount) =
    if command = 'd' then depositWithConsoleAudit ammount account
    elif command = 'w' && ammount <= account.CurrentBalance then withdrawWithConsoleAudit ammount account
    elif command = 'w' && ammount > account.CurrentBalance then printfn "\nAccount balance insufficient"; account
    else account

[<EntryPoint>]
let main _ =
    let user = GetUser
    let openingAccount = 
        user |> loadAccountFromDisk
    let closingAccount =
        getCommand
        |> Seq.filter(fun i -> i = 'd' || i = 'w' || i = 'x')
        |> Seq.takeWhile (not << fun i -> i = 'x')
        |> Seq.map getAmmount
        |> Seq.fold processCommand openingAccount
    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore
    0
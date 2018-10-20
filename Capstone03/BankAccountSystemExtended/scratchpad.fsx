﻿#load "E:\\VCS\\FSharp\\Capstone02\\BankAccountSystemAPI\\Domain.fs"
open BankAccountSystemAPI
open System

let openingAccount = 
    {
    Owner = { Firstname = "Matt"; Lastname = "Pratt"; Age = 21 }
    CurrentBalance = 0M
    UniqueID = String.Empty
    }

let isValidCommand command =
    if command = 'd' || command = 'w' || command = 'x' then true
    else false

let isStopCommand command =
    if command = 'x'then true
    else false

let getAmmount command =
    if command = 'w' then (command, 25M)
    elif command = 'x' then (command, 0M)
    else (command, 50M)

let processCommand account (command, ammount) =
    if command = 'w' then {account with CurrentBalance = account.CurrentBalance - ammount}
    elif command = 'd' then {account with CurrentBalance = account.CurrentBalance + ammount }
    else account

let acc =
    let commands = [ 'd'; 'w' ; 'z'; 'f'; 'd'; 'x'; 'w' ]
    commands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmmount
    |> Seq.fold processCommand openingAccount

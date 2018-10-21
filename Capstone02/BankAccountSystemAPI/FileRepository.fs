namespace BankAccountSystemAPI

open System
open System.IO

module FileRepository =

    let private accountsPath =
        let path = @"accounts"
        Directory.CreateDirectory path |> ignore
        path

    let private buildPath(owner, accountId) = sprintf @"%s\%s_%s" accountsPath owner accountId

    let writeTransaction accountId owner transaction =
        let path = buildPath(owner, accountId)    
        path |> Directory.CreateDirectory |> ignore
        let filePath = sprintf "%s/%d.txt" path (transaction.Time.ToFileTimeUtc())
        let line = sprintf "%O***%O***%M***%b" transaction.Time transaction.Operation transaction.Amount transaction.Attempt
        File.WriteAllText(filePath, line)
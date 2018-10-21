namespace BankAccountSystemAPI

open System
open System.IO

module FileRepository =

    let private accountsPath =
        let path = "E:\\VCS\\FSharp\\BankAccountSystemAPI\\"
        Directory.CreateDirectory path |> ignore
        path

    let private findAccountFolder owner =    
        let folders = Directory.EnumerateDirectories(accountsPath, sprintf "%s_*" (owner.Firstname + "_" + owner.Lastname))
        if Seq.isEmpty folders then ""
        else
            let folder = Seq.head folders
            DirectoryInfo(folder).Name

    let private buildPath(owner, accountId) = sprintf @"%s%s_%s" accountsPath owner accountId

    let loadTransactions (folder:string) =
        let owner, accountId =
            let parts = folder.Split '_'
            parts.[0], parts.[1]
        owner, accountId, buildPath(owner, accountId)
                      |> Directory.EnumerateFiles
                      |> Seq.map (File.ReadAllText >> Transactions.deserialize)


    let writeTransaction accountId owner transaction =
        let path = buildPath(owner, accountId)    
        path |> Directory.CreateDirectory |> ignore
        let filePath = sprintf "%s/%d.txt" path (transaction.Time.ToFileTimeUtc())
        let line = sprintf "%O***%O***%M***%b" transaction.Time transaction.Operation transaction.Amount transaction.Attempt
        File.WriteAllText(filePath, line)
    
    let findTransactionsOnDisk owner =
        let folder = findAccountFolder owner
        if String.IsNullOrEmpty folder then (owner.Firstname + "_" + owner.Lastname + "_" + string owner.Age), "", Seq.empty
        else loadTransactions folder


namespace BankAccountSystemAPI

module Operations =
    let deposit ammount account = { account with CurrentBalance = account.CurrentBalance + ammount }

    let withdraw ammount account =
        if account.CurrentBalance >= ammount then { account with CurrentBalance = account.CurrentBalance - ammount }
        else printfn "Account balance is low. Transaction declined."; account

    let loadAccount (owner:string, accountId, transactions) =
        let fname, lname, age = 
            let parts = owner.Split '_' 
            parts.[0], parts.[1], parts.[2] |> int
        let openingAccount = { UniqueID = accountId; CurrentBalance = 0M; Owner = { Firstname = fname; Lastname = lname; Age = age } }
        transactions
        |> Seq.sortBy(fun txn -> txn.Time)
        |> Seq.fold(fun account txn ->
            if txn.Operation = OperationType.Withdraw then account |> withdraw txn.Amount
            else account |> deposit txn.Amount) openingAccount

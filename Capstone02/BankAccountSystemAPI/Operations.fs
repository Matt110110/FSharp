namespace BankAccountSystemAPI

module Operations =
    let deposit ammount account = { account with CurrentBalance = account.CurrentBalance + ammount }

    let withdraw ammount account =
        if account.CurrentBalance >= ammount then { account with CurrentBalance = account.CurrentBalance - ammount }
        else printfn "Account balance is low. Transaction declined."; account

    let loadAccount (owner, accountId, transactions) =
        let openingAccount = { UniqueID = accountId; CurrentBalance = 0M; Owner = owner }
        transactions
        |> Seq.sortBy(fun txn -> txn.Time)
        |> Seq.fold(fun account txn ->
            if txn.Operation = OperationType.Withdraw then account |> withdraw txn.Amount
            else account |> deposit txn.Amount) openingAccount

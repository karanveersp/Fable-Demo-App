module App

open Browser.Dom
let rnd = System.Random()

let mutable count = 0

let increaseBtn = document.getElementById "increase"
let decreaseBtn = document.getElementById "decrease"

let countViewer = document.getElementById "countViewer"
countViewer.innerText <- sprintf "Count is at %d" count


let increaseCount() =
    count <- count + rnd.Next(5, 10)

let decreaseCount() =
    count <- count - rnd.Next(5, 10)

let updateCount() = 
    countViewer.innerText <- sprintf "Count is at %d" count

let runAfter (ms: int) callback =
    async {
        do! Async.Sleep ms
        do callback()
    }
    |> Async.StartImmediate

let increaseDelayed = document.getElementById "increaseDelayed"

increaseDelayed.onclick <- fun _ ->
    runAfter 1000 (fun () -> 
        increaseCount()
        updateCount()
    )

increaseBtn.onclick <- fun _ ->
    increaseCount()
    updateCount()

decreaseBtn.onclick <- fun _ ->
    decreaseCount()
    updateCount()


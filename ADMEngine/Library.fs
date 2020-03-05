namespace ADMEngine

module ADMEngine =
    open System
    open System.Threading
    open System.Windows.Input

    let putChar (sleep_ms: int) (x: char) =
        Thread.Sleep sleep_ms
        Console.Write x
    
    let putCharString sleep_ms x =
        x |> String.iter (putChar sleep_ms)
    
    let getInputKey () = Console.ReadKey ()

    let rec getInputKeyInRange range =
        let key = getInputKey ()
        if List.exists ((=) key.Key) range
        then key.KeyChar
        else getInputKeyInRange range

    let showAndGetInput str range =
        let r =
            range
            |> List.map (fun x -> "|" + (x.ToString ()))
            |> List.reduce (+)
        let str = String.Format ("{0} [{1}]: ", str, r.[1..])
        in Console.Write str
        let ret = getInputKeyInRange range
        Console.Write '\n'
        ret

    type Actor = {
        name: string
        attributes: Map<string, string> ref
    }
 
    type Game = {
        actors:  Actor list ref
        execflow: Actor list ref
        pos: int ref
    }

    let gameInit () = {
        actors= ref [];
        execflow= ref [];
        pos=ref 0
    }

    let createActor (game: Game) name =
        let res = {
            name = name;
            attributes = ref <| Map [];
        }
        game.actors := res :: (!game.actors)
        res

    let create_narrator game = createActor game "???"

    let say actor sleep_ms color (message: string) =
        String.Format ("{0}: ", actor.name)
        |> Console.Write
        Console.ForegroundColor <- color
        putCharString sleep_ms message
        getInputKeyInRange [ConsoleKey.Enter; ConsoleKey.Spacebar] |> ignore
        Console.Write '\n'
        Console.ForegroundColor <- ConsoleColor.White

    let narration narrator message =
        say narrator 64 ConsoleColor.DarkGray message

    let statement actor message =
        say actor 80 ConsoleColor.White message

    // 愤怒
    let roar actor message =
        say actor 300 ConsoleColor.Red message
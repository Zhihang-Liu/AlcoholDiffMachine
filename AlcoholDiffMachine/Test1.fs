open System
open ADMEngine.ADMEngine

let game = gameInit ()

let narrator = create_narrator game
let narrationSay = narration narrator

let hoshino= createActor game "Hoshino"
let hoshinoSay = statement hoshino

let sans = createActor game "Sans"
let sansSay = statement sans

let hoshino_demo _ =
    narrationSay "此时她还不知道，这已是她能见到你的最后一面了"
    hoshinoSay "锤鸽"
    hoshinoSay "锤鸽醒醒！"
    hoshinoSay "锤鸽"
    hoshinoSay "抱抱星野野"

let sans_demo _ =
    sansSay "今天是多美好的一天啊"
    sansSay "鸟儿在歌唱，花儿在绽放"
    sansSay "在这样的一天里，像你这样的孩子"
    roar sans "就应当在地狱里焚烧！"

[<EntryPoint>]
let main _ =
    (*gameInit ()*)
    putCharString 40 "Welcome to AlcoholDiffMachine\n"
    (*getInputKey () |> ignore*)
    (*showAndGetInput "咕咕咕？" ['是'; '否'] |> ignore
    ADMEngine.showAndGetInput "苟利国家生死以" ['是'; '否'] |> ignore
    *)
    hoshino_demo ()
    sans_demo
    0 // return an integer exit code

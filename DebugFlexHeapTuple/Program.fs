namespace DebugFlexHeapTuple

open FSharpx.DataStructures
open Gen

module console1 =

    let tailOK t =
        let f = (fun (t : #IHeap<_,'a> * 'a list) ->
                                        let h = fst t
                                        let l = snd t
                                        let tl = h.Tail()
                                        let tlHead =
                                            if (tl.Length() > 0) then (tl.Head() = l.Item(1))
                                            else true
                                        ((tlHead && (tl.Length() = (l.Length - 1))))
                                            )
        f t

    [<EntryPoint>]
    let main argv = 
        printfn "%A" argv

        //this works
        let l = ["a"; "b"; "c"; "d"; "e"; "f"]
        printfn "%A" (tailOK (tuple l))


        //my problem is I need to box tuples created with different heaps implementing the IHeap interface
        //this is because NUnit apparently cannot use tuples with the TestCaseSource attribute
        let x1 = box (tuple l)

        //neither of the following two solutions work to cast my tuple to the interface
        //let x2 : #IHeap<_,_> * list<'a> = unbox x1

        //let x2 = unbox x1 :> #IHeap<_,_> * list<'a>

        System.Console.ReadKey() |> ignore
        0 // return an integer exit code

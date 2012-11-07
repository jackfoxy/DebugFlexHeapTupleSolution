namespace DebugFlexHeapTuple

open FSharpx.DataStructures

module Gen = 

    let insertThruList l h =
        List.fold (fun (h' : #IHeap<_,'a>) x -> h'.Insert  x  ) h l

    let tuple l =
        (insertThruList l (LeftistHeap.empty false)), l

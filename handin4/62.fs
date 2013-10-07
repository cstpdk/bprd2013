open Absyn;;
open ParseAndRunHigher;;

printfn "\n";;

let john1 = Fun("x",Prim("*",CstI 2, Var "x"));;
let john2 = Let("y", CstI 22, Fun("z",Prim("+",Var "z", Var "y")));;

printfn "john1 %A" (eval john1 []);;
printfn "%A" (eval john2 []);;

fromString @"let add x = fun y -> x+y
                  in add 2 5 end";;

printfn "%A" (run it);;

printfn "%A" (run (fromString @"let add = fun x -> fun y -> x+y
                  in add 2 5 end"));;


#q;;

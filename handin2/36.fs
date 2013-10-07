open Parse;;
open Expr;;

run (fromString "2 + 3 * 4");;
eval (fromString "2 + x * 4") [("x", 3)];;
eval (fromString "let x = 1+2 in 2 + x * 4 end") [];;

let code1 = scomp (fromString "2 + 3 * 4") [];;
seval code1 [];;

let code2 = scomp (fromString "2 + x * 4") [Bound "x"];;
seval code2 [3];;

let code3 = scomp (fromString "let x = 1+2 in 2 + x * 4 end") [];;
seval code3 [];;

#q;;

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(x, erhs, ebody) -> 
          union (freevars erhs, minus (freevars ebody, [x]))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x 
    | Let(l,e1) -> 
        let newEnv = List.fold (fun acc (s,e2) -> (s,(eval e2 acc))::acc) env l
        eval e1 newEnv
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;
(*
 * Execution
 *)
[<EntryPoint>]
let main (args: string[]) =

 let fiveplus7 = Prim("+",(CstI 5),(CstI 7))
 let x1plus2 = Prim("*",(Var "x1"),(CstI 2))

 let e1 = Let([("x1",fiveplus7);("x2",x1plus2)],
    Prim("+",Var("x1"),Var("x2"))
    )
 printfn "%A" (eval e1 env)

 0;;

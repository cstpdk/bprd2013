(* Intro *)

(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;

(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)

(* Exercise 1.1 *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> match (eval e1 env) with
                             | n when n > (eval e2 env) -> n // First argument larger or equal
                             | n when n < (eval e2 env) -> (eval e2 env) // First argument smaller
                             | n -> n
    | Prim("max2", e1, e2) -> 
                            let i1 = eval e1 env
                            let i2 = eval e2 env
                            match i1 with
                             | n when n > i2 -> n // First argument larger or equal
                             | n when n < i2 -> i2 // First argument smaller
                             | n -> n
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env) // The smart way
    | Prim("==", e1, e2) -> match (eval e1 env) = (eval e2 env) with
                            | true -> 1
                            | false -> 0
    | If(e1,e2,e3) -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim _       -> failwith "unknown primitive";;

(* Exercise 1.2 *)

type aexpr = 
 | ACstI of int
 | AVar of string
 | AAdd of aexpr * aexpr
 | AMul of aexpr * aexpr
 | ASub of aexpr * aexpr

let rec fmt = function
 | ACstI i -> string(i)
 | AVar s -> s
 | AAdd(e1,e2) -> "(" + (fmt e1) + "+" + (fmt e2) + ")"
 | AMul(e1,e2) -> "(" + (fmt e1) + "*" + (fmt e2) + ")"
 | ASub(e1,e2) -> "(" + (fmt e1) + "*" + (fmt e2) + ")"

let rec simplify exp =
 match exp with
  | ACstI i -> ACstI i
  | AVar s -> AVar s
  | AAdd(e1,e2) when (simplify e1) = (ACstI 0) -> simplify e2
  | AAdd(e1,e2) when (simplify e2) = (ACstI 0) -> simplify e1
  | AMul(e1,e2) when (simplify e1) = (ACstI 0) -> simplify e1
  | AMul(e1,e2) when (simplify e2) = (ACstI 0) -> simplify e2
  | ASub(e1,e2) when (simplify e1) = (simplify e2) -> ACstI 0 
  | ASub(e1,e2) when (simplify e1) = (ACstI 0) || (simplify e1) = (ACstI 1) -> simplify e1
  | ASub(e1,e2) when (simplify e2) = (ACstI 0) || (simplify e1) = (ACstI 1) -> simplify e2
  | ae -> ae

(**
  * If this is wrong it's because I don't know math (highly likely!)
  *)
let rec derive exp = 
 match exp with
  | ACstI i -> ACstI 0
  | AVar s -> ACstI 1
  | AMul(e1,e2) -> AAdd(AMul(derive e1,e2),AMul(e1,derive(e2)))
  | ASub(e1,e2) -> ASub(derive e1,derive e2)
  | AAdd(e1,e2) -> AAdd(derive e1,derive e2)


(*
 * Execution
 *)
[<EntryPoint>]
let main (param: string[]) =
    
    printfn "____________________________________________________"
    printfn "Ex. 1.1"
    printfn "____________________________________________________"
    printfn "Max 2 2 = 2 %A" ((eval (Prim("max",CstI 2,CstI 2)) (emptyenv)) = 2) 
    printfn "Max 2 3 = 3 %A" ((eval (Prim("max",CstI 2,CstI 3)) (emptyenv)) = 3) 
    printfn "Max 3 2 = 3 %A" ((eval (Prim("max",CstI 3,CstI 2)) (emptyenv)) = 3) 
    printfn "Max2 3 2 = 3 %A" ((eval (Prim("max2",CstI 3,CstI 2)) (emptyenv)) = 3) 
    printfn "Min 3 2 = 2 %A" ((eval (Prim("min",CstI 3,CstI 2)) (emptyenv)) = 2) 
    printfn "!== 3 2 %A" ((eval (Prim("==",CstI 3,CstI 2)) (emptyenv)) = 0) 
    printfn "== 2 2 %A" ((eval (Prim("==",CstI 2,CstI 2)) (emptyenv)) = 1) 
    printfn "if 1 2 3 = 2 %A" ((eval (If(CstI 1,CstI 2,CstI 3)) (emptyenv)) = 2) 
    printfn "if 0 2 3 = 3 %A" ((eval (If(CstI 0,CstI 2,CstI 3)) (emptyenv)) = 3) 
    printfn "a = 1 in if Var a 2 3 = 2 %A" ((eval (If(Var "a",CstI 2,CstI 3)) ([("a",1)])) = 2) 
    
    printfn "____________________________________________________"
    printfn "Ex. 1.2"
    printfn "____________________________________________________"
    printfn "Aexp v - (w + z) 
    Sub( AVar(\"v\", AAdd(AVar(\"w\",AVar(\"z\")) )"

    printfn "Aexp 2 * (v-(w+x))
    AMul(2,ASub(Var(v),AAdd(Var(w),Var(z))))"

    printfn "Aexp x + y + z + v
    AAdd(Var(x),AAdd(y,AAdd(x,AAd(v))))
    "
    printfn "%A" (fmt(ASub(ACstI 2, ACstI 4)))

    printfn "%A" (simplify(AAdd((ACstI 2),(ACstI 0))))
    printfn "%A" (simplify(AAdd((ACstI 2),(ACstI 2))))
    printfn "%A" (simplify(ASub((ACstI 2),(ACstI 2))))
    printfn "%A" (simplify(derive(ASub(AMul(ACstI 2,AVar "x"),(AVar "b")))))

    printfn "____________________________________________________"
    printfn "Ex. 1.3"
    printfn "____________________________________________________"

    0;;

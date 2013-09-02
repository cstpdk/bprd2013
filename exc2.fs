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

let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

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
    | Let([],ebody) -> freevars ebody
    | Let((x,erhs)::varLst, ebody) -> 
      union((freevars erhs),minus(freevars (Let(varLst, ebody)),[x]))
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


type texpr =                        (* target expressions *)
  | TCstI of int
  | TVar of int                     (* index into runtime environment *)
  | TLet of texpr * texpr           (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;


(* Map variable name to variable index at compile-time *)

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

(* Compiling from expr to texpr *)
let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x)
    | Let(xs, e1) -> 
        let cenv1 = List.fold (fun acc (s,_) -> s::acc) cenv xs
        TLet(tcomp e1 cenv, tcomp e1 cenv1)
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);;

(*    | Let(x, erhs, ebody) -> 
      let cenv1 = x :: cenv 
      TLet(tcomp erhs cenv, tcomp ebody cenv1)
*)
(*
 * Execution
 *)
[<EntryPoint>]
let main (args: string[]) =

 let fiveplus7 = Prim("+",(CstI 5),(CstI 7))
 let x1plus2 = Prim("*",(Var "x1"),(CstI 2))
 
 let freevexp = Let(["x1",Prim("+",Var "x1",CstI(7))],Prim("+",Var("x1"),CstI(8)))

 let e1 = Let([("x1",fiveplus7);("x2",x1plus2);("x3",x1plus2)],
    Prim("+",Prim("+",Var("x1"),Var("x2")),Var("x3"))
    )

 printfn "%A" (eval e1 env)

 printfn "%A" (freevars e1)
 printfn "%A" (freevars freevexp)

 printfn "%A" (tcomp e1 (List.map(fun (s,e)-> s) env))
 0;;

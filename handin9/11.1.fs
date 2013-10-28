let id = fun v -> v
let ud = fun v -> v*2

let rec lenc xs k = 
    match xs with
    | [] -> k 0
    | x::xr -> lenc xr (fun v -> k(v+1));;

lenc [2;5;7] (printf "The answer us '%d' \n");;

lenc [2;5;7] ud;;

let rec leni xs i = 
    match xs with
    | [] -> i
    | x::xr -> leni xr (i+1);;

leni [2;5;7] 0;;

#q;;

let rec revc xs k = 
    match xs with
    | [] -> k []
    | x::xr -> revc xr (fun v -> k(v @ [x]));;

revc [1;2;3;4;5] id;;
revc [1;2;3;4;5] (fun v -> v @ v);;

let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xr -> revi xr ([x] @ acc)

revi [1;2;3;4;5] [];;

#q;;

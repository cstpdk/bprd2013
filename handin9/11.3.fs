let rec prodc xs k = 
    match xs with
    | [] -> k 1
    | x::xr -> prodc xr (fun v -> k(x*v));;

prodc [1;2;3;4;5] id;;

#q;;

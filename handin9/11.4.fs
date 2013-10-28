let rec prodc xs k = 
    match xs with
    | [] -> k 1
    | x::xr when x = 0 -> prodc [] (fun v -> printf "Arg0. NOT GONNA FLY WHITEBOY \n"; 0)
    | x::xr -> prodc xr (fun v -> k(x*v));;

prodc [1;2;3;4;5] id;;
prodc [1;2;0;4;5] id;;

let rec prodi xs acc = 
    match xs with
    | [] -> acc
    | x::xr when x = 0 -> printf "Arg0. NOT GONNA FLY WHITEBOY \n"; prodi [] 0
    | x::xr -> prodi xr (x*acc);;

prodi [1;2;3;4;5] 0;;
prodi [1;2;0;4;5] 0;;

#q;;

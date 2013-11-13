open Contcomp;;
open Machine;;

let L1 = "L1"
let L2 = "L2"
let L3 = "L3"

let indata = [IFZERO L3;GOTO L2;Label L3];;
let outdata = [IFNZRO L2; Label L3];;

//(compare (addIFZRO L2 indata) outdata) = 0
addIFZRO L2 indata;;

#q;;

open ParseAndContcomp;;

contCompileToFile (fromFile "lessThanEx.c") "john"

//[LDARGS; CALL (1,"L1"); STOP; Label "L1"; CSTI 0; IFNZRO "L2"; CSTI 33;
//   PRINTI; RET 1; Label "L2"; RET 0]
//
//
// There's no evaluation as CSTI 0 is added instead of a comparison of 11
// and 22

#q;;

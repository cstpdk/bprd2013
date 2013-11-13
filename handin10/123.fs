open Absyn;;
open Contcomp;;

cExpr (Cond(CstI 1, CstI 1111, CstI 2222)) ([],0) [] [];;
cExpr (Cond(CstI 0, CstI 1111, CstI 2222)) ([],0) [] [];;

#q;;
